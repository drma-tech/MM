using FluentValidation;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MM.WEB.Modules.Auth.Core;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Shared.Core;
using static MM.Shared.Core.Helper.ProfileHelper;

namespace MM.WEB.Modules.Profile;

public partial class ProfileData : PageCore<ProfileData>
{
    [Inject] protected PrincipalApi PrincipalApi { get; set; } = default!;
    [Inject] protected ProfileApi ProfileApi { get; set; } = default!;
    [Inject] protected MapApi MapApi { get; set; } = default!;

    private ProfileModel? Profile { get; set; }
    public ComponentActions<ProfileModel?> Actions { get; set; } = new(obj => obj == null);

    protected override void OnInitialized()
    {
        AppStateStatic.LocationChanged += async location =>
        {
            if (location is GeoLocation geoLocation)
            {
                await UpdateLocation(Profile!, geoLocation);
                StateHasChanged();
            }
        };
    }

    protected override async Task LoadAuthDataAsync()
    {
        Actions.StartLoading?.Invoke(null);

        Profile = await ProfileApi.Get(AppStateStatic.IsAuthenticated);

        if (Profile == null && AppStateStatic.IsAuthenticated)
        {
            bool confirmed;
            var language = await AppStateStatic.GetAppLanguage(JsRuntime);

            if (language == AppLanguage.pt)
            {
                var message = new MarkupString(
                    "Para fornecer correspondências mais precisas, solicitamos informações como etnia, religião e orientação sexual, que podem ser consideradas dados sensíveis pelas leis de privacidade.<br><br>" +
                    "Ao clicar em “Concordo”, você consente com o processamento desses dados para fins de compatibilidade.<br><br>" +
                    $"Consulte nossa <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Política de Privacidade</a> e nossos <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Termos de Uso</a>."
                );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else if (language == AppLanguage.es)
            {
                var message = new MarkupString(
                    "Para ofrecer coincidencias más precisas, solicitamos información como etnia, religión y orientación sexual, que puede considerarse datos sensibles según las leyes de privacidad.<br><br>" +
                    "Al hacer clic en “Acepto”, usted consiente el procesamiento de estos datos con fines de compatibilidad.<br><br>" +
                    $"Consulte nuestra <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Política de Privacidad</a> y nuestros <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Términos de Uso</a>."
                );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else //English
            {
                var message = new MarkupString(
                     "To provide accurate matches, we ask for information such as ethnicity, religion, and sexual orientation, which may be considered sensitive under privacy laws.<br><br>" +
                     "By clicking “I agree”, you consent to the processing of this data for compatibility.<br><br>" +
                     $"See our <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Privacy Policy</a> and <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Terms of Use</a>."
                 );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }

            if (!confirmed)
            {
                Navigation.NavigateTo($"/{Culture}/profile");
                return;
            }

            await PrincipalApi.Event(AppInfo.Title, "Data processing granted");

            await ShowWarning(GlobalTranslations.BasicRequired);
        }

        Profile ??= new ProfileModel
        {
            GenderIdentities = [GenderIdentity.Cisgender],
            SexualOrientations = [SexualOrientation.Heterosexual],
            //BirthDate = DateTime.UtcNow.Date,
            Diet = Diet.Omnivore
        };

        Actions.FinishLoading?.Invoke(Profile);
    }

    private async Task SetLocation(ProfileModel profile)
    {
        try
        {
            if (profile != null)
            {
                await JsRuntime.Utils().UpdateLocation();
            }
        }
        catch (Exception ex)
        {
            await ProcessException(ex);
        }
    }

    private async Task UpdateLocation(ProfileModel profile, GeoLocation? gps)
    {
        if (gps != null)
        {
            var here = await MapApi.GetLocationHere(gps.Latitude, gps.Longitude);
            if (here != null && here.items.Count != 0)
            {
                var address = here.items[0].address;
                profile.Country = address?.GetCountry();
                profile.State = address?.GetState();
                profile.City = address?.GetCity();
            }

            if (gps.Accuracy > 1000) await ShowInfo(GlobalTranslations.GpsNotAccurate);
        }
        else
        {
            await ShowWarning(GlobalTranslations.UnableDetectGps);
        }
    }

    private async Task SaveHandle()
    {
        if (Profile == null) throw new InvalidOperationException("profile is null");

        try
        {
            Profile.SanitizeOpenTextFields();

            var validator = new ProfileValidation();

            var result = await validator.ValidateAsync(Profile, options => options.IncludeRuleSets(Tabs.BASIC.ToString()));

            if (result.IsValid)
            {
                Actions.StartProcessing?.Invoke(null);
                Profile = await ProfileApi.Update(Profile);
                Actions.FinishProcessing?.Invoke(Profile);

                _PendingAction = false; StateHasChanged();

                Navigation.NavigateTo($"/{Culture}/profile");
            }
            else
            {
                var message = result.Errors[0].ErrorMessage;

                await ShowWarning(message);

                if (message.Contains("spam-like"))
                {
                    await ProcessException(new Exception("Description contains suspicious or spam-like content.", new Exception(Profile.Description)), false);
                }
            }
        }
        catch (Exception ex)
        {
            await ProcessException(ex);
        }
    }

    private async Task ShowErrors(ProfileModel? profile)
    {
        if (profile == null) return;

        var validator = new ProfileValidation();

        var result = await validator.ValidateAsync(profile, options => options.IncludeAllRuleSets());

        if (!result.IsValid) await ShowWarning(result.Errors[0].ErrorMessage);
    }
}