namespace MM.Shared.Enums;

public enum WantChildren
{
    [FieldSettings(nameof(Translations.Enum.WantChildren.No), ResourceType = typeof(Translations.Enum.WantChildren))]
    No = 1,

    [FieldSettings(nameof(Translations.Enum.WantChildren.Maybe), ResourceType = typeof(Translations.Enum.WantChildren))]
    Maybe = 2,

    [FieldSettings(nameof(Translations.Enum.WantChildren.Yes), ResourceType = typeof(Translations.Enum.WantChildren))]
    Yes = 3
}