using MM.Shared.Models.Profile;
using MM.WEB.Api;

namespace MM.WEB.Modules.Profile.Core;

public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, ApiType.Authenticated, "profile-validation")
{
    public async Task<ValidationModel?> Get()
    {
        return await GetAsync(ProfileEndpoint.Get);
    }

    public async Task<string?> CreateVerificationSession()
    {
        return await GetValueAsync(ProfileEndpoint.CreateVerificationSession);
    }

    public async Task<ValidationModel?> UploadPhotoValidation(byte[] bytes)
    {
        return await PutAsync(StorageEndpoint.UploadPhotoValidation, new { Stream = bytes });
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-validation";
        public const string CreateVerificationSession = "didit/create-verification-session";
    }
}