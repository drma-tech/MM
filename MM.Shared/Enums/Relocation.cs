namespace MM.Shared.Enums;

public enum Relocation
{
    [FieldSettings(nameof(Translations.Enum.Relocation.NoRelocations_Name), Description = nameof(Translations.Enum.Relocation.NoRelocations_Description), ResourceType = typeof(Translations.Enum.Relocation))]
    NoRelocations = 1,

    [FieldSettings(nameof(Translations.Enum.Relocation.OpenMovingCities_Name), Description = nameof(Translations.Enum.Relocation.OpenMovingCities_Description), ResourceType = typeof(Translations.Enum.Relocation))]
    OpenMovingCities = 2,

    [FieldSettings(nameof(Translations.Enum.Relocation.OpenMovingCountries_Name), Description = nameof(Translations.Enum.Relocation.OpenMovingCountries_Description), ResourceType = typeof(Translations.Enum.Relocation))]
    OpenMovingCountries = 3
}