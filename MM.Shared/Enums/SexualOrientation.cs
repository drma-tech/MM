namespace MM.Shared.Enums;

/// <summary>
///     https://www.india.com/lifestyle/there-are-at-least-15-types-of-sexual-orientations-how-many-do-you-know-2205005/
///     https://www.healthline.com/health/different-types-of-sexuality
/// </summary>
public enum SexualOrientation
{
    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Androgynsexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Androgynsexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Androgynsexual = 1,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Androsexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Androsexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Androsexual = 2,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Asexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Asexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Asexual = 3,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Autosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Autosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Autosexual = 4,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Bisexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Bisexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Bisexual = 5,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Demisexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Demisexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Demisexual = 6,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Graysexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Graysexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Graysexual = 7,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Gynosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Gynosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Gynosexual = 8,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Heterosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Heterosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Heterosexual = 9,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Homosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Homosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Homosexual = 10,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Pansexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Pansexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Pansexual = 11,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Polysexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Polysexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Polysexual = 12,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Pomosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Pomosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Pomosexual = 13,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Sapiosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Sapiosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Sapiosexual = 14,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Skoliosexual_Name), Description = nameof(Translations.Enum.SexualOrientation.Skoliosexual_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Skoliosexual = 15,

    [FieldSettings(nameof(Translations.Enum.SexualOrientation.Other_Name), Description = nameof(Translations.Enum.SexualOrientation.Other_Description), ResourceType = typeof(Translations.Enum.SexualOrientation))]
    Other = 99
}