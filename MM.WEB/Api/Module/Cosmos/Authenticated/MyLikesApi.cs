using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, ApiType.Authenticated, "profile-mylikes", [], ApiContext.Default.MyLikesModel)
{
    public async Task<MyLikesModel?> Get(bool setNewVersion, RenderControlState<MyLikesModel?>[] states, CancellationToken cancellationToken)
    {
        if (!AppStateStatic.IsAuthenticated) return default;

        return await GetAsync("profile/get-mylikes", setNewVersion, states, cancellationToken);
    }
}