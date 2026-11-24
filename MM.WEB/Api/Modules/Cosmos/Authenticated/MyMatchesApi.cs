using MM.Common.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Modules.Cosmos.Authenticated;

public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, ApiType.Authenticated, "profile-mymatches", [], ApiContext.Default.MyMatchesModel)
{
    public async Task<MyMatchesModel?> Get(bool setNewVersion, RenderControlState<MyMatchesModel?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("profile/get-mymatches", setNewVersion, states, cancellationToken);
    }
}