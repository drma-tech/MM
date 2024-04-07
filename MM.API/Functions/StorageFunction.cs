using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Server.Mediator.Commands.Profile;

namespace VerusDate.Api.Function
{
    public class StorageFunction
    {
        private readonly IMediator _mediator;

        public StorageFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Function("StorageUploadPhotoFace")]
        public async Task<IActionResult> UploadPhotoFace(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "Storage/UploadPhotoFace")] HttpRequestData req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<UploadPhotoFaceCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [Function("StorageUploadPhotoGallery")]
        public async Task<IActionResult> UploadPhotoGallery(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Storage/UploadPhotoGallery")] HttpRequestData req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = await req.BuildRequestCommand<UploadPhotoGalleryCommand>(source.Token);

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        [Function("StorageDeletePhotoGallery")]
        public async Task<IActionResult> DeletePhotoGallery(
            [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.DELETE, Route = "Storage/DeletePhotoGallery")] HttpRequestData req,
            ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var request = req.BuildRequestDelete<DeletePhotoGalleryCommand, bool>();

                var result = await _mediator.Send(request, source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }

        //[Function("StorageUploadPhotoValidation")]
        //public async Task<IActionResult> UploadPhotoValidation(
        //   [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Storage/UploadPhotoValidation")] HttpRequestData req,
        //   ILogger log, CancellationToken cancellationToken)
        //{
        //    using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

        //    try
        //    {
        //        var request = await req.BuildRequestCommand<UploadPhotoValidationCommand>(source.Token);

        //        var result = await _mediator.Send(request, source.Token);

        //        if (result)
        //            return new OkObjectResult("Rosto reconhecido com sucesso!");
        //        else
        //            return new BadRequestObjectResult("Não foi possível reconhecer seu rosto. Favor, tentar novamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
        //        return new BadRequestObjectResult(ex.ProcessException());
        //    }
        //}
    }
}