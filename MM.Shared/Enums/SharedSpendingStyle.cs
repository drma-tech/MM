namespace MM.Shared.Enums;

/// <summary>
///     Invented by ChatGPD
/// </summary>
public enum SharedSpendingStyle
{
    [FieldSettings("Provider_Name", Description = "Provider_Description", ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Provider = 1,

    [FieldSettings("Contributor_Name", Description = "Contributor_Description", ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Contributor = 2,

    [FieldSettings("Balanced_Name", Description = "Balanced_Description", ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Balanced = 3,

    [FieldSettings("Supporter_Name", Description = "Supporter_Description", ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Supporter = 4,

    [FieldSettings("Dependent_Name", Description = "Dependent_Description", ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Dependent = 5
}