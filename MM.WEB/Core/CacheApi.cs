using MM.Shared.Models.Dashboard;
using MM.WEB.Api.Core;

namespace MM.WEB.Core;

public class DashboardApi(IHttpClientFactory http) : ApiCosmos<SumUsersCache>(http, ApiType.Anonymous, key: null, [], ApiContext.Default.SumUsersCache)
{
    public async Task<SumUsersCache?> GetSumUsers(RenderControlState<SumUsersCache?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("public/cache/sum-users", setNewVersion: false, states, cancellationToken);
    }
}

public class LastUsersApi(IHttpClientFactory http) : ApiCosmos<LastUsersCache>(http, ApiType.Anonymous, key: null, [], ApiContext.Default.LastUsersCache)
{
    public async Task<LastUsersCache?> GetLastUsers(RenderControlState<LastUsersCache?> state, CancellationToken cancellationToken)
    {
        return await GetAsync("public/cache/last-users", setNewVersion: false, [state], cancellationToken);
    }
}

public class LastRegionUsersApi(IHttpClientFactory http) : ApiCosmos<LastRegionUsersCache>(http, ApiType.Anonymous, key: null, [], ApiContext.Default.LastRegionUsersCache)
{
    public async Task<LastRegionUsersCache?> LastRegionUsers(string mode, string? region, RenderControlState<LastRegionUsersCache?> state, CancellationToken cancellationToken)
    {
        if (region == null) return null;

        return await GetAsync($"public/cache/last-region-users/{mode}/{region}", setNewVersion: false, [state], cancellationToken);
    }
}