namespace MM.Shared.Enums;

/// <summary>
///     https://autumnasphodel.com/types-of-diets
/// </summary>
public enum Diet
{
    [FieldSettings("Omnivore", Description = "Omnivore_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Omnivore = 1,

    [FieldSettings("Flexitarian", Description = "Flexitarian_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Flexitarian = 2,

    [FieldSettings("Vegetarian", Description = "Vegetarian_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Vegetarian = 3,

    [FieldSettings("Vegan", Description = "Vegan_Description", ResourceType = typeof(Translations.Enum.Diet))]
    Vegan = 4,

    [FieldSettings("RawFood", Description = "RawFood_Description", ResourceType = typeof(Translations.Enum.Diet))]
    RawFood = 5,

    [FieldSettings("GlutenFree", Description = "GlutenFree_Description", ResourceType = typeof(Translations.Enum.Diet))]
    GlutenFree = 6,

    [FieldSettings("OrganicAllnaturalLocal", Description = "OrganicAllnaturalLocal_Description", ResourceType = typeof(Translations.Enum.Diet))]
    OrganicAllnaturalLocal = 7,

    [FieldSettings("DetoxWeightLoss", Description = "DetoxWeightLoss_Description", ResourceType = typeof(Translations.Enum.Diet))]
    DetoxWeightLoss = 8
}