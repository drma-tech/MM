using MM.Shared.Models.Profile;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class SettingApi(IHttpClientFactory http) : ApiCosmos<SettingModel>(http, ApiType.Authenticated, "profile-setting", [], ApiContext.Default.SettingModel)
{
    public async Task<SettingModel?> Get(RenderControlState<SettingModel?>[] states, CancellationToken cancellationToken)
    {
        if (!AppStateStatic.IsAuthenticated) return default;

        return await GetAsync("profile/get-setting", setNewVersion: false, states, cancellationToken);
    }

    public async Task<SettingModel?> Update(SettingModel? obj, CancellationToken cancellationToken)
    {
        return await PutAsync("profile/update-setting", obj, ApiContext.Default.SettingModel, states: [], cancellationToken);
    }
}