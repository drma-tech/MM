namespace MM.Shared.Enums;

public enum Section
{
    [FieldSettings(nameof(Translations.Enum.Section.Basic), ResourceType = typeof(Translations.Enum.Section))]
    Basic,

    [FieldSettings(nameof(Translations.Enum.Section.Bio), ResourceType = typeof(Translations.Enum.Section))]
    Bio,

    [FieldSettings(nameof(Translations.Enum.Section.Lifestyle), ResourceType = typeof(Translations.Enum.Section))]
    Lifestyle,

    [FieldSettings(nameof(Translations.Enum.Section.Personality), ResourceType = typeof(Translations.Enum.Section))]
    Personality,

    [FieldSettings(nameof(Translations.Enum.Section.Interest), ResourceType = typeof(Translations.Enum.Section))]
    Interest,

    [FieldSettings(nameof(Translations.Enum.Section.Relationship), ResourceType = typeof(Translations.Enum.Section))]
    Relationship,

    [FieldSettings(nameof(Translations.Enum.Section.Goals), ResourceType = typeof(Translations.Enum.Section))]
    Goals
}