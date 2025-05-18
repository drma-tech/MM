namespace MM.Shared.Enums;

/// <summary>
///     https://www.verywellmind.com/what-is-neurodivergence-and-what-does-it-mean-to-be-neurodivergent-5196627
/// </summary>
public enum Neurodiversity
{
    [Custom(Name = "Neurotypical_Name", Description = "Neurotypical_Description",
        ResourceType = typeof(Resources.Neurodiversity))]
    Neurotypical = 1,

    [Custom(Name = "Neurodivergent_Name", Description = "Neurodivergent_Description",
        ResourceType = typeof(Resources.Neurodiversity))]
    Neurodivergent = 2
}