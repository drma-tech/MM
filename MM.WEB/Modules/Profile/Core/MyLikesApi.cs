using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class MyLikesApi(IHttpClientFactory http) : ApiCosmos<MyLikesModel>(http, "profile-mylikes")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-mylikes";
        }

        public async Task<MyLikesModel?> Get(RenderControlCore<MyLikesModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }
    }
}