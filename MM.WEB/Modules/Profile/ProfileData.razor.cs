using BrowserInterop.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MM.Shared.Models.Profile;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile
{
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

            Profile ??= new()
            {
                GenderIdentities = [GenderIdentity.Cisgender],
                SexualOrientations = [SexualOrientation.Heterosexual],
                BirthDate = DateTime.UtcNow.Date,
                Diet = Diet.Omnivore,
            };

            Core?.LoadingFinished?.Invoke(Profile);
        }

        private async Task SetLocation(ProfileModel profile)
        {
            try
            {
                if (profile != null /*&& !profile.Longitude.HasValue*/)
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
                        GPS ??= new();

                        GPS.Latitude = position.Location.Coords.Latitude;
                        GPS.Longitude = position.Location.Coords.Longitude;
                        GPS.Accuracy = position.Location.Coords.Accuracy;

                        //TODO: chamar código da api
                        var here = await MapApi.GetLocationHere(GPS.Latitude, GPS.Longitude);
                        if (here != null && here.items.Count != 0)
                        {
                            var address = here.items[0].address;
                            profile.Country = address?.GetCountry();
                            profile.State = address?.GetState();
                            profile.City = address?.GetCity();
                        }
                        else
                        {
                            //profile.Location = "Unknown Location";
                        }
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

        private async Task ValidSubmit()
        {
            if (Profile == null) throw new InvalidOperationException("profile is null");

            try
            {
                Profile = await ProfileApi.Update(Core, Profile);
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }

        private async Task InvalidSubmit(EditContext context)
        {
            if (Profile == null) throw new InvalidOperationException("profile is null");

            var validations = context.GetValidationMessages().ToList();

            if (validations.Count == 1)
                await Toast.Warning(validations[0]);
            else
                await Toast.Warning(GlobalTranslations.ValidationErrorsDetected);
        }
    }
}