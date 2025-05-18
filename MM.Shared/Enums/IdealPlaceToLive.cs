namespace MM.Shared.Enums;

public enum IdealPlaceToLive
{
    [Custom(Name = "Urban", Description = "Urban_Description", ResourceType = typeof(Resources.IdealPlaceToLive))]
    Urban = 1,

    [Custom(Name = "Suburban", Description = "Suburban_Description", ResourceType = typeof(Resources.IdealPlaceToLive))]
    Suburban = 2,

    [Custom(Name = "Rural", Description = "Rural_Description", ResourceType = typeof(Resources.IdealPlaceToLive))]
    Rural = 3,

    [Custom(Name = "Flexible", Description = "Flexible_Description", ResourceType = typeof(Resources.IdealPlaceToLive))]
    Flexible = 4
}