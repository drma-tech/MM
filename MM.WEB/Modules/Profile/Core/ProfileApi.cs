using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class ProfileApi(IHttpClientFactory http) : ApiCosmos<ProfileModel>(http, "profile")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-data";
            public const string UpdateData = "profile/update-data";
            //public const string ListMatch = "Profile/ListMatch";
            //public const string ListSearch = "Profile/ListSearch";

            //public static string GetView(string IdUserView) => $"Profile/GetView?id={IdUserView}";
        }

        public async Task<ProfileModel?> Get(RenderControlCore<ProfileModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }

        //public async Task<ProfileView?> Profile_GetView(string? IdUserView)
        //{
        //    if (IdUserView == null) return default;

        //    return await GetAsync<ProfileView>(ProfileEndpoint.GetView(IdUserView), false);
        //}

        //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
        //{
        //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
        //}

        public async Task<ProfileModel?> Update(RenderControlCore<ProfileModel?>? core, ProfileModel obj)
        {
            return await PutAsync(ProfileEndpoint.UpdateData, core, obj);
        }
    }
}