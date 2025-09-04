using BrowserInterop.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
    [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;

    private AuthPrincipal? Principal { get; set; }
    private ProfileModel? Profile { get; set; }
    public RenderControlCore<ProfileModel?>? Core { get; set; } = new();

    private GeoLocation? GPS { get; set; }

    protected override async Task LoadDataRender()
    {
        Core?.LoadingStarted?.Invoke();

        Principal = await PrincipalApi.Get(IsAuthenticated);
        Profile = await ProfileApi.Get(null);

        if (Profile == null)
        {
            bool confirmed;
            if (AppStateStatic.Language == Language.Portuguese)
            {
                var message = new MarkupString(
                    "Para combinar você com mais precisão, pedimos algumas informações pessoais, como etnia, religião e orientação sexual. Esses dados são considerados sensíveis pelas leis de privacidade.<br><br>" +
                    "Ao clicar em “Concordo”, você consente expressamente com o tratamento desses dados para fins de compatibilidade dentro da plataforma.<br><br>" +
                    "Leia nossa <a href=\"/support/privacy/pt\" target=\"_blank\">Política de Privacidade</a> e nossos <a href=\"/support/terms/pt\" target=\"_blank\">Termos de Uso</a> para mais detalhes."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else if (AppStateStatic.Language == Language.Spanish)
            {
                var message = new MarkupString(
                    "Para emparejarte con precisión, te pedimos algunos datos personales como etnia, religión y orientación sexual. Estos se consideran datos personales sensibles según las leyes de privacidad.<br><br>" +
                    "Al hacer clic en “Acepto”, usted consiente expresamente el tratamiento de estos datos con fines de compatibilidad dentro de la plataforma.<br><br>" +
                    "Lee nuestra <a href=\"/support/privacy/es\" target=\"_blank\">Política de Privacidad</a> y nuestros <a href=\"/support/terms/es\" target=\"_blank\">Términos de Uso</a> para más información."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }
            else //english
            {
                var message = new MarkupString(
                    "To match you accurately, we ask for some personal information such as ethnicity, religion, and sexual orientation. These are considered sensitive personal data under privacy laws.<br><br>" +
                    "By clicking “I agree”, you expressly consent to the processing of this data for compatibility purposes within the platform.<br><br>" +
                    "Read our <a href=\"/support/privacy/en\" target=\"_blank\">Privacy Policy</a> and <a href=\"/support/terms/en\" target=\"_blank\">Terms of Use</a> for full details."
                );

                confirmed = await DialogService.ShowMessageBox("Modern Matchmaker", message, Button.IAgree, Button.IDoNotAgree) ?? false;
            }

            if (!confirmed)
            {
                Navigation.NavigateTo("profile");
                return;
            }

            Snackbar.Add(GlobalTranslations.BasicRequired, MudBlazor.Severity.Warning);
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
                var window = await JsRuntime.Window(); //todo: remove this component
                var navigator = await window.Navigator();
                var position = await navigator.Geolocation.GetCurrentPosition();

                if (position.Error != null)
                {
                    Snackbar.Add(position.Error.Message, MudBlazor.Severity.Warning);
                }
                else if (position.Location != null)
                {
                    GPS ??= new GeoLocation();

                    GPS.Latitude = position.Location.Coords.Latitude;
                    GPS.Longitude = position.Location.Coords.Longitude;
                    GPS.Accuracy = position.Location.Coords.Accuracy;

                    var here = await MapApi.GetLocationHere(GPS.Latitude, GPS.Longitude);
                    if (here != null && here.items.Count != 0)
                    {
                        var address = here.items[0].address;
                        profile.Country = address?.GetCountry();
                        profile.State = address?.GetState();
                        profile.City = address?.GetCity();
                    }

                    if (GPS.Accuracy > 1000) Snackbar.Add(GlobalTranslations.GpsNotAccurate, MudBlazor.Severity.Warning);
                }
                else
                {
                    Snackbar.Add(GlobalTranslations.UnableDetectGps, MudBlazor.Severity.Warning);
                }
            }
        }
        catch (Exception ex)
        {
            ex.ProcessException(Snackbar, Logger);
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
                Snackbar.Add(result.Errors[0].ErrorMessage, MudBlazor.Severity.Warning);
            }
        }
        catch (Exception ex)
        {
            ex.ProcessException(Snackbar, Logger);
        }
    }

    private async Task ShowErrors(ProfileModel? profile)
    {
        if (profile == null) return;

        var validator = new ProfileValidation();

        var result = await validator.ValidateAsync(profile, options => options.IncludeRuleSets(Tab.ToString()));

        if (!result.IsValid) Snackbar.Add(result.Errors[0].ErrorMessage, MudBlazor.Severity.Warning);
    }
}