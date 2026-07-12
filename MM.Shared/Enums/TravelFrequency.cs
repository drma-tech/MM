namespace MM.Shared.Enums;

public enum TravelFrequency
{
    [FieldSettings("NeverRarely_Name", Description = "NeverRarely_Description", ResourceType = typeof(Translations.Enum.TravelFrequency))]
    NeverRarely = 1,

    [FieldSettings("SometimesFrequently_Name", Description = "SometimesFrequently_Description", ResourceType = typeof(Translations.Enum.TravelFrequency))]
    SometimesFrequently = 2,

    [FieldSettings("UsuallyAlwaysNomad_Name", Description = "UsuallyAlwaysNomad_Description", ResourceType = typeof(Translations.Enum.TravelFrequency))]
    UsuallyAlwaysNomad = 3
}