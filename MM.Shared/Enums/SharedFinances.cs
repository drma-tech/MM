namespace MM.Shared.Enums
{
    public enum SharedFinances
    {
        [Custom(Name = "Joint Accounts", Description = "Both partners share bank accounts and incomes.")]
        JointAccounts = 1,

        [Custom(Name = "Separate Accounts", Description = "Each partner maintains their own bank accounts and incomes.")]
        SeparateAccounts = 2,

        [Custom(Name = "Hybrid Approach", Description = "Some finances are shared, while others remain separate.")]
        HybridApproach = 3,
    }
}