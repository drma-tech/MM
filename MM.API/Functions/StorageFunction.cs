using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.AI;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.API.Functions;

public class StorageFunction(CosmosRepository repoGen, CosmosProfileOffRepository repo, StorageHelper storageHelper, IHttpClientFactory factory)
{
    [Function("StorageUploadPhoto")]
    public async Task<ProfileModel> StorageUploadPhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "storage/upload-photo")]
        HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(factory, cancellationToken) ?? throw new NotificationException("Invalid user");
            var request = await req.GetPublicBody<PhotoRequest>(cancellationToken);

            var profile = await repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");
            var currentPictureId = profile.Gallery?.GetPictureId(request.PhotoType);

            using var stream1 = new MemoryStream(request.Buffer);

            profile.Gallery ??= new ProfileGalleryModel();

            var photoId = Guid.NewGuid() + ".jpg";

            profile.Gallery.UpdatePictureId(request.PhotoType, photoId); //reset current photo data

            //await faceHelper.DetectFace(profile, stream1, true, cancellationToken); //validates the photo sent and saves data related to it
            var analysis = await AzureImageAI.AnalyzeImage(stream1, cancellationToken);

            if (analysis.Adult.RacyScore > 0.8 || analysis.Adult.GoreScore > 0.8 || analysis.Adult.AdultScore > 0.8)
                throw new NotificationException("Image content is inappropriate. Please use another one.");

            var faceObjects = analysis.Faces;
            if (faceObjects.Count == 0)
                throw new NotificationException("We cannot clearly identify a face in this photo. Please use another one.");

            if (request.PhotoType == PhotoType.Face && faceObjects.Count > 1)
                throw new NotificationException("Your main photo should only feature you.");

            var personObjects = analysis.Objects.Where(a => a.ObjectProperty == "person" && a.Confidence > 0.85);
            if (request.PhotoType == PhotoType.Body)
            {
                if (!personObjects.Any())
                    throw new NotificationException("We were unable to detect a body in this photo. Please choose a photo that best shows your body.");

                if (personObjects.Count() > 1)
                    throw new NotificationException("We detected more than one person in this photo. Please choose a photo where you are alone.");

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
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("StorageDeletePhoto")]
    public async Task<ProfileModel> StorageDeletePhoto(
        [HttpTrigger(AuthorizationLevel.Function, Method.Delete, Route = "storage/delete-photo/{photoType}")]
        HttpRequestData req, PhotoType photoType, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(factory, cancellationToken) ?? throw new NotificationException("Invalid user");

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
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("StorageUploadPhotoValidation")]
    public async Task<ValidationModel> UploadPhotoValidation(
       [HttpTrigger(AuthorizationLevel.Function, Method.Put, Route = "storage/upload-photo-validation")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var userId = await req.GetUserIdAsync(factory, cancellationToken) ?? throw new NotificationException("Invalid user");
            var request = await req.GetPublicBody<UploadPhotoValidationCommand>(cancellationToken);

            var profile = await repo.Get<ProfileModel>(userId, cancellationToken) ?? throw new NotificationException("Profile not found");
            if (profile == null || string.IsNullOrEmpty(profile.Gallery?.FaceId)) throw new NotificationException("Validation photo not found. Please insert your face photo first.");

            using var faceStream = await GetImageStreamFromUrlAsync(profile.GetPhoto(PhotoType.Face), cancellationToken);
            using var streamValidation = new MemoryStream(request.Stream);
            var response = await AwsFaceAI.CompareFaces(faceStream, streamValidation, cancellationToken);

            if (response.FaceMatches.Count == 0)
            {
                throw new NotificationException("We were unable to detect a matching face. Make sure both images are clear and show only one person.");
            }

            var face = response.FaceMatches[0];

            if (face.Similarity < 95)
            {
                //throw new NotificationException($"Face match similarity too low: {face.Similarity:F2}%. Must be at least 95%.");
                throw new NotificationException("We were unable to detect a matching face. Make sure both images are clear and show only one person.");
            }

            if (response.UnmatchedFaces.Count > 0)
            {
                throw new NotificationException("More than one face was detected. Please ensure only one person is in the image.");
            }

            using var streamStorage = new MemoryStream(request.Stream);

            var idNewPhoto = Guid.NewGuid().ToString();
            var photoName = idNewPhoto + ".jpg";

            await storageHelper.UploadPhoto(PhotoType.Validation, streamStorage, photoName, userId, cancellationToken);
            if (profile.Gallery.ValidationId.NotEmpty()) await storageHelper.DeletePhoto(PhotoType.Validation, profile.Gallery.ValidationId, cancellationToken);

            profile.Gallery.ValidationId = photoName;

            await repo.UpsertItemAsync(profile, cancellationToken);

            var validation = await repoGen.Get<ValidationModel>(DocumentType.Validation, userId, cancellationToken);
            if (validation == null)
            {
                validation = new ValidationModel();
                validation.Initialize(userId);
            }
            validation.Gallery = true;
            return await repoGen.UpsertItemAsync(validation, cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    public class UploadPhotoValidationCommand
    {
        public byte[] Stream { get; set; } = [];
    }

    public static async Task<MemoryStream> GetImageStreamFromUrlAsync(string url, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var imageBytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return new MemoryStream(imageBytes);
    }
}