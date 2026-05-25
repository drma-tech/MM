using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, ApiType.Authenticated, "profile-mylikes", ApiContext.Default.MyLikesModel)
{
    public async Task<MyLikesModel?> Get(bool isAuthenticated, bool setNewVersion, CancellationToken cancellationToken)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, setNewVersion, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mylikes";
    }
}