namespace MM.Shared.Enums
{
    public enum Change
    {
        [Custom(Name = "OpenToChange_Name", Description = "OpenToChange_Description", ResourceType = typeof(Resources.Change))]
        OpenToChange = 1,

        [Custom(Name = "NoChange_Name", Description = "NoChange_Description", ResourceType = typeof(Resources.Change))]
        NoChange = 2,
    }
}