namespace MM.Shared.Enums;

/// <summary>
///     https://aindasolteira.blogs.sapo.pt/qual-a-tua-personalidade-sexual-200268
///     https://medium.com/sexography/11-sex-personalities-types-6b0b0a22d7d4
/// </summary>
public enum SexPersonality
{
    [FieldSettings(nameof(Translations.Enum.SexPersonality.Decompresser_Name), Description = nameof(Translations.Enum.SexPersonality.Decompresser_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Decompresser = 1,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Explorer_Name), Description = nameof(Translations.Enum.SexPersonality.Explorer_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Explorer = 2,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.FairTrader_Name), Description = nameof(Translations.Enum.SexPersonality.FairTrader_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    FairTrader = 3,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Giver_Name), Description = nameof(Translations.Enum.SexPersonality.Giver_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Giver = 4,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Guardian_Name), Description = nameof(Translations.Enum.SexPersonality.Guardian_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Guardian = 5,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.PassionPursuer_Name), Description = nameof(Translations.Enum.SexPersonality.PassionPursuer_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    PassionPursuer = 6,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.PleasureSeeker_Name), Description = nameof(Translations.Enum.SexPersonality.PleasureSeeker_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    PleasureSeeker = 7,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Prioritizer_Name), Description = nameof(Translations.Enum.SexPersonality.Prioritizer_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Prioritizer = 8,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Romantic_Name), Description = nameof(Translations.Enum.SexPersonality.Romantic_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Romantic = 9,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.Spiritualist_Name), Description = nameof(Translations.Enum.SexPersonality.Spiritualist_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    Spiritualist = 10,

    [FieldSettings(nameof(Translations.Enum.SexPersonality.ThrillSeeker_Name), Description = nameof(Translations.Enum.SexPersonality.ThrillSeeker_Description), ResourceType = typeof(Translations.Enum.SexPersonality))]
    ThrillSeeker = 11
}