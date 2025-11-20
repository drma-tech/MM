using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;
using System.Linq.Expressions;
using System.Net;

namespace MM.API.Repository;

public class CosmosProfileOnRepository
{
    private readonly ILogger<CosmosProfileOnRepository> _logger;

    public CosmosProfileOnRepository(CosmosClient CosmosClient, IConfiguration config, ILogger<CosmosProfileOnRepository> logger)
    {
        _logger = logger;

        var databaseId = config.GetValue<string>("CosmosDB:DatabaseId");

        Container = CosmosClient.GetContainer(databaseId, "profile-on");
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

    public async Task<List<T>> ListAll<T>(CancellationToken cancellationToken) where T : CosmosDocument
    {
        try
        {
            var query = Container.GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetQueryRequestOptions());

            using var iterator = query.ToFeedIterator();
            var results = new List<T>();

            double charges = 0;
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);
                charges += response.RequestCharge;
                results.AddRange(response.Resource);
            }

            if (charges > 12) _logger.LogWarning("ListAll - ProfileOn, RequestCharge {Charges}", charges);

            return results;
        }
        catch (CosmosOperationCanceledException)
        {
            return [];
        }
    }

    public async Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        where T : CosmosDocument
    {
        try
        {
            var query = Container
                .GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetQueryRequestOptions())
                .Where(predicate);

            using var iterator = query.ToFeedIterator();
            var results = new List<T>();

            double charges = 0;
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);
                charges += response.RequestCharge;
                results.AddRange(response.Resource);
            }

            if (charges > 7) _logger.LogWarning("Query, RequestCharge {Charges}", charges);

            return results;
        }
        catch (CosmosOperationCanceledException)
        {
            return [];
        }
    }

    public async Task<T> UpsertItemAsync<T>(T item, CancellationToken cancellationToken) where T : CosmosDocument, new()
    {
        try
        {
            var response = await Container.UpsertItemAsync(item, new PartitionKey(item.Id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 15)
                _logger.LogWarning("Upsert - ID {Id}, RequestCharge {Charges}", item.Id, response.RequestCharge);

            return response.Resource;
        }
        catch (CosmosOperationCanceledException)
        {
            return new T();
        }
    }

    public async Task<T> PatchItemAsync<T>(string? id, List<PatchOperation> operations, CancellationToken cancellationToken)
        where T : CosmosDocument, new()
    {
        //https://learn.microsoft.com/en-us/azure/cosmos-db/partial-document-update-getting-started?tabs=dotnet

        try
        {
            var response = await Container.PatchItemAsync<T>(id, new PartitionKey(id), operations,
                CosmosRepositoryExtensions.GetPatchItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 12)
                _logger.LogWarning("PatchItem - ID {Id}, RequestCharge {Charges}", id, response.RequestCharge);

            return response.Resource;
        }
        catch (CosmosOperationCanceledException)
        {
            return new T();
        }
    }

    public async Task<bool> DeleteItemAsync<T>(T item, CancellationToken cancellationToken) where T : CosmosDocument
    {
        try
        {
            var response = await Container.DeleteItemAsync<T>(item.Id, new PartitionKey(item.Id),
                CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 12)
                _logger.LogWarning("Delete - ID {Id}, RequestCharge {Charges}", item.Id, response.RequestCharge);

            return response.StatusCode == HttpStatusCode.OK;
        }
        catch (CosmosOperationCanceledException)
        {
            return false;
        }
    }
}