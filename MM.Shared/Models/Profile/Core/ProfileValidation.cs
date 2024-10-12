﻿using FluentValidation;

namespace MM.Shared.Models.Profile.Core
{
    public class ProfileValidation : AbstractValidator<ProfileModel>
    {
        public ProfileValidation()
        {
            RuleSet("BASIC", () =>
            {
                RuleFor(x => x.NickName)
                    .NotEmpty()
                    .MaximumLength(20)
                    .WithName(Resources.ProfileBasicModel.NickName_Name);

                RuleFor(x => x.Description)
                    .MaximumLength(512)
                    .WithName(Resources.ProfileBasicModel.Description_Name);

                RuleFor(x => x.Location)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.Location_Name);

                RuleFor(x => x.Languages)
                  .NotEmpty()
                  .Must((value) => value.Count <= 3)
                  .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3))
                  .WithName(Resources.ProfileBasicModel.Languages_Name);

                RuleFor(x => x.CurrentSituation)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.CurrentSituation_Name);

                RuleFor(x => x.BiologicalSex)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.BiologicalSex_Name);

                RuleFor(x => x.GenderIdentities)
                    .NotEmpty()
                    .Must((value) => value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3))
                    .WithName(Resources.ProfileBasicModel.GenderIdentity_Name);

                RuleFor(x => x.SexualOrientations)
                    .NotEmpty()
                    .Must((value) => value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3))
                    .WithName(Resources.ProfileBasicModel.SexualOrientation_Name);
            });

            RuleSet("BIO", () =>
            {
                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage(Shared.Resources.Validations.OlderToRegister);

                RuleFor(x => x.RaceCategory)
                    .NotEmpty()
                    .WithName(Resources.ProfileBioModel.RaceCategory_Name);

                RuleFor(x => x.Height)
                    .NotEmpty()
                    .WithName(Resources.ProfileBioModel.Height_Name);

                RuleFor(x => x.BodyMass)
                    .NotEmpty()
                    .WithName(Resources.ProfileBioModel.BodyMass_Name);
            });

            RuleSet("LIFESTYLE", () =>
            {
                RuleFor(x => x.Drink)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.Drink_Name);

                RuleFor(x => x.Smoke)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.Smoke_Name);

                RuleFor(x => x.Diet)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.Diet_Name);

                RuleFor(x => x.Religion)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.Religion_Name);

                RuleFor(x => x.HaveChildren)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.HaveChildren_Name);

                RuleFor(x => x.EducationLevel)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.EducationLevel_Name);

                RuleFor(x => x.CareerCluster)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.CareerCluster_Name);

                RuleFor(x => x.TravelFrequency)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.TravelFrequency_Name);
            });

            RuleSet("PERSONALITY", () =>
            {
                //none here
            });

            RuleSet("INTEREST", () =>
            {
                RuleFor(x => x.Food)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.Vacation)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.Sports)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.LeisureActivities)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.MusicGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.MovieGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.TVGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));

                RuleFor(x => x.ReadingGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3));
            });

            RuleSet("GOAL", () =>
            {
                RuleFor(x => x.Intentions)
                   .NotEmpty()
                   .Must((value) => value.Count <= 2)
                   .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 2))
                   .WithName(Resources.ProfileBasicModel.Intentions_Name);

                RuleFor(x => x.WantChildren)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.WantChildren_Name);

                RuleFor(x => x.Relocation)
                    .NotEmpty();
            });
        }
    }
}