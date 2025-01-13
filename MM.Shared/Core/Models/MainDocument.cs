namespace MM.Shared.Core.Models
{
    public enum DocumentType
    {
        Principal = 1,
        Ticket = 2,
        TicketVote = 3,
        Announcement = 4,
        Login = 5,
        Update = 6,
        Filter = 7,
        Setting = 8,
        Suggestions = 9,
        Likes = 10,
        Matches = 11,
        Interaction = 12
    }

    public abstract class MainDocument : CosmosDocument
    {
        protected MainDocument(DocumentType type)
        {
            Type = type;
        }

        protected MainDocument(string id, DocumentType type) : base($"{type}:{id}")
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

        protected ProtectedMainDocument(string id, DocumentType type) : base($"{type}:{id}", type)
        {
            this.type = type;
        }

        public virtual void Initialize(string id)
        {
            SetIds($"{type}:{id}");
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

        public virtual void Initialize(string? userId)
        {
            SetIds($"{type}:{userId}");
        }
    }
}