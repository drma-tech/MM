namespace MM.Shared.Enums;

/// <summary>
///     https://www.masterclass.com/articles/gender-identity-guide
/// </summary>
public enum GenderIdentity
{
    [Custom(Name = "Agender_Name", Description = "Agender_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Agender = 1,

    [Custom(Name = "Androgyne_Name", Description = "Androgyne_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Androgyne = 2,

    [Custom(Name = "Bigender_Name", Description = "Bigender_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Bigender = 3,

    [Custom(Name = "Cisgender_Name", Description = "Cisgender_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Cisgender = 4,

    [Custom(Name = "Genderfluid_Name", Description = "Genderfluid_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Genderfluid = 5,

    [Custom(Name = "GenderNonconforming_Name", Description = "GenderNonconforming_Description", ResourceType = typeof(Resources.GenderIdentity))]
    GenderNonconforming = 6,

    [Custom(Name = "Genderqueer_Name", Description = "Genderqueer_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Genderqueer = 7,

    [Custom(Name = "Intersex_Name", Description = "Intersex_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Intersex = 8,

    [Custom(Name = "NonBinary_Name", Description = "NonBinary_Description", ResourceType = typeof(Resources.GenderIdentity))]
    NonBinary = 9,

    [Custom(Name = "Omnigender_Name", Description = "Omnigender_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Omnigender = 10,

    [Custom(Name = "Questioning_Name", Description = "Questioning_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Questioning = 11,

    [Custom(Name = "Transgender_Name", Description = "Transgender_Description", ResourceType = typeof(Resources.GenderIdentity))]
    Transgender = 12,

    [Custom(Name = "TwoSpirit_Name", Description = "TwoSpirit_Description", ResourceType = typeof(Resources.GenderIdentity))]
    TwoSpirit = 13
}