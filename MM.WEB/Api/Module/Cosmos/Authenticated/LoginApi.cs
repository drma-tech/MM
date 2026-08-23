using MM.Shared.Models.Auth;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class LoginApi(IHttpClientFactory factory) : ApiCosmos<AuthLogin>(factory, ApiType.Authenticated, key: null, [], ApiContext.Default.AuthLogin)
{
    public async Task<AuthLogin?> Get(CancellationToken cancellationToken)
    {
        if (!AppStateStatic.IsAuthenticated) return default;

        return await GetAsync("login/get", setNewVersion: true, states: [], cancellationToken);
    }

    public async Task Add(Platform platform, string? country, CancellationToken cancellationToken)
    {
        await PostAsync($"login/add?platform={platform}&country={country ?? "error"}", cancellationToken);
    }
}
