namespace MM.Shared.Enums;

public enum HavePets
{
    [Custom(Name = "IDontHave", Description = "IDontHave_Description", ResourceType = typeof(Resources.HavePets))]
    IDontHave = 1,

    [Custom(Name = "IDontWant", Description = "IDontWant_Description", ResourceType = typeof(Resources.HavePets))]
    IDontWant = 2,

    [Custom(Name = "Dog", Description = "Dog_Description", ResourceType = typeof(Resources.HavePets))]
    Dog = 3,

    [Custom(Name = "Cat", Description = "Cat_Description", ResourceType = typeof(Resources.HavePets))]
    Cat = 4,

    [Custom(Name = "DogCat", Description = "DogCat_Description", ResourceType = typeof(Resources.HavePets))]
    DogCat = 5,

    [Custom(Name = "SmallPets", Description = "SmallPets_Description", ResourceType = typeof(Resources.HavePets))]
    SmallPets = 6,

    [Custom(Name = "ExoticPets", Description = "ExoticPets_Description", ResourceType = typeof(Resources.HavePets))]
    ExoticPets = 7
}