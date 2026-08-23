using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class ValidationApi(IHttpClientFactory http) : ApiCosmos<ValidationModel>(http, ApiType.Authenticated, "profile-validation", [], ApiContext.Default.ValidationModel)
{
    public async Task<ValidationModel?> Get(RenderControlState<ValidationModel?>[] states, CancellationToken cancellationToken)
    {
        return await GetAsync("profile/get-validation", setNewVersion: false, states, cancellationToken);
    }

    public async Task<byte[]> GetSafetyGalleryPhoto(CancellationToken cancellationToken)
    {
        return await GetBytesAsync("safety/get-photo-gallery", states: [], cancellationToken);
    }

    public async Task<string?> CreateVerificationSession(string url, string? email, CancellationToken cancellationToken)
    {
        return await GetStringAsync($"didit/create-verification-session?url={url}&email={email}", cancellationToken);
    }

    public async Task<ValidationModel?> UploadPhotoValidation(PhotoValidationRequest request, CancellationToken cancellationToken)
    {
        return await PutAsync("storage/upload-photo-validation", request, ApiContext.Default.PhotoValidationRequest, states: [], cancellationToken);
    }
}