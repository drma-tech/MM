using MM.Common.Core.Types;

namespace MM.Common.Models.Job
{
    public class GoPublicModel(string id, DateTimeOffset runAt) : JobDocument(new JobIdentity(JobType.GoPublic, id), runAt)
    {
        public string? Email { get; set; }

        protected override object?[] EqualityValues => [Id];
    }
}