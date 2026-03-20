using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.AI;
using MM.API.Core.Auth;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Safety;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Functions;

public class StorageFunction(CosmosRepository repoGen, CosmosSafetyRepository repoSafety, CosmosProfileOffRepository repo, StorageHelper storageHelper, IHttpClientFactory factory)
{
    [Function("StorageUploadPhoto")]
    public async Task<ProfileModel> StorageUploadPhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "storage/upload-photo")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("Invalid user");
        var request = await req.GetPublicBody<PhotoRequest>(cancellationToken);

        var profile = await repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");
        var currentPictureId = profile.Gallery?.GetPictureId(request.PhotoType);

        using var stream1 = new MemoryStream(request.Buffer);

        profile.Gallery ??= new ProfileGalleryModel();

        var photoId = Guid.NewGuid() + ".jpg";

        profile.Gallery.UpdatePictureId(request.PhotoType, photoId); //reset current photo data

        var responseAdult = await AwsFaceAI.DetectAdultContent(stream1, cancellationToken);

        if (responseAdult.ModerationLabels.Any(x => x.Confidence >= 80f))
            throw new NotificationException("Image content is inappropriate. Please use another one.");

        var responseFace = await AwsFaceAI.DetectFaces(stream1, cancellationToken);
        var faces = responseFace.FaceDetails;

        if (faces.Count == 0)
            throw new NotificationException("We cannot clearly identify a face in this photo. Please use another one.");

        if (request.PhotoType == PhotoType.Face && faces.Count > 1)
            throw new NotificationException("Your main photo should only feature you.");

        var face = faces.Single();

        if (face.FaceOccluded.Value == true && face.FaceOccluded.Confidence >= 80f)
            throw new NotificationException("Ideally, use a photo where your face is clearly visible.");

        ////todo: improve body detection using labels and bounding boxes, to avoid false positives with photos that have a clear face but no body(e.g.selfies, close - ups, etc.)
        //if (request.PhotoType == PhotoType.Body)
        //{
        //    var responseLabels = await AwsFaceAI.DetectLabels(stream1, cancellationToken);

        //    var personObjects = responseLabels.Labels.Where(l => l.Name == "Person" && l.Confidence >= 80);

        //    if (!personObjects.Any())
        //        throw new NotificationException("We were unable to detect a body in this photo. Please choose a photo that best shows your body.");

        //    if (personObjects.Count() > 1)
        //        throw new NotificationException("We detected more than one person in this photo. Please choose a photo where you are alone.");
        //}

        if (currentPictureId != null) //delete old picture from azure storage
        {
            //if you keep the photo with the same id, the browser cache will not update the photo
            await storageHelper.DeletePhoto(request.PhotoType, currentPictureId, cancellationToken);

            //reset validation flag
            var validation = await repoGen.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);
            if (validation != null)
            {
                validation.Gallery = false;
                await repoGen.UpsertItemAsync(validation, cancellationToken);
            }
        }

        using var stream2 = new MemoryStream(request.Buffer);

        await storageHelper.UploadPhoto(request.PhotoType, stream2, photoId, userId, cancellationToken);

        profile.UpdatePhoto(profile.Gallery);

        return await repo.UpsertItemAsync(profile, cancellationToken);
    }

    [Function("StorageDeletePhoto")]
    public async Task<ProfileModel> StorageDeletePhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.Delete, Route = "storage/delete-photo/{photoType}")]
        HttpRequestData req, PhotoType photoType, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("Invalid user");

        var profile = await repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");

        profile.Gallery ??= new ProfileGalleryModel();

        await storageHelper.DeletePhoto(photoType, profile.Gallery.GetPictureId(photoType), cancellationToken);

        profile.Gallery.UpdatePictureId(photoType, null); //reset current photo data

        profile.UpdatePhoto(profile.Gallery);

        //reset validation flag
        var validation = await repoGen.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);
        if (validation != null)
        {
            validation.Gallery = false;
            await repoGen.UpsertItemAsync(validation, cancellationToken);
        }

        return await repo.UpsertItemAsync(profile, cancellationToken);
    }

    [Function("StorageUploadPhotoValidation")]
    public async Task<ValidationModel> UploadPhotoValidation(
       [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "storage/upload-photo-validation")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("Invalid user");
        var request = await req.GetPublicBody<UploadPhotoValidationCommand>(cancellationToken);

        var profile = await repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");
        if (profile == null || string.IsNullOrEmpty(profile.Gallery?.FaceId)) throw new NotificationException("Validation photo not found. Please insert your face photo first.");

        using var http = factory.CreateClient();
        using var faceStream = await http.GetImageStreamFromUrlAsync(profile.GetPhoto(PhotoType.Face), cancellationToken);
        using var bodyStream = await http.GetImageStreamFromUrlAsync(profile.GetPhoto(PhotoType.Body), cancellationToken);
        using var streamValidation = new MemoryStream(request.Stream);
        var responsFace = await AwsFaceAI.CompareFaces(faceStream, streamValidation, cancellationToken);
        var responsBody = await AwsFaceAI.CompareFaces(bodyStream, streamValidation, cancellationToken);

        if (responsFace.FaceMatches.Count == 0 || responsBody.FaceMatches.Count == 0)
        {
            throw new NotificationException("We were unable to detect a matching face. Make sure both images are clear and show only one person.");
        }

        var face = responsFace.FaceMatches[0];
        var body = responsBody.FaceMatches[0];

        if (face.Similarity < 90 || body.Similarity < 90)
        {
            throw new NotificationException("We were unable to detect a matching face. Make sure both images are clear and show only one person.");
        }

        if (responsFace.UnmatchedFaces.Count > 0)
        {
            throw new NotificationException("More than one face was detected. Please ensure only one person is in the image.");
        }

        var safety = await repoSafety.Get<SafetyModel>(userId, cancellationToken);
        if (safety == null)
        {
            safety = new SafetyModel();
            safety.SetIds(userId);
        }

        using var streamStorage = new MemoryStream(request.Stream);

        var idNewPhoto = Guid.NewGuid().ToString();
        var photoName = idNewPhoto + ".jpg";

        await storageHelper.UploadSafetyPhoto(SafetyType.Gallery, streamStorage, photoName, userId, cancellationToken);
        if (safety.GalleryPhotoId.NotEmpty()) await storageHelper.DeleteSafetyPhoto(SafetyType.Gallery, safety.GalleryPhotoId, cancellationToken);

        safety.GalleryPhotoId = photoName;
        safety.Email = request.Email;

        await repoSafety.UpsertItemAsync(safety, cancellationToken);

        var validation = await repoGen.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);
        if (validation == null)
        {
            validation = new ValidationModel();
            validation.Initialize(userId);
        }
        validation.Gallery = true;
        return await repoGen.UpsertItemAsync(validation, cancellationToken);
    }

    public class UploadPhotoValidationCommand
    {
        public byte[] Stream { get; set; } = [];
        public string? Email { get; set; }
    }
}