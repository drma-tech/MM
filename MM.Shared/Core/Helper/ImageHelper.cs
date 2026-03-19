namespace MM.Shared.Core.Helper;

public static class ImageHelper
{
    public enum PhotoType
    {
        Face = 1,
        Body = 2
    }

    public enum SafetyType
    {
        Gallery = 1,
        id = 2
    }

    public static string GetFacePhoto => "images/no-face-photo.png";
    public static string GetBodyPhoto => "images/no-body-photo.png";
    public static string GetBlindDate => "images/blind-date.png";

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
            SafetyType.id => "safety-id",
            _ => throw new InvalidOperationException(nameof(SafetyType))
        };
    }
}