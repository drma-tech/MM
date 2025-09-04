using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core;

public class PrincipalApi(IHttpClientFactory factory) : ApiCosmos<AuthPrincipal>(factory, "principal")
{
    public async Task<AuthPrincipal?> Get(bool isUserAuthenticated, bool setNewVersion = false)
    {
        if (isUserAuthenticated) return await GetAsync(Endpoint.Get, null, setNewVersion);

        return null;
    }

    public async Task<AuthPrincipal?> Add(AuthPrincipal? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PostAsync(Endpoint.Add, null, obj);
    }

    public async Task<AuthPrincipal?> Paddle(AuthPrincipal? obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PutAsync(Endpoint.Paddle, null, obj);
    }

    public async Task Remove()
    {
        await DeleteAsync(Endpoint.Remove, null);
    }

    public async Task<AuthPrincipal?> Public()
    {
        return await PutAsync<AuthPrincipal>(Endpoint.Public, null, null);
    }

    public async Task<AuthPrincipal?> Private()
    {
        return await PutAsync<AuthPrincipal>(Endpoint.Private, null, null);
    }

    private struct Endpoint
    {
        public const string Get = "principal/get";
        public const string Add = "principal/add";
        public const string Paddle = "principal/paddle";
        public const string Remove = "principal/remove";
        public const string Public = "principal/public";
        public const string Private = "principal/private";
    }
}