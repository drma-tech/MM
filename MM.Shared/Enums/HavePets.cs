namespace MM.Shared.Enums;

public enum HavePets
{
    [FieldSettings("IDontHave", Description = "IDontHave_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    IDontHave = 1,

    [FieldSettings("IDontWant", Description = "IDontWant_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    IDontWant = 2,

    [FieldSettings("Dog", Description = "Dog_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    Dog = 3,

    [FieldSettings("Cat", Description = "Cat_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    Cat = 4,

    [FieldSettings("DogCat", Description = "DogCat_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    DogCat = 5,

    [FieldSettings("SmallPets", Description = "SmallPets_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    SmallPets = 6,

    [FieldSettings("ExoticPets", Description = "ExoticPets_Description", ResourceType = typeof(Translations.Enum.HavePets))]
    ExoticPets = 7
}