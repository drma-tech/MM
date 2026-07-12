namespace MM.Shared.Enums;

/// <summary>
///     https://helenfisher.com/personality/
///     https://theanatomyoflove.com/relationship-quizzes/helen-fishers-personality-test/
/// </summary>
public enum RelationshipPersonality
{
    [FieldSettings("Explorers_Name", Description = "Explorers_Description", ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Explorers = 1,

    [FieldSettings("Directors_Name", Description = "Directors_Description", ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Directors = 2,

    [FieldSettings("Builders_Name", Description = "Builders_Description", ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Builders = 3,

    [FieldSettings("Negotiator_Name", Description = "Negotiator_Description", ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Negotiator = 4
}