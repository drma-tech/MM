using BrowserInterop.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

    private ProfileModel? Profile { get; set; }
    public RenderControlCore<ProfileModel?>? Core { get; set; } = new();

    private GeoLocation? GPS { get; set; }

    protected override async Task LoadDataRender()
    {
        Core?.LoadingStarted?.Invoke();

        Profile = await ProfileApi.Get(null);

        if (Profile == null) await Toast.Warning(GlobalTranslations.BasicRequired);

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
                    await Toast.Warning(position.Error.Message);
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

                    if (GPS.Accuracy > 1000) await Toast.Warning(GlobalTranslations.GpsNotAccurate);
                }
                else
                {
                    await Toast.Warning(GlobalTranslations.UnableDetectGps);
                }
            }
        }
        catch (Exception ex)
        {
            ex.ProcessException(Toast, Logger);
        }
    }

    private async Task SaveHandle()
    {
        if (Profile == null) throw new InvalidOperationException("profile is null");

        try
        {
            var validator = new ProfileValidation();

            var result =
                await validator.ValidateAsync(Profile, options => options.IncludeRuleSets(Tabs.BASIC.ToString()));

            if (result.IsValid)
            {
                Profile = await ProfileApi.Update(Core, Profile);

                Navigation.NavigateTo("profile");
            }
            else
            {
                await Toast.Warning(result.Errors[0].ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            ex.ProcessException(Toast, Logger);
        }
    }

    private async Task ShowErrors(ProfileModel? profile)
    {
        if (profile == null) return;

        var validator = new ProfileValidation();

        var result = await validator.ValidateAsync(profile, options => options.IncludeRuleSets(Tab.ToString()));

        if (!result.IsValid) await Toast.Warning(result.Errors[0].ErrorMessage);
    }
}