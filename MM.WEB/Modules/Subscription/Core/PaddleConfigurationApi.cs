﻿using MM.Shared.Models.Subscription;

namespace MM.WEB.Modules.Subscription.Core;

public class PaddleConfigurationApi(IHttpClientFactory factory) : ApiCosmos<PaddleConfigurations>(factory, ApiType.Anonymous, null)
{
    public async Task<PaddleConfigurations?> GetConfigurations()
    {
        return await GetAsync(Endpoint.Configurations, null);
    }

    private struct Endpoint
    {
        public const string Configurations = "public/paddle/configurations";
    }
}
