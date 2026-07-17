namespace MM.Shared.Enums;

public enum BodyType
{
    [FieldSettings(nameof(Translations.Enum.BodyType.Slim), ResourceType = typeof(Translations.Enum.BodyType))]
    Slim = 1,

    [FieldSettings(nameof(Translations.Enum.BodyType.Average), ResourceType = typeof(Translations.Enum.BodyType))]
    Average = 2,

    [FieldSettings(nameof(Translations.Enum.BodyType.Athletic), ResourceType = typeof(Translations.Enum.BodyType))]
    Athletic = 3,

    [FieldSettings(nameof(Translations.Enum.BodyType.Curvy), ResourceType = typeof(Translations.Enum.BodyType))]
    Curvy = 4,

    [FieldSettings(nameof(Translations.Enum.BodyType.Heavyset), ResourceType = typeof(Translations.Enum.BodyType))]
    Heavyset = 5
}