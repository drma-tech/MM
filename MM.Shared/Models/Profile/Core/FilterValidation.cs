using FluentValidation;

namespace MM.Shared.Models.Profile.Core
{
    public class FilterValidation : AbstractValidator<FilterModel>
    {
        public FilterValidation()
        {
            //BASIC

            RuleFor(x => x.Region)
                .NotEmpty();

            RuleFor(x => x.Nationality)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Nationality"))
                .WithName("Nationality");

            RuleFor(x => x.Languages)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, Resources.ProfileBasicModel.Languages_Name))
                .WithName(Resources.ProfileBasicModel.Languages_Name);

            RuleFor(x => x.MaritalStatus)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Marital Status"))
                .WithName("Marital Status");

            RuleFor(x => x.BiologicalSex)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Biological Sex"))
                .WithName("Biological Sex");

            RuleFor(x => x.GenderIdentities)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Gender Identities"))
                .WithName("Gender Identities");

            RuleFor(x => x.SexualOrientations)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Sexual Orientations"))
                .WithName("Sexual Orientations");

            //BIO

            RuleFor(x => x.Ethnicity)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Ethnicity"))
                .WithName("Ethnicity");

            RuleFor(x => x.BodyType)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Body Type"))
                .WithName("Body Type");

            RuleFor(x => x.Neurodiversities)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Neurodiversities"))
                .WithName("Neurodiversities");

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

            RuleFor(x => x.Disabilities)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Disabilities"))
                .WithName("Disabilities");

            //LIFESTYLE

            RuleFor(x => x.Drink)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Drink"))
                .WithName("Drink");

            RuleFor(x => x.Smoke)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Smoke"))
                .WithName("Smoke");

            RuleFor(x => x.Diet)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Diet"))
                .WithName("Diet");

            RuleFor(x => x.Religion)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Religion"))
                .WithName("Religion");

            RuleFor(x => x.FamilyInvolvement)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Family Involvement"))
                .WithName("Family Involvement");

            RuleFor(x => x.NetWorth)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Net Worth"))
                .WithName("Net Worth");

            RuleFor(x => x.HaveChildren)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Have Children"))
                .WithName("Have Children");

            RuleFor(x => x.HavePets)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Have Pets"))
                .WithName("Have Pets");

            RuleFor(x => x.EducationLevel)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Education Level"))
                .WithName("Education Level");

            RuleFor(x => x.CareerCluster)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Career Cluster"))
                .WithName("Career Cluster");

            RuleFor(x => x.LivingSituation)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Living Situation"))
                .WithName("Living Situation");

            RuleFor(x => x.TravelFrequency)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Travel Frequency"))
                .WithName("Travel Frequency");

            RuleFor(x => x.AnnualIncome)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Annual Income"))
                .WithName("Annual Income");

            //INTEREST

            RuleFor(x => x.Food)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Food"))
                .WithName("Food");

            RuleFor(x => x.Vacation)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Vacation"))
                .WithName("Vacation");

            RuleFor(x => x.Sports)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Sports"))
                .WithName("Sports");

            RuleFor(x => x.LeisureActivities)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Leisure Activities"))
                .WithName("Leisure Activities");

            RuleFor(x => x.MusicGenre)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Music Genre"))
                .WithName("Music Genre");

            RuleFor(x => x.MovieGenre)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Movie Genre"))
                .WithName("Movie Genre");

            RuleFor(x => x.TVGenre)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "TV Genre"))
                .WithName("TV Genre");

            RuleFor(x => x.ReadingGenre)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Reading Genre"))
                .WithName("Reading Genre");

            //RELATIONSHIP

            RuleFor(x => x.SharedFinances)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Shared Finances"))
                .WithName("Shared Finances");

            RuleFor(x => x.ConflictResolutionStyle)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Conflict Resolution Style"))
                .WithName("Conflict Resolution Style");

            RuleFor(x => x.HouseholdManagement)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Household Management"))
                .WithName("Household Management");

            RuleFor(x => x.TimeTogetherPreference)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Time Together Preference"))
                .WithName("Time Together Preference");

            RuleFor(x => x.OppositeSexFriendships)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Opposite-Sex Friendships"))
                .WithName("Opposite-Sex Friendships");

            //GOALS

            RuleFor(x => x.RelationshipIntentions)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Relationship Intentions"))
                .WithName("Relationship Intentions");

            RuleFor(x => x.WantChildren)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Want Children"))
                .WithName("Want Children");

            RuleFor(x => x.IdealPlaceToLive)
                .Must((value) => value.Count <= 3)
                .WithMessage(string.Format(Shared.Resources.Validations.ChooseMaximumOptions, 3, "Ideal Place to Live"))
                .WithName("Ideal Place to Live");
        }
    }
}