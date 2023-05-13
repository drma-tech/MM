namespace MM.Shared.Enums
{
    public enum ReadingGenre
    {
        [Custom(Name = "FictionGenres_Name", Description = "FictionGenres_Description", ResourceType = typeof(Resources.ReadingGenre))]
        FictionGenres = 10,

        [Custom(Name = "Biography_Name", Description = "Biography_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Biography = 31,

        [Custom(Name = "Comics_Name", Description = "Comics_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Comics = 32,

        [Custom(Name = "Essay_Name", Description = "Essay_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Essay = 33,

        [Custom(Name = "Journalism_Name", Description = "Journalism_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Journalism = 34,

        [Custom(Name = "Memoir_Name", Description = "Memoir_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Memoir = 35,

        [Custom(Name = "NarrativeNonfictionPersonalNarrative_Name", Description = "NarrativeNonfictionPersonalNarrative_Description", ResourceType = typeof(Resources.ReadingGenre))]
        NarrativeNonfictionPersonalNarrative = 36,

        [Custom(Name = "Reference_Name", Description = "Reference_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Reference = 37,

        [Custom(Name = "SelfHelp_Name", Description = "SelfHelp_Description", ResourceType = typeof(Resources.ReadingGenre))]
        SelfHelp = 38,

        [Custom(Name = "ScientificArticle_Name", Description = "ScientificArticle_Description", ResourceType = typeof(Resources.ReadingGenre))]
        ScientificArticle = 39,

        [Custom(Name = "Textbook_Name", Description = "Textbook_Description", ResourceType = typeof(Resources.ReadingGenre))]
        Textbook = 40
    }
}