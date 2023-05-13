namespace MM.Shared.Enums
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/List_of_religious_populations
    /// </summary>
    public enum Religion
    {
        [Custom(Name = "Christianity_Name", Description = "Christianity_Description", ResourceType = typeof(Resources.Religion))]
        Christianity = 11,

        [Custom(Name = "Islam_Name", Description = "Islam_Description", ResourceType = typeof(Resources.Religion))]
        Islam = 12,

        [Custom(Name = "NonReligious_Name", Description = "NonReligious_Description", ResourceType = typeof(Resources.Religion))]
        NonReligious = 13,

        [Custom(Name = "Hinduism_Name", Description = "Hinduism_Description", ResourceType = typeof(Resources.Religion))]
        Hinduism = 14,

        [Custom(Name = "Buddhism_Name", Description = "Buddhism_Description", ResourceType = typeof(Resources.Religion))]
        Buddhism = 15,

        [Custom(Name = "ChineseTraditionalReligion_Name", Description = "ChineseTraditionalReligion_Description", ResourceType = typeof(Resources.Religion))]
        ChineseTraditionalReligion = 16,

        [Custom(Name = "EthnicReligions_Name", Description = "EthnicReligions_Description", ResourceType = typeof(Resources.Religion))]
        EthnicReligions = 17,

        [Custom(Name = "AfricanTraditionalReligions_Name", Description = "AfricanTraditionalReligions_Description", ResourceType = typeof(Resources.Religion))]
        AfricanTraditionalReligions = 18,

        [Custom(Name = "Sikhism_Name", Description = "Sikhism_Description", ResourceType = typeof(Resources.Religion))]
        Sikhism = 19,

        [Custom(Name = "Spiritism_Name", Description = "Spiritism_Description", ResourceType = typeof(Resources.Religion))]
        Spiritism = 20,

        [Custom(Name = "Judaism_Name", Description = "Judaism_Description", ResourceType = typeof(Resources.Religion))]
        Judaism = 21,

        [Custom(Name = "Other_Name", Description = "Other_Description", ResourceType = typeof(Resources.Religion))]
        Other = 99
    }
}