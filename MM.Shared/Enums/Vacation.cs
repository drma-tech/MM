namespace MM.Shared.Enums;

public enum Vacation
{
    [Custom(Name = "BeachWaterActivities", Description = "BeachWaterActivities_Description",
        ResourceType = typeof(Resources.Vacation))]
    BeachWaterActivities = 1,

    [Custom(Name = "AdventureTravel", Description = "AdventureTravel_Description",
        ResourceType = typeof(Resources.Vacation))]
    AdventureTravel = 2,

    [Custom(Name = "CulturalExploration", Description = "CulturalExploration_Description",
        ResourceType = typeof(Resources.Vacation))]
    CulturalExploration = 3,

    [Custom(Name = "NatureWildlife", Description = "NatureWildlife_Description",
        ResourceType = typeof(Resources.Vacation))]
    NatureWildlife = 4,

    [Custom(Name = "RoadTrips", Description = "RoadTrips_Description", ResourceType = typeof(Resources.Vacation))]
    RoadTrips = 5,

    [Custom(Name = "CitySightseeing", Description = "CitySightseeing_Description",
        ResourceType = typeof(Resources.Vacation))]
    CitySightseeing = 6,

    [Custom(Name = "FoodCulinaryTourism", Description = "FoodCulinaryTourism_Description",
        ResourceType = typeof(Resources.Vacation))]
    FoodCulinaryTourism = 7,

    [Custom(Name = "RelaxationWellness", Description = "RelaxationWellness_Description",
        ResourceType = typeof(Resources.Vacation))]
    RelaxationWellness = 8,

    [Custom(Name = "WinterSports", Description = "WinterSports_Description", ResourceType = typeof(Resources.Vacation))]
    WinterSports = 9,

    [Custom(Name = "FamilyFriendlyActivities", Description = "FamilyFriendlyActivities_Description",
        ResourceType = typeof(Resources.Vacation))]
    FamilyFriendlyActivities = 10,

    [Custom(Name = "CruisesBoatTours", Description = "CruisesBoatTours_Description",
        ResourceType = typeof(Resources.Vacation))]
    CruisesBoatTours = 11,

    [Custom(Name = "VolunteeringVacations", Description = "VolunteeringVacations_Description",
        ResourceType = typeof(Resources.Vacation))]
    VolunteeringVacations = 12,

    [Custom(Name = "ArtsFestivals", Description = "ArtsFestivals_Description",
        ResourceType = typeof(Resources.Vacation))]
    ArtsFestivals = 13,

    [Custom(Name = "EcoTourism", Description = "EcoTourism_Description", ResourceType = typeof(Resources.Vacation))]
    EcoTourism = 14,

    [Custom(Name = "LearningEnrichment", Description = "LearningEnrichment_Description",
        ResourceType = typeof(Resources.Vacation))]
    LearningEnrichment = 15
}