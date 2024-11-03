using FluentValidation;

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

                RuleFor(x => x.Nationality)
                  .NotEmpty()
                  .WithName("Nationality");

                RuleFor(x => x.Location)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.Location_Name);

                RuleFor(x => x.Languages)
                  .NotEmpty()
                  .Must((value) => value.Count <= 3)
                  .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileBasicModel.Languages_Name))
                  .WithName(Resources.ProfileBasicModel.Languages_Name);

                RuleFor(x => x.MaritalStatus)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.MaritalStatus_Name);

                RuleFor(x => x.BiologicalSex)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.BiologicalSex_Name);

                RuleFor(x => x.GenderIdentities)
                    .NotEmpty()
                    .Must((value) => value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileBasicModel.GenderIdentity_Name))
                    .WithName(Resources.ProfileBasicModel.GenderIdentity_Name);

                RuleFor(x => x.SexualOrientations)
                    .NotEmpty()
                    .Must((value) => value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileBasicModel.SexualOrientation_Name))
                    .WithName(Resources.ProfileBasicModel.SexualOrientation_Name);
            });

            RuleSet("BIO", () =>
            {
                RuleFor(x => x.Ethnicity)
                  .NotEmpty()
                  .WithName(Resources.ProfileBioModel.Ethnicity);

                RuleFor(x => x.BodyType)
                  .NotEmpty()
                  .WithName(Resources.ProfileBioModel.BodyType);

                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage(Shared.Resources.Validations.OlderToRegister);

                RuleFor(x => x.Height)
                    .NotEmpty()
                    .WithName(Resources.ProfileBioModel.Height_Name);
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

                RuleFor(x => x.FamilyInvolvement)
                   .NotEmpty()
                   .WithName("Family Involvement");

                RuleFor(x => x.HaveChildren)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.HaveChildren_Name);

                RuleFor(x => x.EducationLevel)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.EducationLevel_Name);

                RuleFor(x => x.CareerCluster)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.CareerCluster_Name);

                RuleFor(x => x.LivingSituation)
                   .NotEmpty()
                   .WithName("Living Situation");

                RuleFor(x => x.TravelFrequency)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.TravelFrequency_Name);
            });

            RuleSet("PERSONALITY", () =>
            {
                RuleFor(x => x.MoneyPersonality)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.MoneyPersonality_Name);

                RuleFor(x => x.SharedSpendingStyle)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.SharedSpendingStyle_Name);

                RuleFor(x => x.RelationshipPersonality)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.SharedSpendingStyle_Name);

                RuleFor(x => x.MBTI)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.MBTI_Name);

                RuleFor(x => x.LoveLanguage)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.LoveLanguage_Name);

                RuleFor(x => x.SexPersonality)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.SexPersonality_Name);

                RuleFor(x => x.SexPersonalityPreference)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.SexPersonalityPreferences_Name);
            });

            RuleSet("INTEREST", () =>
            {
                RuleFor(x => x.Food)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.Food));

                RuleFor(x => x.Vacation)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.Vacation));

                RuleFor(x => x.Sports)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.Sports));

                RuleFor(x => x.LeisureActivities)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.LeisureActivities));

                RuleFor(x => x.MusicGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.MusicGenre));

                RuleFor(x => x.MovieGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.MovieGenre));

                RuleFor(x => x.TVGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.TVGenre));

                RuleFor(x => x.ReadingGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileInterestModel.ReadingGenre));
            });

            RuleSet("GOAL", () =>
            {
                RuleFor(x => x.RelationshipIntentions)
                   .NotEmpty()
                   .Must((value) => value.Count <= 2)
                   .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 2, Resources.ProfileBasicModel.RelationshipIntentions_Name))
                   .WithName(Resources.ProfileBasicModel.RelationshipIntentions_Name);

                RuleFor(x => x.WantChildren)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.WantChildren_Name);

                RuleFor(x => x.Relocation)
                    .NotEmpty();
            });
        }
    }
}