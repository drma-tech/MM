﻿using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;
using System.Linq.Expressions;

namespace MM.API.Repository
{
    public class CosmosProfileRepository
    {
        public Container Container { get; private set; }
        private readonly ILogger<CosmosProfileRepository> _logger;

        public CosmosProfileRepository(IConfiguration config, ILogger<CosmosProfileRepository> logger)
        {
            _logger = logger;

            var databaseId = config.GetValue<string>("RepositoryOptions_DatabaseId");
            var containerId = config.GetValue<string>("RepositoryOptions_ContainerProfileId");

            Container = ApiStartup.CosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task<T?> Get<T>(string? id, CancellationToken cancellationToken) where T : CosmosDocument
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            try
            {
                var response = await Container.ReadItemAsync<T>(id, new PartitionKey(id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

                if (response.RequestCharge > 1.5)
                {
                    _logger.LogWarning("Get - ID {0}, RequestCharge {1}", id, response.RequestCharge);
                }

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<List<T>> Query<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : MainDocument
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

            if (charges > 5)
            {
                _logger.LogWarning("Query, RequestCharge {Charges}", charges);
            }

            return results;
        }

        public async Task<T> Upsert<T>(T item, CancellationToken cancellationToken) where T : CosmosDocument
        {
            var response = await Container.UpsertItemAsync(item, new PartitionKey(item.Id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 12)
            {
                _logger.LogWarning("Upsert - ID {Id}, RequestCharge {Charges}", item.Id, response.RequestCharge);
            }

            return response.Resource;
        }

        public async Task<T> PatchItem<T>(string? id, List<PatchOperation> operations, CancellationToken cancellationToken) where T : CosmosDocument
        {
            //https://learn.microsoft.com/en-us/azure/cosmos-db/partial-document-update-getting-started?tabs=dotnet

            var response = await Container.PatchItemAsync<T>(id, new PartitionKey(id), operations, CosmosRepositoryExtensions.GetPatchItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 12)
            {
                _logger.LogWarning("PatchItem - ID {Id}, RequestCharge {Charges}", id, response.RequestCharge);
            }

            return response.Resource;
        }

        public async Task<bool> Delete<T>(T item, CancellationToken cancellationToken) where T : CosmosDocument
        {
            var response = await Container.DeleteItemAsync<T>(item.Id, new PartitionKey(item.Id), CosmosRepositoryExtensions.GetItemRequestOptions(), cancellationToken);

            if (response.RequestCharge > 12)
            {
                _logger.LogWarning("Delete - ID {Id}, RequestCharge {Charges}", item.Id, response.RequestCharge);
            }

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        //Overview of indexing in Azure Cosmos DB
        //https://learn.microsoft.com/en-us/azure/cosmos-db/index-overview
    }
}