namespace MM.Shared.Enums;

public enum Religion
{
    [FieldSettings("Christianity", Description = "Christianity_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Christianity = 1,

    [FieldSettings("Islam", Description = "Islam_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Islam = 2,

    [FieldSettings("Hinduism", Description = "Hinduism_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Hinduism = 3,

    [FieldSettings("NonReligious", Description = "NonReligious_Description", ResourceType = typeof(Translations.Enum.Religion))]
    NonReligious = 4,

    [FieldSettings("Buddhism", Description = "Buddhism_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Buddhism = 5,

    [FieldSettings("Sikhism", Description = "Sikhism_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Sikhism = 6,

    [FieldSettings("Judaism", Description = "Judaism_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Judaism = 7,

    [FieldSettings("Other", Description = "Other_Description", ResourceType = typeof(Translations.Enum.Religion))]
    Other = 8
}