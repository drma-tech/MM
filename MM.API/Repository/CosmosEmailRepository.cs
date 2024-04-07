﻿using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using MM.Shared.Models.Support;
using System.Linq.Expressions;

namespace MM.API.Repository
{
    public class CosmosEmailRepository
    {
        public Container Container { get; private set; }

        public CosmosEmailRepository(IConfiguration config)
        {
            var databaseId = config.GetValue<string>("RepositoryOptions_DatabaseId");
            var containerId = config.GetValue<string>("RepositoryOptions_ContainerMailId");

            Container = ApiStartup.CosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task<EmailDocument?> Get(string key, CancellationToken cancellationToken)
        {
            try
            {
                var response = await Container.ReadItemAsync<EmailDocument?>(key, new PartitionKey(key), null, cancellationToken);

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<List<EmailDocument>> Query(Expression<Func<EmailDocument, bool>>? predicate, CancellationToken cancellationToken)
        {
            IQueryable<EmailDocument> query;

            if (predicate is null)
            {
                query = Container.GetItemLinqQueryable<EmailDocument>();
            }
            else
            {
                query = Container.GetItemLinqQueryable<EmailDocument>().Where(predicate);
            }

            using var iterator = query.ToFeedIterator();
            var results = new List<EmailDocument>();
            double count = 0;

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync(cancellationToken);

                count += response.RequestCharge;

                results.AddRange(response.Resource);
            }

            return results;
        }

        public async Task<EmailDocument?> Upsert(EmailDocument email, CancellationToken cancellationToken)
        {
            var response = await Container.UpsertItemAsync(email, new PartitionKey(email.Key), null, cancellationToken);

            return response.Resource;
        }
    }
}