using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Distributed;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using System.Text.Json;

namespace MM.API.Functions;

public class CacheFunction(CosmosCacheRepository cacheRepo, CosmosRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, IDistributedCache cache)
{
    [Function("Dashboard")]
    public async Task<HttpResponseData?> Dashboard(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/cache/sum-users")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var cacheKey = "dashboard";

        var doc = await cache.Get<SumUsers>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.Get<SumUsers>(cacheKey, cancellationToken);

            if (doc == null)
            {
                var obj = new SumUsers();

                var offProfiles = await repoOff.ListAll<ProfileModel>(cancellationToken);
                var onProfiles = await repoOn.ListAll<ProfileModel>(cancellationToken);
                var profiles = offProfiles.Union(onProfiles);
                var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

                var principals = await repo.ListAll<AuthPrincipal>(DocumentType.Principal, cancellationToken);

                //var relationships = await repo.Query<InteractionModel>(x => x.Status == InteractionStatus.Relationship, DocumentType.Interaction, cancellationToken);

                obj.Countries = profiles.Select(s => s.Country).Distinct().Count();
                obj.Cities = profiles.Select(s => s.Location).Distinct().Count();
                obj.TotalUsers = principals.Count;
                obj.RecentlyJoined = principals.Count(w => w.DateTimeCreated > oneWeekAgo);

                obj.Regions = profiles
                    .GroupBy(g => g.Country)
                    .Select(s => new Shared.Models.Dashboard.Region
                    {
                        Name = s.Key,
                        Cities = s.Select(s => s.City!).Distinct().ToList()
                    }).ToList();

                doc = await cacheRepo.UpsertItemAsync(new SumUsersCache(obj, cacheKey), cancellationToken);
            }

            await SaveCache(doc, cacheKey, TtlCache.HalfDay, cancellationToken);
        }

        return await req.CreateResponse(doc, TtlCache.OneDay, cancellationToken);
    }

    private async Task SaveCache<TData>(CacheDocument<TData>? doc, string cacheKey, TtlCache ttl, CancellationToken cancellationToken) where TData : class, new()
    {
        if (doc != null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(doc);
            await cache.SetAsync(cacheKey, bytes, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds((int)ttl) }, cancellationToken);
        }
    }
}
