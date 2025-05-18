namespace MM.Shared.Enums;

public enum LeisureActivities
{
    [Custom(Name = "OutdoorNature", Description = "OutdoorNature_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    OutdoorNature = 1,

    [Custom(Name = "SportsFitness", Description = "SportsFitness_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    SportsFitness = 2,

    [Custom(Name = "CreativeArtistic", Description = "CreativeArtistic_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    CreativeArtistic = 3,

    [Custom(Name = "SocialCultural", Description = "SocialCultural_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    SocialCultural = 4,

    [Custom(Name = "GamingEntertainment", Description = "GamingEntertainment_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    GamingEntertainment = 5,

    [Custom(Name = "ReadingWriting", Description = "ReadingWriting_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    ReadingWriting = 6,

    [Custom(Name = "DIYHobbies", Description = "DIYHobbies_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    DIYHobbies = 7,

    [Custom(Name = "MusicPerformingArts", Description = "MusicPerformingArts_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    MusicPerformingArts = 8,

    [Custom(Name = "CookingCulinaryExploration", Description = "CookingCulinaryExploration_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    CookingCulinaryExploration = 9,

    [Custom(Name = "MindfulnessWellness", Description = "MindfulnessWellness_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    MindfulnessWellness = 10,

    [Custom(Name = "TravelExploration", Description = "TravelExploration_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    TravelExploration = 11,

    [Custom(Name = "VolunteeringCommunityService", Description = "VolunteeringCommunityService_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    VolunteeringCommunityService = 12,

    [Custom(Name = "EducationalSelfImprovement", Description = "EducationalSelfImprovement_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    EducationalSelfImprovement = 13,

    [Custom(Name = "Collecting", Description = "Collecting_Description",
        ResourceType = typeof(Resources.LeisureActivities))]
    Collecting = 14
}