using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, ApiType.Authenticated, "profile-mymatches", ApiContext.Default.MyMatchesModel)
{
    public async Task<MyMatchesModel?> Get(bool isAuthenticated, bool setNewVersion, CancellationToken cancellationToken)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, setNewVersion, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mymatches";
    }
}