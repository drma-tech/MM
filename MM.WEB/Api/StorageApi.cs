using MM.Shared.Models.Profile;
using MM.Shared.Requests;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.WEB.Api;

public struct StorageEndpoint
{
    public const string UploadPhoto = "storage/upload-photo";
    public const string UploadPhotoValidation = "storage/UploadPhotoValidation";

    public static string DeletePhotoGallery(PhotoType photoType)
    {
        return $"storage/delete-photo/{(int)photoType}";
    }
}

public class StorageApi(IHttpClientFactory factory) : ApiCosmos<ProfileModel>(factory, null)
{
    public async Task<ProfileModel?> UploadPhoto(PhotoRequest request)
    {
        SetNewVersion("profile");
        return await PutAsync(StorageEndpoint.UploadPhoto, null, request);
    }

    public async Task<ProfileModel?> DeletePhotoGallery(PhotoType photoType)
    {
        SetNewVersion("profile");
        return await DeleteAsync(StorageEndpoint.DeletePhotoGallery(photoType), null);
    }

    //public async Task Storage_UploadPhotoValidation(this HttpClient http, byte[] bytes, ISyncSessionStorageService storage, INotificationService toast)
    //{
    //    var response = await http.Put(StorageEndpoint.UploadPhotoValidation, new { Stream = bytes });

    //    if (response.IsSuccessStatusCode)
    //    {
    //        storage.RemoveItem(ProfileEndpoint.Get);
    //        await http.Profile_Get(storage); //TODO ??
    //    }

    //    await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
    //}
}