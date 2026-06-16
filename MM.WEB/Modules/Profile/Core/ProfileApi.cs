using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class ProfileApi(IHttpClientFactory http) : ApiCosmos<ProfileModel>(http, ApiType.Authenticated, "profile", ApiContext.Default.ProfileModel)
{
    public async Task<ProfileModel?> Get(ComponentActions<ProfileModel?>? actions, CancellationToken cancellationToken)
    {
        return await GetAsync(ProfileEndpoint.Get, false, actions, cancellationToken);
    }

    public async Task<HashSet<ProfileManage>> GetAll(ComponentActions<HashSet<ProfileManage>>? actions, CancellationToken cancellationToken)
    {
        return await GetListAsync(ProfileEndpoint.GetAll, actions, cancellationToken);
    }

    public async Task<ProfileModel?> GetView(string? IdUserView, ComponentActions<ProfileModel?>? actions, CancellationToken cancellationToken)
    {
        if (IdUserView == null) return default;

        return await GetAsync(ProfileEndpoint.GetView(IdUserView), false, actions, cancellationToken);
    }

    //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
    //{
    //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
    //}

    public async Task<ProfileModel?> Update(ProfileModel obj, CancellationToken cancellationToken)
    {
        return await PutAsync(ProfileEndpoint.UpdateData, obj, ApiContext.Default.ProfileModel, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-data";
        public const string GetAll = "profile/get-all";
        public const string UpdateData = "profile/update-data";

        public static string GetView(string id)
        {
            return $"profile/get-view/{id}";
        }
    }
}