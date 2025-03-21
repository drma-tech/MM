using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Models.Profile
{
    public class ProfileGalleryModel
    {
        public string? FaceId { get; set; }
        public string? BodyId { get; set; }
        public string? ValidationId { get; set; }

        public string? GetPictureId(PhotoType type)
        {
            return type switch
            {
                PhotoType.Face => FaceId,
                PhotoType.Body => BodyId,
                PhotoType.Validation => ValidationId,
                _ => throw new InvalidOperationException(nameof(PhotoType)),
            };
        }

        public void UpdatePictureId(PhotoType type, string? pictureId)
        {
            if (type == PhotoType.Face)
            {
                FaceId = pictureId;
            }
            else if (type == PhotoType.Body)
            {
                BodyId = pictureId;
            }
            else if (type == PhotoType.Validation)
            {
                ValidationId = pictureId;
            }
        }
    }
}