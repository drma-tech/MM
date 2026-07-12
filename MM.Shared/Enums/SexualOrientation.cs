namespace MM.Shared.Enums;

/// <summary>
///     https://www.india.com/lifestyle/there-are-at-least-15-types-of-sexual-orientations-how-many-do-you-know-2205005/
///     https://www.healthline.com/health/different-types-of-sexuality
/// </summary>
public enum SexualOrientation
{
    [FieldSettings("Androgynsexual_Name", Description = "Androgynsexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Androgynsexual = 1,

    [FieldSettings("Androsexual_Name", Description = "Androsexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Androsexual = 2,

    [FieldSettings("Asexual_Name", Description = "Asexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Asexual = 3,

    [FieldSettings("Autosexual_Name", Description = "Autosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Autosexual = 4,

    [FieldSettings("Bisexual_Name", Description = "Bisexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Bisexual = 5,

    [FieldSettings("Demisexual_Name", Description = "Demisexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Demisexual = 6,

    [FieldSettings("Graysexual_Name", Description = "Graysexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Graysexual = 7,

    [FieldSettings("Gynosexual_Name", Description = "Gynosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Gynosexual = 8,

    [FieldSettings("Heterosexual_Name", Description = "Heterosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Heterosexual = 9,

    [FieldSettings("Homosexual_Name", Description = "Homosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Homosexual = 10,

    [FieldSettings("Pansexual_Name", Description = "Pansexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Pansexual = 11,

    [FieldSettings("Polysexual_Name", Description = "Polysexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Polysexual = 12,

    [FieldSettings("Pomosexual_Name", Description = "Pomosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Pomosexual = 13,

    [FieldSettings("Sapiosexual_Name", Description = "Sapiosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Sapiosexual = 14,

    [FieldSettings("Skoliosexual_Name", Description = "Skoliosexual_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Skoliosexual = 15,

    [FieldSettings("Other_Name", Description = "Other_Description", ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Other = 99
}