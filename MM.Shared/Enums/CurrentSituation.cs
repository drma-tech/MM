namespace MM.Shared.Enums
{
    public enum CurrentSituation
    {
        [Custom(Name = "Single_Name", Description = "Single_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Single = 1,

        [Custom(Name = "NonMonogamous_Name", Description = "NonMonogamous_Description", ResourceType = typeof(Resources.CurrentSituation))]
        NonMonogamous = 2
    }
}