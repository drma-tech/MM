using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    public static class EventHelper
    {
        public static async Task<InteractionModel> SetInteraction(this CosmosRepository repo, HttpRequestData req, string? partnerUserId, EventType type, CancellationToken cancellationToken)
        {
            var userId = req.GetUserId();

            if (userId == partnerUserId) throw new NotificationException("cannot interact with yourself");

            var intId = InteractionModel.FormatId($"{userId}:{partnerUserId}");

            var interaction = await repo.Get<InteractionModel>(DocumentType.Interaction, intId, cancellationToken);

            if (interaction == null)
            {
                interaction = new InteractionModel();
                interaction.Initialize(intId);
            }

            interaction.AddEventUser(userId, type);

            if (type == EventType.Like)
            {
                if (interaction.Status != InteractionStatus.Explorer)
                {
                    throw new NotificationException("cannot like this user");
                }

                if (interaction.EventsUserA.Any(a => a.Type == EventType.Like) && interaction.EventsUserB.Any(a => a.Type == EventType.Like))
                {
                    interaction.Status = InteractionStatus.Match;
                }
            }
            else if (type == EventType.Dislike)
            {
                if (interaction.Status != InteractionStatus.Explorer)
                {
                    throw new NotificationException("cannot dislike this user");
                }
            }

            return await repo.Upsert(interaction, cancellationToken);
        }
    }

    public class EventFunction(CosmosRepository repoGen)
    {
        private readonly CosmosRepository _repoGen = repoGen;

        [Function("EventLike")]
        public async Task<HttpResponseData?> EventLike(
           [HttpTrigger(AuthorizationLevel.Function, Method.POST, Route = "event/like/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
        {
            try
            {
                var interaction = await _repoGen.SetInteraction(req, id, EventType.Like, cancellationToken);

                return await req.CreateResponse(interaction, ttlCache.one_hour, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }

        [Function("EventDislike")]
        public async Task<HttpResponseData?> EventDislike(
          [HttpTrigger(AuthorizationLevel.Function, Method.POST, Route = "event/dislike/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
        {
            try
            {
                var interaction = await _repoGen.SetInteraction(req, id, EventType.Dislike, cancellationToken);

                return await req.CreateResponse(interaction, ttlCache.one_hour, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw;
            }
        }
    }
}