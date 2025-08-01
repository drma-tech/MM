﻿using MM.Shared.Models.Profile;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class MyMatchesApi(IHttpClientFactory http) : ApiCosmos<MyMatchesModel>(http, "profile-mymatches")
{
    public async Task<MyMatchesModel?> Get(RenderControlCore<MyMatchesModel?>? core, bool isAuthenticated,
        bool setNewVersion = false)
    {
        if (!isAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get, core, setNewVersion);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-mymatches";
    }
}