using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class FilterApi(IHttpClientFactory http) : ApiCosmos<FilterModel>(http, ApiType.Authenticated, "profile-filter")
{
    public async Task<FilterModel?> Get()
    {
        return await GetAsync(ProfileEndpoint.Get);
    }

    public async Task<FilterModel?> Update(FilterModel? obj)
    {
        return await PutAsync(ProfileEndpoint.UpdateFilter, obj);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-filter";
        public const string UpdateFilter = "profile/update-filter";
    }
}