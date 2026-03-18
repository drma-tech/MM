using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosIdsRepository
{
    private readonly ILogger<CosmosIdsRepository> _logger;

    public CosmosIdsRepository(CosmosClient CosmosClient, ILogger<CosmosIdsRepository> logger)
    {
        _logger = logger;

        var databaseId = ApiStartup.Configurations.CosmosDB?.DatabaseId;

        Container = CosmosClient.GetContainer(databaseId, "ids");
    }

    public Container Container { get; }

    public async Task<T> CreateItemAsync<T>(T item, CancellationToken cancellationToken) where T : CosmosDocument, new()
    {
        try
        {
            var response = await Container.CreateItemAsync(item, new PartitionKey(item.Id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

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