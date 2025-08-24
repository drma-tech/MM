namespace MM.Shared.Models.Profile;

public class ValidationModel() : PrivateMainDocument(DocumentType.Validation)
{
    [Custom(Name = "Gallery", Description = "Validates all photos in the gallery (all photos must contain you and only you and be easily identifiable)")]
    public bool Gallery { get; set; }

    [Custom(Name = "Identity", Description = "Identity validation (must be done before any interaction on the platform)")]
    public bool Identity { get; set; }

    [Custom(Name = "Net Worth", Description = "Validation required to use this field in your filters")]
    public bool NetWorth { get; set; }

    [Custom(Name = "Annual Income", Description = "Validation required to use this field in your filters")]
    public bool AnnualIncome { get; set; }
}