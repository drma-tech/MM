namespace MM.Shared.Enums
{
    public enum Smoke
    {
        [Custom(Name = "No", ResourceType = typeof(Resources.Smoke))]
        No = 1,

        [Custom(Name = "YesOccasionally", ResourceType = typeof(Resources.Smoke))]
        YesOccasionally = 2,

        [Custom(Name = "YesOften", ResourceType = typeof(Resources.Smoke))]
        YesOften = 3
    }
}