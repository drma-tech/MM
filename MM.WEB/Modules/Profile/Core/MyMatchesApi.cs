using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, ApiType.Authenticated, "profile-mymatches", ApiContext.Default.MyMatchesModel)
{
    public async Task<MyMatchesModel?> Get(bool setNewVersion, ComponentActions<MyMatchesModel?> actions, CancellationToken cancellationToken)
    {
        return await GetAsync(ProfileEndpoint.Get, setNewVersion, actions, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mymatches";
    }
}