namespace MM.Shared.Enums;

/// <summary>
///     https://5lovelanguages.com/quizzes/love-language
/// </summary>
public enum LoveLanguage
{
    [Custom(Name = "WordsOfAffirmation_Name", Description = "WordsOfAffirmation_Description",
        ResourceType = typeof(Resources.LoveLanguage))]
    WordsOfAffirmation = 1,

    [Custom(Name = "ActsOfServices_Name", Description = "ActsOfServices_Description",
        ResourceType = typeof(Resources.LoveLanguage))]
    ActsOfServices = 2,

    [Custom(Name = "ReceivingGifts_Name", Description = "ReceivingGifts_Description",
        ResourceType = typeof(Resources.LoveLanguage))]
    ReceivingGifts = 3,

    [Custom(Name = "QualityTime_Name", Description = "QualityTime_Description",
        ResourceType = typeof(Resources.LoveLanguage))]
    QualityTime = 4,

    [Custom(Name = "PhysicalTouch_Name", Description = "PhysicalTouch_Description",
        ResourceType = typeof(Resources.LoveLanguage))]
    PhysicalTouch = 5
}