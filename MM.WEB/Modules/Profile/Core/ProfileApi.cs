using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class ProfileApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<ProfileModel>(http, memoryCache, "profile")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get";
            public const string Update = "profile/update";
            public const string UpdateLooking = "profile/update-preference";
            public static string UpdatePartner(string? id, string? email) => $"profile/update-partner?id={id}&email={email}";

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
            return await PutAsync(ProfileEndpoint.Update, core, obj);
        }

        public async Task<ProfileModel?> UpdateLooking(RenderControlCore<ProfileModel?>? core, ProfileModel? obj, FilterModel? filter)
        {
            ArgumentNullException.ThrowIfNull(obj);
            ArgumentNullException.ThrowIfNull(filter);

            //obj.Preference = preference;

            return await PutAsync(ProfileEndpoint.UpdateLooking, core, filter);

            //if (storage != null && response.IsSuccessStatusCode)
            //{
            //    storage.RemoveItem(ProfileEndpoint.ListMatch);
            //    storage.RemoveItem(ProfileEndpoint.ListSearch);
            //}
        }

        public async Task UpdatePartner(string? id, string? email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            await PutAsync<ProfileModel>(ProfileEndpoint.UpdatePartner(id, email), null, null);
        }
    }
}