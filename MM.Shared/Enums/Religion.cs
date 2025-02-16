namespace MM.Shared.Enums
{
    public enum Religion
    {
        [Custom(Name = "Christianity", Description = "Christianity_Description", ResourceType = typeof(Resources.Religion))]
        Christianity = 1,

        [Custom(Name = "Islam", Description = "Islam_Description", ResourceType = typeof(Resources.Religion))]
        Islam = 2,

        [Custom(Name = "Hinduism", Description = "Hinduism_Description", ResourceType = typeof(Resources.Religion))]
        Hinduism = 3,

        [Custom(Name = "NonReligious", Description = "NonReligious_Description", ResourceType = typeof(Resources.Religion))]
        NonReligious = 4,

        [Custom(Name = "Buddhism", Description = "Buddhism_Description", ResourceType = typeof(Resources.Religion))]
        Buddhism = 5,

        [Custom(Name = "Sikhism", Description = "Sikhism_Description", ResourceType = typeof(Resources.Religion))]
        Sikhism = 6,

        [Custom(Name = "Judaism", Description = "Judaism_Description", ResourceType = typeof(Resources.Religion))]
        Judaism = 7,

        [Custom(Name = "Other", Description = "Other_Description", ResourceType = typeof(Resources.Religion))]
        Other = 8
    }
}