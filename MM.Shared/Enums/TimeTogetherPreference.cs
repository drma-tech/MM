namespace MM.Shared.Enums;

public enum TimeTogetherPreference
{
    [Custom(Name = "AloneTime", Description = "AloneTime_Description",
        ResourceType = typeof(Resources.TimeTogetherPreference))]
    AloneTime = 1,

    [Custom(Name = "BalancedTime", Description = "BalancedTime_Description",
        ResourceType = typeof(Resources.TimeTogetherPreference))]
    BalancedTime = 2,

    [Custom(Name = "QualityTogether", Description = "QualityTogether_Description",
        ResourceType = typeof(Resources.TimeTogetherPreference))]
    QualityTogether = 3
}