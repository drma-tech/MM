using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, "profile-validation")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-validation";
        }

        public async Task<ValidationModel?> Get(RenderControlCore<ValidationModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }
    }
}