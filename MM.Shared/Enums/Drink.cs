namespace MM.Shared.Enums;

public enum Drink
{
    [Custom(Name = "No_Name", Description = "No_Description", ResourceType = typeof(Resources.Drink))]
    No = 1,

    [Custom(Name = "YesLight_Name", Description = "YesLight_Description", ResourceType = typeof(Resources.Drink))]
    YesLight = 2,

    [Custom(Name = "YesModerate_Name", Description = "YesModerate_Description", ResourceType = typeof(Resources.Drink))]
    YesModerate = 3,

    [Custom(Name = "YesHeavy_Name", Description = "YesHeavy_Description", ResourceType = typeof(Resources.Drink))]
    YesHeavy = 4
}