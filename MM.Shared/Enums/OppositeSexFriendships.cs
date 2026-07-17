namespace MM.Shared.Enums;

public enum OppositeSexFriendships
{
    [FieldSettings(nameof(Translations.Enum.OppositeSexFriendships.Comfortable), Description = nameof(Translations.Enum.OppositeSexFriendships.Comfortable_Description), ResourceType = typeof(Translations.Enum.OppositeSexFriendships))]
    Comfortable = 1,

    [FieldSettings(nameof(Translations.Enum.OppositeSexFriendships.BoundariesNeeded), Description = nameof(Translations.Enum.OppositeSexFriendships.BoundariesNeeded_Description), ResourceType = typeof(Translations.Enum.OppositeSexFriendships))]
    BoundariesNeeded = 2,

    [FieldSettings(nameof(Translations.Enum.OppositeSexFriendships.Uncomfortable), Description = nameof(Translations.Enum.OppositeSexFriendships.Uncomfortable_Description), ResourceType = typeof(Translations.Enum.OppositeSexFriendships))]
    Uncomfortable = 3
}