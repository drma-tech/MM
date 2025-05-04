using MM.Shared.Models.Dashboard;
using MM.WEB.Shared;

namespace MM.WEB.Core
{
    public struct Endpoint
    {
        public static string Settings => $"public/settings";
        public static string SumUsers => "public/cache/sum-users";
    }

    public class CacheSettingsApi(IHttpClientFactory http) : ApiCosmos<Settings>(http, null)
    {
        public async Task<Settings?> GetSettings()
        {
            return await GetAsync(Endpoint.Settings, null);
        }
    }

    public class DashboardApi(IHttpClientFactory http) : ApiCosmos<CacheDocument<SumUsers>>(http, null)
    {
        public async Task<CacheDocument<SumUsers>?> GetSumUsers(RenderControlCore<CacheDocument<SumUsers>?>? core)
        {
            return await GetAsync(Endpoint.SumUsers, core);
        }
    }
}