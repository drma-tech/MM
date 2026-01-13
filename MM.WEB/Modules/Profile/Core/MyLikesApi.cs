using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, ApiType.Authenticated, "profile-mylikes")
{
    public async Task<MyLikesModel?> Get(bool isAuthenticated,
        bool setNewVersion = false)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, setNewVersion);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mylikes";
    }
}