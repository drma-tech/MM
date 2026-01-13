using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class ProfileApi(IHttpClientFactory http) : ApiCosmos<ProfileModel>(http, ApiType.Authenticated, "profile")
{
    public async Task<ProfileModel?> Get()
    {
        return await GetAsync(ProfileEndpoint.Get);
    }

    public async Task<ProfileModel?> GetView(string? IdUserView)
    {
        if (IdUserView == null) return default;

        return await GetAsync(ProfileEndpoint.GetView(IdUserView));
    }

    //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
    //{
    //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
    //}

    public async Task<ProfileModel?> Update(ProfileModel obj)
    {
        return await PutAsync(ProfileEndpoint.UpdateData, obj);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-data";
        public const string UpdateData = "profile/update-data";

        public static string GetView(string id)
        {
            return $"profile/get-view/{id}";
        }
    }
}