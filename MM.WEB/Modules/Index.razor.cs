using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Dashboard;
using MudBlazor;

namespace MM.WEB.Modules
{
    public partial class Index
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "language")]
        public string? Language { get; set; }

        private MudDialog? DialogCountries { get; set; }
        private MudDialog? DialogCities { get; set; }

        public SumUsers? SumUsers { get; set; }

        private RenderControlState<LastUsersCache> LastUsersActions { get; } = new(obj => obj?.Data == null || obj.Data.Items.Empty());

        protected override async Task LoadStaticDataAsync()
        {
            var cache = await DashboardApi.GetSumUsers(actions: null, Cts.Token);
            SumUsers = cache?.Data;

            var cache2 = await LastUsersApi.GetLastUsers(LastUsersActions, Cts.Token);

            foreach (var item in cache2?.Data?.Items ?? [])
            {
                item.CountryObj = item.Country?.GetFieldSettings();
            }
        }

        private double GetPhaseValue(int phase)
        {
            var totUsers = SumUsers?.TotalUsers ?? 0;

            if (phase == 1)
            {
                //do nothing
            }
            else if (phase == 2)
            {
                if (totUsers > 10_000) totUsers -= 10_000;
                else return 0;
            }
            else if (phase == 3)
            {
                if (totUsers > 20_000) totUsers -= 20_000;
                else return 0;
            }
            else if (phase == 4)
            {
                if (totUsers > 30_000) totUsers -= 30_000;
                else return 0;
            }

            if (totUsers < 10_000) return (double)totUsers / 10_000;

            return 1;
        }

        private Color GetPhaseColor(int phase)
        {
            var value = GetPhaseValue(phase);

            if (value == 1) return Color.Success;

            if (value == 0) return Color.Default;

            return Color.Primary;
        }

        private async Task Login()
        {
            Navigation.NavigateTo($"/{Culture}/auth/login?returnUrl={Uri.EscapeDataString(Navigation.Uri.Split('#')[0])}");
        }

        private async Task DialogCountriesCloseClick()
        {
            await DialogCountries!.CloseAsync();
        }

        private async Task DialogCitiesCloseClick()
        {
            await DialogCities!.CloseAsync();
        }
    }
}
