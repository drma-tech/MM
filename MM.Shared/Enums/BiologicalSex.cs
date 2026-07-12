namespace MM.Shared.Enums;

public enum BiologicalSex
{
    [FieldSettings("MaleName", Description = "MaleDescription", ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Male = 1,

    [FieldSettings("FemaleName", Description = "FemaleDescription", ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Female = 2,

    [FieldSettings("OtherName", Description = "OtherDescription", ResourceType = typeof(Translations.Enum.BiologicalSex))]
    Other = 99
}