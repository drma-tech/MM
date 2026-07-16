namespace MM.Shared.Enums;

public enum Drink
{
    [FieldSettings("No_Name", Description = "No_Description", ResourceType = typeof(Translations.Enum.Drink))]
    No = 1,

    [FieldSettings("YesLight_Name", Description = "YesLight_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesLight = 2,

    [FieldSettings("YesModerate_Name", Description = "YesModerate_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesModerate = 3,

    [FieldSettings("YesHeavy_Name", Description = "YesHeavy_Description", ResourceType = typeof(Translations.Enum.Drink))]
    YesHeavy = 4
}