using MM.Shared.Models.Dashboard;

namespace MM.WEB.Core;

public struct Endpoint
{
    public static string SumUsers => "public/cache/sum-users";
    public static string LastUsers => "public/cache/last-users";

    public static string LastRegionUsers(string mode, string region) => $"public/cache/last-region-users/{mode}/{region}";
}

public class DashboardApi(IHttpClientFactory http) : ApiCosmos<SumUsersCache>(http, ApiType.Anonymous, null, [], ApiContext.Default.SumUsersCache)
{
    public async Task<SumUsersCache?> GetSumUsers(ComponentActions<SumUsersCache>? actions, CancellationToken cancellationToken)
    {
        return await GetAsync(Endpoint.SumUsers, false, actions, cancellationToken);
    }
}

public class LastUsersApi(IHttpClientFactory http) : ApiCosmos<LastUsersCache>(http, ApiType.Anonymous, null, [], ApiContext.Default.LastUsersCache)
{
    public async Task<LastUsersCache?> GetLastUsers(ComponentActions<LastUsersCache>? actions, CancellationToken cancellationToken)
    {
        return await GetAsync(Endpoint.LastUsers, false, actions, cancellationToken);
    }
}

public class LastRegionUsersApi(IHttpClientFactory http) : ApiCosmos<LastRegionUsersCache>(http, ApiType.Anonymous, null, [], ApiContext.Default.LastRegionUsersCache)
{
    public async Task<LastRegionUsersCache?> LastRegionUsers(string mode, string? region, ComponentActions<LastRegionUsersCache>? actions, CancellationToken cancellationToken)
    {
        if (region == null) return null;

        return await GetAsync(Endpoint.LastRegionUsers(mode, region), false, actions, cancellationToken);
    }
}