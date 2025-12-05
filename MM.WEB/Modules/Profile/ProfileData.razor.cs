using FluentValidation;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile;

public partial class ProfileData : PageCore<ProfileData>
{
    [Inject] protected ProfileApi ProfileApi { get; set; } = default!;
    [Inject] protected MapApi MapApi { get; set; } = default!;

    private AuthPrincipal? Principal { get; set; }
    private ProfileModel? Profile { get; set; }
    public RenderControlCore<ProfileModel?>? Core { get; set; } = new();


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
        Core?.LoadingStarted?.Invoke();

        Principal = await PrincipalApi.Get(AppStateStatic.IsAuthenticated);
        Profile = await ProfileApi.Get(null);

        if (Profile == null)
        {
            bool confirmed;
            var language = await AppStateStatic.GetAppLanguage(JsRuntime);

            if (language == AppLanguage.pt)
            {
                var message = new MarkupString(
                    "Para combinar você com mais precisão, pedimos algumas informações pessoais, como etnia, religião e orientação sexual. Esses dados são considerados sensíveis pelas leis de privacidade.<br><br>" +
                    "Ao clicar em “Concordo”, você consente expressamente com o tratamento desses dados para fins de compatibilidade dentro da plataforma.<br><br>" +
                    "Leia nossa <a href=\"/support/privacy\" target=\"_blank\">Política de Privacidade</a> e nossos <a href=\"/support/terms\" target=\"_blank\">Termos de Uso</a> para mais detalhes."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else if (language == AppLanguage.es)
            {
                var message = new MarkupString(
                    "Para emparejarte con precisión, te pedimos algunos datos personales como etnia, religión y orientación sexual. Estos se consideran datos personales sensibles según las leyes de privacidad.<br><br>" +
                    "Al hacer clic en “Acepto”, usted consiente expresamente el tratamiento de estos datos con fines de compatibilidad dentro de la plataforma.<br><br>" +
                    "Lee nuestra <a href=\"/support/privacy\" target=\"_blank\">Política de Privacidad</a> y nuestros <a href=\"/support/terms\" target=\"_blank\">Términos de Uso</a> para más información."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else //English
            {
                var message = new MarkupString(
                    "To match you accurately, we ask for some personal information such as ethnicity, religion, and sexual orientation. These are considered sensitive personal data under privacy laws.<br><br>" +
                    "By clicking “I agree”, you expressly consent to the processing of this data for compatibility purposes within the platform.<br><br>" +
                    "Read our <a href=\"/support/privacy\" target=\"_blank\">Privacy Policy</a> and <a href=\"/support/terms\" target=\"_blank\">Terms of Use</a> for full details."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }

            if (!confirmed)
            {
                Navigation.NavigateTo("profile");
                return;
            }

            await PrincipalApi.Event("data processing granted");

            await ShowWarning(GlobalTranslations.BasicRequired);
        }

        Profile ??= new ProfileModel
        {
            GenderIdentities = [GenderIdentity.Cisgender],
            SexualOrientations = [SexualOrientation.Heterosexual],
            //BirthDate = DateTime.UtcNow.Date,
            Diet = Diet.Omnivore
        };

        Core?.LoadingFinished?.Invoke(Profile);
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
            var validator = new ProfileValidation();

            var result = await validator.ValidateAsync(Profile, options => options.IncludeRuleSets(Tabs.BASIC.ToString()));

            if (result.IsValid)
            {
                Profile = await ProfileApi.Update(Core, Profile);

                Navigation.NavigateTo("profile");
            }
            else
            {
                await ShowWarning(result.Errors[0].ErrorMessage);
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

        var result = await validator.ValidateAsync(profile, options => options.IncludeRuleSets(Tab.ToString()));

        if (!result.IsValid) await ShowWarning(result.Errors[0].ErrorMessage);
    }
}