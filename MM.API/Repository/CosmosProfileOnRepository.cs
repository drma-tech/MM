using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;
using System.Linq.Expressions;

namespace MM.API.Repository;

public class CosmosProfileOnRepository(CosmosClient client, ILogger<CosmosProfileOnRepository> logger)
    : BaseRepository<CosmosProfileOnRepository, ProfileDocument, ProfileIdentity>(client, logger, "profile-on")
{
    public async Task<IReadOnlyCollection<T>> Query<T>(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IQueryable<T>>? transform, CancellationToken cancellationToken)
        where T : ProfileDocument
    {
        try
        {
            IQueryable<T> queryable = Container.GetItemLinqQueryable<T>(requestOptions: CosmosRepositoryExtensions.GetQueryRequestOptions());

            if (predicate != null) queryable = queryable.Where(predicate);
            if (transform != null) queryable = transform(queryable);

            using var iterator = queryable.ToFeedIterator();
            var results = new List<T>();

            double charges = 0;
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);
                charges += response.RequestCharge;
                results.AddRange(response.Resource);
            }

            if (charges > 10d + extra)
                LogMessages.RequestCharge(Logger, "Query", "", charges);

            return results;
        }
        catch (CosmosOperationCanceledException)
        {
            return [];
        }
    }
}