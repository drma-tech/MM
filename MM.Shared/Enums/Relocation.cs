namespace MM.Shared.Enums;

public enum Relocation
{
    [FieldSettings("NoRelocations_Name", Description = "NoRelocations_Description", ResourceType = typeof(Translations.Enum.Relocation))]
    NoRelocations = 1,

    [FieldSettings("OpenMovingCities_Name", Description = "OpenMovingCities_Description", ResourceType = typeof(Translations.Enum.Relocation))]
    OpenMovingCities = 2,

    [FieldSettings("OpenMovingCountries_Name", Description = "OpenMovingCountries_Description", ResourceType = typeof(Translations.Enum.Relocation))]
    OpenMovingCountries = 3
}