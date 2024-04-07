﻿using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Support;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Support.Core
{
    public class TicketApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<TicketModel>(http, memoryCache, "TicketModel")
    {
        private struct Endpoint
        {
            public const string GetList = "public/ticket/get-list";
            public const string GetAll = "adm/ticket/get-all";
            public const string Insert = "Ticket/Insert";
        }

        public async Task<HashSet<TicketModel>> GetList(RenderControlCore<HashSet<TicketModel>>? core)
        {
            return await GetListAsync(Endpoint.GetList, core);
        }

        public async Task<HashSet<TicketModel>> GetAll(RenderControlCore<HashSet<TicketModel>>? core)
        {
            return await GetListAsync(Endpoint.GetAll, core);
        }

        public async Task<TicketModel?> Insert(TicketModel obj)
        {
            return await PostAsync(Endpoint.Insert, null, obj);
        }
    }
}