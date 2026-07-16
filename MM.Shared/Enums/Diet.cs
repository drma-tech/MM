namespace MM.Shared.Enums;

/// <summary>
///     https://autumnasphodel.com/types-of-diets
/// </summary>
public enum Diet
{
    [FieldSettings("Omnivore_Name", Description = "Omnivore_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Omnivore = 1,

    [FieldSettings("Flexitarian_Name", Description = "Flexitarian_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Flexitarian = 2,

    [FieldSettings("Vegetarian_Name", Description = "Vegetarian_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Vegetarian = 3,

    [FieldSettings("Vegan_Name", Description = "Vegan_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Vegan = 4,

    [FieldSettings("RawFood_Name", Description = "RawFood_Description", ResourceType = typeof(Translations.Enum.Diet))]
    RawFood = 5,

    [FieldSettings("GlutenFree_Name", Description = "GlutenFree_Description", ResourceType = typeof(Translations.Enum.Diet))]
    GlutenFree = 6,

    [FieldSettings("OrganicAllnaturalLocal_Name", Description = "OrganicAllnaturalLocal_Description", ResourceType = typeof(Translations.Enum.Diet))]
    OrganicAllnaturalLocal = 7,

    [FieldSettings("DetoxWeightLoss_Name", Description = "DetoxWeightLoss_Description", ResourceType = typeof(Translations.Enum.Diet))]
    DetoxWeightLoss = 8
}