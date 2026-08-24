using Bogus;
using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Api.Module.Cosmos.Authenticated;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfileMatchesComponent
    {
        [Parameter] public ProfileModel? Profile { get; set; }
        [Parameter] public FilterModel? Filter { get; set; }

        private RenderControlState<MyMatchesModel?> MatchesState { get; } = new(null, obj => obj == null || obj.Items.Empty());
        private HashSet<ProfileModel> fakeProfiles { get; set; } = [];

        protected override IReadOnlyList<string> GetParameterKey()
        {
            return [
                Profile?.Id ?? "",
                Filter?.Id ?? "",
            ];
        }

        protected override async Task LoadParameterDataAsync()
        {
            await MyMatchesApi.Get(setNewVersion: false, [MatchesState], Cts.Token);
        }

        private async Task SimulateMatches()
        {
            if (Profile == null)
            {
                await ShowWarning("You need to complete your profile first. (Step 1)");
                return;
            }

            if (Filter == null)
            {
                await ShowWarning("You need to define your filters first. (Step 2)");
                return;
            }

            if (await DialogService.ShowMessageBoxAsync(Translations.Notification.Confirmation, Translations.Module.Profile.GenerateSimulation, Translations.Button.Ok, Translations.Button.Cancel) ?? false)
            {
                var MyMatches = new MyMatchesModel(AppStateStatic.UserId);
                await MatchesState.StartLoading.Invoke(null);

                fakeProfiles = [.. new Faker<ProfileModel>()
                    .CustomInstantiator(f => new ProfileModel(f.Random.Guid().ToString()))
                    .RuleFor(u => u.Gallery, f => new ProfileGalleryModel { FaceId = $"https://api.dicebear.com/9.x/avataaars/svg?size=300&seed=example={f.Random.Guid()}" })
                    //BASIC
                    .RuleFor(x => x.NickName, f => f.Name.FirstName())
                    .RuleFor(x => x.Description, f => f.Lorem.Text())
                    .RuleFor(x => x.Nationality, f => f.PickRandom<Country>())
                    .RuleFor(x => x.Country, f => f.Address.Country())
                    .RuleFor(x => x.State, f => f.Address.County())
                    .RuleFor(x => x.City, f => f.Address.City())
                    .RuleFor(x => x.Languages, f => f.Random.EnumValues<Language>(f.Random.Int(1, 3)).ToHashSet())
                    .RuleFor(x => x.MaritalStatus, f => f.PickRandom<MaritalStatus>())
                    .RuleFor(x => x.BiologicalSex, f => f.PickRandom<BiologicalSex>())
                    .RuleFor(x => x.GenderIdentities, f => f.Random.EnumValues<GenderIdentity>(f.Random.Int(1, 2)).ToHashSet())
                    .RuleFor(x => x.SexualOrientations, f => f.Random.EnumValues<SexualOrientation>(f.Random.Int(1, 2)).ToHashSet())
                    //BIO
                    .RuleFor(x => x.Ethnicity, f => f.PickRandom<Ethnicity>())
                    .RuleFor(x => x.BodyType, f => f.PickRandom<BodyType>())
                    .RuleFor(x => x.BirthDate, f => f.Date.Between(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-19)))
                    .RuleFor(x => x.Age, f => f.Random.Int(18, 80))
                    .RuleFor(x => x.Height, f => f.PickRandom<Height>())
                    .RuleFor(x => x.Neurodiversity, f => f.PickRandom<Neurodiversity>())
                    .RuleFor(x => x.Disabilities, f => f.Random.EnumValues<Disability>(f.Random.Int(0, 1)).ToHashSet())
                    //LIFESTYLE
                    .RuleFor(x => x.Drink, f => f.PickRandom<Drink>())
                    .RuleFor(x => x.Smoke, f => f.PickRandom<Smoke>())
                    .RuleFor(x => x.Diet, f => f.PickRandom<Diet>())
                    .RuleFor(x => x.Religion, f => f.PickRandom<Religion>())
                    .RuleFor(x => x.FamilyInvolvement, f => f.PickRandom<FamilyInvolvement>())
                    .RuleFor(x => x.HaveChildren, f => f.PickRandom<HaveChildren>())
                    .RuleFor(x => x.HavePets, f => f.PickRandom<HavePets>())
                    .RuleFor(x => x.EducationLevel, f => f.PickRandom<EducationLevel>())
                    .RuleFor(x => x.CareerCluster, f => f.PickRandom<CareerCluster>())
                    .RuleFor(x => x.LivingSituation, f => f.PickRandom<LivingSituation>())
                    .RuleFor(x => x.TravelFrequency, f => f.PickRandom<TravelFrequency>())
                    .RuleFor(x => x.NetWorth, f => f.PickRandom<NetWorth>())
                    .RuleFor(x => x.AnnualIncome, f => f.PickRandom<AnnualIncome>())
                    //PERSONALITY
                    .RuleFor(x => x.MoneyPersonality, f => f.PickRandom<MoneyPersonality>())
                    .RuleFor(x => x.SharedSpendingStyle, f => f.PickRandom<SharedSpendingStyle>())
                    .RuleFor(x => x.RelationshipPersonality, f => f.PickRandom<RelationshipPersonality>())
                    .RuleFor(x => x.MBTI, f => f.PickRandom<MyersBriggsTypeIndicator>())
                    .RuleFor(x => x.LoveLanguage, f => f.PickRandom<LoveLanguage>())
                    .RuleFor(x => x.SexPersonality, f => f.PickRandom<SexPersonality>())
                    .RuleFor(x => x.SexPersonalityPreference, f => f.Random.EnumValues<SexPersonality>(f.Random.Int(1, 3)).ToHashSet())
                    //INTEREST
                    .RuleFor(x => x.Food, f => f.Random.EnumValues<Food>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.Vacation, f => f.Random.EnumValues<Vacation>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.Sports, f => f.Random.EnumValues<Sports>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.LeisureActivities, f => f.Random.EnumValues<LeisureActivities>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.MusicGenre, f => f.Random.EnumValues<MusicGenre>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.MovieGenre, f => f.Random.EnumValues<MovieGenre>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.TVGenre, f => f.Random.EnumValues<TVGenre>(f.Random.Int(0, 3)).ToHashSet())
                    .RuleFor(x => x.ReadingGenre, f => f.Random.EnumValues<ReadingGenre>(f.Random.Int(0, 3)).ToHashSet())
                    //RELATIONSHIP
                    .RuleFor(x => x.SharedFinances, f => f.PickRandom<SharedFinances>())
                    .RuleFor(x => x.ConflictResolutionStyle, f => f.PickRandom<ConflictResolutionStyle>())
                    .RuleFor(x => x.HouseholdManagement, f => f.PickRandom<HouseholdManagement>())
                    .RuleFor(x => x.TimeTogetherPreference, f => f.PickRandom<TimeTogetherPreference>())
                    .RuleFor(x => x.OppositeSexFriendships, f => f.PickRandom<OppositeSexFriendships>())
                    //GOAL
                    .RuleFor(x => x.RelationshipIntentions, f => f.Random.EnumValues<RelationshipIntention>(f.Random.Int(1, 2)).ToHashSet())
                    .RuleFor(x => x.WantChildren, f => f.PickRandom<WantChildren>())
                    .RuleFor(x => x.Relocation, f => f.PickRandom<Relocation>())
                    .RuleFor(x => x.IdealPlaceToLive, f => f.PickRandom<IdealPlaceToLive>())
                .GenerateLazy(8)];

                MyMatches.Items = fakeProfiles.Select(s => new PersonModel { UserId = s.Id, UserName = s.NickName, UserPhoto = s.Gallery?.FaceId, Fake = true }).ToHashSet();

                await MatchesState.FinishLoading.Invoke(MyMatches);
            }
        }
    }
}