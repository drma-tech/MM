namespace MM.Common.Requests
{
    public class PhotoValidationRequest
    {
        public byte[] Stream { get; set; } = [];
        public string? Email { get; set; }
    }
}