namespace MM.Shared.Enums
{
    public enum Relocation
    {
        [Custom(Name = "Not Willing to Relocate", Description = "I am not open to moving and have no plans or desire to relocate")]
        NoRelocations = 1,

        [Custom(Name = "Open to Moving Cities", Description = "I am willing to move to another city or region within my country if the opportunity arises")]
        OpenMovingCities = 2,

        [Custom(Name = "Open to Moving Countries", Description = "I am open to moving to another country in the near future or if the right situation presents itself")]
        OpenMovingCountries = 3,
    }
}