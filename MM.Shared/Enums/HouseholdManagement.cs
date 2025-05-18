namespace MM.Shared.Enums;

public enum HouseholdManagement
{
    [Custom(Name = "SharedResponsibilities", Description = "SharedResponsibilities_Description",
        ResourceType = typeof(Resources.HouseholdManagement))]
    SharedResponsibilities = 1,

    [Custom(Name = "PrimaryResponsibilities", Description = "PrimaryResponsibilities_Description",
        ResourceType = typeof(Resources.HouseholdManagement))]
    PrimaryResponsibilities = 2,

    [Custom(Name = "ExternalSupport", Description = "ExternalSupport_Description",
        ResourceType = typeof(Resources.HouseholdManagement))]
    ExternalSupport = 3
}