namespace MM.Shared.Enums;

public enum EducationLevel
{
    [FieldSettings("Basic_Name", Description = "Basic_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Basic = 1,

    [FieldSettings("Intermediary_Name", Description = "Intermediary_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Intermediary = 2,

    [FieldSettings("Advanced_Name", Description = "Advanced_Description", ResourceType = typeof(Translations.Enum.EducationLevel))]
    Advanced = 3
}