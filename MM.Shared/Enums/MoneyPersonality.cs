namespace MM.Shared.Enums
{
    /// <summary>
    /// https://empower.me/quiz/
    /// </summary>
    public enum MoneyPersonality
    {
        [Custom(Name = "Idealist_Name", Description = "Idealist_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Idealist = 1,

        [Custom(Name = "Stockpiler_Name", Description = "Stockpiler_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Stockpiler = 2,

        [Custom(Name = "Hedonist_Name", Description = "Hedonist_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Hedonist = 3,

        [Custom(Name = "Celebrity_Name", Description = "Celebrity_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Celebrity = 4,

        [Custom(Name = "Nurturer_Name", Description = "Nurturer_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Nurturer = 5,

        [Custom(Name = "Conqueror_Name", Description = "Conqueror_Description", ResourceType = typeof(Resources.MoneyPersonality))]
        Conqueror = 6
    }
}