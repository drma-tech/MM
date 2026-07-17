namespace MM.Shared.Models.Profile;

public class ValidationModel() : PrivateMainDocument(DocumentType.Validation)
{
    public bool Gallery { get; set; }
    public bool Identity { get; set; }
    public bool NetWorth { get; set; }
    public bool AnnualIncome { get; set; }
}