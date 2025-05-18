namespace MM.Shared.Enums;

public enum HaveChildren
{
    [Custom(Name = "No", ResourceType = typeof(Resources.HaveChildren))]
    No = 1,

    [Custom(Name = "YesNo", ResourceType = typeof(Resources.HaveChildren))]
    YesNo = 2,

    [Custom(Name = "Yes", ResourceType = typeof(Resources.HaveChildren))]
    Yes = 3
}