using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Api;

public struct StorageEndpoint
{
    public const string UploadPhoto = "storage/upload-photo";

    public static string DeletePhotoGallery(PhotoType photoType)
    {
        return $"storage/delete-photo/{(int)photoType}";
    }
}

public class StorageApi(IHttpClientFactory factory) : ApiCosmos<ProfileModel>(factory, ApiType.Authenticated, null, ApiContext.Default.ProfileModel)
{
    public async Task<ProfileModel?> UploadPhoto(PhotoRequest request, CancellationToken cancellationToken)
    {
        SetNewVersion("profile");
        SetNewVersion("profile-validation");
        return await PutAsync(StorageEndpoint.UploadPhoto, request, ApiContext.Default.PhotoRequest, cancellationToken);
    }

    public async Task<ProfileModel?> DeletePhotoGallery(PhotoType photoType, CancellationToken cancellationToken)
    {
        SetNewVersion("profile");
        SetNewVersion("profile-validation");
        return await DeleteAsync(StorageEndpoint.DeletePhotoGallery(photoType), cancellationToken);
    }
}