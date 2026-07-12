namespace MM.Shared.Enums;

public enum ReadingGenre
{
    [FieldSettings("FictionLiterature", Description = "FictionLiterature_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    FictionLiterature = 1,

    [FieldSettings("SpeculativeAdventure", Description = "SpeculativeAdventure_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SpeculativeAdventure = 2,

    [FieldSettings("RomanceRelationships", Description = "RomanceRelationships_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    RomanceRelationships = 3,

    [FieldSettings("HistoryBiographical", Description = "HistoryBiographical_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    HistoryBiographical = 4,

    [FieldSettings("SelfImprovementMindfulness", Description = "SelfImprovementMindfulness_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SelfImprovementMindfulness = 5,

    [FieldSettings("ScienceNatureExploration", Description = "ScienceNatureExploration_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    ScienceNatureExploration = 6,

    [FieldSettings("SocietyCurrentAffairs", Description = "SocietyCurrentAffairs_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SocietyCurrentAffairs = 7,

    [FieldSettings("EducationReference", Description = "EducationReference_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    EducationReference = 8,

    [FieldSettings("VisualStorytelling", Description = "VisualStorytelling_Description", ResourceType = typeof(Translations.Enum.ReadingGenre))]
    VisualStorytelling = 9
}