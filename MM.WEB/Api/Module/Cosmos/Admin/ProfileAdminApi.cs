using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Admin
{
    public class ProfileAdminApi(IHttpClientFactory http) : ApiCosmos<ProfileManage>(http, ApiType.Authenticated, "profile", [], ApiContext.Default.ProfileManage)
    {
        public async Task<IEnumerable<ProfileManage>> GetAll(RenderControlState<IEnumerable<ProfileManage>>[] states, CancellationToken cancellationToken)
        {
            return await GetListAsync("profile/get-all", states, cancellationToken);
        }
    }
}