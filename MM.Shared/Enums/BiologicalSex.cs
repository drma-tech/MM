namespace MM.Shared.Enums;

public enum BiologicalSex
{
    [FieldSettings(nameof(Translations.Enum.BiologicalSex.MaleName), Description = nameof(Translations.Enum.BiologicalSex.MaleDescription), ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Male = 1,

    [FieldSettings(nameof(Translations.Enum.BiologicalSex.FemaleName), Description = nameof(Translations.Enum.BiologicalSex.FemaleDescription), ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Female = 2,

    [FieldSettings(nameof(Translations.Enum.BiologicalSex.OtherName), Description = nameof(Translations.Enum.BiologicalSex.OtherDescription), ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Other = 99
}