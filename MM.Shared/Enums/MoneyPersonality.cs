namespace MM.Shared.Enums;

/// <summary>
///     https://moneytype.hermoney.com/
/// </summary>
public enum MoneyPersonality
{
    [FieldSettings("Visionary_Name", Description = "Visionary_Description", ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Visionary = 1,

    [FieldSettings("Nurturer_Name", Description = "Nurturer_Description", ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Nurturer = 2,

    [FieldSettings("Independent_Name", Description = "Independent_Description", ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Independent = 3,

    [FieldSettings("Connoisseur_Name", Description = "Connoisseur_Description", ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Connoisseur = 4,

    [FieldSettings("Producer_Name", Description = "Producer_Description", ResourceType = typeof(Translations.Enum.MoneyPersonality))]
    Producer = 5
}