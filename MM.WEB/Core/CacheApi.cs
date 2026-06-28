using MM.Shared.Models.Dashboard;

namespace MM.WEB.Core;

public struct Endpoint
{
    public static string SumUsers => "public/cache/sum-users";
    public static string LastUsers => "public/cache/last-users";
}

public class DashboardApi(IHttpClientFactory http) : ApiCosmos<CacheDocument<SumUsers>>(http, ApiType.Anonymous, null, ApiContext.Default.CacheDocumentSumUsers)
{
    public async Task<CacheDocument<SumUsers>?> GetSumUsers(CancellationToken cancellationToken)
    {
        return await GetAsync(Endpoint.SumUsers, false, null, cancellationToken);
    }
}

public class LastUsersApi(IHttpClientFactory http) : ApiCosmos<CacheDocument<LastUsers>>(http, ApiType.Anonymous, null, ApiContext.Default.CacheDocumentLastUsers)
{
    public async Task<CacheDocument<LastUsers>?> GetSumUsers(CancellationToken cancellationToken)
    {
        return await GetAsync(Endpoint.LastUsers, false, null, cancellationToken);
    }
}