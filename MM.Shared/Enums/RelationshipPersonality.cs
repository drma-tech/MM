namespace MM.Shared.Enums;

/// <summary>
///     https://helenfisher.com/personality/
///     https://theanatomyoflove.com/relationship-quizzes/helen-fishers-personality-test/
/// </summary>
public enum RelationshipPersonality
{
    [Custom(Name = "Explorers_Name", Description = "Explorers_Description",
        ResourceType = typeof(Resources.RelationshipPersonality))]
    Explorers = 1,

    [Custom(Name = "Directors_Name", Description = "Directors_Description",
        ResourceType = typeof(Resources.RelationshipPersonality))]
    Directors = 2,

    [Custom(Name = "Builders_Name", Description = "Builders_Description",
        ResourceType = typeof(Resources.RelationshipPersonality))]
    Builders = 3,

    [Custom(Name = "Negotiator_Name", Description = "Negotiator_Description",
        ResourceType = typeof(Resources.RelationshipPersonality))]
    Negotiator = 4
}