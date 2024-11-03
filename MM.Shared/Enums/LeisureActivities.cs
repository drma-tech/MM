namespace MM.Shared.Enums
{
    public enum LeisureActivities
    {
        [Custom(Name = "Outdoor & Nature", Description = "Activities enjoyed outdoors and in nature (e.g., hiking, camping, birdwatching, beach days)")]
        OutdoorNature = 1,

        [Custom(Name = "Sports & Fitness", Description = "Physical activities for health or fun, solo or team-based (e.g., running, yoga, team sports, martial arts)")]
        SportsFitness = 2,

        [Custom(Name = "Creative & Artistic", Description = "Activities related to artistic creation and expression (e.g., painting, crafting, photography, sculpting)")]
        CreativeArtistic = 3,

        [Custom(Name = "Social & Cultural", Description = "Leisure activities for socializing or cultural enrichment (e.g., dining out, concerts, theater, museum visits)")]
        SocialCultural = 4,

        [Custom(Name = "Gaming & Entertainment", Description = "Activities related to games and digital entertainment (e.g., video games, board games, puzzles, VR experiences)")]
        GamingEntertainment = 5,

        [Custom(Name = "Reading & Writing", Description = "Literary activities for enjoyment or personal expression (e.g., reading books, journaling, creative writing, poetry)")]
        ReadingWriting = 6,

        [Custom(Name = "DIY & Hobbies", Description = "Hands-on activities involving learning and creating independently (e.g., gardening, woodworking, knitting, home improvement)")]
        DIYHobbies = 7,

        [Custom(Name = "Music & Performing Arts", Description = "Activities related to music and performing arts (e.g., playing instruments, singing, dancing, theater)")]
        MusicPerformingArts = 8,

        [Custom(Name = "Cooking & Culinary Exploration", Description = "Culinary activities for creating and exploring new flavors(e.g., baking, experimenting with new recipes, wine tasting)")]
        CookingCulinaryExploration = 9,

        [Custom(Name = "Mindfulness & Wellness", Description = "Activities focused on mental and physical well-being(e.g., meditation, spa days, breathwork, nature walks)")]
        MindfulnessWellness = 10,

        [Custom(Name = "Travel & Exploration", Description = "Activities of discovery and adventure in new places(e.g., road trips, exploring new cities, cultural exchange)")]
        TravelExploration = 11,

        [Custom(Name = "Volunteering & Community Service", Description = "Activities of service and community support(e.g., animal shelter volunteering, community cleanup, tutoring)")]
        VolunteeringCommunityService = 12,

        [Custom(Name = "Educational & Self-Improvement", Description = "Activities for learning and personal growth(e.g., online courses, skill-building, language learning)")]
        EducationalSelfImprovement = 13,

        [Custom(Name = "Collecting", Description = "Activities of collecting and organizing items of personal interest(e.g., stamp collecting, vintage items, coin collection)")]
        Collecting = 14
    }
}