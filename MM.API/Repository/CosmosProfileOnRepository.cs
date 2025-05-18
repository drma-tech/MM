using System.Linq.Expressions;
using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;

namespace MM.API.Repository;

public class CosmosProfileOnRepository
{
    private readonly ILogger<CosmosProfileOnRepository> _logger;

    public CosmosProfileOnRepository(IConfiguration config, ILogger<CosmosProfileOnRepository> logger)
    {
        _logger = logger;

        var databaseId = config.GetValue<string>("CosmosDB:DatabaseId");

        Container = ApiStartup.CosmosClient.GetContainer(databaseId, "profile-off");
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
            var query = Container
                .GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetQueryRequestOptions());

            using var iterator = query.ToFeedIterator();
            var results = new List<T>();

            double charges = 0;
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);
                charges += response.RequestCharge;
                results.AddRange(response.Resource);
            }

            if (charges > 7) _logger.LogWarning("ListAll - ProfileOn, RequestCharge {Charges}", charges);

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
}