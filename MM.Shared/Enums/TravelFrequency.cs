namespace MM.Shared.Enums;

public enum TravelFrequency
{
    [Custom(Name = "NeverRarely_Name", Description = "NeverRarely_Description", ResourceType = typeof(Resources.TravelFrequency))]
    NeverRarely = 1,

    [Custom(Name = "SometimesFrequently_Name", Description = "SometimesFrequently_Description", ResourceType = typeof(Resources.TravelFrequency))]
    SometimesFrequently = 2,

    [Custom(Name = "UsuallyAlwaysNomad_Name", Description = "UsuallyAlwaysNomad_Description", ResourceType = typeof(Resources.TravelFrequency))]
    UsuallyAlwaysNomad = 3
}