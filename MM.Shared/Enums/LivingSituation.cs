namespace MM.Shared.Enums;

public enum LivingSituation
{
    [FieldSettings("Alone_Name", Description = "Alone_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    Alone = 1,

    [FieldSettings("WithFamily_Name", Description = "WithFamily_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithFamily = 2,

    [FieldSettings("WithFriends_Name", Description = "WithFriends_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithFriends = 3,

    [FieldSettings("WithExPartner_Name", Description = "WithExPartner_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithExPartner = 4,

    [FieldSettings("WithRoommates_Name", Description = "WithRoommates_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithRoommates = 5,

    [FieldSettings("Other_Name", Description = "Other_Description", ResourceType = typeof(Translations.Enum.LivingSituation))]
    Other = 9
}