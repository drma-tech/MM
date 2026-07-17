namespace MM.Shared.Enums;

public enum IdealPlaceToLive
{
    [FieldSettings(nameof(Translations.Enum.IdealPlaceToLive.Urban), Description = nameof(Translations.Enum.IdealPlaceToLive.Urban_Description), ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Urban = 1,

    [FieldSettings(nameof(Translations.Enum.IdealPlaceToLive.Suburban), Description = nameof(Translations.Enum.IdealPlaceToLive.Suburban_Description), ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Suburban = 2,

    [FieldSettings(nameof(Translations.Enum.IdealPlaceToLive.Rural), Description = nameof(Translations.Enum.IdealPlaceToLive.Rural_Description), ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Rural = 3,

    [FieldSettings(nameof(Translations.Enum.IdealPlaceToLive.Flexible), Description = nameof(Translations.Enum.IdealPlaceToLive.Flexible_Description), ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Flexible = 4
}