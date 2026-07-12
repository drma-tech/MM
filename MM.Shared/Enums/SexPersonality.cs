namespace MM.Shared.Enums;

/// <summary>
///     https://aindasolteira.blogs.sapo.pt/qual-a-tua-personalidade-sexual-200268
///     https://medium.com/sexography/11-sex-personalities-types-6b0b0a22d7d4
/// </summary>
public enum SexPersonality
{
    [FieldSettings("Decompresser_Name", Description = "Decompresser_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Decompresser = 1,

    [FieldSettings("Explorer_Name", Description = "Explorer_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Explorer = 2,

    [FieldSettings("FairTrader_Name", Description = "FairTrader_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    FairTrader = 3,

    [FieldSettings("Giver_Name", Description = "Giver_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Giver = 4,

    [FieldSettings("Guardian_Name", Description = "Guardian_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Guardian = 5,

    [FieldSettings("PassionPursuer_Name", Description = "PassionPursuer_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    PassionPursuer = 6,

    [FieldSettings("PleasureSeeker_Name", Description = "PleasureSeeker_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    PleasureSeeker = 7,

    [FieldSettings("Prioritizer_Name", Description = "Prioritizer_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Prioritizer = 8,

    [FieldSettings("Romantic_Name", Description = "Romantic_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Romantic = 9,

    [FieldSettings("Spiritualist_Name", Description = "Spiritualist_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    Spiritualist = 10,

    [FieldSettings("ThrillSeeker_Name", Description = "ThrillSeeker_Description", ResourceType = typeof(Translations.Enum.SexPersonality))]
    ThrillSeeker = 11
}