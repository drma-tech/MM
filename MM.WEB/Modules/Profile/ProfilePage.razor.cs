using Bogus;
using FluentValidation;
using Microsoft.JSInterop;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Profile.Core;
using MudBlazor;

namespace MM.WEB.Modules.Profile
{
    public partial class ProfilePage
    {
        private RenderControlState<LastRegionUsersCache> LastUsersActions { get; } = new(obj => obj?.Data == null || obj.Data.Items.Empty());
        public LastRegionUsers? LastUsers { get; set; }
        private Country? CountryEnum;

        private ProfileValidation ProfileValidator { get; } = new();
        private ProfileModel? profile;

        private HashSet<ProfileModel> fakeProfiles { get; set; } = [];
        private RenderControlState<ProfileModel> ProfileActions { get; } = new(obj => obj == null);

        private FilterValidation FilterValidator { get; } = new();
        private FilterModel? filter;
        private RenderControlState<FilterModel> FilterActions { get; } = new(obj => obj == null);

        private PhotoValidation PhotoValidator { get; } = new();

        private SettingModel? setting;
        private RenderControlState<SettingModel> SettingActions { get; } = new(obj => obj == null);

        private ValidationModel? validation;

        private List<string> Suggestions { get; } = [];
        private RenderControlState<List<string>> SuggestionsActions { get; } = new(lst => lst == null || lst.Empty());

        private MyLikesModel? MyLikes { get; set; }
        private RenderControlState<MyLikesModel> LikesActions { get; } = new(obj => obj == null || obj.Items.Empty());

        private MyMatchesModel? MyMatches { get; set; }
        private RenderControlState<MyMatchesModel> MatchesActions { get; } = new(obj => obj == null || obj.Items.Empty());

        private static string imageSize => AppStateStatic.Size == Size.Small ? "20px" : "24px";
        private static string titleFontSize => AppStateStatic.Size == Size.Small ? "20px" : "24px";

        private bool ProfileValid => profile != null && ProfileValidator.Validate(profile, options => options.IncludeAllRuleSets()).IsValid;
        private bool FilterValid => filter != null && FilterValidator.Validate(filter).IsValid;
        private bool SettingValid => setting != null;
        private bool GalleryValid => profile?.Gallery != null && PhotoValidator.Validate(profile.Gallery).IsValid;
        private bool ValidationGeral => validation != null && validation.Gallery; //todo: implement the others when available
        private bool ValidationGallery => validation != null && validation.Gallery;
        private bool ValidationIdentity => validation != null && validation.Kyc;
        //private bool ValidationNetWorth => validation != null && validation.NetWorth;
        //private bool ValidationAnnualIncome => validation != null && validation.AnnualIncome;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ProfileApi.DataChanged += model =>
            {
                profile = model;
                StateHasChanged();
            };

            SuggestionsActions.CustomPremiumDescription = Translations.Module.Profile.FeatureNotAvailable.CustomFormat(2);
        }

        // protected override async Task OnAfterRenderAsync(bool firstRender)
        // {
        //     if (AppStateStatic.IsAuthenticated)
        //     {
        //         var subscription = await GetLocalStorage("subscription-popup");

        //         if (subscription.Empty())
        //         {
        //             await DialogService.SubscriptionPopup(AppStateStatic.IsAuthenticated);
        //             await SetLocalStorage("subscription-popup", true.ToString().ToLower());
        //         }
        //     }

        //     await base.OnAfterRenderAsync(firstRender);
        // }

        protected override async Task<bool> LoadInteropDataAsync(IJSRuntime JsRuntime)
        {
            var countryStr = await AppStateStatic.GetCountry(IpInfoApi, JsRuntime, Cts.Token);

            if (countryStr.NotEmpty())
            {
                CountryEnum = EnumHelper.ParseToEnum<Country>(countryStr);

                var cache2 = await LastRegionUsersApi.LastRegionUsers("compact", countryStr, LastUsersActions, Cts.Token);
                LastUsers = cache2?.Data;
            }
            else
            {
                await LastUsersActions.ShowError("It was not possible to determine your location.");
            }

            if (countryStr.NotEmpty() && (LastUsers?.Items.Empty() ?? true))
            {
                if (AppStateStatic.IsAuthenticated)
                    await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOn);
                else
                    await LastUsersActions.ShowWarning(Translations.Module.Profile.NoUsersYetOff);
            }

            return true;
        }

        protected override async Task LoadAuthenticatedDataAsync(CancellationToken token)
        {
            profile = await ProfileApi.Get(ProfileActions, token);
            filter = await FilterApi.Get(FilterActions, token);
            setting = await SettingApi.Get(SettingActions, token);
            validation = await ValidationApi.Get(token);

            //remove the loading status
            await SuggestionsActions.StartLoading.Invoke(null);
            await SuggestionsActions.FinishLoading.Invoke(null);

            MyLikes = await MyLikesApi.Get(setNewVersion: false, LikesActions, token);
            MyMatches = await MyMatchesApi.Get(setNewVersion: false, MatchesActions, token);
        }

        private static Color GetButtonColor(bool valid)
        {
            return valid ? Color.Success : Color.Warning;
        }

        private static string? GetButtonIcon(bool valid)
        {
            return valid ? IconsFA.Solid.Icon("check").Font : IconsFA.Solid.Icon("circle-question").Font;
        }

        private async Task IsPublicChanged(bool value)
        {
            try
            {
                if (value)
                {
                    if (!ProfileValid || !FilterValid || !SettingValid || !GalleryValid || !ValidationGeral)
                    {
                        await ShowWarning(Translations.Module.Profile.CompleteAllSteps);
                    }
                    else
                    {
                        await PrincipalApi.Public(Cts.Token);
                        await ShowSuccess(Translations.Module.Profile.ProfilePublicMode);
                    }
                }
                else
                {
                    await PrincipalApi.Private(Cts.Token);
                    await ShowSuccess(Translations.Module.Profile.ProfilePrivateMode);
                }
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
            }
        }

        private async Task GenerateSuggestions()
        {
            await ShowWarning(Translations.Module.Profile.FeatureNotAvailable.CustomFormat(2));
        }

        private async Task SimulateMatches()
        {
            if (profile == null)
            {
                await ShowWarning("You need to complete your profile first. (Step 1)");
                return;
            }

            if (filter == null)
            {
                await ShowWarning("You need to define your filters first. (Step 2)");
                return;
            }

            if (await DialogService.ShowMessageBoxAsync(Translations.Notification.Confirmation, Translations.Module.Profile.GenerateSimulation, Translations.Button.Ok, Translations.Button.Cancel) ?? false)
            {
                MyMatches = new MyMatchesModel(AppStateStatic.UserId);
                await MatchesActions.StartLoading.Invoke(null);

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

                await MatchesActions.FinishLoading.Invoke(MyMatches);
            }
        }

        private async Task Login()
        {
            Navigation.NavigateTo($"/{Culture}/auth/login?returnUrl={Uri.EscapeDataString(Navigation.Uri.Split('#')[0])}");
        }

        // private string GetSuggestionTitle()
        // {
        //     if (profile?.Preference?.Region == null) return "";

        //     switch (profile.Preference.Region)
        //     {
        //         case Region.City:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.City)}";
        //         case Region.State:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.State)}";
        //         case Region.Country:
        //             return $"{profile.Preference.Region.GetName()} - {profile?.GetLocation(ProfileModel.LocationType.Country)}";
        //         case Region.World:
        //             return $"{profile.Preference.Region.GetName()}";
        //         default:
        //             return "";
        //     }
        // }
    }
}