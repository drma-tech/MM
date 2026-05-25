namespace MM.Shared.Requests
{
    public class PhotoValidationRequest
    {
        public byte[] Stream { get; set; } = [];
        public string? Email { get; set; }
    }
}