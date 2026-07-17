namespace MM.Shared.Enums;

public enum Smoke
{
    [FieldSettings(nameof(Translations.Enum.Smoke.No), ResourceType = typeof(Translations.Enum.Smoke))]
    No = 1,

    [FieldSettings(nameof(Translations.Enum.Smoke.YesOccasionally), ResourceType = typeof(Translations.Enum.Smoke))]
    YesOccasionally = 2,

    [FieldSettings(nameof(Translations.Enum.Smoke.YesOften), ResourceType = typeof(Translations.Enum.Smoke))]
    YesOften = 3
}