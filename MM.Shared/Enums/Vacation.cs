namespace MM.Shared.Enums
{
    public enum Vacation
    {
        [Custom(Name = "Beach & Water Activities", Description = "Relaxing or adventuring near the water (e.g., beach days, snorkeling, scuba diving, surfing)")]
        BeachWaterActivities = 1,

        [Custom(Name = "Adventure Travel", Description = "High-energy and thrill-seeking experiences (e.g., rock climbing, zip-lining, skydiving, paragliding)")]
        AdventureTravel = 2,

        [Custom(Name = "Cultural Exploration", Description = "Immersive experiences in local cultures and histories (e.g., museum visits, historical tours, local festivals, heritage sites)")]
        CulturalExploration = 3,

        [Custom(Name = "Nature & Wildlife", Description = "Activities centered around nature and wildlife (e.g., safaris, hiking in national parks, birdwatching, camping)")]
        NatureWildlife = 4,

        [Custom(Name = "Road Trips", Description = "Exploring multiple destinations by car, often with scenic routes (e.g., cross-country trips, coastal drives, countryside exploring)")]
        RoadTrips = 5,

        [Custom(Name = "City Sightseeing", Description = "Enjoying urban attractions and city-specific experiences (e.g., visiting landmarks, dining at local restaurants, shopping)")]
        CitySightseeing = 6,

        [Custom(Name = "Food & Culinary Tourism", Description = "Discovering new cuisines and food experiences (e.g., food tours, local markets, cooking classes, wine and cheese tastings)")]
        FoodCulinaryTourism = 7,

        [Custom(Name = "Relaxation & Wellness", Description = "Focusing on relaxation and rejuvenation (e.g., spa retreats, yoga retreats, meditation, thermal springs)")]
        RelaxationWellness = 8,

        [Custom(Name = "Winter Sports", Description = "Enjoying seasonal sports and winter landscapes (e.g., skiing, snowboarding, ice skating, snowshoeing)")]
        WinterSports = 9,

        [Custom(Name = "Family-Friendly Activities", Description = "Activities for all ages, often focused on family fun (e.g., theme parks, aquariums, zoos, family beach days)")]
        FamilyFriendlyActivities = 10,

        [Custom(Name = "Cruises & Boat Tours", Description = "Exploring coastal areas or islands by sea (e.g., river cruises, yacht charters, island-hopping, sunset cruises)")]
        CruisesBoatTours = 11,

        [Custom(Name = "Volunteering Vacations", Description = "Traveling with a purpose to help communities or nature (e.g., habitat restoration, wildlife conservation, community support)")]
        VolunteeringVacations = 12,

        [Custom(Name = "Arts & Festivals", Description = "Attending local arts and entertainment events (e.g., music festivals, art shows, theater performances, film festivals)")]
        ArtsFestivals = 13,

        [Custom(Name = "Eco-Tourism", Description = "Sustainable travel with a focus on conservation (e.g., eco-lodges, guided nature tours, visiting wildlife sanctuaries)")]
        EcoTourism = 14,

        [Custom(Name = "Learning & Enrichment", Description = "Travel focused on personal growth and skills (e.g., language immersion, photography workshops, historical courses)")]
        LearningEnrichment = 15,
    }
}