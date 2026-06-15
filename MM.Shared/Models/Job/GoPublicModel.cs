namespace MM.Shared.Models.Job
{
    public class GoPublicModel() : JobDocument(JobType.GoPublic)
    {
        public string? Email { get; set; }
    }
}