using FluentValidation;

namespace MM.Shared.Models.Profile.Core
{
    public class ProfileValidation : AbstractValidator<ProfileModel>
    {
        public ProfileValidation()
        {
            RuleSet("BASIC", () =>
            {
                RuleFor(x => x.Modality)
                    .NotEmpty()
                    .Must((value) => value == Modality.RelationshipAnalysis).WithMessage("Modalidade Matchmaker ainda não disponível")
                    .WithName(Resources.ProfileBasicModel.Modality_Name);

                RuleFor(x => x.NickName)
                    .NotEmpty()
                    .MaximumLength(20)
                    .WithName(Resources.ProfileBasicModel.NickName_Name);

                RuleFor(x => x.Description)
                    .NotEmpty().When(x => x.Modality == Modality.Matchmaker)
                    .MaximumLength(512)
                    .WithName(Resources.ProfileBasicModel.Description_Name);

                RuleFor(x => x.Location)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.Location_Name);

                RuleFor(x => x.CurrentSituation)
                    .NotEmpty().When(x => x.Modality == Modality.Matchmaker)
                    .WithName(Resources.ProfileBasicModel.CurrentSituation_Name);

                RuleFor(x => x.Intentions)
                    .NotEmpty()
                    .Must((value) => value.Count <= 2)
                    .WithMessage("Escolha até no máximo duas intenções")
                    .WithName(Resources.ProfileBasicModel.Intentions_Name);

                RuleFor(x => x.BiologicalSex)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.BiologicalSex_Name);

                RuleFor(x => x.GenderIdentity)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.GenderIdentity_Name);

                RuleFor(x => x.SexualOrientation)
                    .NotEmpty()
                    .WithName(Resources.ProfileBasicModel.SexualOrientation_Name);

                RuleFor(x => x.Languages)
                    .NotEmpty()
                    .Must((value) => value.Count <= 5)
                    .WithMessage("Escolha até no máximo cinco idiomas")
                    .WithName(Resources.ProfileBasicModel.Languages_Name);
            });

            RuleSet("BIO", () =>
            {
                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTime.UtcNow.AddYears(-18).Date).WithMessage("Você deve ter 18 ou mais para se registrar");

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

                RuleFor(x => x.WantChildren)
                    .NotEmpty()
                    .WithName(Resources.ProfileLifestyleModel.WantChildren_Name);

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
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.Vacation)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.Sports)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.LeisureActivities)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.MusicGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.MovieGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.TVGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");

                RuleFor(x => x.ReadingGenre)
                    .Must((value) => value == null || value.Count <= 3)
                    .WithMessage("Escolha até no máximo três opções");
            });

            RuleSet("MYRELATIONSHIP", () =>
            {
                RuleFor(x => x.Partners)
                    .Must((value) => value != null && value.Count > 0).When(x => x.Modality == Modality.RelationshipAnalysis)
                    .WithMessage("Você deve convidar seu parceiro(a) ou aceitar o convite recebido");
            });
        }
    }
}