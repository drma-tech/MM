namespace MM.Shared.Enums;

/// <summary>
///     https://autumnasphodel.com/types-of-diets
/// </summary>
public enum Diet
{
    [FieldSettings(nameof(Translations.Enum.Diet.Omnivore_Name), Description = nameof(Translations.Enum.Diet.Omnivore_Description), ResourceType = typeof(Translations.Enum.Diet))]
    Omnivore = 1,

    [FieldSettings(nameof(Translations.Enum.Diet.Flexitarian_Name), Description = nameof(Translations.Enum.Diet.Flexitarian_Description), ResourceType = typeof(Translations.Enum.Diet))]
    Flexitarian = 2,

    [FieldSettings(nameof(Translations.Enum.Diet.Vegetarian_Name), Description = nameof(Translations.Enum.Diet.Vegetarian_Description), ResourceType = typeof(Translations.Enum.Diet))]
    Vegetarian = 3,

    [FieldSettings(nameof(Translations.Enum.Diet.Vegan_Name), Description = nameof(Translations.Enum.Diet.Vegan_Description), ResourceType = typeof(Translations.Enum.Diet))]
    Vegan = 4,

    [FieldSettings(nameof(Translations.Enum.Diet.RawFood_Name), Description = nameof(Translations.Enum.Diet.RawFood_Description), ResourceType = typeof(Translations.Enum.Diet))]
    RawFood = 5,

    [FieldSettings(nameof(Translations.Enum.Diet.GlutenFree_Name), Description = nameof(Translations.Enum.Diet.GlutenFree_Description), ResourceType = typeof(Translations.Enum.Diet))]
    GlutenFree = 6,

    [FieldSettings(nameof(Translations.Enum.Diet.OrganicAllnaturalLocal_Name), Description = nameof(Translations.Enum.Diet.OrganicAllnaturalLocal_Description), ResourceType = typeof(Translations.Enum.Diet))]
    OrganicAllnaturalLocal = 7,

    [FieldSettings(nameof(Translations.Enum.Diet.DetoxWeightLoss_Name), Description = nameof(Translations.Enum.Diet.DetoxWeightLoss_Description), ResourceType = typeof(Translations.Enum.Diet))]
    DetoxWeightLoss = 8
}