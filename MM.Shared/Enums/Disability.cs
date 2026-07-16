namespace MM.Shared.Enums;

/// <summary>
///     https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
/// </summary>
public enum Disability
{
    [FieldSettings("Physical_Name", Description = "Physical_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Physical = 1,

    [FieldSettings("Visual_Name", Description = "Visual_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Visual = 2,

    [FieldSettings("Hearing_Name", Description = "Hearing_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Hearing = 3,

    [FieldSettings("MentalHealth_Name", Description = "MentalHealth_Description", ResourceType = typeof(Translations.Enum.Disability))]
    MentalHealth = 4,

    [FieldSettings("Intellectual_Name", Description = "Intellectual_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Intellectual = 5,

    [FieldSettings("Learning_Name", Description = "Learning_Description", ResourceType = typeof(Translations.Enum.Disability))]
    Learning = 6
}