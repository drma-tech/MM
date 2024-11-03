namespace MM.Shared.Enums
{
    public enum TVGenre
    {
        [Custom(Name = "Animated & Anime", Description = "Includes cartoons, animated series, and Japanese anime")]
        AnimatedAnime = 1,

        [Custom(Name = "Cooking & Food", Description = "Programs focused on cooking, baking, and food culture (e.g., cooking competitions, food documentaries)")]
        CookingFood = 2,

        [Custom(Name = "Documentary & Reality", Description = "Real-life stories and situations, either informative or entertaining (e.g., nature documentaries, reality shows)")]
        DocumentaryReality = 3,

        [Custom(Name = "Educational & Science", Description = "Shows focused on learning and science topics, often informative (e.g., science shows, how-to programs)")]
        EducationalScience = 4,

        [Custom(Name = "Game Shows & Competitions", Description = "Shows where contestants compete for prizes or recognition (e.g., trivia shows, talent competitions)")]
        GameShowsCompetitions = 5,

        [Custom(Name = "Kids & Family", Description = "Programming suitable for children and family viewing (e.g., children’s shows, family-friendly series)")]
        KidsFamily = 6,

        [Custom(Name = "Lifestyle & Home", Description = "Shows that explore lifestyle topics, including design, travel, and wellness (e.g., home improvement, travel shows)")]
        LifestyleHome = 7,

        [Custom(Name = "Music & Performances", Description = "Programs centered around music, live performances, and music videos (e.g., music countdowns, concert specials)")]
        MusicPerformances = 8,

        [Custom(Name = "News & Current Affairs", Description = "News reports, talk shows, and in-depth analyses of current events")]
        NewsCurrentAffairs = 9,

        [Custom(Name = "Soap Operas & Dramas", Description = "Serialized dramas with continuous storylines, often emotionally intense (e.g., daytime soaps, family dramas)")]
        SoapOperasDramas = 10,

        [Custom(Name = "Sports & Outdoors", Description = "Programs focusing on sports events, commentary, and outdoor activities (e.g., live sports, extreme sports)")]
        SportsOutdoors = 11,

        [Custom(Name = "Talk Shows & Interviews", Description = "Shows featuring hosts in conversation with guests on various topics (e.g., celebrity interviews, discussion panels)")]
        TalkShowsInterviews = 12,

        [Custom(Name = "Variety & Comedy", Description = "Shows with a mix of entertainment elements, such as skits, stand-up, and comedy acts (e.g., late-night shows, sketch comedy)")]
        VarietyComedy = 13
    }
}