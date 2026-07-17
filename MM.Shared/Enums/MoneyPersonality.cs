namespace MM.Shared.Enums;

/// <summary>
///     https://moneytype.hermoney.com/
/// </summary>
public enum MoneyPersonality
{
    [FieldSettings(nameof(Translations.Enum.MoneyPersonality.Visionary_Name), Description = nameof(Translations.Enum.MoneyPersonality.Visionary_Description), ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Visionary = 1,

    [FieldSettings(nameof(Translations.Enum.MoneyPersonality.Nurturer_Name), Description = nameof(Translations.Enum.MoneyPersonality.Nurturer_Description), ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Nurturer = 2,

    [FieldSettings(nameof(Translations.Enum.MoneyPersonality.Independent_Name), Description = nameof(Translations.Enum.MoneyPersonality.Independent_Description), ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Independent = 3,

    [FieldSettings(nameof(Translations.Enum.MoneyPersonality.Connoisseur_Name), Description = nameof(Translations.Enum.MoneyPersonality.Connoisseur_Description), ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Connoisseur = 4,

    [FieldSettings(nameof(Translations.Enum.MoneyPersonality.Producer_Name), Description = nameof(Translations.Enum.MoneyPersonality.Producer_Description), ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Producer = 5
}