using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MM.Shared.Models.Dashboard;

namespace MM.WEB.Modules
{
    public partial class LastUsersPage
    {
        [Parameter] public string? Region { get; set; }

        private Platform? CurrentPlatform;

        private RenderControlState<LastRegionUsersCache> LastUsersActions { get; } = new(obj => obj?.Data == null || obj.Data.Items.Empty());
        public LastRegionUsers? LastUsers { get; set; }
        private Country? CountryEnum;

        protected override async Task LoadStaticDataAsync()
        {
            if (Region.NotEmpty())
            {
                CountryEnum = EnumHelper.ParseToEnum<Country>(Region);

                var cache2 = await LastRegionUsersApi.LastRegionUsers("full", Region, LastUsersActions, Cts.Token);
                LastUsers = cache2?.Data;
            }

            if (Region.NotEmpty() && (LastUsers?.Items.Empty() ?? true))
            {
                if (AppStateStatic.IsAuthenticated)
                    await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOn);
                else
                    await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOff);
            }
        }

        protected override async Task<bool> LoadInteropDataAsync(IJSRuntime JsRuntime)
        {
            CurrentPlatform = await AppStateStatic.GetPlatform(JsRuntime, Cts.Token);

            return true;
        }
    }
}
