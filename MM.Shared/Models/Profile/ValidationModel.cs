using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class ValidationModel(string? id) : MainDocument(new MainIdentity(MainType.Validation, id))
{
    public bool Gallery { get; set; }
    public bool Kyc { get; set; }
    public bool NetWorth { get; set; }
    public bool AnnualIncome { get; set; }

    protected override object?[] EqualityValues => [Id];
}