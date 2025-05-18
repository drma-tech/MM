using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Models.Profile;

public class ProfileGalleryModel
{
    public GalleryType Type { get; set; } = GalleryType.NoPictures;
    public string? FaceId { get; set; }
    public string? BodyId { get; set; }

    public string? GetPictureId(PhotoType type)
    {
        return type switch
        {
            PhotoType.Face => FaceId,
            PhotoType.Body => BodyId,
            _ => throw new InvalidOperationException(nameof(PhotoType))
        };
    }

    public void UpdatePictureId(PhotoType type, string? pictureId)
    {
        if (type == PhotoType.Face)
            FaceId = pictureId;
        else if (type == PhotoType.Body) BodyId = pictureId;

        if (FaceId == null && BodyId == null)
            Type = GalleryType.NoPictures;
        else
            Type = GalleryType.Picures;
    }

    /// <summary>
    ///     note: cannot update profile after calling this method
    /// </summary>
    public void SimulateBlindDate()
    {
        Type = GalleryType.BlindDate;
        FaceId = null;
        BodyId = null;
    }
}