namespace MM.Shared.Enums;

public enum ConflictResolutionStyle
{
    [Custom(Name = "DirectResolution", Description = "DirectResolution_Description", ResourceType = typeof(Resources.ConflictResolutionStyle))]
    DirectResolution = 1,

    [Custom(Name = "ReflectiveApproach", Description = "ReflectiveApproach_Description", ResourceType = typeof(Resources.ConflictResolutionStyle))]
    ReflectiveApproach = 2,

    [Custom(Name = "AvoidanceDenial", Description = "AvoidanceDenial_Description", ResourceType = typeof(Resources.ConflictResolutionStyle))]
    AvoidanceDenial = 3
}