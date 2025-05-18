using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class ProfileApi(IHttpClientFactory http) : ApiCosmos<ProfileModel>(http, "profile")
{
    public async Task<ProfileModel?> Get(RenderControlCore<ProfileModel?>? core)
    {
        return await GetAsync(ProfileEndpoint.Get, core);
    }

    public async Task<ProfileModel?> GetView(string? IdUserView, RenderControlCore<ProfileModel?>? core)
    {
        if (IdUserView == null) return default;

        return await GetAsync(ProfileEndpoint.GetView(IdUserView), core);
    }

    //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
    //{
    //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
    //}

    public async Task<ProfileModel?> Update(RenderControlCore<ProfileModel?>? core, ProfileModel obj)
    {
        return await PutAsync(ProfileEndpoint.UpdateData, core, obj);
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