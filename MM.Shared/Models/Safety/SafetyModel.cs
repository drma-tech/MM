namespace MM.Shared.Models.Safety
{
    public class SafetyModel : CosmosDocument
    {
        //galery validation

        public string? Email { get; set; }
        public string? GalleryPhotoId { get; set; }

        //identity validation

        public string? session_id { get; set; }
        public string? workflow_id { get; set; }
        public string? nationality { get; set; }
        public string? full_name { get; set; }
        public string? gender { get; set; }
        public string? date_of_birth { get; set; }
        public string? place_of_birth { get; set; }
        public string? IdentityPhotoId { get; set; }

        //additional info
        public string? ip_address { get; set; }
    }
}