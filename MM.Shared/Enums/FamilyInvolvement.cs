namespace MM.Shared.Enums;

public enum FamilyInvolvement
{
    [FieldSettings(nameof(Translations.Enum.FamilyInvolvement.NotInvolved_Name), Description = nameof(Translations.Enum.FamilyInvolvement.NotInvolved_Description), ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    NotInvolved = 1,

    [FieldSettings(nameof(Translations.Enum.FamilyInvolvement.SomeInvolvement_Name), Description = nameof(Translations.Enum.FamilyInvolvement.SomeInvolvement_Description), ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    SomeInvolvement = 2,

    [FieldSettings(nameof(Translations.Enum.FamilyInvolvement.HeavilyInvolved_Name), Description = nameof(Translations.Enum.FamilyInvolvement.HeavilyInvolved_Description), ResourceType = typeof(Translations.Enum.FamilyInvolvement))]
    HeavilyInvolved = 3
}