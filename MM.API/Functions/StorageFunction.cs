using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;

namespace MM.API.Functions
{
    //public class StorageFunction(CosmosProfileRepository repo, StorageHelper storageHelper, FaceHelper faceHelper)
    public class StorageFunction(CosmosProfileRepository repo)
    {
        private readonly CosmosProfileRepository _repo = repo;

        //[Function("StorageUploadPhotoFace")]
        //public async Task<bool> StorageUploadPhotoFace(
        //    [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "storage/upload-photo-face")] HttpRequestData req, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var userId = req.GetUserId();

        //        var profile = await _repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Perfil não encontrado");
        //        var IdOldPhoto = profile.Photo?.Main;

        //        var bytes = await req.GetPublicBody<byte[]>(cancellationToken);

        //        using var stream1 = new MemoryStream(bytes);

        //        profile.Photo ??= new ProfilePhotoModel();

        //        var photoName = Guid.NewGuid().ToString() + ".jpg";
        //        profile.Photo.UpdateMainPhoto(photoName); //reset current photo data

        //        await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //validates the photo sent and saves data related to it

        //        if (!string.IsNullOrEmpty(profile.Photo.Main)) //foto já existente
        //        {
        //            //if you keep the photo with the same id, the browser cache will not update the photo
        //            await storageHelper.DeletePhoto(ImageHelper.PhotoType.PhotoFace, IdOldPhoto, cancellationToken);
        //        }

        //        using var stream2 = new MemoryStream(bytes);

        //        await storageHelper.UploadPhoto(ImageHelper.PhotoType.PhotoFace, stream2, photoName, cancellationToken);

        //        profile.UpdatePhoto(profile.Photo);

        //        return await _repo.Update(profile, cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        req.ProcessException(ex);
        //        throw new UnhandledException(ex.BuildException());
        //    }
        //}

        //[Function("StorageUploadPhotoGallery")]
        //public async Task<IActionResult> UploadPhotoGallery(
        //    [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.PUT, Route = "Storage/UploadPhotoGallery")] HttpRequestData req,
        //    ILogger log, CancellationToken cancellationToken)
        //{
        //    using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

        //    try
        //    {
        //        var request = await req.BuildRequestCommand<UploadPhotoGalleryCommand>(source.Token);

        //        var result = await _mediator.Send(request, source.Token);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
        //        return new BadRequestObjectResult(ex.ProcessException());
        //    }
        //}

        //[Function("StorageDeletePhotoGallery")]
        //public async Task<IActionResult> DeletePhotoGallery(
        //    [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.DELETE, Route = "Storage/DeletePhotoGallery")] HttpRequestData req,
        //    ILogger log, CancellationToken cancellationToken)
        //{
        //    using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

        //    try
        //    {
        //        var request = req.BuildRequestDelete<DeletePhotoGalleryCommand, bool>();

        //        var result = await _mediator.Send(request, source.Token);

        //        return new OkObjectResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
        //        return new BadRequestObjectResult(ex.ProcessException());
        //    }
        //}

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