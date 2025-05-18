namespace MM.Shared.Enums;

public enum AccountCycle
{
    [Custom(Name = "Monthly", Description = "Month", ResourceType = typeof(Shared.Resources.Enum.AccountCycle))]
    Monthly = 1,

    [Custom(Name = "Yearly", Description = "Year", ResourceType = typeof(Shared.Resources.Enum.AccountCycle))]
    Yearly = 2
}
