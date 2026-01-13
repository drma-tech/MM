using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, ApiType.Authenticated, "profile-mymatches")
{
    public async Task<MyMatchesModel?> Get(bool isAuthenticated, bool setNewVersion = false)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, setNewVersion);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mymatches";
    }
}