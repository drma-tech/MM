namespace MM.Shared.Enums;

public enum MovieGenre
{
    [FieldSettings("ActionAdventure", Description = "ActionAdventure_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    ActionAdventure = 1,

    [FieldSettings("Animation", Description = "Animation_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Animation = 2,

    [FieldSettings("Comedy", Description = "Comedy_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Comedy = 3,

    [FieldSettings("Drama", Description = "Drama_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Drama = 4,

    [FieldSettings("FantasyMythology", Description = "FantasyMythology_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    FantasyMythology = 5,

    [FieldSettings("HorrorThriller", Description = "HorrorThriller_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    HorrorThriller = 6,

    [FieldSettings("ScienceFiction", Description = "ScienceFiction_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    ScienceFiction = 7,

    [FieldSettings("Romance", Description = "Romance_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Romance = 8,

    [FieldSettings("MysteryCrime", Description = "MysteryCrime_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    MysteryCrime = 9,

    [FieldSettings("HistoricalBiographical", Description = "HistoricalBiographical_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    HistoricalBiographical = 10,

    [FieldSettings("MusicalDance", Description = "MusicalDance_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    MusicalDance = 11,

    [FieldSettings("Western", Description = "Western_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Western = 12,

    [FieldSettings("Documentary", Description = "Documentary_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    Documentary = 13,

    [FieldSettings("FamilyKids", Description = "FamilyKids_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    FamilyKids = 14,

    [FieldSettings("ExperimentalAvantGarde", Description = "ExperimentalAvantGarde_Description", ResourceType = typeof(Translations.Enum.MovieGenre))]
    ExperimentalAvantGarde = 15
}