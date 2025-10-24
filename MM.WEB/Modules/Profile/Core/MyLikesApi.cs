using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, ApiType.Authenticated, "profile-mylikes")
{
    public async Task<MyLikesModel?> Get(RenderControlCore<MyLikesModel?>? core, bool isAuthenticated,
        bool setNewVersion = false)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, core, setNewVersion);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mylikes";
    }
}