namespace MM.Shared.Enums;

/// <summary>
///     https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
/// </summary>
public enum Disability
{
    [FieldSettings("Physical", Description = "Physical_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Physical = 1,

    [FieldSettings("Visual", Description = "Visual_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Visual = 2,

    [FieldSettings("Hearing", Description = "Hearing_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Hearing = 3,

    [FieldSettings("MentalHealth", Description = "MentalHealth_Description", ResourceType = typeof(Translations.Enum.Disability))]
    MentalHealth = 4,

    [FieldSettings("Intellectual", Description = "Intellectual_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Intellectual = 5,

    [FieldSettings("Learning", Description = "Learning_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Learning = 6
}