namespace MM.Shared.Enums;

public enum Food
{
    [Custom(Name = "AsianCuisine", Description = "AsianCuisine_Description", ResourceType = typeof(Resources.Food))]
    AsianCuisine = 1,

    [Custom(Name = "EuropeanCuisine", Description = "EuropeanCuisine_Description",
        ResourceType = typeof(Resources.Food))]
    EuropeanCuisine = 2,

    [Custom(Name = "MiddleEasternNorthAfrican", Description = "MiddleEasternNorthAfrican_Description",
        ResourceType = typeof(Resources.Food))]
    MiddleEasternNorthAfrican = 3,

    [Custom(Name = "LatinAmerican", Description = "LatinAmerican_Description", ResourceType = typeof(Resources.Food))]
    LatinAmerican = 4,

    [Custom(Name = "AfricanCuisine", Description = "AfricanCuisine_Description", ResourceType = typeof(Resources.Food))]
    AfricanCuisine = 5,

    [Custom(Name = "IndianSouthAsian", Description = "IndianSouthAsian_Description",
        ResourceType = typeof(Resources.Food))]
    IndianSouthAsian = 6,

    [Custom(Name = "NorthAmerican", Description = "NorthAmerican_Description", ResourceType = typeof(Resources.Food))]
    NorthAmerican = 7,

    [Custom(Name = "Mediterranean", Description = "Mediterranean_Description", ResourceType = typeof(Resources.Food))]
    Mediterranean = 8,

    [Custom(Name = "Seafood", Description = "Seafood_Description", ResourceType = typeof(Resources.Food))]
    Seafood = 9,

    [Custom(Name = "Vegetarian", Description = "Vegetarian_Description", ResourceType = typeof(Resources.Food))]
    Vegetarian = 10,

    [Custom(Name = "Vegan", Description = "Vegan_Description", ResourceType = typeof(Resources.Food))]
    Vegan = 11,

    [Custom(Name = "StreetFood", Description = "StreetFood_Description", ResourceType = typeof(Resources.Food))]
    StreetFood = 12,

    [Custom(Name = "FastFoodComfort", Description = "FastFoodComfort_Description",
        ResourceType = typeof(Resources.Food))]
    FastFoodComfort = 13,

    [Custom(Name = "FusionCuisine", Description = "FusionCuisine_Description", ResourceType = typeof(Resources.Food))]
    FusionCuisine = 14,

    [Custom(Name = "DessertsSweets", Description = "DessertsSweets_Description", ResourceType = typeof(Resources.Food))]
    DessertsSweets = 15,

    [Custom(Name = "SpicyFood", Description = "SpicyFood_Description", ResourceType = typeof(Resources.Food))]
    SpicyFood = 16,

    [Custom(Name = "SavorySnacksSmallPlates", Description = "SavorySnacksSmallPlates_Description",
        ResourceType = typeof(Resources.Food))]
    SavorySnacksSmallPlates = 17,

    [Custom(Name = "HomeCookedTraditional", Description = "HomeCookedTraditional_Description",
        ResourceType = typeof(Resources.Food))]
    HomeCookedTraditional = 18,

    [Custom(Name = "GrilledBarbecue", Description = "GrilledBarbecue_Description",
        ResourceType = typeof(Resources.Food))]
    GrilledBarbecue = 19,

    [Custom(Name = "BakedGoods", Description = "BakedGoods_Description", ResourceType = typeof(Resources.Food))]
    BakedGoods = 20
}