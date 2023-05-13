using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core
{
    public class ProfileApi : ApiServices
    {
        public ProfileApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        public struct ProfileEndpoint
        {
            public const string Get = "Profile/Get";
            public const string Update = "Profile/Update";
            public const string UpdateLooking = "Profile/UpdateLooking";
            public const string UpdatePartner = "Profile/UpdatePatner";

            public const string ListMatch = "Profile/ListMatch";
            public const string ListSearch = "Profile/ListSearch";

            public static string GetView(string IdUserView) => $"Profile/GetView?id={IdUserView}";
        }

        public async Task<ProfileModel?> Profile_Get()
        {
            return await GetAsync<ProfileModel>(ProfileEndpoint.Get, false);
        }

        public async Task<ProfileView?> Profile_GetView(string? IdUserView)
        {
            if (IdUserView == null) return default;

            return await GetAsync<ProfileView>(ProfileEndpoint.GetView(IdUserView), false);
        }

        //public async Task<HashSet<ProfileSearch>> Profile_ListSearch()
        //{
        //    return await GetListAsync<ProfileSearch>(ProfileEndpoint.ListSearch, false);
        //}

        public async Task<ProfileModel?> Profile_Update(ProfileModel obj)
        {
            return await PutAsync(ProfileEndpoint.Update, false, obj, ProfileEndpoint.Get);
        }

        public async Task<ProfileModel?> Profile_UpdateLooking(ProfileModel? obj, ProfilePreferenceModel? preference)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (preference == null) throw new ArgumentNullException(nameof(preference));

            obj.Preference = preference;

            return await PutAsync(ProfileEndpoint.UpdateLooking, false, obj, ProfileEndpoint.Get);

            //if (storage != null && response.IsSuccessStatusCode)
            //{
            //    storage.RemoveItem(ProfileEndpoint.ListMatch);
            //    storage.RemoveItem(ProfileEndpoint.ListSearch);
            //}
        }

        public async Task Profile_UpdatePartner(string id, string? email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            await PutAsync(ProfileEndpoint.UpdatePartner, false, new { id, email }, null, null);
        }
    }
}