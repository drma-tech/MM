using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosTrashRepository
{
    private readonly ILogger<CosmosTrashRepository> _logger;

    public CosmosTrashRepository(CosmosClient CosmosClient, ILogger<CosmosTrashRepository> logger)
    {
        _logger = logger;

        var databaseId = ApiStartup.Configurations.CosmosDB?.DatabaseId;

        Container = CosmosClient.GetContainer(databaseId, "trash");
    }

    public Container Container { get; }

    public async Task<T> UpsertItemAsync<T>(T? item, CancellationToken cancellationToken) where T : CosmosDocument, new()
    {
        try
        {
            if (item == null) return new T();

            var response = await Container.UpsertItemAsync(item, new PartitionKey(item.Id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 15)
                _logger.LogWarning("CreateItemAsync - Id {Id}, RequestCharge {RequestCharge}", item.Id, response.RequestCharge);

            return response.Resource;
        }
        catch (CosmosOperationCanceledException)
        {
            return new T();
        }
    }
}