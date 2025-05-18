using FluentValidation;

namespace MM.Shared.Models.Profile.Core;

public class ValidationValidation : AbstractValidator<ValidationModel>
{
    public ValidationValidation()
    {
        RuleSet("GALLERY", () => { RuleFor(x => x.Gallery).Equal(true); });

        RuleSet("IDENTITY", () => { RuleFor(x => x.Identity).Equal(true); });

        RuleSet("NETWORTH", () => { RuleFor(x => x.NetWorth).Equal(true); });

        RuleSet("ANNUALINCOME", () => { RuleFor(x => x.AnnualIncome).Equal(true); });
    }
}