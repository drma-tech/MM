namespace MM.Shared.Enums;

public enum HavePets
{
    [FieldSettings(nameof(Translations.Enum.HavePets.IDontHave), Description = nameof(Translations.Enum.HavePets.IDontHave_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    IDontHave = 1,

    [FieldSettings(nameof(Translations.Enum.HavePets.IDontWant), Description = nameof(Translations.Enum.HavePets.IDontWant_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    IDontWant = 2,

    [FieldSettings(nameof(Translations.Enum.HavePets.Dog), Description = nameof(Translations.Enum.HavePets.Dog_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    Dog = 3,

    [FieldSettings(nameof(Translations.Enum.HavePets.Cat), Description = nameof(Translations.Enum.HavePets.Cat_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    Cat = 4,

    [FieldSettings(nameof(Translations.Enum.HavePets.DogCat), Description = nameof(Translations.Enum.HavePets.DogCat_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    DogCat = 5,

    [FieldSettings(nameof(Translations.Enum.HavePets.SmallPets), Description = nameof(Translations.Enum.HavePets.SmallPets_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    SmallPets = 6,

    [FieldSettings(nameof(Translations.Enum.HavePets.ExoticPets), Description = nameof(Translations.Enum.HavePets.ExoticPets_Description), ResourceType = typeof(Translations.Enum.HavePets))]
    ExoticPets = 7
}