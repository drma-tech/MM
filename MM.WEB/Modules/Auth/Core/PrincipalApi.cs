using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Auth.Core
{
    public class PrincipalApi : ApiServices
    {
        public PrincipalApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        private struct Endpoint
        {
            public const string Get = "Principal/Get";
            public const string Add = "Principal/Add";
        }

        public async Task<ClientePrincipal?> Get()
        {
            return await GetAsync<ClientePrincipal>(Endpoint.Get, false);
        }

        public async Task<ClientePrincipal?> Add(ClientePrincipal? obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return await PostAsync<ClientePrincipal>(Endpoint.Add, false, obj, Endpoint.Get);
        }
    }
}