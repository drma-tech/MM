namespace MM.Shared.Enums
{
    public enum ConflictResolutionStyle
    {
        [Custom(Name = "Direct Resolution", Description = "Prefers to discuss and resolve conflicts immediately and openly.")]
        DirectResolution = 1,

        [Custom(Name = "Reflective Approach", Description = "Takes time to think and reflect before addressing conflicts.")]
        ReflectiveApproach = 2,

        [Custom(Name = "Avoidance/Denial", Description = "Tends to avoid conflicts or overlook their existence altogether.")]
        AvoidanceDenial = 3,
    }
}