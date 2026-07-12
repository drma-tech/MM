namespace MM.Shared.Enums;

public enum Sports
{
    [FieldSettings("TeamSports", Description = "TeamSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    TeamSports = 1,

    [FieldSettings("WaterSports", Description = "WaterSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    WaterSports = 2,

    [FieldSettings("AdventureExtremeSports", Description = "AdventureExtremeSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    AdventureExtremeSports = 3,

    [FieldSettings("CombatSports", Description = "CombatSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    CombatSports = 4,

    [FieldSettings("RacquetSports", Description = "RacquetSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    RacquetSports = 5,

    [FieldSettings("WinterSports", Description = "WinterSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    WinterSports = 6,

    [FieldSettings("Motorsports", Description = "Motorsports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    Motorsports = 7,

    [FieldSettings("FitnessConditioning", Description = "FitnessConditioning_Description", ResourceType = typeof(Translations.Enum.Sports))]
    FitnessConditioning = 8,

    [FieldSettings("OutdoorRecreation", Description = "OutdoorRecreation_Description", ResourceType = typeof(Translations.Enum.Sports))]
    OutdoorRecreation = 9,

    [FieldSettings("GymnasticsAesthetics", Description = "GymnasticsAesthetics_Description", ResourceType = typeof(Translations.Enum.Sports))]
    GymnasticsAesthetics = 10,

    [FieldSettings("MindSports", Description = "MindSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    MindSports = 11,

    [FieldSettings("ShootingSports", Description = "ShootingSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    ShootingSports = 12,

    [FieldSettings("EquestrianSports", Description = "EquestrianSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    EquestrianSports = 13,

    [FieldSettings("Athletics", Description = "Athletics_Description", ResourceType = typeof(Translations.Enum.Sports))]
    Athletics = 14,

    [FieldSettings("CyclingSports", Description = "CyclingSports_Description", ResourceType = typeof(Translations.Enum.Sports))]
    CyclingSports = 15
}