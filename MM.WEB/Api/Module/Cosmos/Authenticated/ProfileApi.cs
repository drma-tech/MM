using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class ProfileApi(IHttpClientFactory http) : ApiCosmos<ProfileModel>(http, ApiType.Authenticated, "profile", [], ApiContext.Default.ProfileModel)
{
    public async Task<ProfileModel?> Get(RenderControlState<ProfileModel?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("profile/get-data", setNewVersion: false, states, cancellationToken);
    }

    public async Task<ProfileModel?> GetView(string? IdUserView, RenderControlState<ProfileModel?>[] states, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await GetAsync($"profile/get-view/{IdUserView}", setNewVersion: false, states, cancellationToken);
    }

    //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
    //{
    //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
    //}

    public async Task<ProfileModel?> Update(ProfileModel obj, CancellationToken cancellationToken)
    {
        return await PutAsync("profile/update-data", obj, ApiContext.Default.ProfileModel, states: [], cancellationToken);
    }
}