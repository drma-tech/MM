namespace MM.Shared.Enums;

/// <summary>
///     https://www.verywellmind.com/what-is-neurodivergence-and-what-does-it-mean-to-be-neurodivergent-5196627
/// </summary>
public enum Neurodiversity
{
    [FieldSettings("Neurotypical_Name", Description = "Neurotypical_Description", ResourceType = typeof(Translations.Enum.Neurodiversity))]
    Neurotypical = 1,

    [FieldSettings("Neurodivergent_Name", Description = "Neurodivergent_Description", ResourceType = typeof(Translations.Enum.Neurodiversity))]
    Neurodivergent = 2
}