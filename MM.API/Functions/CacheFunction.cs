using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    public class CacheFunction(CosmosCacheRepository cacheRepo, CosmosRepository repo, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
    {
        [Function("Dashboard")]
        public async Task<HttpResponseData?> Dashboard(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "public/cache/sum-users")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var doc = await cacheRepo.Get<SumUsers>($"dashboard", cancellationToken);

                if (doc == null)
                {
                    var obj = new SumUsers();

                    var offProfiles = await repoOff.ListAll<ProfileModel>(cancellationToken);
                    var onProfiles = await repoOn.ListAll<ProfileModel>(cancellationToken);
                    var profiles = offProfiles.Union(onProfiles);

                    var principals = await repo.ListAll<ClientePrincipal>(DocumentType.Principal, cancellationToken);

                    var relationships = await repo.Query<InteractionModel>(x => x.Status == InteractionStatus.Relationship, DocumentType.Interaction, cancellationToken);

                    obj.Countries = profiles.Select(s => s.Country).Distinct().Count();
                    obj.Cities = profiles.Select(s => s.Location).Distinct().Count();
                    obj.Users = principals.Count;
                    obj.Couples = relationships.Count;

                    doc = await cacheRepo.UpsertItemAsync(new SumUsersCache(obj, "dashboard"), cancellationToken);
                }

                return await req.CreateResponse(doc, ttlCache.one_day, cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                if (ex.CancellationToken.IsCancellationRequested)
                    req.ProcessException(new NotificationException("Cancellation Requested"));
                else
                    req.ProcessException(new NotificationException("Timeout occurred"));

                return req.CreateResponse(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                return req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}