using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core;

public class LoginApi(IHttpClientFactory factory) : ApiCosmos<AuthLogin>(factory, ApiType.Authenticated, null)
{
    public async Task<AuthLogin?> Get(bool isUserAuthenticated)
    {
        if (isUserAuthenticated) return await GetAsync(Endpoint.Get);

        return null;
    }

    public async Task Add(MM.Shared.Enums.Platform platform, string? country)
    {
        await PostAsync<AuthLogin>(Endpoint.Add(platform.ToString(), country), null);
    }

    private struct Endpoint
    {
        public const string Get = "login/get";

        public static string Add(string platform, string? country)
        {
            return $"login/add?platform={platform}&country={(country ?? "error")}";
        }
    }
}
