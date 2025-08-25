using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;

namespace MM.API.Functions;

public static class EventHelper
{
    public static async Task<InteractionModel> GetInteractionModel(this CosmosRepository repo, string? userId,
        string? partnerId, CancellationToken cancellationToken)
    {
        var intId = InteractionModel.FormatId($"{userId}:{partnerId}");
        var interaction = await repo.Get<InteractionModel>(DocumentType.Interaction, intId, cancellationToken);

        if (interaction == null)
        {
            interaction = new InteractionModel();
            interaction.Initialize(intId);
        }

        return interaction;
    }

    public static async Task<InteractionModel> SetInteractionNew(this CosmosRepository repo, string? trigguerUserId,
        string? passiveUserId,
        EventType type, Origin origin, CancellationToken cancellationToken)
    {
        if (trigguerUserId == passiveUserId) throw new NotificationException("cannot interact with yourself");

        var interaction = await repo.GetInteractionModel(trigguerUserId, passiveUserId, cancellationToken);

        interaction.AddEventUser(trigguerUserId, type, origin);

        if (type == EventType.Like)
        {
            if (interaction.Status != InteractionStatus.Explorer)
                throw new NotificationException("cannot like this user");

            if (interaction.EventsUserA.Any(a => a.Type == EventType.Like) &&
                interaction.EventsUserB.Any(a => a.Type == EventType.Like))
                interaction.Status = InteractionStatus.Match;
        }
        else if (type == EventType.Dislike)
        {
            if (interaction.Status != InteractionStatus.Explorer)
                throw new NotificationException("cannot dislike this user");
        }

        return await repo.UpsertItemAsync(interaction, cancellationToken);
    }
}

public class EventFunction(
    CosmosRepository repoGen,
    CosmosProfileOffRepository repoOff,
    CosmosProfileOnRepository repoOn)
{
    [Function("InteractionGet")]
    public async Task<HttpResponseData?> InteractionGet(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "interaction/get/{id}")]
        HttpRequestData req, string id, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();

            var interaction = await repoGen.GetInteractionModel(userId, id, cancellationToken);

            return await req.CreateResponse(interaction, TtlCache.OneHour, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("InteractionLike")]
    public async Task<HttpResponseData?> InteractionLike(
        [HttpTrigger(AuthorizationLevel.Function, Method.Post, Route = "interaction/like/{origin}/{id}")]
        HttpRequestData req, Origin origin, string id, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();
            var userProfile = await ProfileHelper.GetProfile(repoOff, repoOn, userId, cancellationToken) ??
                              throw new NotificationException("user not found");

            //add like to partner
            var partnerLikes = await repoGen.GetMyLikes(id, cancellationToken);
            var partnerSettings = await repoGen.Get<SettingModel>(DocumentType.Setting, id, cancellationToken);

            partnerLikes.Items.Add(new PersonModel(userProfile, partnerSettings?.BlindDate ?? false));

            //create interaction between users
            var interaction = await repoGen.SetInteractionNew(userId, id, EventType.Like, origin, cancellationToken);

            if (interaction.Status == InteractionStatus.Match)
            {
                var partnerProfile = await ProfileHelper.GetProfile(repoOff, repoOn, id, cancellationToken) ??
                                     throw new NotificationException("user not found");

                var userLikes = await repoGen.GetMyLikes(userId, cancellationToken);
                var userMatches = await repoGen.GetMyMatches(userId, cancellationToken);

                var partnerMatches = await repoGen.GetMyMatches(id, cancellationToken);

                await repoGen.SetMyMatches((userProfile, userLikes, userMatches),
                    (partnerProfile, partnerLikes, partnerMatches), cancellationToken);
            }

            await repoGen.UpsertItemAsync(partnerLikes, cancellationToken);

            return await req.CreateResponse(interaction, TtlCache.OneHour, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("InteractionDislike")]
    public async Task<HttpResponseData?> InteractionDislike(
        [HttpTrigger(AuthorizationLevel.Function, Method.Post, Route = "interaction/dislike/{origin}/{id}")]
        HttpRequestData req, Origin origin, string id, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId();

            var interaction = await repoGen.SetInteractionNew(userId, id, EventType.Dislike, origin, cancellationToken);

            return await req.CreateResponse(interaction, TtlCache.OneHour, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }
}