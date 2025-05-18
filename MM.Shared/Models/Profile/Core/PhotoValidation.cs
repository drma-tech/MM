using FluentValidation;

namespace MM.Shared.Models.Profile.Core;

public class PhotoValidation : AbstractValidator<ProfileGalleryModel>
{
    public PhotoValidation()
    {
        RuleFor(x => x.FaceId)
            .NotEmpty().When(x => x.Type != GalleryType.BlindDate);

        RuleFor(x => x.BodyId)
            .NotEmpty().When(x => x.Type != GalleryType.BlindDate);
    }
}