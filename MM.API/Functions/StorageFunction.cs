using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Functions
{
    public class StorageFunction(CosmosProfileRepository repo, StorageHelper storageHelper, ComputerVisionHelper computerVisionHelper)
    {
        private readonly CosmosProfileRepository _repo = repo;

        [Function("StorageUploadPhoto")]
        public async Task<ProfileModel> StorageUploadPhoto(
            [HttpTrigger(AuthorizationLevel.Function, Method.PUT, Route = "storage/upload-photo")] HttpRequestData req, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId() ?? throw new NotificationException("Invalid user");
                var request = await req.GetPublicBody<PhotoRequest>(cancellationToken);

                var profile = await _repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");
                var currentPictureId = profile.Photo?.GetPictureId(request.PhotoType);

                using var stream1 = new MemoryStream(request.Buffer);

                profile.Photo ??= new ProfilePhotoModel();

                var photoId = Guid.NewGuid().ToString() + ".jpg";

                profile.Photo.UpdatePictureId(request.PhotoType, photoId); //reset current photo data

                //await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //validates the photo sent and saves data related to it
                var analysis = await computerVisionHelper.AnalyzeImage(stream1, cancellationToken);

                if (analysis.Adult.RacyScore > 0.8 || analysis.Adult.GoreScore > 0.8 || analysis.Adult.AdultScore > 0.8)
                {
                    throw new NotificationException("Image content is inappropriate. Please use another one.");
                }

                if (analysis.Faces.Count == 0)
                {
                    throw new NotificationException("We cannot clearly identify a face in this photo. Please use another one.");
                }

                if (request.PhotoType == ImageHelper.PhotoType.Face && analysis.Faces.Count > 1)
                {
                    throw new NotificationException("Your main photo should only feature you.");
                }

                if (currentPictureId != null) //delete old picture from azure storage
                {
                    //if you keep the photo with the same id, the browser cache will not update the photo
                    await storageHelper.DeletePhoto(request.PhotoType, currentPictureId, cancellationToken);
                }

                using var stream2 = new MemoryStream(request.Buffer);

                await storageHelper.UploadPhoto(request.PhotoType, stream2, photoId, userId, cancellationToken);

                profile.UpdatePhoto(profile.Photo);

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
            [HttpTrigger(AuthorizationLevel.Function, Method.DELETE, Route = "storage/delete-photo/{photoType}")] HttpRequestData req, PhotoType photoType, CancellationToken cancellationToken)
        {
            try
            {
                var userId = req.GetUserId() ?? throw new NotificationException("Invalid user");

                var profile = await _repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");

                profile.Photo ??= new ProfilePhotoModel();

                await storageHelper.DeletePhoto(photoType, profile.Photo.GetPictureId(photoType), cancellationToken);

                profile.Photo.UpdatePictureId(photoType, null); //reset current photo data

                profile.UpdatePhoto(profile.Photo);

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
}