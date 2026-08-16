using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core;

public class PrincipalApi(IHttpClientFactory factory) : ApiCosmos<AuthPrincipal>(factory, ApiType.Authenticated, "principal", ["profile"], ApiContext.Default.AuthPrincipal)
{
    public async Task<AuthPrincipal?> Get(bool setNewVersion = false, CancellationToken cancellationToken = default)
    {
        return await GetAsync(Endpoint.Get, setNewVersion, state: null, cancellationToken);
    }

    public async Task<AuthPrincipal> Add(AuthPrincipal? obj, MM.Shared.Enums.Platform platform, string? country, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PostAsync(Endpoint.Add(platform.ToString(), country), obj, state: null, cancellationToken);
    }

    public async Task<AuthPrincipal> Update(AuthPrincipal? obj, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return await PutAsync(Endpoint.Update, obj, ApiContext.Default.AuthPrincipal, state: null, cancellationToken);
    }

    public async Task<AuthPrincipal> Event(string app, string msg, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(msg);

        return await PostAsync(Endpoint.Event(app, msg), null, state: null, cancellationToken);
    }

    public async Task Remove(CancellationToken cancellationToken)
    {
        await DeleteAsync(Endpoint.Remove, cancellationToken);
    }

    public async Task<AuthPrincipal?> Public(CancellationToken cancellationToken)
    {
        return await PutAsync(Endpoint.Public, null, ApiContext.Default.AuthPrincipal, state: null, cancellationToken);
    }

    public async Task<AuthPrincipal?> Private(CancellationToken cancellationToken)
    {
        return await PutAsync(Endpoint.Private, null, ApiContext.Default.AuthPrincipal, state: null, cancellationToken);
    }

    public async Task<AuthPrincipal?> PrivateManage(string userId, CancellationToken cancellationToken)
    {
        return await PutAsync(Endpoint.PrivateManage(userId), null, ApiContext.Default.AuthPrincipal, state: null, cancellationToken);
    }

    private struct Endpoint
    {
        public const string Get = "principal/get";
        public const string Update = "principal/update";
        public const string Remove = "principal/remove";
        public const string Public = "principal/public";
        public const string Private = "principal/private";

        public static string Add(string platform, string? country) => $"principal/add?platform={platform}&country={country}";

        public static string PrivateManage(string userId) => $"principal/private/{userId}";

        public static string Event(string app, string msg) => $"principal/event?app={app}&msg={msg}";
    }
}

public class PrincipalImportApi(IHttpClientFactory factory) : ApiCosmos<AuthPrincipal>(factory, ApiType.Anonymous, "principal_import", [], ApiContext.Default.AuthPrincipal)
{
    public async Task<IEnumerable<AuthPrincipal>> GetAll(CancellationToken cancellationToken)
    {
        return await GetListAsync(Endpoint.GetAll, state: null, cancellationToken);
    }

    public async Task Migrate(string? oldId, string? newId, CancellationToken cancellationToken)
    {
        await PutAsync(Endpoint.Migrate(oldId, newId), null, ApiContext.Default.AuthPrincipal, state: null, cancellationToken);
    }

    private struct Endpoint
    {
        public const string GetAll = "principal/get-all";

        public static string Migrate(string? oldId, string? newId) => $"principal/migrate/{oldId}/{newId}";
    }
}