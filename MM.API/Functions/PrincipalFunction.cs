using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    public class PrincipalFunction(CosmosRepository repo, CosmosCacheRepository repoCache, CosmosProfileOffRepository repoOff, CosmosProfileOnRepository repoOn)
    {
        [Function("PrincipalGet")]
        public async Task<HttpResponseData?> PrincipalGet(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "principal/get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();
                if (string.IsNullOrEmpty(userId)) throw new InvalidOperationException("GetUserId null");

                var doc = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);

                return await req.CreateResponse(doc, ttlCache.one_day, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("PrincipalGetEmail")]
        public async Task<string?> PrincipalGetEmail(
          [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "public/principal/get-email")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var token = req.GetQueryParameters()["token"];

                var principal = await repo.Get<ClientePrincipal>(DocumentType.Principal, token, cancellationToken);

                return principal?.Email;
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("PrincipalAdd")]
        public async Task<ClientePrincipal?> PrincipalAdd(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST, Route = "principal/add")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var principal = await req.GetBody<ClientePrincipal>(cancellationToken);

                var invite = await repoCache.Get<InviteModel>($"invite-{principal.Email}", cancellationToken);
                if (invite != null)
                {
                    //add likes from invites
                    var myLikes = new MyLikesModel();
                    myLikes.Initialize(principal.UserId!);

                    foreach (var partnerId in invite.Data?.UserIds.Distinct() ?? [])
                    {
                        if (principal.UserId == partnerId) continue; //avoid self like

                        var partnerProfile = await ProfileHelper.GetProfile(repoOff, repoOn, partnerId, cancellationToken);

                        if (partnerProfile != null)
                        {
                            var partnerSettings = await repo.Get<SettingModel>(DocumentType.Setting, partnerId, cancellationToken);
                            myLikes.Items.Add(new PersonModel(partnerProfile, partnerSettings?.BlindDate ?? false));
                        }

                        //create interaction between users
                        _ = await repo.SetInteractionNew(partnerId, principal.UserId, EventType.Like, Origin.Invite, cancellationToken);
                    }

                    await repo.Upsert(myLikes, cancellationToken);
                }

                return await repo.Upsert(principal, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("PrincipalPaddle")]
        public async Task<ClientePrincipal> PrincipalPaddle(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.PUT, Route = "principal/paddle")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var Client = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new NotificationException("Client null");
                var body = await req.GetBody<ClientePrincipal>(cancellationToken);

                Client.ClientePaddle = body.ClientePaddle;

                return await repo.Upsert(Client, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("PrincipalRemove")]
        public async Task PrincipalRemove(
           [HttpTrigger(AuthorizationLevel.Anonymous, Method.DELETE, Route = "principal/remove")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                var myPrincipal = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);
                if (myPrincipal != null) await repo.Delete(myPrincipal, cancellationToken);

                //var myProviders = await repo.Get<MyProviders>(DocumentType.MyProvider, userId, cancellationToken);
                //if (myProviders != null) await repo.Delete(myProviders, cancellationToken);

                var myLogins = await repo.Get<ClienteLogin>(DocumentType.Login, userId, cancellationToken);
                if (myLogins != null) await repo.Delete(myLogins, cancellationToken);

                //var mySuggestions = await repo.Get<MySuggestions>(DocumentType.MySuggestions, userId, cancellationToken);
                //if (mySuggestions != null) await repo.Delete(mySuggestions, cancellationToken);

                //var myWatched = await repo.Get<WatchedList>(DocumentType.WatchedList, userId, cancellationToken);
                //if (myWatched != null) await repo.Delete(myWatched, cancellationToken);

                //var myWatching = await repo.Get<WatchingList>(DocumentType.WatchingList, userId, cancellationToken);
                //if (myWatching != null) await repo.Delete(myWatching, cancellationToken);

                //var myWish = await repo.Get<WishList>(DocumentType.WishList, userId, cancellationToken);
                //if (myWish != null) await repo.Delete(myWish, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }
    }
}