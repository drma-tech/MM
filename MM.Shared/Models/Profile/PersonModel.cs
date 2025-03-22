using Newtonsoft.Json;

namespace MM.Shared.Models.Profile
{
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public PersonModel(ProfileModel profile)
        {
            this.UserId = profile.Id;
            this.UserName = profile.NickName;
            this.UserPhoto = profile.GetPhoto(ImageHelper.PhotoType.Face);
        }

        public string? UserId { get; init; }
        public string? UserName { get; set; }
        public string? UserPhoto { get; set; }
        public DateTime DateTime { get; init; } = DateTime.UtcNow;

        public string GetUserPhoto()
        {
            if (UserPhoto.Empty())
                return ImageHelper.GetNoUserPhoto;
            else
                return UserPhoto!;
        }

        [JsonIgnore]
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