namespace MM.Shared.Enums;

public enum LivingSituation
{
    [Custom(Name = "Alone_Name", Description = "Alone_Description", ResourceType = typeof(Resources.LivingSituation))]
    Alone = 1,

    [Custom(Name = "WithFamily_Name", Description = "WithFamily_Description", ResourceType = typeof(Resources.LivingSituation))]
    WithFamily = 2,

    [Custom(Name = "WithFriends_Name", Description = "WithFriends_Description", ResourceType = typeof(Resources.LivingSituation))]
    WithFriends = 3,

    [Custom(Name = "WithExPartner_Name", Description = "WithExPartner_Description", ResourceType = typeof(Resources.LivingSituation))]
    WithExPartner = 4,

    [Custom(Name = "WithRoommates_Name", Description = "WithRoommates_Description", ResourceType = typeof(Resources.LivingSituation))]
    WithRoommates = 5,

    [Custom(Name = "Other_Name", Description = "Other_Description", ResourceType = typeof(Resources.LivingSituation))]
    Other = 9
}