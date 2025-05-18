namespace MM.Shared.Enums;

public enum WantChildren
{
    [Custom(Name = "No", ResourceType = typeof(Resources.WantChildren))]
    No = 1,

    [Custom(Name = "Maybe", ResourceType = typeof(Resources.WantChildren))]
    Maybe = 2,

    [Custom(Name = "Yes", ResourceType = typeof(Resources.WantChildren))]
    Yes = 3
}