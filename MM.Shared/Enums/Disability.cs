namespace MM.Shared.Enums;

/// <summary>
///     https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
/// </summary>
public enum Disability
{
    [FieldSettings(nameof(Translations.Enum.Disability.Physical_Name), Description = nameof(Translations.Enum.Disability.Physical_Description), ResourceType = typeof(Translations.Enum.Disability))]
    Physical = 1,

    [FieldSettings(nameof(Translations.Enum.Disability.Visual_Name), Description = nameof(Translations.Enum.Disability.Visual_Description), ResourceType = typeof(Translations.Enum.Disability))]
    Visual = 2,

    [FieldSettings(nameof(Translations.Enum.Disability.Hearing_Name), Description = nameof(Translations.Enum.Disability.Hearing_Description), ResourceType = typeof(Translations.Enum.Disability))]
    Hearing = 3,

    [FieldSettings(nameof(Translations.Enum.Disability.MentalHealth_Name), Description = nameof(Translations.Enum.Disability.MentalHealth_Description), ResourceType = typeof(Translations.Enum.Disability))]
    MentalHealth = 4,

    [FieldSettings(nameof(Translations.Enum.Disability.Intellectual_Name), Description = nameof(Translations.Enum.Disability.Intellectual_Description), ResourceType = typeof(Translations.Enum.Disability))]
    Intellectual = 5,

    [FieldSettings(nameof(Translations.Enum.Disability.Learning_Name), Description = nameof(Translations.Enum.Disability.Learning_Description), ResourceType = typeof(Translations.Enum.Disability))]
    Learning = 6
}