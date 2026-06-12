using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class SettingApi(IHttpClientFactory http) : ApiCosmos<SettingModel>(http, ApiType.Authenticated, "profile-setting", ApiContext.Default.SettingModel)
{
    public async Task<SettingModel?> Get(ComponentActions<SettingModel?>? actions, CancellationToken cancellationToken)
    {
        return await GetAsync(ProfileEndpoint.Get, false, actions, cancellationToken);
    }

    public async Task<SettingModel?> Update(SettingModel? obj, CancellationToken cancellationToken)
    {
        return await PutAsync(ProfileEndpoint.UpdateFilter, obj, ApiContext.Default.SettingModel, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-setting";
        public const string UpdateFilter = "profile/update-setting";
    }
}