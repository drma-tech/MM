namespace MM.Shared.Enums;

public enum Region
{
    [FieldSettings(nameof(Translations.Enum.Region.City), ResourceType = typeof(Translations.Enum.Region))]
    City = 1,

    [FieldSettings(nameof(Translations.Enum.Region.State), ResourceType = typeof(Translations.Enum.Region))]
    State = 2,

    [FieldSettings(nameof(Translations.Enum.Region.Country), ResourceType = typeof(Translations.Enum.Region))]
    Country = 3,

    [FieldSettings(nameof(Translations.Enum.Region.World), ResourceType = typeof(Translations.Enum.Region))]
    World = 4
}