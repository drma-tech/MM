using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core;

public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, ApiType.Authenticated, "profile-validation")
{
    public async Task<ValidationModel?> Get(bool isUserAuthenticated)
    {
        if (!isUserAuthenticated) return null;

        return await GetAsync(ProfileEndpoint.Get);
    }

    public async Task<byte[]?> GetSafetyGalleryPhoto(bool isUserAuthenticated)
    {
        if (!isUserAuthenticated) return null;

        return await GetBytesAsync(ProfileEndpoint.GetSafetyGalleryPhoto);
    }

    public async Task<string?> CreateVerificationSession(string url, string? email)
    {
        return await GetStringAsync(ProfileEndpoint.CreateVerificationSession(url, email));
    }

    public async Task<ValidationModel?> UploadPhotoValidation(byte[] bytes, string? email)
    {
        return await PutAsync(ProfileEndpoint.UploadPhotoValidation, new { Stream = bytes, Email = email });
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-validation";
        public const string GetSafetyGalleryPhoto = "safety/get-photo-gallery";
        public const string UploadPhotoValidation = "storage/upload-photo-validation";

        public static string CreateVerificationSession(string url, string? email) => $"didit/create-verification-session?url={url}&email={email}";
    }
}