using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class FilterApi(IHttpClientFactory http) : ApiCosmos<FilterModel>(http, ApiType.Authenticated, "profile-filter", [], ApiContext.Default.FilterModel)
{
    public async Task<FilterModel?> Get(RenderControlState<FilterModel?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("profile/get-filter", setNewVersion: false, states, cancellationToken);
    }

    public async Task<FilterModel?> Update(FilterModel? obj, CancellationToken cancellationToken)
    {
        return await PostAsync("profile/update-filter", obj, ApiContext.Default.FilterModel, states: [], cancellationToken);
    }
}