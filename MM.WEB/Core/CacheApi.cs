using MM.Shared.Models.Dashboard;

namespace MM.WEB.Core;

public struct Endpoint
{
    public static string SumUsers => "public/cache/sum-users";
}

public class DashboardApi(IHttpClientFactory http) : ApiCosmos<CacheDocument<SumUsers>>(http, ApiType.Anonymous, null, ApiContext.Default.CacheDocumentSumUsers)
{
    public async Task<CacheDocument<SumUsers>?> GetSumUsers(CancellationToken cancellationToken)
    {
        return await GetAsync(Endpoint.SumUsers, false, null, cancellationToken);
    }
}