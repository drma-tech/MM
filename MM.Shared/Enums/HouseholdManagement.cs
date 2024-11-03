namespace MM.Shared.Enums
{
    public enum HouseholdManagement
    {
        [Custom(Name = "Shared Responsibilities", Description = "Household tasks are divided equally between partners.")]
        SharedResponsibilities = 1,

        [Custom(Name = "Primary Responsibilities", Description = "One partner takes on most of the household tasks.")]
        PrimaryResponsibilities = 2,

        [Custom(Name = "External Support", Description = "Household tasks are handled by hired help or services.")]
        ExternalSupport = 3,
    }
}