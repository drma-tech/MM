namespace MM.Shared.Enums;

public enum Religion
{
    [FieldSettings(nameof(Translations.Enum.Religion.Christianity), Description = nameof(Translations.Enum.Religion.Christianity_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Christianity = 1,

    [FieldSettings(nameof(Translations.Enum.Religion.Islam), Description = nameof(Translations.Enum.Religion.Islam_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Islam = 2,

    [FieldSettings(nameof(Translations.Enum.Religion.Hinduism), Description = nameof(Translations.Enum.Religion.Hinduism_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Hinduism = 3,

    [FieldSettings(nameof(Translations.Enum.Religion.NonReligious), Description = nameof(Translations.Enum.Religion.NonReligious_Description), ResourceType = typeof(Translations.Enum.Religion))]
    NonReligious = 4,

    [FieldSettings(nameof(Translations.Enum.Religion.Buddhism), Description = nameof(Translations.Enum.Religion.Buddhism_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Buddhism = 5,

    [FieldSettings(nameof(Translations.Enum.Religion.Sikhism), Description = nameof(Translations.Enum.Religion.Sikhism_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Sikhism = 6,

    [FieldSettings(nameof(Translations.Enum.Religion.Judaism), Description = nameof(Translations.Enum.Religion.Judaism_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Judaism = 7,

    [FieldSettings(nameof(Translations.Enum.Religion.Other), Description = nameof(Translations.Enum.Religion.Other_Description), ResourceType = typeof(Translations.Enum.Religion))]
    Other = 8
}