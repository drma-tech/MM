namespace MM.Shared.Models.Profile
{
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public PersonModel(string? UserId, string? UserName, string? UserPhoto)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.UserPhoto = UserPhoto;
        }

        public string? UserId { get; init; }
        public string? UserName { get; set; }
        public string? UserPhoto { get; set; }
        public DateTime DateTime { get; init; } = DateTime.UtcNow;
        public bool Fake { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PersonModel);
        }

        private bool Equals(PersonModel? other)
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