using Microsoft.Extensions.Caching.Memory;
using MM.Shared.Models.Profile;
using MM.Shared.Requests;

namespace MM.WEB.Api
{
    public struct StorageEndpoint
    {
        public const string UploadPhotoFace = "storage/upload-photo-face";
        public const string UploadPhotoGallery = "storage/UploadPhotoGallery";
        public const string UploadPhotoValidation = "storage/UploadPhotoValidation";

        public static string DeletePhotoGallery(string IdPhoto) => $"storage/DeletePhotoGallery?IdPhoto={IdPhoto}";
    }

    public class StorageApi(IHttpClientFactory factory, IMemoryCache memoryCache) : ApiCosmos<ProfilePhotoModel>(factory, memoryCache, "ProfilePhotoModel")
    {
        public async Task<ProfilePhotoModel?> UploadPhotoFace(PhotoRequest request)
        {
            return await PutAsync(StorageEndpoint.UploadPhotoFace, null, request);
        }

        //public static async Task Storage_UploadPhotoGallery(this HttpClient http, List<byte[]> Streams, ISyncSessionStorageService storage, INotificationService toast)
        //{
        //    var response = await http.Put(StorageEndpoint.UploadPhotoGallery, new { Streams });

        //    if (response.IsSuccessStatusCode)
        //    {
        //        storage.RemoveItem(ProfileEndpoint.Get);
        //        await http.Profile_Get(storage); //TODO ??
        //    }

        //    await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        //}

        //public static async Task Storage_DeletePhotoGallery(this HttpClient http, string IdPhoto, ISyncSessionStorageService storage, INotificationService toast)
        //{
        //    var response = await http.Delete(StorageEndpoint.DeletePhotoGallery(IdPhoto));

        //    if (response.IsSuccessStatusCode)
        //    {
        //        storage.RemoveItem(ProfileEndpoint.Get);
        //        await http.Profile_Get(storage); //TODO ??
        //    }

        //    await response.ProcessResponse(toast, "Foto atualizada com sucesso!");
        //}

        //public static async Task Storage_UploadPhotoValidation(this HttpClient http, byte[] bytes, ISyncSessionStorageService storage, INotificationService toast)
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
}