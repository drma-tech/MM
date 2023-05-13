using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Repository.Core;
using MM.Shared.Core.Models;
using MM.Shared.Models.Profile;

namespace VerusDate.Api.Function
{
    public class InviteFunction
    {
        private readonly IRepository _repo;

        public InviteFunction(IRepository repo)
        {
            _repo = repo;
        }

        [Function("InviteGet")]
        public async Task<InviteModel?> Get(
          [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "Invite/Get")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId();

                return await _repo.Get<InviteModel>(DocumentType.Invite + ":" + userId, new PartitionKey(userId), cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }

        [Function("InviteUpdate")]
        public async Task<InviteModel> Update(
            [HttpTrigger(AuthorizationLevel.Function, Method.POST, Route = "Invite/Update")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var body = await req.GetBody<InviteModel>(cancellationToken);

                return await _repo.Upsert(body, cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }
    }
}