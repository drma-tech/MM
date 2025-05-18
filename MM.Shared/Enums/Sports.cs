namespace MM.Shared.Enums;

public enum Sports
{
    [Custom(Name = "TeamSports", Description = "TeamSports_Description", ResourceType = typeof(Resources.Sports))]
    TeamSports = 1,

    [Custom(Name = "WaterSports", Description = "WaterSports_Description", ResourceType = typeof(Resources.Sports))]
    WaterSports = 2,

    [Custom(Name = "AdventureExtremeSports", Description = "AdventureExtremeSports_Description",
        ResourceType = typeof(Resources.Sports))]
    AdventureExtremeSports = 3,

    [Custom(Name = "CombatSports", Description = "CombatSports_Description", ResourceType = typeof(Resources.Sports))]
    CombatSports = 4,

    [Custom(Name = "RacquetSports", Description = "RacquetSports_Description", ResourceType = typeof(Resources.Sports))]
    RacquetSports = 5,

    [Custom(Name = "WinterSports", Description = "WinterSports_Description", ResourceType = typeof(Resources.Sports))]
    WinterSports = 6,

    [Custom(Name = "Motorsports", Description = "Motorsports_Description", ResourceType = typeof(Resources.Sports))]
    Motorsports = 7,

    [Custom(Name = "FitnessConditioning", Description = "FitnessConditioning_Description",
        ResourceType = typeof(Resources.Sports))]
    FitnessConditioning = 8,

    [Custom(Name = "OutdoorRecreation", Description = "OutdoorRecreation_Description",
        ResourceType = typeof(Resources.Sports))]
    OutdoorRecreation = 9,

    [Custom(Name = "GymnasticsAesthetics", Description = "GymnasticsAesthetics_Description",
        ResourceType = typeof(Resources.Sports))]
    GymnasticsAesthetics = 10,

    [Custom(Name = "MindSports", Description = "MindSports_Description", ResourceType = typeof(Resources.Sports))]
    MindSports = 11,

    [Custom(Name = "ShootingSports", Description = "ShootingSports_Description",
        ResourceType = typeof(Resources.Sports))]
    ShootingSports = 12,

    [Custom(Name = "EquestrianSports", Description = "EquestrianSports_Description",
        ResourceType = typeof(Resources.Sports))]
    EquestrianSports = 13,

    [Custom(Name = "Athletics", Description = "Athletics_Description", ResourceType = typeof(Resources.Sports))]
    Athletics = 14,

    [Custom(Name = "CyclingSports", Description = "CyclingSports_Description", ResourceType = typeof(Resources.Sports))]
    CyclingSports = 15
}