namespace MM.Shared.Enums;

public enum Drink
{
    [FieldSettings(nameof(Translations.Enum.Drink.No_Name), Description = nameof(Translations.Enum.Drink.No_Description), ResourceType = typeof(Translations.Enum.Drink))]
    No = 1,

    [FieldSettings(nameof(Translations.Enum.Drink.YesLight_Name), Description = nameof(Translations.Enum.Drink.YesLight_Description), ResourceType = typeof(Translations.Enum.Drink))]
    YesLight = 2,

    [FieldSettings(nameof(Translations.Enum.Drink.YesModerate_Name), Description = nameof(Translations.Enum.Drink.YesModerate_Description), ResourceType = typeof(Translations.Enum.Drink))]
    YesModerate = 3,

    [FieldSettings(nameof(Translations.Enum.Drink.YesHeavy_Name), Description = nameof(Translations.Enum.Drink.YesHeavy_Description), ResourceType = typeof(Translations.Enum.Drink))]
    YesHeavy = 4
}