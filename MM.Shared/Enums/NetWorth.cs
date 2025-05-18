namespace MM.Shared.Enums;

public enum NetWorth
{
    [Custom(Name = "_0_10K", ResourceType = typeof(Resources.NetWorth))]
    _0_10K = 1,

    [Custom(Name = "_10K_15K", ResourceType = typeof(Resources.NetWorth))]
    _10K_15K = 2,

    [Custom(Name = "_15K_22K", ResourceType = typeof(Resources.NetWorth))]
    _15K_22K = 3,

    [Custom(Name = "_22K_33K", ResourceType = typeof(Resources.NetWorth))]
    _22K_33K = 4,

    [Custom(Name = "_33K_50K", ResourceType = typeof(Resources.NetWorth))]
    _33K_50K = 5,

    [Custom(Name = "_50K_75K", ResourceType = typeof(Resources.NetWorth))]
    _50K_75K = 6,

    [Custom(Name = "_75K_113K", ResourceType = typeof(Resources.NetWorth))]
    _75K_113K = 7,

    [Custom(Name = "_113K_170K", ResourceType = typeof(Resources.NetWorth))]
    _113K_170K = 8,

    [Custom(Name = "_170K_256K", ResourceType = typeof(Resources.NetWorth))]
    _170K_256K = 9,

    [Custom(Name = "_256K_384K", ResourceType = typeof(Resources.NetWorth))]
    _256K_384K = 10,

    [Custom(Name = "_384K_576K", ResourceType = typeof(Resources.NetWorth))]
    _384K_576K = 11,

    [Custom(Name = "_576K_864K", ResourceType = typeof(Resources.NetWorth))]
    _576K_864K = 12,

    [Custom(Name = "_864K_1_3M", ResourceType = typeof(Resources.NetWorth))]
    _864K_1_3M = 13,

    [Custom(Name = "_1_3M", ResourceType = typeof(Resources.NetWorth))]
    _1_3M = 14
}