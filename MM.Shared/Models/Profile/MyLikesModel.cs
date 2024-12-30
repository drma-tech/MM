namespace MM.Shared.Models.Profile
{
    public class MyLikesModel : PrivateMainDocument
    {
        public MyLikesModel() : base(DocumentType.Likes)
        {
        }

        public HashSet<LikeItem> Likes { get; init; } = [];

        public override bool HasValidData()
        {
            return Likes.Count != 0;
        }

        public override bool Equals(object? obj)
        {
            return obj is MyLikesModel q && q.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }

    public class LikeItem
    {
        public LikeItem()
        {
        }

        public LikeItem(string? UserId, string? UserName, string? UserPhoto)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserPhoto = UserPhoto;
        }

        public string? UserId { get; init; }
        public string? UserName { get; set; }
        public string? UserPhoto { get; set; }
        public DateTime DateTime { get; init; } = DateTime.UtcNow;

        public override bool Equals(object? obj)
        {
            return Equals(obj as LikeItem);
        }

        private bool Equals(LikeItem? other)
        {
            if (other is null || other.UserId is null) return false;
            if (UserId is null) return false;

            return UserId.Equals(other.UserId);
        }

        public override int GetHashCode()
        {
            return UserId?.GetHashCode() ?? 0;
        }
    }
}