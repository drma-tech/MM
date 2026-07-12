namespace MM.Shared.Enums;

public enum Region
{
    [FieldSettings("City", ResourceType = typeof(Translations.Enum.Region))]
    City = 1,

    [FieldSettings("State", ResourceType = typeof(Translations.Enum.Region))]
    State = 2,

    [FieldSettings("Country", ResourceType = typeof(Translations.Enum.Region))]
    Country = 3,

    [FieldSettings("World", ResourceType = typeof(Translations.Enum.Region))]
    World = 4
}