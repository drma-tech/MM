using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Caching.Distributed;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using System.Net;
using System.Text.Json;

namespace MM.API.Functions;

public class CacheFunction(CosmosCacheRepository cacheRepo, CosmosRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn, IDistributedCache distributedCache)
{
    [Function("Settings")]
    public static async Task<HttpResponseData> Configurations(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/settings")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            return await req.CreateResponse(ApiStartup.Configurations.Settings, TtlCache.OneDay, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("Dashboard")]
    public async Task<HttpResponseData?> Dashboard(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/cache/sum-users")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var cacheKey = "dashboard";
            CacheDocument<SumUsers>? doc;
            var cachedBytes = await distributedCache.GetAsync(cacheKey);
            if (cachedBytes is { Length: > 0 })
            {
                doc = JsonSerializer.Deserialize<CacheDocument<SumUsers>>(cachedBytes);
            }
            else
            {
                doc = await cacheRepo.Get<SumUsers>(cacheKey, cancellationToken);

                if (doc == null)
                {
                    var obj = new SumUsers();

                    var offProfiles = await repoOff.ListAll<ProfileModel>(cancellationToken);
                    var onProfiles = await repoOn.ListAll<ProfileModel>(cancellationToken);
                    var profiles = offProfiles.Union(onProfiles);

                    var principals = await repo.ListAll<AuthPrincipal>(DocumentType.Principal, cancellationToken);

                    var relationships = await repo.Query<InteractionModel>(x => x.Status == InteractionStatus.Relationship, DocumentType.Interaction, cancellationToken);

                    obj.Countries = profiles.Select(s => s.Country).Distinct().Count();
                    obj.Cities = profiles.Select(s => s.Location).Distinct().Count();
                    obj.Users = principals.Count;
                    obj.Couples = relationships.Count;

                    doc = await cacheRepo.UpsertItemAsync(new SumUsersCache(obj, cacheKey), cancellationToken);
                }

                await SaveCache(doc, cacheKey, TtlCache.HalfDay);
            }

            return await req.CreateResponse(doc, TtlCache.OneDay, cancellationToken);
        }
        catch (TaskCanceledException ex)
        {
            req.ProcessException(ex.CancellationToken.IsCancellationRequested
                ? new NotificationException("Cancellation Requested")
                : new NotificationException("Timeout occurred"));

            return req.CreateResponse(HttpStatusCode.RequestTimeout);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    private async Task SaveCache<TData>(CacheDocument<TData>? doc, string cacheKey, TtlCache ttl) where TData : class, new()
    {
        if (doc != null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(doc);
            await distributedCache.SetAsync(cacheKey, bytes, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds((int)ttl) });
        }
    }
}
