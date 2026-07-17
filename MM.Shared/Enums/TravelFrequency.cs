namespace MM.Shared.Enums;

public enum TravelFrequency
{
    [FieldSettings(nameof(Translations.Enum.TravelFrequency.NeverRarely_Name), Description = nameof(Translations.Enum.TravelFrequency.NeverRarely_Description), ResourceType = typeof(Translations.Enum.TravelFrequency))]
    NeverRarely = 1,

    [FieldSettings(nameof(Translations.Enum.TravelFrequency.SometimesFrequently_Name), Description = nameof(Translations.Enum.TravelFrequency.SometimesFrequently_Description), ResourceType = typeof(Translations.Enum.TravelFrequency))]
    SometimesFrequently = 2,

    [FieldSettings(nameof(Translations.Enum.TravelFrequency.UsuallyAlwaysNomad_Name), Description = nameof(Translations.Enum.TravelFrequency.UsuallyAlwaysNomad_Description), ResourceType = typeof(Translations.Enum.TravelFrequency))]
    UsuallyAlwaysNomad = 3
}