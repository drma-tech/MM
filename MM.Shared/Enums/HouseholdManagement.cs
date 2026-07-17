namespace MM.Shared.Enums;

public enum HouseholdManagement
{
    [FieldSettings(nameof(Translations.Enum.HouseholdManagement.SharedResponsibilities), Description = nameof(Translations.Enum.HouseholdManagement.SharedResponsibilities_Description), ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    SharedResponsibilities = 1,

    [FieldSettings(nameof(Translations.Enum.HouseholdManagement.PrimaryResponsibilities), Description = nameof(Translations.Enum.HouseholdManagement.PrimaryResponsibilities_Description), ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    PrimaryResponsibilities = 2,

    [FieldSettings(nameof(Translations.Enum.HouseholdManagement.ExternalSupport), Description = nameof(Translations.Enum.HouseholdManagement.ExternalSupport_Description), ResourceType = typeof(Translations.Enum.HouseholdManagement))]
    ExternalSupport = 3
}