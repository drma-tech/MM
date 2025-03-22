namespace MM.Shared.Core.Helper
{
    public static class ImageHelper
    {
        public enum PhotoType
        {
            Face = 1,
            Body = 2,
            Validation = 9
        }

        public static string GetNoUserPhoto => "images/no-picture.png";
        public static string GetBlindDate => "images/blind-date.png";

        public static string GetPhotoContainer(PhotoType type)
        {
            return type switch
            {
                PhotoType.Face => "photo-face",
                PhotoType.Body => "photo-body",
                PhotoType.Validation => "photo-validation",
                _ => throw new InvalidOperationException(nameof(PhotoType)),
            };
        }
    }
}