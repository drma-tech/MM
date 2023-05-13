using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core
{
    public class LoginApi : ApiServices
    {
        public LoginApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        private struct Endpoint
        {
            public const string Add = "Login/Add";
        }

        public async Task Add()
        {
            await PostAsync<ClienteLogin>(Endpoint.Add, false, null, null);
        }
    }
}