using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Distributed;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using MM.Shared.Translations.Enum;
using System.Text.Json;

namespace MM.API.Functions;

public class CacheFunction(CosmosCacheRepository cacheRepo, CosmosRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, IDistributedCache cache, IHttpClientFactory factory)
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
                    .Select(s => new SumUsersRegion
                    {
                        Name = s.Key,
                        //Cities = s.Select(s => s.City!).Distinct().ToList()
                    }).ToList();

                doc = await cacheRepo.UpsertItemAsync(new SumUsersCache(obj, cacheKey), cancellationToken);
            }

            await SaveCache(doc, cacheKey, TtlCache.HalfDay, cancellationToken);
        }

        return await req.CreateResponse(doc, TtlCache.HalfDay, cancellationToken);
    }

    [Function("LastUsers")]
    public async Task<HttpResponseData?> LastUsers(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/cache/last-users")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var cacheKey = "last-users";

        var doc = await cache.Get<LastUsers>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.Get<LastUsers>(cacheKey, cancellationToken);

            if (doc == null)
            {
                var obj = new LastUsers();

                var logins = await repo.Query<AuthLogin>(DocumentType.Login,
                   null,
                   p => p.OrderByDescending(x => x.TimestampCreated).Take(20),
                   cancellationToken);

                foreach (var login in logins)
                {
                    var loginCountry = login.Accesses.LastOrDefault()?.Country?.ToLower();
                    var enumCountry = EnumHelper.ParseToEnum<Shared.Enums.Country>(loginCountry);

                    obj.Items.Add(new LastUsersItem { Created = login.DateTimeCreated ?? DateTime.Now, Country = enumCountry });
                }

                doc = await cacheRepo.UpsertItemAsync(new LastUsersCache(obj, cacheKey), cancellationToken);
            }

            await SaveCache(doc, cacheKey, TtlCache.HalfDay, cancellationToken);
        }

        return await req.CreateResponse(doc, TtlCache.HalfDay, cancellationToken);
    }

    [Function("LastRegionUsers")]
    public async Task<HttpResponseData?> LastRegionUsers(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/cache/last-region-users/{country}")] HttpRequestData req, string country, CancellationToken cancellationToken)
    {
        var cacheKey = $"last-region-users-{country.ToLowerInvariant()}";
        var doc = await cache.Get<LastRegionUsers>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.Get<LastRegionUsers>(cacheKey, cancellationToken);

            if (doc == null)
            {
                var obj = new LastRegionUsers();

                var logins = await repo.Query<AuthLogin>(DocumentType.Login,
                    p => p.Accesses.Any(x => x.Country == country),
                    p => p.OrderByDescending(x => x.TimestampCreated).Take(20),
                    cancellationToken);

                foreach (var login in logins)
                {
                    if (login?.Accesses.LastOrDefault()?.Country?.ToLower() == country)
                    {
                        var profile = await repoOff.Get<ProfileModel>(login.UserId, cancellationToken);

                        profile ??= await repoOn.Get<ProfileModel>(login.UserId, cancellationToken);

                        if (profile?.NickName == "drma-tech") continue;

                        obj.Items.Add(new LastRegionUsersItem { Id = login.UserId, Nickname = profile?.NickName, State = profile?.State });
                    }
                }

                doc = await cacheRepo.UpsertItemAsync(new LastRegionUsersCache(obj, cacheKey), cancellationToken);
            }

            await SaveCache(doc, cacheKey, TtlCache.OneWeek, cancellationToken);
        }

        return await req.CreateResponse(doc, TtlCache.OneWeek, cancellationToken);
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