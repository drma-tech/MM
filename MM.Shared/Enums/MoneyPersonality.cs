namespace MM.Shared.Enums;

/// <summary>
///     https://moneytype.hermoney.com/
/// </summary>
public enum MoneyPersonality
{
    [Custom(Name = "Visionary_Name", Description = "Visionary_Description", ResourceType = typeof(Resources.MoneyPersonality))]
    Visionary = 1,

    [Custom(Name = "Nurturer_Name", Description = "Nurturer_Description", ResourceType = typeof(Resources.MoneyPersonality))]
    Nurturer = 2,

    [Custom(Name = "Independent_Name", Description = "Independent_Description", ResourceType = typeof(Resources.MoneyPersonality))]
    Independent = 3,

    [Custom(Name = "Connoisseur_Name", Description = "Connoisseur_Description", ResourceType = typeof(Resources.MoneyPersonality))]
    Connoisseur = 4,

    [Custom(Name = "Producer_Name", Description = "Producer_Description", ResourceType = typeof(Resources.MoneyPersonality))]
    Producer = 5
}