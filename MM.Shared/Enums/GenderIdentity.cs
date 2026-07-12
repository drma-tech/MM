namespace MM.Shared.Enums;

/// <summary>
///     https://www.masterclass.com/articles/gender-identity-guide
/// </summary>
public enum GenderIdentity
{
    [FieldSettings("Agender_Name", Description = "Agender_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Agender = 1,

    [FieldSettings("Androgyne_Name", Description = "Androgyne_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Androgyne = 2,

    [FieldSettings("Bigender_Name", Description = "Bigender_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Bigender = 3,

    [FieldSettings("Cisgender_Name", Description = "Cisgender_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Cisgender = 4,

    [FieldSettings("Genderfluid_Name", Description = "Genderfluid_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Genderfluid = 5,

    [FieldSettings("GenderNonconforming_Name", Description = "GenderNonconforming_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    GenderNonconforming = 6,

    [FieldSettings("Genderqueer_Name", Description = "Genderqueer_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Genderqueer = 7,

    [FieldSettings("Intersex_Name", Description = "Intersex_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Intersex = 8,

    [FieldSettings("NonBinary_Name", Description = "NonBinary_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    NonBinary = 9,

    [FieldSettings("Omnigender_Name", Description = "Omnigender_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Omnigender = 10,

    [FieldSettings("Questioning_Name", Description = "Questioning_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Questioning = 11,

    [FieldSettings("Transgender_Name", Description = "Transgender_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    Transgender = 12,

    [FieldSettings("TwoSpirit_Name", Description = "TwoSpirit_Description", ResourceType = typeof(Translations.Enum.GenderIdentity))]
    TwoSpirit = 13
}