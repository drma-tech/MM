namespace MM.Shared.Enums;

public enum Ethnicity
{
    [FieldSettings("WhiteCaucasian", Description = "WhiteCaucasian_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    WhiteCaucasian = 1,

    [FieldSettings("BlackAfricanDescent", Description = "BlackAfricanDescent_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    BlackAfricanDescent = 2,

    [FieldSettings("IndigenousNativePeoples", Description = "IndigenousNativePeoples_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    IndigenousNativePeoples = 3,

    [FieldSettings("Asian", Description = "Asian_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    Asian = 4,

    [FieldSettings("HispanicLatino", Description = "HispanicLatino_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    HispanicLatino = 5,

    [FieldSettings("MiddleEasternNorthAfrican", Description = "MiddleEasternNorthAfrican_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    MiddleEasternNorthAfrican = 6,

    [FieldSettings("NativeHawaiianPacificIslander", Description = "NativeHawaiianPacificIslander_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    NativeHawaiianPacificIslander = 7,

    [FieldSettings("MultiracialMixed", Description = "MultiracialMixed_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    MultiracialMixed = 8,

    [FieldSettings("Other", Description = "Other_Description", ResourceType = typeof(Translations.Enum.Ethnicity))]
    Other = 9
}