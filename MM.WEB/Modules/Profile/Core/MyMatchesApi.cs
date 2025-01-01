using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, "profile-mymatches")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-mymatches";
        }

        public async Task<MyMatchesModel?> Get(RenderControlCore<MyMatchesModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }
    }
}