namespace MM.Shared.Enums;

public enum EducationLevel
{
    [FieldSettings("Basic", Description = "Basic_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Basic = 1,

    [FieldSettings("Intermediary", Description = "Intermediary_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Intermediary = 2,

    [FieldSettings("Advanced", Description = "Advanced_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Advanced = 3
}