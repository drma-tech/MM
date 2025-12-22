using FluentValidation;
using MM.Shared.Models.Profile.Resources;
using MM.Shared.Resources;

namespace MM.Shared.Models.Profile.Core;

public class ProfileValidation : AbstractValidator<ProfileModel>
{
    public ProfileValidation()
    {
        RuleSet("BASIC", () =>
        {
            RuleFor(x => x.NickName)
                .NotEmpty()
                .MaximumLength(18).WithMessage("Nickname must be 18 characters or fewer.")
                 .Must(n => !StringHelper.IsLikelySpam(n)).WithMessage("Nickname contains suspicious or spam-like content.")
                .WithName(ProfileBasicModel.NickName_Name);

            RuleFor(x => x.Description)
                .MaximumLength(512).WithMessage("Description must be 512 characters or fewer.")
                 .Must(d => !StringHelper.IsLikelySpam(d)).WithMessage("Description contains suspicious or spam-like content.")
                .WithName(ProfileBasicModel.Description_Name);

            RuleFor(x => x.Nationality)
                .NotEmpty()
                .WithName("Nationality");

            RuleFor(x => x.Location)
                .NotEmpty()
                .WithName(ProfileBasicModel.Location_Name);

            RuleFor(x => x.Languages)
                .NotEmpty()
                .Must(value => value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileBasicModel.Languages_Name))
                .WithName(ProfileBasicModel.Languages_Name);

            RuleFor(x => x.MaritalStatus)
                .NotEmpty()
                .WithName(ProfileBasicModel.MaritalStatus_Name);

            RuleFor(x => x.BiologicalSex)
                .NotEmpty()
                .WithName(ProfileBasicModel.BiologicalSex_Name);

            RuleFor(x => x.GenderIdentities)
                .NotEmpty()
                .Must(value => value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileBasicModel.GenderIdentity_Name))
                .WithName(ProfileBasicModel.GenderIdentity_Name);

            RuleFor(x => x.SexualOrientations)
                .NotEmpty()
                .Must(value => value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3,
                    ProfileBasicModel.SexualOrientation_Name))
                .WithName(ProfileBasicModel.SexualOrientation_Name);
        });

        RuleSet("BIO", () =>
        {
            RuleFor(x => x.Ethnicity)
                .NotEmpty()
                .WithName(ProfileBioModel.Ethnicity_Name);

            RuleFor(x => x.BodyType)
                .NotEmpty()
                .WithName(ProfileBioModel.BodyType_Name);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage(Validations.OlderToRegister);

            RuleFor(x => x.Height)
                .NotEmpty()
                .WithName(ProfileBioModel.Height_Name);
        });

        RuleSet("LIFESTYLE", () =>
        {
            RuleFor(x => x.Drink)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.Drink_Name);

            RuleFor(x => x.Smoke)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.Smoke_Name);

            RuleFor(x => x.Diet)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.Diet_Name);

            RuleFor(x => x.Religion)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.Religion_Name);

            RuleFor(x => x.FamilyInvolvement)
                .NotEmpty()
                .WithName("Family Involvement");

            RuleFor(x => x.HaveChildren)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.HaveChildren_Name);

            RuleFor(x => x.HavePets)
                .NotEmpty()
                .WithName("Have Pets");

            RuleFor(x => x.EducationLevel)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.EducationLevel_Name);

            RuleFor(x => x.CareerCluster)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.CareerCluster_Name);

            RuleFor(x => x.LivingSituation)
                .NotEmpty()
                .WithName("Living Situation");

            RuleFor(x => x.TravelFrequency)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.TravelFrequency_Name);
        });

        RuleSet("PERSONALITY", () =>
        {
            RuleFor(x => x.MoneyPersonality)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.MoneyPersonality_Name);

            RuleFor(x => x.SharedSpendingStyle)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.SharedSpendingStyle_Name);

            RuleFor(x => x.RelationshipPersonality)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.SharedSpendingStyle_Name);

            RuleFor(x => x.MBTI)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.MBTI_Name);

            RuleFor(x => x.LoveLanguage)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.LoveLanguage_Name);

            RuleFor(x => x.SexPersonality)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.SexPersonality_Name);

            RuleFor(x => x.SexPersonalityPreference)
                .NotEmpty()
                .WithName(ProfileLifestyleModel.SexPersonalityPreferences_Name);
        });

        RuleSet("INTEREST", () =>
        {
            RuleFor(x => x).Must(value => AtLeastThreeInterests(value))
                .WithMessage("Fill in at least 3 interests");

            RuleFor(x => x.Food)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.Food));

            RuleFor(x => x.Vacation)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.Vacation));

            RuleFor(x => x.Sports)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.Sports));

            RuleFor(x => x.LeisureActivities)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3,
                    ProfileInterestModel.LeisureActivities));

            RuleFor(x => x.MusicGenre)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.MusicGenre));

            RuleFor(x => x.MovieGenre)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.MovieGenre));

            RuleFor(x => x.TVGenre)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.TVGenre));

            RuleFor(x => x.ReadingGenre)
                .Must(value => value == null || value.Count <= 3)
                .WithMessage(string.Format(Validations.ChooseMaximumOptions, 3, ProfileInterestModel.ReadingGenre));
        });

        RuleSet("RELATIONSHIP", () =>
        {
            RuleFor(x => x.SharedFinances)
                .NotEmpty();

            RuleFor(x => x.ConflictResolutionStyle)
                .NotEmpty();

            RuleFor(x => x.HouseholdManagement)
                .NotEmpty();

            RuleFor(x => x.TimeTogetherPreference)
                .NotEmpty();

            RuleFor(x => x.OppositeSexFriendships)
                .NotEmpty();
        });

        RuleSet("GOAL", () =>
        {
            RuleFor(x => x.RelationshipIntentions)
                .NotEmpty()
                .Must(value => value.Count <= 2)
                .WithMessage(
                    string.Format(Validations.ChooseMaximumOptions, 2, ProfileGoalModel.RelationshipIntentions))
                .WithName(ProfileGoalModel.RelationshipIntentions);

            RuleFor(x => x.WantChildren)
                .NotEmpty()
                .WithName(ProfileGoalModel.WantChildren);

            RuleFor(x => x.Relocation)
                .NotEmpty()
                .WithName(ProfileGoalModel.Relocation);

            RuleFor(x => x.IdealPlaceToLive)
                .NotEmpty()
                .WithName(ProfileGoalModel.IdealPlaceToLive);
        });
    }

    private static bool AtLeastThreeInterests(ProfileModel profile)
    {
        var tot = 0;

        if (profile.Food.Count != 0) tot++;
        if (profile.Vacation.Count != 0) tot++;
        if (profile.Sports.Count != 0) tot++;
        if (profile.LeisureActivities.Count != 0) tot++;
        if (profile.MusicGenre.Count != 0) tot++;
        if (profile.MovieGenre.Count != 0) tot++;
        if (profile.TVGenre.Count != 0) tot++;
        if (profile.ReadingGenre.Count != 0) tot++;

        return tot >= 3;
    }
}