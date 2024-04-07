namespace MM.Shared.Models.Profile
{
    public class ProfilePhotoModel
    {
        public string? Main { get; set; }
        public string[] Gallery { get; set; } = [];

        public string? Validation { get; set; }
        public Guid? FaceId { get; set; }
        public DateTime DtMainUpload { get; set; }

        public double Confidence { get; set; }
        public double? Age { get; set; }
        public BiologicalSex? Gender { get; set; }

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;

            Validation = null;
            FaceId = null;
            DtMainUpload = DateTime.UtcNow;

            Confidence = 0;
            Age = null;
            Gender = null;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }

        public void RemovePhotoGallery(string IdPhoto)
        {
            Gallery = Gallery.Where(w => w != IdPhoto).ToArray();
        }
    }
}