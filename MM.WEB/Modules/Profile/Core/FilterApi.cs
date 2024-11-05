using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class FilterApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<FilterModel>(http, memoryCache, "profile-filter")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-filter";
            public const string UpdateFilter = "profile/update-filter";
        }

        public async Task<FilterModel?> Get(RenderControlCore<FilterModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }

        public async Task<FilterModel?> Update(RenderControlCore<FilterModel?>? core, FilterModel? obj)
        {
            return await PutAsync(ProfileEndpoint.UpdateFilter, core, obj);
        }
    }
}