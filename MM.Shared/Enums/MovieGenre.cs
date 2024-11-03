namespace MM.Shared.Enums
{
    public enum MovieGenre
    {
        [Custom(Name = "Action & Adventure", Description = "High-energy films with exciting sequences and often heroic themes (e.g., action, spy thrillers, survival)")]
        ActionAdventure = 1,

        [Custom(Name = "Animation", Description = "Films that use animated techniques to tell stories, appealing to all ages (e.g., family animation, anime, CGI)")]
        Animation = 2,

        [Custom(Name = "Comedy", Description = "Light-hearted films intended to entertain and amuse with humor (e.g., romantic comedy, slapstick, dark comedy)")]
        Comedy = 3,

        [Custom(Name = "Drama", Description = "Emotionally focused films that explore complex characters and real-life situations (e.g., family drama, social issues, historical drama)")]
        Drama = 4,

        [Custom(Name = "Fantasy & Mythology", Description = "Films featuring magical worlds, mythical creatures, and supernatural elements (e.g., epic fantasy, fairy tales, urban fantasy)")]
        FantasyMythology = 5,

        [Custom(Name = "Horror & Thriller", Description = "Tension-driven films designed to elicit fear or suspense (e.g., psychological horror, supernatural thriller, slasher)")]
        HorrorThriller = 6,

        [Custom(Name = "Science Fiction", Description = "Films exploring futuristic concepts, technology, or alien life (e.g., space opera, dystopian, time travel)")]
        ScienceFiction = 7,

        [Custom(Name = "Romance", Description = "Stories centered around romantic relationships and emotional connections (e.g., romantic drama, rom-com, period romance)")]
        Romance = 8,

        [Custom(Name = "Mystery & Crime", Description = "Films focused on solving puzzles, often involving crime or investigation (e.g., detective stories, whodunit, heist)")]
        MysteryCrime = 9,

        [Custom(Name = "Historical & Biographical", Description = "Films based on real events, historical periods, or significant figures (e.g., biographies, war dramas, historical epics)")]
        HistoricalBiographical = 10,

        [Custom(Name = "Musical & Dance", Description = "Films where music and dance are central to the storytelling (e.g., musicals, dance movies, rock operas)")]
        MusicalDance = 11,

        [Custom(Name = "Western", Description = "Films set in the American frontier, often exploring themes of justice and survival (e.g., classic westerns, revisionist westerns)")]
        Western = 12,

        [Custom(Name = "Documentary", Description = "Nonfiction films presenting real events, people, or issues in an informative way (e.g., nature docs, true crime, cultural exploration)")]
        Documentary = 13,

        [Custom(Name = "Family & Kids", Description = "Films aimed at younger audiences or suitable for family viewing (e.g., family-friendly adventure, animated kids' movies)")]
        FamilyKids = 14,

        [Custom(Name = "Experimental & Avant-Garde", Description = "Nontraditional films that push the boundaries of narrative and form (e.g., surrealism, abstract cinema, art films)")]
        ExperimentalAvantGarde = 15
    }
}