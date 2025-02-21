namespace MM.Shared.Enums
{
    public enum SharedFinances
    {
        [Custom(Name = "JointAccounts", Description = "JointAccounts_Description", ResourceType = typeof(Resources.SharedFinances))]
        JointAccounts = 1,

        [Custom(Name = "SeparateAccounts", Description = "SeparateAccounts_Description", ResourceType = typeof(Resources.SharedFinances))]
        SeparateAccounts = 2,

        [Custom(Name = "HybridApproach", Description = "HybridApproach_Description", ResourceType = typeof(Resources.SharedFinances))]
        HybridApproach = 3,
    }
}