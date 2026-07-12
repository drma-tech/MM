namespace MM.Shared.Enums;

public enum ConflictResolutionStyle
{
    [FieldSettings("DirectResolution", Description = "DirectResolution_Description", ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    DirectResolution = 1,

    [FieldSettings("ReflectiveApproach", Description = "ReflectiveApproach_Description", ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    ReflectiveApproach = 2,

    [FieldSettings("AvoidanceDenial", Description = "AvoidanceDenial_Description", ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    AvoidanceDenial = 3
}