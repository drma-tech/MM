using System.ComponentModel.DataAnnotations.Schema;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Models.Profile
{
    public class ProfileGalleryModel
    {
        public string? FaceId { get; set; }
        public string? BodyId { get; set; }

        [NotMapped]
        public bool BlindDate { get; set; } = false;

        public string? GetPictureId(PhotoType type)
        {
            return type switch
            {
                PhotoType.Face => FaceId,
                PhotoType.Body => BodyId,
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
        }

        /// <summary>
        /// note: cannot update profile after calling this method
        /// </summary>
        public void BlindDateMode()
        {
            FaceId = null;
            BodyId = null;
            BlindDate = true;
        }
    }
}