﻿using Newtonsoft.Json;

namespace MM.Shared.Models.Profile;

public class PersonModel
{
    public PersonModel()
    {
    }

    public PersonModel(ProfileModel profile, bool forceBlindDate)
    {
        UserId = profile.Id;
        UserName = profile.NickName;
        UserPhoto = forceBlindDate ? ImageHelper.GetBlindDate : profile.GetPhoto(ImageHelper.PhotoType.Face);
    }

    public string? UserId { get; init; }
    public string? UserName { get; set; }
    public string? UserPhoto { get; set; }
    public DateTime DateTime { get; init; } = DateTime.UtcNow;

    [JsonIgnore] public bool Fake { get; set; }

    public string GetUserPhoto()
    {
        if (UserPhoto.Empty())
            return ImageHelper.GetNoUserPhoto;
        return UserPhoto!;
    }

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