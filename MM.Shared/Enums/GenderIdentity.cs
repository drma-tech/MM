namespace MM.Shared.Enums;

/// <summary>
///     https://www.masterclass.com/articles/gender-identity-guide
/// </summary>
public enum GenderIdentity
{
    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Agender_Name), Description = nameof(Translations.Enum.GenderIdentity.Agender_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Agender = 1,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Androgyne_Name), Description = nameof(Translations.Enum.GenderIdentity.Androgyne_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Androgyne = 2,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Bigender_Name), Description = nameof(Translations.Enum.GenderIdentity.Bigender_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Bigender = 3,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Cisgender_Name), Description = nameof(Translations.Enum.GenderIdentity.Cisgender_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Cisgender = 4,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Genderfluid_Name), Description = nameof(Translations.Enum.GenderIdentity.Genderfluid_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Genderfluid = 5,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.GenderNonconforming_Name), Description = nameof(Translations.Enum.GenderIdentity.GenderNonconforming_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    GenderNonconforming = 6,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Genderqueer_Name), Description = nameof(Translations.Enum.GenderIdentity.Genderqueer_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Genderqueer = 7,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Intersex_Name), Description = nameof(Translations.Enum.GenderIdentity.Intersex_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Intersex = 8,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.NonBinary_Name), Description = nameof(Translations.Enum.GenderIdentity.NonBinary_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    NonBinary = 9,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Omnigender_Name), Description = nameof(Translations.Enum.GenderIdentity.Omnigender_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Omnigender = 10,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Questioning_Name), Description = nameof(Translations.Enum.GenderIdentity.Questioning_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Questioning = 11,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.Transgender_Name), Description = nameof(Translations.Enum.GenderIdentity.Transgender_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Transgender = 12,

    [FieldSettings(nameof(Translations.Enum.GenderIdentity.TwoSpirit_Name), Description = nameof(Translations.Enum.GenderIdentity.TwoSpirit_Description), ResourceType = typeof(Translations.Enum.GenderIdentity))]
    TwoSpirit = 13
}