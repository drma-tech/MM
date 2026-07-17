namespace MM.Shared.Enums;

public enum EducationLevel
{
    [FieldSettings(nameof(Translations.Enum.EducationLevel.Basic_Name), Description = nameof(Translations.Enum.EducationLevel.Basic_Description), ResourceType = typeof(Translations.Enum.EducationLevel))]
    Basic = 1,

    [FieldSettings(nameof(Translations.Enum.EducationLevel.Intermediary_Name), Description = nameof(Translations.Enum.EducationLevel.Intermediary_Description), ResourceType = typeof(Translations.Enum.EducationLevel))]
    Intermediary = 2,

    [FieldSettings(nameof(Translations.Enum.EducationLevel.Advanced_Name), Description = nameof(Translations.Enum.EducationLevel.Advanced_Description), ResourceType = typeof(Translations.Enum.EducationLevel))]
    Advanced = 3
}