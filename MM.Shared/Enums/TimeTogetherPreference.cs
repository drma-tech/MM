namespace MM.Shared.Enums;

public enum TimeTogetherPreference
{
    [FieldSettings(nameof(Translations.Enum.TimeTogetherPreference.AloneTime), Description = nameof(Translations.Enum.TimeTogetherPreference.AloneTime_Description), ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    AloneTime = 1,

    [FieldSettings(nameof(Translations.Enum.TimeTogetherPreference.BalancedTime), Description = nameof(Translations.Enum.TimeTogetherPreference.BalancedTime_Description), ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    BalancedTime = 2,

    [FieldSettings(nameof(Translations.Enum.TimeTogetherPreference.QualityTogether), Description = nameof(Translations.Enum.TimeTogetherPreference.QualityTogether_Description), ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    QualityTogether = 3
}