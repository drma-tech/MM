using MM.Shared.Models.Dashboard;

namespace MM.WEB.Core;

public struct Endpoint
{
    public static string SumUsers => "public/cache/sum-users";
}

public class DashboardApi(IHttpClientFactory http) : ApiCosmos<CacheDocument<SumUsers>>(http, ApiType.Anonymous, null)
{
    public async Task<CacheDocument<SumUsers>?> GetSumUsers()
    {
        return await GetAsync(Endpoint.SumUsers);
    }
}