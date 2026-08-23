using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using MM.WEB.Api.Core;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Api;

public class StorageApi(IHttpClientFactory factory) : ApiCosmos<ProfileModel>(factory, ApiType.Authenticated, null, ["profile", "profile-validation"], ApiContext.Default.ProfileModel)
{
    public async Task<ProfileModel?> UploadPhoto(PhotoRequest request, CancellationToken cancellationToken)
    {
        SetNewVersion();
        return await PutAsync("storage/upload-photo", request, ApiContext.Default.PhotoRequest, states: [], cancellationToken);
    }

    public async Task<ProfileModel?> DeletePhotoGallery(PhotoType photoType, CancellationToken cancellationToken)
    {
        SetNewVersion();
        return await PutAsync($"storage/delete-photo/{(int)photoType}", null, ApiContext.Default.ProfileModel, states: [], cancellationToken);
    }
}