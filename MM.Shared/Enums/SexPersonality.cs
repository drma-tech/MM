﻿namespace MM.Shared.Enums;

/// <summary>
///     https://aindasolteira.blogs.sapo.pt/qual-a-tua-personalidade-sexual-200268
///     https://medium.com/sexography/11-sex-personalities-types-6b0b0a22d7d4
/// </summary>
public enum SexPersonality
{
    [Custom(Name = "Decompresser_Name", Description = "Decompresser_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Decompresser = 1,

    [Custom(Name = "Explorer_Name", Description = "Explorer_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Explorer = 2,

    [Custom(Name = "FairTrader_Name", Description = "FairTrader_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    FairTrader = 3,

    [Custom(Name = "Giver_Name", Description = "Giver_Description", ResourceType = typeof(Resources.SexPersonality))]
    Giver = 4,

    [Custom(Name = "Guardian_Name", Description = "Guardian_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Guardian = 5,

    [Custom(Name = "PassionPursuer_Name", Description = "PassionPursuer_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    PassionPursuer = 6,

    [Custom(Name = "PleasureSeeker_Name", Description = "PleasureSeeker_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    PleasureSeeker = 7,

    [Custom(Name = "Prioritizer_Name", Description = "Prioritizer_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Prioritizer = 8,

    [Custom(Name = "Romantic_Name", Description = "Romantic_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Romantic = 9,

    [Custom(Name = "Spiritualist_Name", Description = "Spiritualist_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    Spiritualist = 10,

    [Custom(Name = "ThrillSeeker_Name", Description = "ThrillSeeker_Description",
        ResourceType = typeof(Resources.SexPersonality))]
    ThrillSeeker = 11
}