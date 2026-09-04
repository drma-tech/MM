using MM.Shared.Models.Profile;
using MM.WEB.Api.Module.Cosmos.Authenticated;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfilePage
    {
        //private RenderControlState<LastRegionUsersCache> LastUsersActions { get; } = new(obj => obj?.Data == null || obj.Data.Items.Empty());
        //public LastRegionUsers? LastUsers { get; set; }
        //private Country? CountryEnum;

        private RenderControlState<ProfileModel?> ProfileState { get; } = new(new ProfileModel(null), obj => obj == null);
        private RenderControlState<FilterModel?> FilterState { get; } = new(null, obj => obj == null);
        private RenderControlState<SettingModel?> SettingState { get; } = new(null, obj => obj == null);

        //private bool ValidationNetWorth => validation != null && validation.NetWorth;
        //private bool ValidationAnnualIncome => validation != null && validation.AnnualIncome;

        // protected override async Task OnAfterRenderAsync(bool firstRender)
        // {
        //     if (AppStateStatic.IsAuthenticated)
        //     {
        //         var subscription = await GetLocalStorage("subscription-popup");

        //         if (subscription.Empty())
        //         {
        //             await DialogService.SubscriptionPopup(AppStateStatic.IsAuthenticated);
        //             await SetLocalStorage("subscription-popup", true.ToString().ToLower());
        //         }
        //     }

        //     await base.OnAfterRenderAsync(firstRender);
        // }

        //protected override async Task<bool> LoadInteropDataAsync(IJSRuntime JsRuntime)
        //{
        //    var countryStr = await AppStateStatic.GetCountry(IpInfoApi, JsRuntime, Cts.Token);

        //    if (countryStr.NotEmpty())
        //    {
        //        CountryEnum = EnumHelper.ParseToEnum<Country>(countryStr);

        //        var cache2 = await LastRegionUsersApi.LastRegionUsers("compact", countryStr, LastUsersActions, Cts.Token);
        //        LastUsers = cache2?.Data;
        //    }
        //    else
        //    {
        //        await LastUsersActions.ShowError("It was not possible to determine your location.");
        //    }

        //    if (countryStr.NotEmpty() && (LastUsers?.Items.Empty() ?? true))
        //    {
        //        if (AppStateStatic.IsAuthenticated)
        //            await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOn);
        //        else
        //            await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOff);
        //    }

        //    return true;
        //}

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            await ProfileApi.Get([ProfileState], token);
            await FilterApi.Get([FilterState], token);
            await SettingApi.Get([SettingState], token);
        }

        private async Task Login()
        {
            await JsRuntime.Clerk().SignInAsync(Cts.Token);
        }

        // private string GetSuggestionTitle()
        // {
        //     if (profile?.Preference?.Region == null) return "";

        //     switch (profile.Preference.Region)
        //     {
        //         case Region.City:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.City)}";
        //         case Region.State:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.State)}";
        //         case Region.Country:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.Country)}";
        //         case Region.World:
        //             return $"{profile.Preference.Region.GetName()}";
        //         default:
        //             return "";
        //     }
        // }
    }
}