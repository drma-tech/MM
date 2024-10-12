namespace MM.Shared.Enums
{
    public enum AnnualIncome
    {
        [Custom(Name = "_0K_1K", ResourceType = typeof(Resources.AnnualIncome))]
        _0K_1K = 1,

        [Custom(Name = "_2K_5K", ResourceType = typeof(Resources.AnnualIncome))]
        _2K_5K = 2,

        [Custom(Name = "_6K_10K", ResourceType = typeof(Resources.AnnualIncome))]
        _6K_10K = 3,

        [Custom(Name = "_20K_50K", ResourceType = typeof(Resources.AnnualIncome))]
        _20K_50K = 4,

        [Custom(Name = "_60K_100K", ResourceType = typeof(Resources.AnnualIncome))]
        _60K_100K = 5,

        [Custom(Name = "_200K_500K", ResourceType = typeof(Resources.AnnualIncome))]
        _200K_500K = 6,

        [Custom(Name = "_600K_1M", ResourceType = typeof(Resources.AnnualIncome))]
        _600K_1M = 7,

        [Custom(Name = "_2M_5M", ResourceType = typeof(Resources.AnnualIncome))]
        _2M_5M = 8,

        [Custom(Name = "_6M_10M", ResourceType = typeof(Resources.AnnualIncome))]
        _6M_10M = 9,

        [Custom(Name = "_20M", ResourceType = typeof(Resources.AnnualIncome))]
        _20M = 10
    }
}