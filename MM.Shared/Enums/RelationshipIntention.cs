namespace MM.Shared.Enums;

public enum RelationshipIntention
{
    [FieldSettings(nameof(Translations.Enum.RelationshipIntention.Serious_Name), Description = nameof(Translations.Enum.RelationshipIntention.Serious_Description), ResourceType = typeof(Translations.Enum.RelationshipIntention))]
    Serious = 1,

    [FieldSettings(nameof(Translations.Enum.RelationshipIntention.LiveTogether_Name), Description = nameof(Translations.Enum.RelationshipIntention.LiveTogether_Description), ResourceType = typeof(Translations.Enum.RelationshipIntention))]
    LiveTogether = 2,

    [FieldSettings(nameof(Translations.Enum.RelationshipIntention.Married_Name), Description = nameof(Translations.Enum.RelationshipIntention.Married_Description), ResourceType = typeof(Translations.Enum.RelationshipIntention))]
    Married = 3
}