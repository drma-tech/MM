namespace MM.Shared.Enums;

public enum FamilyInvolvement
{
    [FieldSettings("NotInvolved_Name", Description = "NotInvolved_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    NotInvolved = 1,

    [FieldSettings("SomeInvolvement_Name", Description = "SomeInvolvement_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    SomeInvolvement = 2,

    [FieldSettings("HeavilyInvolved_Name", Description = "HeavilyInvolved_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    HeavilyInvolved = 3
}