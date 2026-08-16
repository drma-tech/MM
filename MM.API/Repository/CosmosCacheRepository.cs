using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosCacheRepository(CosmosClient client, ILogger<CosmosCacheRepository> logger)
     : BaseRepository<CosmosCacheRepository, CacheDocument, CacheIdentity>(client, logger, "cache")
{
}
