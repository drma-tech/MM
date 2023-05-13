namespace MM.Shared.Enums
{
    /// <summary>
    /// https://www.ranker.com/crowdranked-list/favorite-types-of-cuisine
    /// </summary>
    public enum Food
    {
        [Custom(Name = "ItalianFood", ResourceType = typeof(Resources.Food))]
        ItalianFood = 1,

        [Custom(Name = "MexicanFood", ResourceType = typeof(Resources.Food))]
        MexicanFood = 2,

        [Custom(Name = "ThaiFood", ResourceType = typeof(Resources.Food))]
        ThaiFood = 3,

        [Custom(Name = "MediterraneanFood", ResourceType = typeof(Resources.Food))]
        MediterraneanFood = 4,

        [Custom(Name = "MoroccanFood", ResourceType = typeof(Resources.Food))]
        MoroccanFood = 5,

        [Custom(Name = "ChineseFood", ResourceType = typeof(Resources.Food))]
        ChineseFood = 6,

        [Custom(Name = "IndianCuisine", ResourceType = typeof(Resources.Food))]
        IndianCuisine = 7,

        [Custom(Name = "JapaneseCuisine", ResourceType = typeof(Resources.Food))]
        JapaneseCuisine = 8,

        [Custom(Name = "Seafood", ResourceType = typeof(Resources.Food))]
        Seafood = 9,

        [Custom(Name = "GreekFood", ResourceType = typeof(Resources.Food))]
        GreekFood = 10,

        [Custom(Name = "AmericanFood", ResourceType = typeof(Resources.Food))]
        AmericanFood = 11,

        [Custom(Name = "SoulFood", ResourceType = typeof(Resources.Food))]
        SoulFood = 12,

        [Custom(Name = "SouthernAmericanFood", ResourceType = typeof(Resources.Food))]
        SouthernAmericanFood = 13,

        [Custom(Name = "SpanishCuisine", ResourceType = typeof(Resources.Food))]
        SpanishCuisine = 14,

        [Custom(Name = "VietnameseFood", ResourceType = typeof(Resources.Food))]
        VietnameseFood = 15,

        [Custom(Name = "TexMexFood", ResourceType = typeof(Resources.Food))]
        TexMexFood = 16,

        [Custom(Name = "KoreanBarbecue", ResourceType = typeof(Resources.Food))]
        KoreanBarbecue = 17,

        [Custom(Name = "MiddleEasternFood", ResourceType = typeof(Resources.Food))]
        MiddleEasternFood = 18,

        [Custom(Name = "CajunFood", ResourceType = typeof(Resources.Food))]
        CajunFood = 19,

        [Custom(Name = "LebaneseFood", ResourceType = typeof(Resources.Food))]
        LebaneseFood = 20,

        [Custom(Name = "TexasBarbecue", ResourceType = typeof(Resources.Food))]
        TexasBarbecue = 21,

        [Custom(Name = "SicilianCuisine", ResourceType = typeof(Resources.Food))]
        SicilianCuisine = 22,

        [Custom(Name = "CaribbeanFood", ResourceType = typeof(Resources.Food))]
        CaribbeanFood = 23,

        [Custom(Name = "SouthKoreanFood", ResourceType = typeof(Resources.Food))]
        SouthKoreanFood = 24,

        [Custom(Name = "BrazilianBarbecue", ResourceType = typeof(Resources.Food))]
        BrazilianBarbecue = 25,

        [Custom(Name = "FrenchFood", ResourceType = typeof(Resources.Food))]
        FrenchFood = 26,

        [Custom(Name = "TurkishFood", ResourceType = typeof(Resources.Food))]
        TurkishFood = 27,

        [Custom(Name = "JunkFood", ResourceType = typeof(Resources.Food))]
        JunkFood = 28,

        [Custom(Name = "MidwesternFood", ResourceType = typeof(Resources.Food))]
        MidwesternFood = 29,

        [Custom(Name = "PortugueseFood", ResourceType = typeof(Resources.Food))]
        PortugueseFood = 30,

        [Custom(Name = "GermanFood", ResourceType = typeof(Resources.Food))]
        GermanFood = 31,

        [Custom(Name = "BrazilianFood", ResourceType = typeof(Resources.Food))]
        BrazilianFood = 32,

        [Custom(Name = "CubanFood", ResourceType = typeof(Resources.Food))]
        CubanFood = 33,

        [Custom(Name = "IrishFood", ResourceType = typeof(Resources.Food))]
        IrishFood = 34,

        [Custom(Name = "TunisianCuisine", ResourceType = typeof(Resources.Food))]
        TunisianCuisine = 35,

        [Custom(Name = "UnitedKingdomCuisine", ResourceType = typeof(Resources.Food))]
        UnitedKingdomCuisine = 36,

        [Custom(Name = "SouthIndianCuisine", ResourceType = typeof(Resources.Food))]
        SouthIndianCuisine = 37,

        [Custom(Name = "JamaicanFood", ResourceType = typeof(Resources.Food))]
        JamaicanFood = 38,

        [Custom(Name = "CanadianCuisine", ResourceType = typeof(Resources.Food))]
        CanadianCuisine = 39,

        [Custom(Name = "VegetarianFood", ResourceType = typeof(Resources.Food))]
        VegetarianFood = 40,

        [Custom(Name = "FilipinoCuisine", ResourceType = typeof(Resources.Food))]
        FilipinoCuisine = 41,

        [Custom(Name = "ArgentinianFood", ResourceType = typeof(Resources.Food))]
        ArgentinianFood = 42,

        [Custom(Name = "MalaysianFood", ResourceType = typeof(Resources.Food))]
        MalaysianFood = 43,

        [Custom(Name = "IranianCuisine", ResourceType = typeof(Resources.Food))]
        IranianCuisine = 44,

        [Custom(Name = "IndonesianCuisine", ResourceType = typeof(Resources.Food))]
        IndonesianCuisine = 45,

        [Custom(Name = "SichuanCuisine", ResourceType = typeof(Resources.Food))]
        SichuanCuisine = 46,

        [Custom(Name = "JewishCuisine", ResourceType = typeof(Resources.Food))]
        JewishCuisine = 47,

        [Custom(Name = "SwissCuisine", ResourceType = typeof(Resources.Food))]
        SwissCuisine = 48,

        [Custom(Name = "ShanghaineseCuisine", ResourceType = typeof(Resources.Food))]
        ShanghaineseCuisine = 49,

        [Custom(Name = "SingaporeanFood", ResourceType = typeof(Resources.Food))]
        SingaporeanFood = 50,
    }

    public enum FoodOld
    {
        [Custom(Name = "Italian", ResourceType = typeof(Resources.Food))]
        Italian = 1,

        [Custom(Name = "French", ResourceType = typeof(Resources.Food))]
        French = 2,

        [Custom(Name = "German", ResourceType = typeof(Resources.Food))]
        German = 3,

        [Custom(Name = "Greek", ResourceType = typeof(Resources.Food))]
        Greek = 4,

        [Custom(Name = "Spanish", ResourceType = typeof(Resources.Food))]
        Spanish = 5,

        [Custom(Name = "MiddleEastern", ResourceType = typeof(Resources.Food))]
        MiddleEastern = 6,

        [Custom(Name = "Indian", ResourceType = typeof(Resources.Food))]
        Indian = 7,

        [Custom(Name = "Chinese", ResourceType = typeof(Resources.Food))]
        Chinese = 8,

        [Custom(Name = "Thai", ResourceType = typeof(Resources.Food))]
        Thai = 9,

        [Custom(Name = "Vietnamese", ResourceType = typeof(Resources.Food))]
        Vietnamese = 10,

        [Custom(Name = "Japanese", ResourceType = typeof(Resources.Food))]
        Japanese = 11,

        [Custom(Name = "Korean", ResourceType = typeof(Resources.Food))]
        Korean = 12,

        [Custom(Name = "Cuban", ResourceType = typeof(Resources.Food))]
        Cuban = 13,

        [Custom(Name = "PuertoRican", ResourceType = typeof(Resources.Food))]
        PuertoRican = 14,

        [Custom(Name = "SouthAmericanCuisine", ResourceType = typeof(Resources.Food))]
        SouthAmericanCuisine = 15,

        [Custom(Name = "Mexican", ResourceType = typeof(Resources.Food))]
        Mexican = 16,

        [Custom(Name = "AfricanAmerican", ResourceType = typeof(Resources.Food))]
        AfricanAmerican = 17,

        [Custom(Name = "Fusionkitchen", ResourceType = typeof(Resources.Food))]
        Fusionkitchen = 18,

        [Custom(Name = "StreetFood", ResourceType = typeof(Resources.Food))]
        StreetFood = 19,

        [Custom(Name = "FastFood", ResourceType = typeof(Resources.Food))]
        FastFood = 20,

        [Custom(Name = "PlainFare", ResourceType = typeof(Resources.Food))]
        PlainFare = 21
    }
}