namespace MM.Shared.Enums;

/// <summary>
///     https://helenfisher.com/personality/
///     https://theanatomyoflove.com/relationship-quizzes/helen-fishers-personality-test/
/// </summary>
public enum RelationshipPersonality
{
    [FieldSettings(nameof(Translations.Enum.RelationshipPersonality.Explorers_Name), Description = nameof(Translations.Enum.RelationshipPersonality.Explorers_Description), ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Explorers = 1,

    [FieldSettings(nameof(Translations.Enum.RelationshipPersonality.Directors_Name), Description = nameof(Translations.Enum.RelationshipPersonality.Directors_Description), ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Directors = 2,

    [FieldSettings(nameof(Translations.Enum.RelationshipPersonality.Builders_Name), Description = nameof(Translations.Enum.RelationshipPersonality.Builders_Description), ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Builders = 3,

    [FieldSettings(nameof(Translations.Enum.RelationshipPersonality.Negotiator_Name), Description = nameof(Translations.Enum.RelationshipPersonality.Negotiator_Description), ResourceType = typeof(Translations.Enum.RelationshipPersonality))]
    Negotiator = 4
}