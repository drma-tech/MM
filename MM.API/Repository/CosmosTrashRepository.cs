using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosTrashRepository(CosmosClient client, ILogger<CosmosTrashRepository> logger)
    : BaseRepository<CosmosTrashRepository, MainDocument, MainIdentity>(client, logger, "trash")
{
}