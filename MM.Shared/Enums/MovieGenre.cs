namespace MM.Shared.Enums
{
    public enum MovieGenre
    {
        [Custom(Name = "ActionAdventure", Description = "ActionAdventure_Description", ResourceType = typeof(Resources.MovieGenre))]
        ActionAdventure = 1,

        [Custom(Name = "Animation", Description = "Animation_Description", ResourceType = typeof(Resources.MovieGenre))]
        Animation = 2,

        [Custom(Name = "Comedy", Description = "Comedy_Description", ResourceType = typeof(Resources.MovieGenre))]
        Comedy = 3,

        [Custom(Name = "Drama", Description = "Drama_Description", ResourceType = typeof(Resources.MovieGenre))]
        Drama = 4,

        [Custom(Name = "FantasyMythology", Description = "FantasyMythology_Description", ResourceType = typeof(Resources.MovieGenre))]
        FantasyMythology = 5,

        [Custom(Name = "HorrorThriller", Description = "HorrorThriller_Description", ResourceType = typeof(Resources.MovieGenre))]
        HorrorThriller = 6,

        [Custom(Name = "ScienceFiction", Description = "ScienceFiction_Description", ResourceType = typeof(Resources.MovieGenre))]
        ScienceFiction = 7,

        [Custom(Name = "Romance", Description = "Romance_Description", ResourceType = typeof(Resources.MovieGenre))]
        Romance = 8,

        [Custom(Name = "MysteryCrime", Description = "MysteryCrime_Description", ResourceType = typeof(Resources.MovieGenre))]
        MysteryCrime = 9,

        [Custom(Name = "HistoricalBiographical", Description = "HistoricalBiographical_Description", ResourceType = typeof(Resources.MovieGenre))]
        HistoricalBiographical = 10,

        [Custom(Name = "MusicalDance", Description = "MusicalDance_Description", ResourceType = typeof(Resources.MovieGenre))]
        MusicalDance = 11,

        [Custom(Name = "Western", Description = "Western_Description", ResourceType = typeof(Resources.MovieGenre))]
        Western = 12,

        [Custom(Name = "Documentary", Description = "Documentary_Description", ResourceType = typeof(Resources.MovieGenre))]
        Documentary = 13,

        [Custom(Name = "FamilyKids", Description = "FamilyKids_Description", ResourceType = typeof(Resources.MovieGenre))]
        FamilyKids = 14,

        [Custom(Name = "ExperimentalAvantGarde", Description = "ExperimentalAvantGarde_Description", ResourceType = typeof(Resources.MovieGenre))]
        ExperimentalAvantGarde = 15
    }
}