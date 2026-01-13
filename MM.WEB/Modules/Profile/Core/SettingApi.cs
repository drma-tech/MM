using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class SettingApi(IHttpClientFactory http) : ApiCosmos<SettingModel>(http, ApiType.Authenticated, "profile-setting")
{
    public async Task<SettingModel?> Get()
    {
        return await GetAsync(ProfileEndpoint.Get);
    }

    public async Task<SettingModel?> Update(SettingModel? obj)
    {
        return await PutAsync(ProfileEndpoint.UpdateFilter, obj);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-setting";
        public const string UpdateFilter = "profile/update-setting";
    }
}