namespace MM.Shared.Core.Models
{
    public enum DocumentType
    {
        Principal = 1,
        Ticket = 2,
        TicketVote = 3,
        Profile = 4,
        Invite = 5,
        Announcement = 6,
        Login = 7,
        Update = 8
    }

    public abstract class MainDocument : CosmosDocument
    {
        protected MainDocument(DocumentType type)
        {
            Type = type;
        }

        protected MainDocument(string id, string key, DocumentType type) : base($"{type}:{id}", key)
        {
            Type = type;
        }

        public DocumentType Type { get; set; }
    }

    /// <summary>
    /// Public read and private write
    /// </summary>
    public abstract class ProtectedMainDocument : MainDocument
    {
        private readonly DocumentType type;

        protected ProtectedMainDocument(DocumentType type) : base(type)
        {
            this.type = type;
        }

        protected ProtectedMainDocument(string id, string key, DocumentType type) : base($"{type}:{id}", key, type)
        {
            this.type = type;
        }

        public virtual void Initialize(string id, string key)
        {
            SetIds($"{type}:{id}", key);
        }
    }

    /// <summary>
    /// Private read and write
    /// </summary>
    public abstract class PrivateMainDocument : MainDocument
    {
        private readonly DocumentType type;

        protected PrivateMainDocument(DocumentType type) : base(type)
        {
            this.type = type;
        }

        public virtual void Initialize(string userId)
        {
            SetIds($"{type}:{userId}", userId);
        }
    }
}