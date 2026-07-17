namespace MM.Shared.Enums;

public enum ReadingGenre
{
    [FieldSettings(nameof(Translations.Enum.ReadingGenre.FictionLiterature), Description = nameof(Translations.Enum.ReadingGenre.FictionLiterature_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    FictionLiterature = 1,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.SpeculativeAdventure), Description = nameof(Translations.Enum.ReadingGenre.SpeculativeAdventure_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SpeculativeAdventure = 2,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.RomanceRelationships), Description = nameof(Translations.Enum.ReadingGenre.RomanceRelationships_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    RomanceRelationships = 3,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.HistoryBiographical), Description = nameof(Translations.Enum.ReadingGenre.HistoryBiographical_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    HistoryBiographical = 4,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.SelfImprovementMindfulness), Description = nameof(Translations.Enum.ReadingGenre.SelfImprovementMindfulness_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SelfImprovementMindfulness = 5,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.ScienceNatureExploration), Description = nameof(Translations.Enum.ReadingGenre.ScienceNatureExploration_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    ScienceNatureExploration = 6,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.SocietyCurrentAffairs), Description = nameof(Translations.Enum.ReadingGenre.SocietyCurrentAffairs_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    SocietyCurrentAffairs = 7,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.EducationReference), Description = nameof(Translations.Enum.ReadingGenre.EducationReference_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    EducationReference = 8,

    [FieldSettings(nameof(Translations.Enum.ReadingGenre.VisualStorytelling), Description = nameof(Translations.Enum.ReadingGenre.VisualStorytelling_Description), ResourceType = typeof(Translations.Enum.ReadingGenre))]
    VisualStorytelling = 9
}