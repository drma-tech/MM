namespace MM.Shared.Models.Profile;

public class ValidationModel() : PrivateMainDocument(DocumentType.Validation)
{
    [Custom(Name = "Gallery", Description = "GalleryDesc", WhyImportant = "GalleryWhy", ResourceType = typeof(Resources.ProfileValidation))]
    public bool Gallery { get; set; }

    [Custom(Name = "Identity", Description = "IdentityDesc", WhyImportant = "IdentityWhy", ResourceType = typeof(Resources.ProfileValidation))]
    public bool Identity { get; set; }

    [Custom(Name = "NetWorth", Description = "NetWorthDesc", WhyImportant = "NetWorthWhy", ResourceType = typeof(Resources.ProfileValidation))]
    public bool NetWorth { get; set; }

    [Custom(Name = "AnnualIncome", Description = "AnnualIncomeDesc", WhyImportant = "AnnualIncomeWhy", ResourceType = typeof(Resources.ProfileValidation))]
    public bool AnnualIncome { get; set; }
}