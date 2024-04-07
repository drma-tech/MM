using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Repository.Core;
using MM.Shared.Models.Support;

namespace MM.API.Functions
{
    public class SupportFunction(IRepository repo)
    {
        //[OpenApiOperation("UpdatesGet", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(AnnouncementModel))]
        [Function("UpdatesGet")]
        public async Task<List<UpdateModel>> UpdatesGet(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "public/updates/get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                return await repo.ListAll<UpdateModel>(DocumentType.Update, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("UpdatesAdd")]
        public async Task<UpdateModel> UpdatesAdd(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST, Route = "adm/updates/add")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var item = await req.GetPublicBody<UpdateModel>(cancellationToken);
                var dbItem = await repo.Get<UpdateModel>(DocumentType.Update + ":" + item.Key, new PartitionKey(item.Key), cancellationToken);

                if (dbItem != null)
                {
                    dbItem.Title = item.Title;
                    dbItem.Description = item.Description;

                    return await repo.Upsert(dbItem, cancellationToken);
                }
                else
                {
                    return await repo.Upsert(item, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("UpdatesDelete")]
        public async Task UpdatesDelete(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.PUT, Route = "adm/updates/delete")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var item = await req.GetPublicBody<UpdateModel>(cancellationToken);

                await repo.Delete(item, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[OpenApiOperation("TicketGetList", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(List<TicketModel>))]
        [Function("TicketGetList")]
        public async Task<List<TicketModel>> TicketGetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "public/ticket/get-list")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await repo.Query<TicketModel>(m => m.TicketStatus != TicketStatus.New || m.IdUserOwner == userId, null, DocumentType.Ticket, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("TicketGetAll")]
        public async Task<List<TicketModel>> TicketGetAll(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "adm/ticket/get-all")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                return await repo.ListAll<TicketModel>(DocumentType.Ticket, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[OpenApiOperation("TicketGetMyVotes", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(List<TicketVoteModel>))]
        [Function("TicketGetMyVotes")]
        public async Task<List<TicketVoteModel>> TicketGetMyVotes(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.GET, Route = "Ticket/GetMyVotes")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await repo.Query<TicketVoteModel>(x => x.IdVotedUser == userId, null, DocumentType.TicketVote, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[OpenApiOperation("TicketInsert", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(TicketModel))]
        [Function("TicketInsert")]
        public async Task<TicketModel?> TicketInsert(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST, Route = "Ticket/Insert")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var item = await req.GetPublicBody<TicketModel>(cancellationToken);

                return await repo.Upsert(item, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        //[OpenApiOperation("TicketVote", "Azure (Cosmos DB)")]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(TicketVoteModel))]
        [Function("TicketVote")]
        public async Task<TicketVoteModel?> TicketVote(
            [HttpTrigger(AuthorizationLevel.Anonymous, Method.POST, Route = "Ticket/Vote")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var item = await req.GetPublicBody<TicketVoteModel>(cancellationToken);

                if (item.VoteType == VoteType.PlusOne)
                    await repo.PatchItem<TicketModel>(nameof(DocumentType.Ticket) + ":" + item.Key, new PartitionKey(item.Key), [PatchOperation.Increment("/totalVotes", 1)], cancellationToken);
                else if (item.VoteType == VoteType.MinusOne)
                    await repo.PatchItem<TicketModel>(nameof(DocumentType.Ticket) + ":" + item.Key, new PartitionKey(item.Key), [PatchOperation.Increment("/totalVotes", -1)], cancellationToken);

                item.IdVotedUser = req.GetUserId();

                return await repo.Upsert(item, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }
    }
}