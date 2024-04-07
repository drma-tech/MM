namespace MM.Shared.Models.Profile
{
    public class InviteModel : PrivateMainDocument
    {
        public InviteModel() : base(DocumentType.Invite)
        {
        }

        public List<Invite> Invites { get; set; } = [];

        public override bool HasValidData()
        {
            throw new NotImplementedException();
        }
    }

    public class Invite(string UserId, string UserEmail, InviteType Type)
    {
        public string UserId { get; set; } = UserId;
        public string UserEmail { get; set; } = UserEmail;
        public DateTime DtInvite { get; set; } = DateTime.UtcNow;
        public InviteType Type { get; set; } = Type;
        public bool Accepted { get; set; }
    }

    public enum InviteType
    {
        Partner = 1
    }
}