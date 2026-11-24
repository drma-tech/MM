using MM.Common.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Modules.Cosmos.Authenticated;

public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, ApiType.Authenticated, "profile-mylikes", [], ApiContext.Default.MyLikesModel)
{
    public async Task<MyLikesModel?> Get(bool setNewVersion, RenderControlState<MyLikesModel?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("profile/get-mylikes", setNewVersion, states, cancellationToken);
    }
}