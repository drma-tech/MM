namespace MM.Shared.Enums
{
    public enum Relocation
    {
        [Custom(Name = "NoRelocations_Name", Description = "NoRelocations_Description", ResourceType = typeof(Resources.Relocation))]
        NoRelocations = 1,

        [Custom(Name = "OpenMovingCities_Name", Description = "OpenMovingCities_Description", ResourceType = typeof(Resources.Relocation))]
        OpenMovingCities = 2,

        [Custom(Name = "OpenMovingCountries_Name", Description = "OpenMovingCountries_Description", ResourceType = typeof(Resources.Relocation))]
        OpenMovingCountries = 3,
    }
}