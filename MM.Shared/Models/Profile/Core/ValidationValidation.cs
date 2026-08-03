using FluentValidation;

namespace MM.Shared.Models.Profile.Core;

public class ValidationValidation : AbstractValidator<ValidationModel>
{
    public ValidationValidation()
    {
        RuleSet("GALLERY", () => { RuleFor(x => x.Gallery).Equal(toCompare: true); });

        RuleSet("IDENTITY", () => { RuleFor(x => x.Kyc).Equal(toCompare: true); });

        RuleSet("NETWORTH", () => { RuleFor(x => x.NetWorth).Equal(toCompare: true); });

        RuleSet("ANNUALINCOME", () => { RuleFor(x => x.AnnualIncome).Equal(toCompare: true); });
    }
}