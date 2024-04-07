using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MM.Shared.ModelQuery;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Core.Models;
using System.Globalization;

namespace VerusDate.Api.Function
{
    public class PublicFunction
    {
        private readonly IMediator _mediator;

        public PublicFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("PublicListDestaques")]
        public async Task<IActionResult> ListDestaques(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "Public/ListDestaques")] HttpRequestData req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = req.BuildRequestQuery<ProfileGetDestaquesCommand, List<ProfileSearch>>();

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result.Take(12));
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }
    }
}