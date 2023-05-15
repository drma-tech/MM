using Microsoft.Extensions.Caching.Memory;

namespace MM.WEB.Core
{
    public class CacheApi : ApiServices
    {
        public CacheApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }
    }
}