namespace MM.Shared.Enums;

/// <summary>
///     https://5lovelanguages.com/quizzes/love-language
/// </summary>
public enum LoveLanguage
{
    [FieldSettings("WordsOfAffirmation_Name", Description = "WordsOfAffirmation_Description", ResourceType = typeof(Translations.Enum.LoveLanguage))]
    WordsOfAffirmation = 1,

    [FieldSettings("ActsOfServices_Name", Description = "ActsOfServices_Description", ResourceType = typeof(Translations.Enum.LoveLanguage))]
    ActsOfServices = 2,

    [FieldSettings("ReceivingGifts_Name", Description = "ReceivingGifts_Description", ResourceType = typeof(Translations.Enum.LoveLanguage))]
    ReceivingGifts = 3,

    [FieldSettings("QualityTime_Name", Description = "QualityTime_Description", ResourceType = typeof(Translations.Enum.LoveLanguage))]
    QualityTime = 4,

    [FieldSettings("PhysicalTouch_Name", Description = "PhysicalTouch_Description", ResourceType = typeof(Translations.Enum.LoveLanguage))]
    PhysicalTouch = 5
}