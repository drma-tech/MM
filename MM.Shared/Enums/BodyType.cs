namespace MM.Shared.Enums
{
    public enum BodyMass
    {
        [Custom(Name = "UnderWeight", ResourceType = typeof(Resources.BodyMass))]
        UnderWeight = 1,

        [Custom(Name = "NormalWeight", ResourceType = typeof(Resources.BodyMass))]
        NormalWeight = 2,

        [Custom(Name = "Athletic", ResourceType = typeof(Resources.BodyMass))]
        Athletic = 3,

        [Custom(Name = "OverWeight", ResourceType = typeof(Resources.BodyMass))]
        OverWeight = 4,

        [Custom(Name = "Obese", ResourceType = typeof(Resources.BodyMass))]
        Obese = 5,
    }
}