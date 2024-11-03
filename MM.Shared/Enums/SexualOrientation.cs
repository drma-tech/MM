namespace MM.Shared.Enums
{
    /// <summary>
    /// https://www.india.com/lifestyle/there-are-at-least-15-types-of-sexual-orientations-how-many-do-you-know-2205005/
    /// https://www.healthline.com/health/different-types-of-sexuality
    /// </summary>
    public enum SexualOrientation
    {
        [Custom(Name = "Androgynsexual_Name", Description = "Androgynsexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Androgynsexual = 1,

        [Custom(Name = "Androsexual_Name", Description = "Androsexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Androsexual = 2,

        [Custom(Name = "Asexual_Name", Description = "Asexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Asexual = 3,

        [Custom(Name = "Autosexual_Name", Description = "Autosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Autosexual = 4,

        [Custom(Name = "Bisexual_Name", Description = "Bisexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Bisexual = 5,

        [Custom(Name = "Demisexual_Name", Description = "Demisexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Demisexual = 6,

        [Custom(Name = "Graysexual_Name", Description = "Graysexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Graysexual = 7,

        [Custom(Name = "Gynosexual_Name", Description = "Gynosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Gynosexual = 8,

        [Custom(Name = "Heterosexual_Name", Description = "Heterosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Heterosexual = 9,

        [Custom(Name = "Homosexual_Name", Description = "Homosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Homosexual = 10,

        [Custom(Name = "Pansexual_Name", Description = "Pansexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Pansexual = 11,

        [Custom(Name = "Polysexual_Name", Description = "Polysexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Polysexual = 12,

        [Custom(Name = "Pomosexual_Name", Description = "Pomosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Pomosexual = 13,

        [Custom(Name = "Sapiosexual_Name", Description = "Sapiosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Sapiosexual = 14,

        [Custom(Name = "Skoliosexual_Name", Description = "Skoliosexual_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Skoliosexual = 15,

        [Custom(Name = "Other_Name", Description = "Other_Description", ResourceType = typeof(Resources.SexualOrientation))]
        Other = 99
    }
}