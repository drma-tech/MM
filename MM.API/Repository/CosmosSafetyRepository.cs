using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosSafetyRepository(CosmosClient CosmosClient, ILogger<CosmosSafetyRepository> logger)
    : BaseRepository<CosmosSafetyRepository, SafetyDocument, SafetyIdentity>(CosmosClient, logger, "safety")
{
}