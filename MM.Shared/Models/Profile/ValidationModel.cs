namespace MM.Shared.Models.Profile;

public class ValidationModel() : PrivateMainDocument(DocumentType.Validation)
{
    [FieldSettings("Gallery", Description = "GalleryDesc", WhyImportant = "GalleryWhy", ResourceType = typeof(Translations.Model.ProfileValidation))]
    public bool Gallery { get; set; }

    [FieldSettings("Identity", Description = "IdentityDesc", WhyImportant = "IdentityWhy", ResourceType = typeof(Translations.Model.ProfileValidation))]
    public bool Identity { get; set; }

    [FieldSettings("NetWorth", Description = "NetWorthDesc", WhyImportant = "NetWorthWhy", ResourceType = typeof(Translations.Model.ProfileValidation))]
    public bool NetWorth { get; set; }

    [FieldSettings("AnnualIncome", Description = "AnnualIncomeDesc", WhyImportant = "AnnualIncomeWhy", ResourceType = typeof(Translations.Model.ProfileValidation))]
    public bool AnnualIncome { get; set; }
}