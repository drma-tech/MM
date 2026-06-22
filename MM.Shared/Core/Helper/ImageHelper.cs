namespace MM.Shared.Core.Helper;

public static class ImageHelper
{
    public static string BlobPath = "https://drmammstorage.blob.core.windows.net";

    public enum PhotoType
    {
        Face = 1,
        Body = 2
    }

    public enum SafetyType
    {
        Gallery = 1,
    }

    public static string GetFacePhoto => "images/no-face-photo.webp";
    public static string GetBodyPhoto => "images/no-body-photo.webp";
    public static string GetBlindDate => "images/blind-date.webp";

    public static string GetPhotoContainer(PhotoType type)
    {
        return type switch
        {
            PhotoType.Face => "photo-face",
            PhotoType.Body => "photo-body",
            _ => throw new InvalidOperationException(nameof(PhotoType))
        };
    }

    public static string GetSafetyContainer(SafetyType type)
    {
        return type switch
        {
            SafetyType.Gallery => "safety-gallery",
            _ => throw new InvalidOperationException(nameof(SafetyType))
        };
    }
}