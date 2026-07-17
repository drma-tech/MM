namespace MM.Shared.Enums;

public enum HaveChildren
{
    [FieldSettings(nameof(Translations.Enum.HaveChildren.No), ResourceType = typeof(Translations.Enum.HaveChildren))]
    No = 1,

    [FieldSettings(nameof(Translations.Enum.HaveChildren.YesNo), ResourceType = typeof(Translations.Enum.HaveChildren))]
    YesNo = 2,

    [FieldSettings(nameof(Translations.Enum.HaveChildren.Yes), ResourceType = typeof(Translations.Enum.HaveChildren))]
    Yes = 3
}