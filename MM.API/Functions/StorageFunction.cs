using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Functions;

public class StorageFunction(
    CosmosProfileOffRepository repo,
    StorageHelper storageHelper,
    ComputerVisionHelper computerVisionHelper)
{
    private readonly CosmosProfileOffRepository _repo = repo;

    [Function("StorageUploadPhoto")]
    public async Task<ProfileModel> StorageUploadPhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "storage/upload-photo")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId() ?? throw new NotificationException("Invalid user");
            var request = await req.GetPublicBody<PhotoRequest>(cancellationToken);

            var profile = await _repo.Get<ProfileModel>(userId, cancellationToken) ??
                          throw new NotificationException("Profile not found");
            var currentPictureId = profile.Gallery?.GetPictureId(request.PhotoType);

            using var stream1 = new MemoryStream(request.Buffer);

            profile.Gallery ??= new ProfileGalleryModel();

            var photoId = Guid.NewGuid() + ".jpg";

            profile.Gallery.UpdatePictureId(request.PhotoType, photoId); //reset current photo data

            //await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //validates the photo sent and saves data related to it
            var analysis = await computerVisionHelper.AnalyzeImage(stream1, cancellationToken);

            if (analysis.Adult.RacyScore > 0.8 || analysis.Adult.GoreScore > 0.8 || analysis.Adult.AdultScore > 0.8)
                throw new NotificationException("Image content is inappropriate. Please use another one.");

            var faceObjects = analysis.Faces;
            if (faceObjects.Count == 0)
                throw new NotificationException(
                    "We cannot clearly identify a face in this photo. Please use another one.");

            if (request.PhotoType == PhotoType.Face && faceObjects.Count > 1)
                throw new NotificationException("Your main photo should only feature you.");

            var personObjects = analysis.Objects.Where(a => a.ObjectProperty == "person" && a.Confidence > 0.85);
            if (request.PhotoType == PhotoType.Body)
            {
                if (!personObjects.Any())
                    throw new NotificationException(
                        "We were unable to detect a body in this photo. Please choose a photo that best shows your body.");

                if (personObjects.Count() > 1)
                    throw new NotificationException(
                        "We detected more than one person in this photo. Please choose a photo where you are alone.");

                //todo: find a better way to detect a full body

                //var body = personObjects.Single();
                //var bodyArea = body.Rectangle.H * body.Rectangle.W;
                //var rect = body.Rectangle;
                //var aspectRatio = Math.Max(rect.H, rect.W) / (double)Math.Min(rect.H, rect.W);
                //var faceArea = faceObjects.Sum(face => face.FaceRectangle.Height * face.FaceRectangle.Width);

                //if (aspectRatio < 1.3)
                //{
                //    throw new NotificationException("We were unable to detect a full body in this photo. Please choose a photo that best shows your entire body.");
                //}

                //var face = faceObjects.FirstOrDefault();
                //if (face != null)
                //{
                //    var faceY = face.FaceRectangle.Left;
                //    if (faceY < rect.Y + rect.H * 0.25) // The face cannot be too far above the body
                //    {
                //        throw new NotificationException("We detected only the head or a partial body. Please choose a photo that best shows your entire body.");
                //    }
                //}

                //if (bodyArea < faceArea * 3)
                //{
                //    throw new NotificationException("We were unable to detect a full body in this photo. Please choose a photo that best shows your entire body.");
                //}
            }

            if (currentPictureId != null) //delete old picture from azure storage
                //if you keep the photo with the same id, the browser cache will not update the photo
                await storageHelper.DeletePhoto(request.PhotoType, currentPictureId, cancellationToken);

            using var stream2 = new MemoryStream(request.Buffer);

            await storageHelper.UploadPhoto(request.PhotoType, stream2, photoId, userId, cancellationToken);

            profile.UpdatePhoto(profile.Gallery);

            return await _repo.Upsert(profile, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("StorageDeletePhoto")]
    public async Task<ProfileModel> StorageDeletePhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.DELETE, Route = "storage/delete-photo/{photoType}")]
        HttpRequestData req, PhotoType photoType, CancellationToken cancellationToken)
    {
        try
        {
            var userId = req.GetUserId() ?? throw new NotificationException("Invalid user");

            var profile = await _repo.Get<ProfileModel>(userId, cancellationToken) ??
                          throw new NotificationException("Profile not found");

            profile.Gallery ??= new ProfileGalleryModel();

            await storageHelper.DeletePhoto(photoType, profile.Gallery.GetPictureId(photoType), cancellationToken);

            profile.Gallery.UpdatePictureId(photoType, null); //reset current photo data

            profile.UpdatePhoto(profile.Gallery);

            return await _repo.Upsert(profile, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
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