namespace MM.Shared.Enums;

public enum FamilyInvolvement
{
    [FieldSettings("NotInvolved", Description = "NotInvolved_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    NotInvolved = 1,

    [FieldSettings("SomeInvolvement", Description = "SomeInvolvement_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    SomeInvolvement = 2,

    [FieldSettings("HeavilyInvolved", Description = "HeavilyInvolved_Description", ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    HeavilyInvolved = 3
}