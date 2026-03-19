using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;
using System.Net;

namespace MM.API.Repository;

public class CosmosSafetyRepository
{
    private readonly ILogger<CosmosSafetyRepository> _logger;

    public CosmosSafetyRepository(CosmosClient CosmosClient, ILogger<CosmosSafetyRepository> logger)
    {
        _logger = logger;

        var databaseId = ApiStartup.Configurations.CosmosDB?.DatabaseId;

        Container = CosmosClient.GetContainer(databaseId, "safety");
    }

    public Container Container { get; }

    public async Task<T?> Get<T>(string? id, CancellationToken cancellationToken) where T : CosmosDocument
    {
        if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

        try
        {
            var response = await Container.ReadItemAsync<T>(id, new PartitionKey(id),
                CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 1.7)
                _logger.LogWarning("Get - ID {Id}, RequestCharge {RequestCharge}", id, response.RequestCharge);

            return response.Resource;
        }
        catch (CosmosOperationCanceledException)
        {
            return null;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }

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