using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Distributed;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using System.Text.Json;

namespace MM.API.Functions;

public class CacheFunction(CosmosCacheRepository cacheRepo, CosmosMainRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, IDistributedCache cache)
{
    [Function("Dashboard")]
    public async Task<HttpResponseData?> Dashboard(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/cache/sum-users")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var cacheKey = "dashboard";

        var doc = await cache.Get<SumUsersCache>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.ReadItemAsync<SumUsersCache>(new CacheIdentity(cacheKey), cancellationToken);

            if (doc == null)
            {
                var obj = new SumUsers();

                var offProfiles = await repoOff.Query<ProfileModel>(null, null, cancellationToken);
                var onProfiles = await repoOn.Query<ProfileModel>(null, null, cancellationToken);
                var profiles = offProfiles.Union(onProfiles);
                var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

                var principals = await repo.Query<AuthPrincipal>(MainType.Principal, null, null, cancellationToken);

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

                doc = await cacheRepo.CreateItemAsync(new SumUsersCache(cacheKey, obj));
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

        var doc = await cache.Get<LastUsersCache>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.ReadItemAsync<LastUsersCache>(new CacheIdentity(cacheKey), cancellationToken);

            if (doc == null)
            {
                var obj = new LastUsers();

                var logins = await repo.Query<AuthLogin>(MainType.Login,
                   null,
                   p => p.OrderByDescending(x => x.TimestampCreated).Take(20),
                   cancellationToken);

                foreach (var login in logins)
                {
                    var loginCountry = login.Accesses.LastOrDefault()?.Country?.ToLower();
                    var enumCountry = loginCountry.NotEmpty() ? EnumHelper.ParseToEnum<Shared.Enums.Country>(loginCountry) : (Country?)null;

                    obj.Items.Add(new LastUsersItem { Created = login.DateTimeCreated ?? DateTime.Now, Country = enumCountry });
                }

                doc = await cacheRepo.CreateItemAsync(new LastUsersCache(cacheKey, obj));
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
        var doc = await cache.Get<LastRegionUsersCache>(cacheKey, cancellationToken);

        if (doc == null)
        {
            doc = await cacheRepo.ReadItemAsync<LastRegionUsersCache>(new CacheIdentity(cacheKey), cancellationToken);

            if (doc == null)
            {
                var obj = new LastRegionUsers();

                var logins = await repo.Query<AuthLogin>(MainType.Login,
                    p => p.Accesses.Any(x => x.Country == country),
                    p => p.OrderByDescending(x => x.TimestampCreated).Take(20),
                    cancellationToken);

                foreach (var login in logins)
                {
                    if (login?.Accesses.LastOrDefault()?.Country?.ToLower() == country)
                    {
                        var profile = await repoOff.ReadItemAsync<ProfileModel>(new ProfileIdentity(login.UserId), cancellationToken);

                        profile ??= await repoOn.ReadItemAsync<ProfileModel>(new ProfileIdentity(login.UserId), cancellationToken);

                        if (profile?.NickName == "drma-tech") continue;

                        obj.Items.Add(new LastRegionUsersItem { Id = login.UserId, Nickname = profile?.NickName, State = profile?.State });
                    }
                }

                doc = await cacheRepo.CreateItemAsync(new LastRegionUsersCache(cacheKey, obj));
            }

            await SaveCache(doc, cacheKey, TtlCache.OneWeek, cancellationToken);
        }

        return await req.CreateResponse(doc, TtlCache.OneWeek, cancellationToken);
    }

    private async Task SaveCache<TData>(CacheDocumentData<TData>? doc, string cacheKey, TtlCache ttl, CancellationToken cancellationToken) where TData : class, new()
    {
        if (doc != null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(doc);
            await cache.SetAsync(cacheKey, bytes, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds((int)ttl) }, cancellationToken);
        }
    }
}