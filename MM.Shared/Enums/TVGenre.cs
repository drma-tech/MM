namespace MM.Shared.Enums;

public enum TVGenre
{
    [Custom(Name = "AnimatedAnime", Description = "AnimatedAnime_Description",
        ResourceType = typeof(Resources.TVGenre))]
    AnimatedAnime = 1,

    [Custom(Name = "CookingFood", Description = "CookingFood_Description", ResourceType = typeof(Resources.TVGenre))]
    CookingFood = 2,

    [Custom(Name = "DocumentaryReality", Description = "DocumentaryReality_Description",
        ResourceType = typeof(Resources.TVGenre))]
    DocumentaryReality = 3,

    [Custom(Name = "EducationalScience", Description = "EducationalScience_Description",
        ResourceType = typeof(Resources.TVGenre))]
    EducationalScience = 4,

    [Custom(Name = "GameShowsCompetitions", Description = "GameShowsCompetitions_Description",
        ResourceType = typeof(Resources.TVGenre))]
    GameShowsCompetitions = 5,

    [Custom(Name = "KidsFamily", Description = "KidsFamily_Description", ResourceType = typeof(Resources.TVGenre))]
    KidsFamily = 6,

    [Custom(Name = "LifestyleHome", Description = "LifestyleHome_Description",
        ResourceType = typeof(Resources.TVGenre))]
    LifestyleHome = 7,

    [Custom(Name = "MusicPerformances", Description = "MusicPerformances_Description",
        ResourceType = typeof(Resources.TVGenre))]
    MusicPerformances = 8,

    [Custom(Name = "NewsCurrentAffairs", Description = "NewsCurrentAffairs_Description",
        ResourceType = typeof(Resources.TVGenre))]
    NewsCurrentAffairs = 9,

    [Custom(Name = "SoapOperasDramas", Description = "SoapOperasDramas_Description",
        ResourceType = typeof(Resources.TVGenre))]
    SoapOperasDramas = 10,

    [Custom(Name = "SportsOutdoors", Description = "SportsOutdoors_Description",
        ResourceType = typeof(Resources.TVGenre))]
    SportsOutdoors = 11,

    [Custom(Name = "TalkShowsInterviews", Description = "TalkShowsInterviews_Description",
        ResourceType = typeof(Resources.TVGenre))]
    TalkShowsInterviews = 12,

    [Custom(Name = "VarietyComedy", Description = "VarietyComedy_Description",
        ResourceType = typeof(Resources.TVGenre))]
    VarietyComedy = 13
}