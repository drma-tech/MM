using MM.Shared.Core.Types;

namespace MM.Shared.Models.Profile;

public class FilterModel(string? id) : MainDocument(new MainIdentity(MainType.Filter, id))
{
    #region BASIC

    public Region Region { get; set; }
    public IReadOnlyCollection<Country> Nationality { get; set; } = [];
    public IReadOnlyCollection<Language> Languages { get; set; } = [];
    public IReadOnlyCollection<MaritalStatus> MaritalStatus { get; set; } = [];
    public IReadOnlyCollection<BiologicalSex> BiologicalSex { get; set; } = [];
    public IReadOnlyCollection<GenderIdentity> GenderIdentities { get; set; } = [];
    public IReadOnlyCollection<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    public IReadOnlyCollection<Ethnicity> Ethnicity { get; set; } = [];
    public IReadOnlyCollection<BodyType> BodyType { get; set; } = [];
    public int? MinimalAge { get; set; }
    public int? MaxAge { get; set; }
    public Height? MinimalHeight { get; set; }
    public Height? MaxHeight { get; set; }
    public IReadOnlyCollection<Neurodiversity> Neurodiversity { get; set; } = [];
    public IReadOnlyCollection<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    public IReadOnlyCollection<Drink> Drink { get; set; } = [];
    public IReadOnlyCollection<Smoke> Smoke { get; set; } = [];
    public IReadOnlyCollection<Diet> Diet { get; set; } = [];
    public IReadOnlyCollection<Religion> Religion { get; set; } = [];
    public IReadOnlyCollection<FamilyInvolvement> FamilyInvolvement { get; set; } = [];
    public IReadOnlyCollection<HaveChildren> HaveChildren { get; set; } = [];
    public IReadOnlyCollection<HavePets> HavePets { get; set; } = [];
    public IReadOnlyCollection<EducationLevel> EducationLevel { get; set; } = [];
    public IReadOnlyCollection<CareerCluster> CareerCluster { get; set; } = [];
    public IReadOnlyCollection<LivingSituation> LivingSituation { get; set; } = [];
    public IReadOnlyCollection<TravelFrequency> TravelFrequency { get; set; } = [];
    public IReadOnlyCollection<NetWorth> NetWorth { get; set; } = [];
    public IReadOnlyCollection<AnnualIncome> AnnualIncome { get; set; } = [];

    #endregion LIFESTYLE

    #region PERSONALITY

    public bool MoneyPersonality { get; set; }
    public bool SharedSpendingStyle { get; set; }
    public bool RelationshipPersonality { get; set; }
    public bool MyersBriggsTypeIndicator { get; set; }
    public bool LoveLanguage { get; set; }
    public bool SexPersonality { get; set; }

    #endregion PERSONALITY

    #region INTEREST

    public IReadOnlyCollection<Food> Food { get; set; } = [];
    public IReadOnlyCollection<Vacation> Vacation { get; set; } = [];
    public IReadOnlyCollection<Sports> Sports { get; set; } = [];
    public IReadOnlyCollection<LeisureActivities> LeisureActivities { get; set; } = [];
    public IReadOnlyCollection<MusicGenre> MusicGenre { get; set; } = [];
    public IReadOnlyCollection<MovieGenre> MovieGenre { get; set; } = [];
    public IReadOnlyCollection<TVGenre> TVGenre { get; set; } = [];
    public IReadOnlyCollection<ReadingGenre> ReadingGenre { get; set; } = [];

    #endregion INTEREST

    #region RELATIONSHIP

    public IReadOnlyCollection<SharedFinances> SharedFinances { get; set; } = [];
    public IReadOnlyCollection<ConflictResolutionStyle> ConflictResolutionStyle { get; set; } = [];
    public IReadOnlyCollection<HouseholdManagement> HouseholdManagement { get; set; } = [];
    public IReadOnlyCollection<TimeTogetherPreference> TimeTogetherPreference { get; set; } = [];
    public IReadOnlyCollection<OppositeSexFriendships> OppositeSexFriendships { get; set; } = [];

    #endregion RELATIONSHIP

    #region GOALS

    public IReadOnlyCollection<RelationshipIntention> RelationshipIntentions { get; set; } = [];
    public Relocation? Relocation { get; set; }
    public IReadOnlyCollection<WantChildren> WantChildren { get; set; } = [];
    public IReadOnlyCollection<IdealPlaceToLive> IdealPlaceToLive { get; set; } = [];

    #endregion GOALS

    protected override object?[] EqualityValues => [Id];
}