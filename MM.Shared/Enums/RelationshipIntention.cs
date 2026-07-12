using MM.Shared.Translations.Enum;

namespace MM.Shared.Enums;

public enum RelationshipIntention
{
    [FieldSettings("Serious_Name", Description = "Serious_Description", ResourceType = typeof(Intentions))]
    Serious = 1,

    [FieldSettings("LiveTogether_Name", Description = "LiveTogether_Description", ResourceType = typeof(Intentions))]
    LiveTogether = 2,

    [FieldSettings("Married_Name", Description = "Married_Description", ResourceType = typeof(Intentions))]
    Married = 3
}