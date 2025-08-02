namespace MM.Shared.Enums;

public enum FamilyInvolvement
{
    [Custom(Name = "NotInvolved_Name", Description = "NotInvolved_Description", ResourceType = typeof(Resources.FamilyInvolvement))]
    NotInvolved = 1,

    [Custom(Name = "SomeInvolvement_Name", Description = "SomeInvolvement_Description", ResourceType = typeof(Resources.FamilyInvolvement))]
    SomeInvolvement = 2,

    [Custom(Name = "HeavilyInvolved_Name", Description = "HeavilyInvolved_Description", ResourceType = typeof(Resources.FamilyInvolvement))]
    HeavilyInvolved = 3
}