using BrowserInterop.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MM.Shared.Models.Profile;
using MM.WEB.Api;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileData : PageCore<ProfileData>
    {
        [Inject] protected ProfileApi ProfileApi { get; set; } = default!;
        [Inject] protected InviteApi InviteApi { get; set; } = default!;
        [Inject] protected MapApi MapApi { get; set; } = default!;
        [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;

        private ProfileModel? profile { get; set; }
        public RenderControlCore<ProfileModel?>? Core { get; set; } = new();

        private GeoLocation? GPS { get; set; }

        protected override async Task LoadDataRender()
        {
            //LoadingProfile?.Start();
            profile = await ProfileApi.Get(Core);
            //LoadingProfile?.Finish(profile == null);

            profile ??= new()
            {
                GenderIdentity = GenderIdentity.Cisgender,
                SexualOrientation = SexualOrientation.Heterosexual,
                BirthDate = DateTime.UtcNow.AddYears(-18).AddDays(1).Date,
                Diet = Diet.Omnivore,
            };
        }

        private async Task SetLocation(ProfileModel profile)
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
                    var here = await MapApi.GetLocation(GPS.Latitude, GPS.Longitude);
                    if (here != null && here.items.Any())
                    {
                        var address = here.items[0].address;
                        profile.Location = address?.GetLocation();

                        var country = (Country)Enum.Parse(typeof(Country), address.countryCode);

                        profile.AddLanguages(country);
                    }
                    else
                    {
                        profile.Location = "Unknown Location";
                    }

                    //profile.Longitude = GPS.Longitude;
                    //profile.Latitude = GPS.Latitude;

                    //if (GPS.Accuracy > 500)
                    //{
                    //    Toast.ShowWarning("", $"A posição do GPS foi recuperada, mas a precisão é de apenas: {Math.Round(GPS.Accuracy / 1000, 1)} km. Tente novamente mais tarde ou use um dispositivo mais preciso.");
                    //}
                }
                else
                {
                    await Toast.Warning(GlobalTranslations.UnableDetectGps);
                }
            }
        }

        private async Task HandleValidSubmit()
        {
            if (profile == null) throw new InvalidOperationException("profile is null");

            try
            {
                //profile.Zodiac = profile.BirthDate.GetWesternZodiac();

                await ProfileApi.Update(Core, profile);

                profile = await ProfileApi.Get(Core); //TODO update id field

                if (profile.Modality == Modality.Matchmaker)
                {
                    foreach (var item in profile.Partners)
                    {
                        //TODO: remove the conections on others users
                    }

                    profile.Partners = [];
                }
                else
                {
                    //var invites = NewInvites.Except(RemovedInvites).ToList();
                    //var principal = await PrincipalApi.Get();
                    //var emailUser = principal?.Email;

                    //foreach (var email in invites)
                    //{
                    //    var invite = await InviteApi.Invite_Get(email);
                    //    var newInvite = false;

                    //    if (invite == null)
                    //    {
                    //        invite = new InviteModel();
                    //        invite.Initialize(email);
                    //        newInvite = true;
                    //    }

                    //    invite.Invites.Add(new Invite(profile.Key, emailUser, InviteType.Partner));

                    //    if (newInvite)
                    //        await InviteApi.Invite_Add(invite);
                    //    else
                    //        await InviteApi.Invite_Update(invite);
                    //}

                    //foreach (var item in RemovedInvites)
                    //{
                    //    //TODO: remove removed invites
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.ProcessException(Toast, Logger);
            }
        }

        private async Task HandleInvalidSubmit(EditContext context)
        {
            if (profile == null) throw new InvalidOperationException("profile is null");

            var errors = context.GetValidationMessages().ToList();

            if (errors.Count == 1)
                await Toast.Warning(errors[0]);
            else
                await Toast.Warning(GlobalTranslations.ValidationErrorsDetected);
        }
    }
}