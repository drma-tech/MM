namespace MM.Shared.Enums
{
    public enum TimeTogetherPreference
    {
        [Custom(Name = "Alone Time", Description = "Enjoys significant alone time.")]
        AloneTime = 1,

        [Custom(Name = "Balanced Time", Description = "Values both personal time and time with a partner.")]
        BalancedTime = 2,

        [Custom(Name = "Quality Together", Description = "Prefers to spend most time with their partner.")]
        QualityTogether = 3,
    }
}