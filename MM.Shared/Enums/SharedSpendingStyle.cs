namespace MM.Shared.Enums;

/// <summary>
///     Invented by ChatGPD
/// </summary>
public enum SharedSpendingStyle
{
    [FieldSettings(nameof(Translations.Enum.SharedSpendingStyle.Provider_Name), Description = nameof(Translations.Enum.SharedSpendingStyle.Provider_Description), ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Provider = 1,

    [FieldSettings(nameof(Translations.Enum.SharedSpendingStyle.Contributor_Name), Description = nameof(Translations.Enum.SharedSpendingStyle.Contributor_Description), ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Contributor = 2,

    [FieldSettings(nameof(Translations.Enum.SharedSpendingStyle.Balanced_Name), Description = nameof(Translations.Enum.SharedSpendingStyle.Balanced_Description), ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Balanced = 3,

    [FieldSettings(nameof(Translations.Enum.SharedSpendingStyle.Supporter_Name), Description = nameof(Translations.Enum.SharedSpendingStyle.Supporter_Description), ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Supporter = 4,

    [FieldSettings(nameof(Translations.Enum.SharedSpendingStyle.Dependent_Name), Description = nameof(Translations.Enum.SharedSpendingStyle.Dependent_Description), ResourceType = typeof(Translations.Enum.SharedSpendingStyle))]
    Dependent = 5
}