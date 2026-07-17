namespace MM.Shared.Enums;

public enum Sports
{
    [FieldSettings(nameof(Translations.Enum.Sports.TeamSports), Description = nameof(Translations.Enum.Sports.TeamSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    TeamSports = 1,

    [FieldSettings(nameof(Translations.Enum.Sports.WaterSports), Description = nameof(Translations.Enum.Sports.WaterSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    WaterSports = 2,

    [FieldSettings(nameof(Translations.Enum.Sports.AdventureExtremeSports), Description = nameof(Translations.Enum.Sports.AdventureExtremeSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    AdventureExtremeSports = 3,

    [FieldSettings(nameof(Translations.Enum.Sports.CombatSports), Description = nameof(Translations.Enum.Sports.CombatSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    CombatSports = 4,

    [FieldSettings(nameof(Translations.Enum.Sports.RacquetSports), Description = nameof(Translations.Enum.Sports.RacquetSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    RacquetSports = 5,

    [FieldSettings(nameof(Translations.Enum.Sports.WinterSports), Description = nameof(Translations.Enum.Sports.WinterSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    WinterSports = 6,

    [FieldSettings(nameof(Translations.Enum.Sports.Motorsports), Description = nameof(Translations.Enum.Sports.Motorsports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    Motorsports = 7,

    [FieldSettings(nameof(Translations.Enum.Sports.FitnessConditioning), Description = nameof(Translations.Enum.Sports.FitnessConditioning_Description), ResourceType = typeof(Translations.Enum.Sports))]
    FitnessConditioning = 8,

    [FieldSettings(nameof(Translations.Enum.Sports.OutdoorRecreation), Description = nameof(Translations.Enum.Sports.OutdoorRecreation_Description), ResourceType = typeof(Translations.Enum.Sports))]
    OutdoorRecreation = 9,

    [FieldSettings(nameof(Translations.Enum.Sports.GymnasticsAesthetics), Description = nameof(Translations.Enum.Sports.GymnasticsAesthetics_Description), ResourceType = typeof(Translations.Enum.Sports))]
    GymnasticsAesthetics = 10,

    [FieldSettings(nameof(Translations.Enum.Sports.MindSports), Description = nameof(Translations.Enum.Sports.MindSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    MindSports = 11,

    [FieldSettings(nameof(Translations.Enum.Sports.ShootingSports), Description = nameof(Translations.Enum.Sports.ShootingSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    ShootingSports = 12,

    [FieldSettings(nameof(Translations.Enum.Sports.EquestrianSports), Description = nameof(Translations.Enum.Sports.EquestrianSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    EquestrianSports = 13,

    [FieldSettings(nameof(Translations.Enum.Sports.Athletics), Description = nameof(Translations.Enum.Sports.Athletics_Description), ResourceType = typeof(Translations.Enum.Sports))]
    Athletics = 14,

    [FieldSettings(nameof(Translations.Enum.Sports.CyclingSports), Description = nameof(Translations.Enum.Sports.CyclingSports_Description), ResourceType = typeof(Translations.Enum.Sports))]
    CyclingSports = 15
}