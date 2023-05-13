using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Support;

namespace MM.WEB.Modules.Support.Core
{
    public class TicketApi : ApiServices
    {
        public TicketApi(IHttpClientFactory http, IMemoryCache memoryCache) : base(http, memoryCache)
        {
        }

        private struct Endpoint
        {
            public const string GetList = "Public/Ticket/GetList";
            public const string Insert = "Ticket/Insert";
        }

        public async Task<HashSet<TicketModel>> GetList()
        {
            return await GetListAsync<TicketModel>(Endpoint.GetList, false);
        }

        public async Task<TicketModel?> Insert(TicketModel obj)
        {
            return await PostAsync(Endpoint.Insert, false, obj);
        }
    }
}