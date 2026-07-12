namespace MM.Shared.Enums;

public enum HouseholdManagement
{
    [FieldSettings("SharedResponsibilities", Description = "SharedResponsibilities_Description", ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    SharedResponsibilities = 1,

    [FieldSettings("PrimaryResponsibilities", Description = "PrimaryResponsibilities_Description", ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    PrimaryResponsibilities = 2,

    [FieldSettings("ExternalSupport", Description = "ExternalSupport_Description", ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    ExternalSupport = 3
}