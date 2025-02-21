namespace MM.Shared.Enums
{
    public enum ReadingGenre
    {
        [Custom(Name = "FictionLiterature", Description = "FictionLiterature_Description", ResourceType = typeof(Resources.ReadingGenre))]
        FictionLiterature = 1,

        [Custom(Name = "SpeculativeAdventure", Description = "SpeculativeAdventure_Description", ResourceType = typeof(Resources.ReadingGenre))]
        SpeculativeAdventure = 2,

        [Custom(Name = "RomanceRelationships", Description = "RomanceRelationships_Description", ResourceType = typeof(Resources.ReadingGenre))]
        RomanceRelationships = 3,

        [Custom(Name = "HistoryBiographical", Description = "HistoryBiographical_Description", ResourceType = typeof(Resources.ReadingGenre))]
        HistoryBiographical = 4,

        [Custom(Name = "SelfImprovementMindfulness", Description = "SelfImprovementMindfulness_Description", ResourceType = typeof(Resources.ReadingGenre))]
        SelfImprovementMindfulness = 5,

        [Custom(Name = "ScienceNatureExploration", Description = "ScienceNatureExploration_Description", ResourceType = typeof(Resources.ReadingGenre))]
        ScienceNatureExploration = 6,

        [Custom(Name = "SocietyCurrentAffairs", Description = "SocietyCurrentAffairs_Description", ResourceType = typeof(Resources.ReadingGenre))]
        SocietyCurrentAffairs = 7,

        [Custom(Name = "EducationReference", Description = "EducationReference_Description", ResourceType = typeof(Resources.ReadingGenre))]
        EducationReference = 8,

        [Custom(Name = "VisualStorytelling", Description = "VisualStorytelling_Description", ResourceType = typeof(Resources.ReadingGenre))]
        VisualStorytelling = 9
    }
}