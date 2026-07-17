namespace MM.Shared.Enums;

public enum Ethnicity
{
    [FieldSettings(nameof(Translations.Enum.Ethnicity.WhiteCaucasian), Description = nameof(Translations.Enum.Ethnicity.WhiteCaucasian_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    WhiteCaucasian = 1,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.BlackAfricanDescent), Description = nameof(Translations.Enum.Ethnicity.BlackAfricanDescent_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    BlackAfricanDescent = 2,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.IndigenousNativePeoples), Description = nameof(Translations.Enum.Ethnicity.IndigenousNativePeoples_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    IndigenousNativePeoples = 3,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.Asian), Description = nameof(Translations.Enum.Ethnicity.Asian_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    Asian = 4,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.HispanicLatino), Description = nameof(Translations.Enum.Ethnicity.HispanicLatino_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    HispanicLatino = 5,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.MiddleEasternNorthAfrican), Description = nameof(Translations.Enum.Ethnicity.MiddleEasternNorthAfrican_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    MiddleEasternNorthAfrican = 6,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.NativeHawaiianPacificIslander), Description = nameof(Translations.Enum.Ethnicity.NativeHawaiianPacificIslander_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    NativeHawaiianPacificIslander = 7,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.MultiracialMixed), Description = nameof(Translations.Enum.Ethnicity.MultiracialMixed_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    MultiracialMixed = 8,

    [FieldSettings(nameof(Translations.Enum.Ethnicity.Other), Description = nameof(Translations.Enum.Ethnicity.Other_Description), ResourceType = typeof(Translations.Enum.Ethnicity))]
    Other = 9
}