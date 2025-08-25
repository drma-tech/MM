using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Blocked;
using MM.Shared.Models.Profile;

namespace MM.API.Functions;

public class PrincipalFunction(
    CosmosRepository repo,
    CosmosCacheRepository repoCache,
    CosmosProfileOffRepository repoOff,
    CosmosProfileOnRepository repoOn,
    ILogger<PrincipalFunction> logger)
{
    [Function("PrincipalGet")]
    public async Task<HttpResponseData?> PrincipalGet(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "principal/get")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();
            if (string.IsNullOrEmpty(userId)) throw new InvalidOperationException("GetUserId null");

            var model = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);

            return await req.CreateResponse(model, TtlCache.OneDay, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("PrincipalAdd")]
    public async Task<ClientePrincipal?> PrincipalAdd(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "principal/add")] HttpRequestData req, CancellationToken cancellationToken)
    {
        //note: its called once per user (first acccess)

        try
        {
            var userId = req.GetUserId();
            var body = await req.GetBody<ClientePrincipal>(cancellationToken);

            //check if user ip is blocked for insert
            var ip = req.GetUserIP(false) ?? throw new NotificationException("Failed to retrieve IP");
            var blockedIp = await repoCache.Get<DataBlocked>($"block-{ip}", cancellationToken);
            if (blockedIp?.Data != null)
            {
                blockedIp.Data.Quantity++;
                await repoCache.UpsertItemAsync(blockedIp, cancellationToken);

                if (blockedIp.Data?.Quantity > 2)
                {
                    //todo: create a mecanism to increase block time if user persist on this action (first = block one hour, second = block 24 hours)
                    logger.LogWarning("PrincipalAdd blocked IP {IP}", ip);
                    throw new NotificationException("You've reached the limit for creating profiles. Please try again later.");
                }
            }
            else
            {
                _ = repoCache.CreateItemAsync(new DataBlockedCache(new DataBlocked(), $"block-{ip}", TtlCache.OneWeek), cancellationToken);
            }

            //check if user was invited
            var invite = await repoCache.Get<InviteModel>($"invite-{body.Email}", cancellationToken);
            if (invite != null)
            {
                //add likes from invites
                var myLikes = new MyLikesModel();
                myLikes.Initialize(userId);

                foreach (var partnerId in invite.Data?.UserIds.Distinct() ?? [])
                {
                    if (userId == partnerId) continue; //avoid self like

                    var partnerProfile = await ProfileHelper.GetProfile(repoOff, repoOn, partnerId, cancellationToken);

                    if (partnerProfile != null)
                    {
                        var mySettings = await repo.Get<SettingModel>(DocumentType.Setting, userId, cancellationToken);

                        myLikes.Items.Add(new PersonModel(partnerProfile, mySettings?.BlindDate ?? false));
                    }

                    //create interaction between users
                    await repo.SetInteractionNew(partnerId, userId, EventType.Like, Origin.Invite, cancellationToken);
                }

                await repo.UpsertItemAsync(myLikes, cancellationToken);
            }

            var model = new ClientePrincipal
            {
                IdentityProvider = body.IdentityProvider,
                DisplayName = body.DisplayName,
                Email = body.Email
            };
            model.Initialize(userId);

            return await repo.CreateItemAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("PrincipalPaddle")]
    public async Task<ClientePrincipal> PrincipalPaddle(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/paddle")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();

            var model = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("Client null");
            var body = await req.GetBody<ClientePrincipal>(cancellationToken);

            model.ClientePaddle = body.ClientePaddle;

            return await repo.UpsertItemAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("PrincipalRemove")]
    public async Task PrincipalRemove(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Delete, Route = "principal/remove")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var id = req.GetQueryParameters()["offlineId"];

            var userId = id ?? req.GetUserId();

            var myPrincipal = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken);
            if (myPrincipal != null) await repo.Delete(myPrincipal, cancellationToken);

            var myLogins = await repo.Get<ClienteLogin>(DocumentType.Login, userId, cancellationToken);
            if (myLogins != null) await repo.Delete(myLogins, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("PrincipalPublicMode")]
    public async Task<ClientePrincipal?> PrincipalPublicMode(
     [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/public")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();

            var profile = await repoOff.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("profile not found");
            await repoOn.Upsert(profile, cancellationToken);
            await repoOff.Delete(profile, cancellationToken);

            var principal = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("ClientePrincipal null");
            principal.PublicProfile = true;

            return await repo.UpsertItemAsync(principal, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("PrincipalPrivateMode")]
    public async Task<ClientePrincipal?> PrincipalPrivateMode(
    [HttpTrigger(AuthorizationLevel.Anonymous, Method.Put, Route = "principal/private")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();

            var profile = await repoOn.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("profile not found");
            await repoOff.Upsert(profile, cancellationToken);
            await repoOn.Delete(profile, cancellationToken);

            var principal = await repo.Get<ClientePrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("ClientePrincipal null");
            principal.PublicProfile = false;

            return await repo.UpsertItemAsync(principal, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }
}