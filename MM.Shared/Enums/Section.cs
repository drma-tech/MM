namespace MM.Shared.Enums;

public enum Section
{
    [FieldSettings("Basic", ResourceType = typeof(Translations.Enum.Section))]
    Basic,

    [FieldSettings("Bio", ResourceType = typeof(Translations.Enum.Section))]
    Bio,

    [FieldSettings("Lifestyle", ResourceType = typeof(Translations.Enum.Section))]
    Lifestyle,

    [FieldSettings("Personality", ResourceType = typeof(Translations.Enum.Section))]
    Personality,

    [FieldSettings("Interest", ResourceType = typeof(Translations.Enum.Section))]
    Interest,

    [FieldSettings("Relationship", ResourceType = typeof(Translations.Enum.Section))]
    Relationship,

    [FieldSettings("Goals", ResourceType = typeof(Translations.Enum.Section))]
    Goals
}