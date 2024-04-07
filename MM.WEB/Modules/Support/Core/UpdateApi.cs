﻿using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Support;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Support.Core
{
    public class UpdateApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<UpdateModel>(http, memoryCache, null)
    {
        private struct Endpoint
        {
            public const string Get = "public/updates/get";
            public const string Add = "adm/updates/add";
            public const string Delete = "adm/updates/delete";
        }

        public async Task<HashSet<UpdateModel>> Get(RenderControlCore<HashSet<UpdateModel>>? core)
        {
            return await GetListAsync(Endpoint.Get, core, "UpdateModelList");
        }

        public async Task<UpdateModel?> Add(UpdateModel model)
        {
            return await PostAsync(Endpoint.Add, null, model);
        }

        public async Task<UpdateModel?> Delete(UpdateModel model)
        {
            return await PutAsync(Endpoint.Delete, null, model);
        }
    }
}