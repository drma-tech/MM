using MM.Shared.Models.Profile;
using MM.Shared.Requests;

namespace MM.WEB.Modules.Profile.Core;

public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, ApiType.Authenticated, "profile-validation", ApiContext.Default.ValidationModel)
{
    public async Task<ValidationModel?> Get(CancellationToken cancellationToken)
    {
        return await GetAsync(ProfileEndpoint.Get, false, null, cancellationToken);
    }

    public async Task<byte[]?> GetSafetyGalleryPhoto(CancellationToken cancellationToken)
    {
        return await GetBytesAsync(ProfileEndpoint.GetSafetyGalleryPhoto, null, cancellationToken);
    }

    public async Task<string?> CreateVerificationSession(string url, string? email, CancellationToken cancellationToken)
    {
        return await GetStringAsync(ProfileEndpoint.CreateVerificationSession(url, email), cancellationToken);
    }

    public async Task<ValidationModel?> UploadPhotoValidation(PhotoValidationRequest request, CancellationToken cancellationToken)
    {
        return await PutAsync(ProfileEndpoint.UploadPhotoValidation, request, ApiContext.Default.PhotoValidationRequest, cancellationToken);
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-validation";
        public const string GetSafetyGalleryPhoto = "safety/get-photo-gallery";
        public const string UploadPhotoValidation = "storage/upload-photo-validation";

        public static string CreateVerificationSession(string url, string? email) => $"didit/create-verification-session?url={url}&email={email}";
    }
}