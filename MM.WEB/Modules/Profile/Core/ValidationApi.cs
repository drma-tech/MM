using MM.Shared.Models.Profile;
using MM.WEB.Api;
using MM.WEB.Shared;

namespace MM.WEB.Modules.Profile.Core;

public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, "profile-validation")
{
    public async Task<ValidationModel?> Get(RenderControlCore<ValidationModel?>? core)
    {
        return await GetAsync(ProfileEndpoint.Get, core);
    }

    public async Task<ValidationModel?> UploadPhotoValidation(RenderControlCore<ValidationModel?>? core, byte[] bytes)
    {
        return await PutAsync(StorageEndpoint.UploadPhotoValidation, core, new { Stream = bytes });
    }

    public struct ProfileEndpoint
    {
        public const string Get = "profile/get-validation";
    }
}