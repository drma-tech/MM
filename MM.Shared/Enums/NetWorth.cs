namespace MM.Shared.Enums
{
    public enum NetWorth
    {
        [Custom(Name = "_0K_10k", ResourceType = typeof(Resources.NetWorth))]
        _0K_10k = 1,

        [Custom(Name = "_20K_50K", ResourceType = typeof(Resources.NetWorth))]
        _20K_50K = 2,

        [Custom(Name = "_60K_100K", ResourceType = typeof(Resources.NetWorth))]
        _60K_100K = 3,

        [Custom(Name = "_200K_500K", ResourceType = typeof(Resources.NetWorth))]
        _200K_500K = 4,

        [Custom(Name = "_600K_1M", ResourceType = typeof(Resources.NetWorth))]
        _600K_1M = 5,

        [Custom(Name = "_2M_5M", ResourceType = typeof(Resources.NetWorth))]
        _2M_5M = 6,

        [Custom(Name = "_6M_10M", ResourceType = typeof(Resources.NetWorth))]
        _6M_10M = 7,

        [Custom(Name = "_20M_50M", ResourceType = typeof(Resources.NetWorth))]
        _20M_50M = 8,

        [Custom(Name = "_60M_100M", ResourceType = typeof(Resources.NetWorth))]
        _60M_100M = 9,

        [Custom(Name = "_200M", ResourceType = typeof(Resources.NetWorth))]
        _200M = 10
    }
}