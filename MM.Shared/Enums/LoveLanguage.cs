namespace MM.Shared.Enums;

/// <summary>
///     https://5lovelanguages.com/quizzes/love-language
/// </summary>
public enum LoveLanguage
{
    [FieldSettings(nameof(Translations.Enum.LoveLanguage.WordsOfAffirmation_Name), Description = nameof(Translations.Enum.LoveLanguage.WordsOfAffirmation_Description), ResourceType = typeof(Translations.Enum.LoveLanguage))]
    WordsOfAffirmation = 1,

    [FieldSettings(nameof(Translations.Enum.LoveLanguage.ActsOfServices_Name), Description = nameof(Translations.Enum.LoveLanguage.ActsOfServices_Description), ResourceType = typeof(Translations.Enum.LoveLanguage))]
    ActsOfServices = 2,

    [FieldSettings(nameof(Translations.Enum.LoveLanguage.ReceivingGifts_Name), Description = nameof(Translations.Enum.LoveLanguage.ReceivingGifts_Description), ResourceType = typeof(Translations.Enum.LoveLanguage))]
    ReceivingGifts = 3,

    [FieldSettings(nameof(Translations.Enum.LoveLanguage.QualityTime_Name), Description = nameof(Translations.Enum.LoveLanguage.QualityTime_Description), ResourceType = typeof(Translations.Enum.LoveLanguage))]
    QualityTime = 4,

    [FieldSettings(nameof(Translations.Enum.LoveLanguage.PhysicalTouch_Name), Description = nameof(Translations.Enum.LoveLanguage.PhysicalTouch_Description), ResourceType = typeof(Translations.Enum.LoveLanguage))]
    PhysicalTouch = 5
}