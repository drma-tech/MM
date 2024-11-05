﻿using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core
{
    public class SettingApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<SettingModel>(http, memoryCache, "profile-setting")
    {
        public struct ProfileEndpoint
        {
            public const string Get = "profile/get-setting";
            public const string UpdateFilter = "profile/update-setting";
        }

        public async Task<SettingModel?> Get(RenderControlCore<SettingModel?>? core)
        {
            return await GetAsync(ProfileEndpoint.Get, core);
        }

        public async Task<SettingModel?> Update(RenderControlCore<SettingModel?>? core, SettingModel? obj)
        {
            return await PutAsync(ProfileEndpoint.UpdateFilter, core, obj);
        }
    }
}