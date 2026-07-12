namespace MM.Shared.Enums;

public enum WantChildren
{
    [FieldSettings("No", ResourceType = typeof(Translations.Enum.WantChildren))]
    No = 1,

    [FieldSettings("Maybe", ResourceType = typeof(Translations.Enum.WantChildren))]
    Maybe = 2,

    [FieldSettings("Yes", ResourceType = typeof(Translations.Enum.WantChildren))]
    Yes = 3
}