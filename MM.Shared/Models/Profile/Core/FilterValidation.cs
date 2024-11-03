using FluentValidation;

namespace MM.Shared.Models.Profile.Core
{
    public class FilterValidation : AbstractValidator<FilterModel>
    {
        public FilterValidation()
        {
            RuleFor(x => x.Region)
                .NotEmpty();

            RuleFor(x => x.MinimalAge)
                .NotEmpty()
                .GreaterThanOrEqualTo(18);

            RuleFor(x => x.MaxAge)
                .NotEmpty()
                .LessThanOrEqualTo(120);

            RuleFor(x => x.MinimalAge)
                .Must((value, MinimalAge) => MinimalAge <= value.MaxAge)
                .WithMessage("Minimum age must be less than maximum age");

            RuleFor(x => x.MaxAge)
                .Must((value, MaxAge) => MaxAge >= value.MinimalAge)
                .WithMessage("Maximum age must be greater than minimum age");

            RuleFor(x => x.MinimalHeight)
                .Must((value, MinimalHeight) => MinimalHeight <= value.MaxHeight)
                .WithMessage("Minimum height must be less than maximum height")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);

            RuleFor(x => x.MaxHeight)
                .Must((value, MaxHeight) => MaxHeight >= value.MinimalHeight)
                .WithMessage("Maximum height must be greater than minimum height")
                .When(x => x.MinimalHeight.HasValue && x.MaxHeight.HasValue);
        }
    }
}