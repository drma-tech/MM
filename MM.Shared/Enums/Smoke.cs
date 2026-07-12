namespace MM.Shared.Enums;

public enum Smoke
{
    [FieldSettings("No", ResourceType = typeof(Translations.Enum.Smoke))]
    No = 1,

    [FieldSettings("YesOccasionally", ResourceType = typeof(Translations.Enum.Smoke))]
    YesOccasionally = 2,

    [FieldSettings("YesOften", ResourceType = typeof(Translations.Enum.Smoke))]
    YesOften = 3
}