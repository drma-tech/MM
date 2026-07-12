namespace MM.Shared.Enums;

public enum BodyType
{
    [FieldSettings("Slim", ResourceType = typeof(Translations.Enum.BodyType))]
    Slim = 1,

    [FieldSettings("Average", ResourceType = typeof(Translations.Enum.BodyType))]
    Average = 2,

    [FieldSettings("Athletic", ResourceType = typeof(Translations.Enum.BodyType))]
    Athletic = 3,

    [FieldSettings("Curvy", ResourceType = typeof(Translations.Enum.BodyType))]
    Curvy = 4,

    [FieldSettings("Heavyset", ResourceType = typeof(Translations.Enum.BodyType))]
    Heavyset = 5
}