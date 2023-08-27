namespace MM.Shared.Enums
{
    public enum Region
    {
        [Custom(Name = "City", ResourceType = typeof(Resources.Region))]
        City = 1,

        [Custom(Name = "State", ResourceType = typeof(Resources.Region))]
        State = 2,

        [Custom(Name = "Country", ResourceType = typeof(Resources.Region))]
        Country = 3,

        [Custom(Name = "World", ResourceType = typeof(Resources.Region))]
        World = 4
    }
}