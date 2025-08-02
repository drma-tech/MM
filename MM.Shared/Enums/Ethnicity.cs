namespace MM.Shared.Enums;

public enum Ethnicity
{
    [Custom(Name = "WhiteCaucasian", Description = "WhiteCaucasian_Description", ResourceType = typeof(Resources.Ethnicity))]
    WhiteCaucasian = 1,

    [Custom(Name = "BlackAfricanDescent", Description = "BlackAfricanDescent_Description", ResourceType = typeof(Resources.Ethnicity))]
    BlackAfricanDescent = 2,

    [Custom(Name = "IndigenousNativePeoples", Description = "IndigenousNativePeoples_Description", ResourceType = typeof(Resources.Ethnicity))]
    IndigenousNativePeoples = 3,

    [Custom(Name = "Asian", Description = "Asian_Description", ResourceType = typeof(Resources.Ethnicity))]
    Asian = 4,

    [Custom(Name = "HispanicLatino", Description = "HispanicLatino_Description", ResourceType = typeof(Resources.Ethnicity))]
    HispanicLatino = 5,

    [Custom(Name = "MiddleEasternNorthAfrican", Description = "MiddleEasternNorthAfrican_Description", ResourceType = typeof(Resources.Ethnicity))]
    MiddleEasternNorthAfrican = 6,

    [Custom(Name = "NativeHawaiianPacificIslander", Description = "NativeHawaiianPacificIslander_Description", ResourceType = typeof(Resources.Ethnicity))]
    NativeHawaiianPacificIslander = 7,

    [Custom(Name = "MultiracialMixed", Description = "MultiracialMixed_Description", ResourceType = typeof(Resources.Ethnicity))]
    MultiracialMixed = 8,

    [Custom(Name = "Other", Description = "Other_Description", ResourceType = typeof(Resources.Ethnicity))]
    Other = 9
}