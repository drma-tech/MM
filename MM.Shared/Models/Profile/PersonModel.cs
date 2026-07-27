using Newtonsoft.Json;

namespace MM.Shared.Models.Profile;

public class PersonModel : EqualityBase<PersonModel>
{
    public PersonModel()
    {
    }

    public PersonModel(ProfileModel profile, bool forceBlindDate)
    {
        UserId = profile.Id;
        UserName = profile.NickName;
        UserPhoto = forceBlindDate ? ImageHelper.GetBlindDate : profile.GetPhoto(ImageHelper.PhotoType.Face, true);
    }

    public string? UserId { get; init; }
    public string? UserName { get; set; }
    public string? UserPhoto { get; set; }
    public DateTime DateTime { get; init; } = DateTime.UtcNow;

    [JsonIgnore] public bool Fake { get; set; }

    public string GetUserPhoto()
    {
        if (UserPhoto.Empty()) return ImageHelper.GetFacePhoto;

        return UserPhoto;
    }

    protected override object?[] EqualityValues => [UserId];
}