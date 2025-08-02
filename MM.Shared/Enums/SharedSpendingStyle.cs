namespace MM.Shared.Enums;

/// <summary>
///     Invented by ChatGPD
/// </summary>
public enum SharedSpendingStyle
{
    [Custom(Name = "Provider_Name", Description = "Provider_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
    Provider = 1,

    [Custom(Name = "Contributor_Name", Description = "Contributor_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
    Contributor = 2,

    [Custom(Name = "Balanced_Name", Description = "Balanced_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
    Balanced = 3,

    [Custom(Name = "Supporter_Name", Description = "Supporter_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
    Supporter = 4,

    [Custom(Name = "Dependent_Name", Description = "Dependent_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
    Dependent = 5
}