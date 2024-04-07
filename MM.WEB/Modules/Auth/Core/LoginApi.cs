using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core
{
    public class LoginApi(IHttpClientFactory factory, IMemoryCache memoryCache) : ApiCosmos<ClienteLogin>(factory, memoryCache, "ClienteLogin")
    {
        private struct Endpoint
        {
            public static string Add(string platform) => $"login/add?platform={platform}";
        }

        public async Task Add(string platform)
        {
            await PostAsync<ClienteLogin>(Endpoint.Add(platform), null, null);
        }
    }
}