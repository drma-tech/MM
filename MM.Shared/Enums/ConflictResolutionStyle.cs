namespace MM.Shared.Enums;

public enum ConflictResolutionStyle
{
    [FieldSettings(nameof(Translations.Enum.ConflictResolutionStyle.DirectResolution), Description = nameof(Translations.Enum.ConflictResolutionStyle.DirectResolution_Description),
        ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    DirectResolution = 1,

    [FieldSettings(nameof(Translations.Enum.ConflictResolutionStyle.ReflectiveApproach), Description = nameof(Translations.Enum.ConflictResolutionStyle.ReflectiveApproach_Description),
        ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    ReflectiveApproach = 2,

    [FieldSettings(nameof(Translations.Enum.ConflictResolutionStyle.AvoidanceDenial), Description = nameof(Translations.Enum.ConflictResolutionStyle.AvoidanceDenial_Description),
        ResourceType = typeof(Translations.Enum.ConflictResolutionStyle))]
    AvoidanceDenial = 3
}