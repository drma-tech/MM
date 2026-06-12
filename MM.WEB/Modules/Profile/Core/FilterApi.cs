using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class FilterApi(IHttpClientFactory http) : ApiCosmos<FilterModel>(http, ApiType.Authenticated, "profile-filter", ApiContext.Default.FilterModel)
{
    public async Task<FilterModel?> Get(ComponentActions<FilterModel?>? actions, CancellationToken cancellationToken)
    {
        return await GetAsync(ProfileEndpoint.Get, false, actions, cancellationToken);
    }

    public async Task<FilterModel?> Update(FilterModel? obj, CancellationToken cancellationToken)
    {
        return await PutAsync(ProfileEndpoint.UpdateFilter, obj, ApiContext.Default.FilterModel, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-filter";
        public const string UpdateFilter = "profile/update-filter";
    }
}