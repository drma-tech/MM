namespace MM.Shared.Enums;

/// <summary>
///     https://www.verywellmind.com/what-is-neurodivergence-and-what-does-it-mean-to-be-neurodivergent-5196627
/// </summary>
public enum Neurodiversity
{
    [FieldSettings(nameof(Translations.Enum.Neurodiversity.Neurotypical_Name), Description = nameof(Translations.Enum.Neurodiversity.Neurotypical_Description), ResourceType = typeof(Translations.Enum.Neurodiversity))]
    Neurotypical = 1,

    [FieldSettings(nameof(Translations.Enum.Neurodiversity.Neurodivergent_Name), Description = nameof(Translations.Enum.Neurodiversity.Neurodivergent_Description), ResourceType = typeof(Translations.Enum.Neurodiversity))]
    Neurodivergent = 2
}