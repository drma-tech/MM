namespace MM.Shared.Enums;

public enum IdealPlaceToLive
{
    [FieldSettings("Urban", Description = "Urban_Description", ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Urban = 1,

    [FieldSettings("Suburban", Description = "Suburban_Description", ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Suburban = 2,

    [FieldSettings("Rural", Description = "Rural_Description", ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Rural = 3,

    [FieldSettings("Flexible", Description = "Flexible_Description", ResourceType = typeof(Translations.Enum.IdealPlaceToLive))]
    Flexible = 4
}