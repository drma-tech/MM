using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Api;

public struct StorageEndpoint
{
    public const string UploadPhoto = "storage/upload-photo";
    public const string UploadPhotoValidation = "storage/upload-photo-validation";

    public static string DeletePhotoGallery(PhotoType photoType)
    {
        return $"storage/delete-photo/{(int)photoType}";
    }
}

public class StorageApi(IHttpClientFactory factory) : ApiCosmos<ProfileModel>(factory, ApiType.Authenticated, null)
{
    public async Task<ProfileModel?> UploadPhoto(PhotoRequest request)
    {
        SetNewVersion("profile");
        SetNewVersion("profile-validation");
        return await PutAsync(StorageEndpoint.UploadPhoto, request);
    }

    public async Task<ProfileModel?> DeletePhotoGallery(PhotoType photoType)
    {
        SetNewVersion("profile");
        SetNewVersion("profile-validation");
        return await DeleteAsync(StorageEndpoint.DeletePhotoGallery(photoType));
    }
}