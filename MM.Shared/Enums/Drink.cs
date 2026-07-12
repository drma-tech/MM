namespace MM.Shared.Enums;

public enum Drink
{
    [FieldSettings("No", Description = "No_Description", ResourceType = typeof(Translations.Enum.Drink))]
    No = 1,

    [FieldSettings("YesLight", Description = "YesLight_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesLight = 2,

    [FieldSettings("YesModerate", Description = "YesModerate_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesModerate = 3,

    [FieldSettings("YesHeavy", Description = "YesHeavy_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesHeavy = 4
}