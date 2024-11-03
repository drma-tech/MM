namespace MM.Shared.Enums
{
    public enum HavePets
    {
        [Custom(Name = "I Don’t Have", Description = "I currently don’t own any pets.")]
        IDontHave = 1,

        [Custom(Name = "I Don’t Want", Description = "I don’t have pets and prefer not to have any.")]
        IDontWant = 2,

        [Custom(Name = "Dog(s)", Description = "I have dog(s) (e.g., Labrador, Poodle, Bulldog).")]
        Dog = 3,

        [Custom(Name = "Cat(s)", Description = "I have cat(s) (e.g., Persian, Siamese, Maine Coon).")]
        Cat = 4,

        [Custom(Name = "Dog(s) and Cat(s)", Description = "I have both dog(s) and cat(s).")]
        DogCat = 5,

        [Custom(Name = "Small Pets", Description = "I have small pets (e.g., rabbits, hamsters, guinea pigs, or birds).")]
        SmallPets = 6,

        [Custom(Name = "Exotic Pets", Description = "I have exotic pets (e.g., snakes, lizards, ferrets, fish, or tarantulas).")]
        ExoticPets = 7,
    }
}