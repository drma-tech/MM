using FluentValidation;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MM.WEB.Api.Module.Cosmos.Authenticated;
using MM.WEB.Core.Component;
using MudBlazor;
using MudBlazor.Utilities;

namespace MM.WEB.Modules.Profile;

public partial class ProfileDataPage : PageCore<ProfileDataPage>
{
    [Inject] protected PrincipalApi PrincipalApi { get; set; } = default!;
    [Inject] protected ProfileApi ProfileApi { get; set; } = default!;
    [Inject] protected MapApi MapApi { get; set; } = default!;

    private ProfileModel? Profile { get; set; }
    public RenderControlState<ProfileModel?> State { get; set; } = new(null, obj => obj == null);

    private MudDialog? MudDialog { get; set; }

    private bool _BioExpanded;

    private bool _LifeExpanded;

    private MudForm? _form;
    private bool IsDirty { get; set; }

    protected override void OnInitialized()
    {
        AppStateStatic.LocationChanged.Subscribe(async location =>
        {
            if (location is GeoLocation geoLocation)
            {
                await UpdateLocation(Profile!, geoLocation);
                StateHasChanged();
            }
        }, Cts.Token);
    }

    protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
    {
        State.StartLoading?.Invoke(null);

        Profile = await ProfileApi.Get(states: [], token);

        if (Profile == null && AppStateStatic.IsAuthenticated)
        {
            bool confirmed;
            var language = await AppStateStatic.GetAppLanguage(JsRuntime, token);

            if (language == AppLanguage.pt)
            {
                var message = new MarkupString(
                    "Para fornecer correspondências mais precisas, solicitamos informações como etnia, religião e orientação sexual, que podem ser consideradas dados sensíveis pelas leis de privacidade.<br><br>" +
                    "Ao clicar em “Concordo”, você consente com o processamento desses dados para fins de compatibilidade.<br><br>" +
                    $"Consulte nossa <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Política de Privacidade</a> e nossos <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Termos de Uso</a>."
                );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Translations.Button.IAgree, Translations.Button.IDoNotAgree) ?? false;
            }
            else if (language == AppLanguage.es)
            {
                var message = new MarkupString(
                    "Para ofrecer coincidencias más precisas, solicitamos información como etnia, religión y orientación sexual, que puede considerarse datos sensibles según las leyes de privacidad.<br><br>" +
                    "Al hacer clic en “Acepto”, usted consiente el procesamiento de estos datos con fines de compatibilidad.<br><br>" +
                    $"Consulte nuestra <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Política de Privacidad</a> y nuestros <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Términos de Uso</a>."
                );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Translations.Button.IAgree, Translations.Button.IDoNotAgree) ?? false;
            }
            else //English
            {
                var message = new MarkupString(
                     "To provide accurate matches, we ask for information such as ethnicity, religion, and sexual orientation, which may be considered sensitive under privacy laws.<br><br>" +
                     "By clicking “I agree”, you consent to the processing of this data for compatibility.<br><br>" +
                     $"See our <a href=\"/{Culture}/legal/privacy\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Privacy Policy</a> and <a href=\"/{Culture}/legal/terms\" target=\"_blank\" style=\"color: var(--mud-palette-primary)\">Terms of Use</a>."
                 );

                confirmed = await DialogService.ShowMessageBoxAsync("Modern Matchmaker", message, Translations.Button.IAgree, Translations.Button.IDoNotAgree) ?? false;
            }

            if (!confirmed)
            {
                Navigation.NavigateTo($"/{Culture}/profile");
                return;
            }

            await PrincipalApi.Event(AppInfo.Title, "Data processing granted", token);

            await ShowWarning(Translations.Module.Profile.BasicRequired);
        }

        Profile ??= new ProfileModel(AppStateStatic.UserId)
        {
            GenderIdentities = [GenderIdentity.Cisgender],
            SexualOrientations = [SexualOrientation.Heterosexual],
            //BirthDate = DateTime.UtcNow.Date,
            Diet = Diet.Omnivore,
        };

        State.FinishLoading?.Invoke(Profile);
    }

    private async Task SetLocation(ProfileModel profile)
    {
        try
        {
            if (profile != null)
            {
                await JsRuntime.Utils().UpdateLocation(Cts.Token);
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
            var here = await MapApi.GetLocationHere(gps.Latitude, gps.Longitude, Cts.Token);
            if (here != null && here.items.Count != 0)
            {
                var address = here.items.First().address;
                profile.Country = address?.GetCountry();
                profile.State = address?.GetState();
                profile.City = address?.GetCity();
            }

            if (gps.Accuracy > 1000) await ShowInfo(Translations.Module.Profile.GpsNotAccurate);
        }
        else
        {
            await ShowWarning(Translations.Module.Profile.UnableDetectGps);
        }
    }

    private async Task SaveHandle()
    {
        if (Profile == null) throw new InvalidOperationException("profile is null");

        try
        {
            Profile.SanitizeOpenTextFields();

            var validator = new ProfileValidation();

            var result = await validator.ValidateAsync(Profile, options => options.IncludeRuleSets(nameof(Category.BASIC)), Cts.Token);

            if (result.IsValid)
            {
                State.StartProcessing?.Invoke(null);
                Profile = await ProfileApi.Update(Profile, Cts.Token);
                State.FinishProcessing?.Invoke(Profile);

                IsDirty = false; StateHasChanged();

                Navigation.NavigateTo($"/{Culture}/profile");
            }
            else
            {
                var message = result.Errors[0].ErrorMessage;

                await ShowWarning(message);

                if (message.Contains("spam-like", StringComparison.OrdinalIgnoreCase))
                {
                    await ProcessException(new NotificationException(Translations.Notification.SpamLike, new ValidationException(Profile.Description)), showMessage: false);
                }
            }
        }
        catch (Exception ex)
        {
            await ProcessException(ex);
        }
    }

    private async Task ShowErrors(ProfileModel? model)
    {
        if (model == null) return;

        var validator = new ProfileValidation();

        var result = await validator.ValidateAsync(model, options => options.IncludeAllRuleSets(), Cts.Token);

        if (!result.IsValid) await ShowWarning(result.Errors[0].ErrorMessage);
    }

    private void OnFieldChanged(FormFieldChangedEventArgs args)
    {
        IsDirty = true;
    }

    private void CountryChanged(Country? country)
    {
        if (Profile == null) return;

        Profile.Nationality = country;
        Profile.Languages = country.GetLanguages().ToHashSet();
    }
}