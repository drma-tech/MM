using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class FilterApi(IHttpClientFactory http) : ApiCosmos<FilterModel>(http, ApiType.Authenticated, "profile-filter")
{
    public async Task<FilterModel?> Get(RenderControlCore<FilterModel?>? core)
    {
        return await GetAsync(ProfileEndpoint.Get, core);
    }

    public async Task<FilterModel?> Update(RenderControlCore<FilterModel?>? core, FilterModel? obj)
    {
        return await PutAsync(ProfileEndpoint.UpdateFilter, core, obj);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-filter";
        public const string UpdateFilter = "profile/update-filter";
    }
}