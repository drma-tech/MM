namespace MM.Shared.Enums;

public enum LivingSituation
{
    [FieldSettings(nameof(Translations.Enum.LivingSituation.Alone_Name), Description = nameof(Translations.Enum.LivingSituation.Alone_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    Alone = 1,

    [FieldSettings(nameof(Translations.Enum.LivingSituation.WithFamily_Name), Description = nameof(Translations.Enum.LivingSituation.WithFamily_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithFamily = 2,

    [FieldSettings(nameof(Translations.Enum.LivingSituation.WithFriends_Name), Description = nameof(Translations.Enum.LivingSituation.WithFriends_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithFriends = 3,

    [FieldSettings(nameof(Translations.Enum.LivingSituation.WithExPartner_Name), Description = nameof(Translations.Enum.LivingSituation.WithExPartner_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithExPartner = 4,

    [FieldSettings(nameof(Translations.Enum.LivingSituation.WithRoommates_Name), Description = nameof(Translations.Enum.LivingSituation.WithRoommates_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    WithRoommates = 5,

    [FieldSettings(nameof(Translations.Enum.LivingSituation.Other_Name), Description = nameof(Translations.Enum.LivingSituation.Other_Description), ResourceType = typeof(Translations.Enum.LivingSituation))]
    Other = 9
}