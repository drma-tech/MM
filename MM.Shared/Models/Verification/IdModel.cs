namespace MM.Shared.Models.Verification
{
    public class IdModel : CosmosDocument
    {
        public string? session_id { get; set; }
        public string? workflow_id { get; set; }
        public string? full_name { get; set; }
        public string? gender { get; set; }
        public string? issuing_state { get; set; }
        public string? date_of_birth { get; set; }
        public object? date_of_issue { get; set; }
        public string? document_number { get; set; }
        public string? document_type { get; set; }
        public string? nationality { get; set; }
        public string? place_of_birth { get; set; }
    }
}