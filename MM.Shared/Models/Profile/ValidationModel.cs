namespace MM.Shared.Models.Profile;

public class ValidationModel() : PrivateMainDocument(DocumentType.Validation)
{
    [Custom(Name = "Gallery", Description = "A photo of you will be taken to compare with your gallery", WhyImportant = "It is necessary before you publish your profile.")]
    public bool Gallery { get; set; }

    [Custom(Name = "Identity", Description = "A specialized and independent platform will be used", WhyImportant = "It is necessary before any interaction with another user.")]
    public bool Identity { get; set; }

    [Custom(Name = "Net Worth", Description = "A specialized and independent platform will be used", WhyImportant = "It's necessary if you want to use this field as a filter.")]
    public bool NetWorth { get; set; }

    [Custom(Name = "Annual Income", Description = "A specialized and independent platform will be used", WhyImportant = "It's necessary if you want to use this field as a filter.")]
    public bool AnnualIncome { get; set; }
}