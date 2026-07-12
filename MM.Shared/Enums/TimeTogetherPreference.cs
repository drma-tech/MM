namespace MM.Shared.Enums;

public enum TimeTogetherPreference
{
    [FieldSettings("AloneTime", Description = "AloneTime_Description", ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    AloneTime = 1,

    [FieldSettings("BalancedTime", Description = "BalancedTime_Description", ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    BalancedTime = 2,

    [FieldSettings("QualityTogether", Description = "QualityTogether_Description", ResourceType = typeof(Translations.Enum.TimeTogetherPreference))]
    QualityTogether = 3
}