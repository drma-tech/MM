using MM.Shared.Core.Types;

namespace MM.Shared.Models.Job
{
    public class GoPublicModel(string id, DateTimeOffset runAt) : JobDocument(new JobIdentity(JobType.GoPublic, id), runAt)
    {
        public string? Email { get; set; }

        protected override object?[] EqualityValues => [Id];
    }
}