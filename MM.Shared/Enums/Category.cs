namespace MM.Shared.Enums
{
    public enum Category
    {
        [FieldSettings("BASIC", Placeholder = "BASIC_ShortName", Description = "BASIC_Description", ResourceType = typeof(Translations.Enum.Category))]
        BASIC,

        [FieldSettings("BIO", Placeholder = "BIO_ShortName", Description = "BIO_Description", ResourceType = typeof(Translations.Enum.Category))]
        BIO,

        [FieldSettings("LIFESTYLE", Placeholder = "LIFESTYLE_ShortName", Description = "LIFESTYLE_Description", ResourceType = typeof(Translations.Enum.Category))]
        LIFESTYLE,

        [FieldSettings("PERSONALITY", Placeholder = "PERSONALITY_ShortName", Description = "PERSONALITY_Description", ResourceType = typeof(Translations.Enum.Category))]
        PERSONALITY,

        [FieldSettings("INTEREST", Placeholder = "INTEREST_ShortName", Description = "INTEREST_Description", ResourceType = typeof(Translations.Enum.Category))]
        INTEREST,

        [FieldSettings("RELATIONSHIP", Placeholder = "RELATIONSHIP_ShortName", Description = "RELATIONSHIP_Description", ResourceType = typeof(Translations.Enum.Category))]
        RELATIONSHIP,

        [FieldSettings("GOAL", Placeholder = "GOAL_ShortName", Description = "GOAL_Description", ResourceType = typeof(Translations.Enum.Category))]
        GOAL,
    }
}