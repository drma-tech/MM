using FluentValidation;

namespace MM.Shared.Models.Profile.Core
{
    public class PhotoValidation : AbstractValidator<ProfilePhotoModel>
    {
        public PhotoValidation()
        {
            RuleFor(x => x.FaceId)
                  .NotEmpty();

            RuleFor(x => x.BodyId)
                  .NotEmpty();
        }
    }
}