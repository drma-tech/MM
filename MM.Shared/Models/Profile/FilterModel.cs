using MM.Shared.Translations.Model;

namespace MM.Shared.Models.Profile;

public class FilterModel : PrivateMainDocument
{
    public FilterModel() : base(DocumentType.Filter)
    {
    }

    #region BASIC

    public Region Region { get; set; }
    public HashSet<Country> Nationality { get; set; } = [];
    public HashSet<Language> Languages { get; set; } = [];
    public HashSet<MaritalStatus> MaritalStatus { get; set; } = [];
    public HashSet<BiologicalSex> BiologicalSex { get; set; } = [];
    public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];
    public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    public HashSet<Ethnicity> Ethnicity { get; set; } = [];
    public HashSet<BodyType> BodyType { get; set; } = [];
    public int? MinimalAge { get; set; }
    public int? MaxAge { get; set; }
    public Height? MinimalHeight { get; set; }
    public Height? MaxHeight { get; set; }
    public HashSet<Neurodiversity> Neurodiversity { get; set; } = [];
    public HashSet<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    public HashSet<Drink> Drink { get; set; } = [];
    public HashSet<Smoke> Smoke { get; set; } = [];
    public HashSet<Diet> Diet { get; set; } = [];
    public HashSet<Religion> Religion { get; set; } = [];
    public HashSet<FamilyInvolvement> FamilyInvolvement { get; set; } = [];
    public HashSet<HaveChildren> HaveChildren { get; set; } = [];
    public HashSet<HavePets> HavePets { get; set; } = [];
    public HashSet<EducationLevel> EducationLevel { get; set; } = [];
    public HashSet<CareerCluster> CareerCluster { get; set; } = [];
    public HashSet<LivingSituation> LivingSituation { get; set; } = [];
    public HashSet<TravelFrequency> TravelFrequency { get; set; } = [];
    public HashSet<NetWorth> NetWorth { get; set; } = [];
    public HashSet<AnnualIncome> AnnualIncome { get; set; } = [];

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

    public HashSet<Food> Food { get; set; } = [];
    public HashSet<Vacation> Vacation { get; set; } = [];
    public HashSet<Sports> Sports { get; set; } = [];
    public HashSet<LeisureActivities> LeisureActivities { get; set; } = [];
    public HashSet<MusicGenre> MusicGenre { get; set; } = [];
    public HashSet<MovieGenre> MovieGenre { get; set; } = [];
    public HashSet<TVGenre> TVGenre { get; set; } = [];
    public HashSet<ReadingGenre> ReadingGenre { get; set; } = [];

    #endregion INTEREST

    #region RELATIONSHIP

    public HashSet<SharedFinances> SharedFinances { get; set; } = [];
    public HashSet<ConflictResolutionStyle> ConflictResolutionStyle { get; set; } = [];
    public HashSet<HouseholdManagement> HouseholdManagement { get; set; } = [];
    public HashSet<TimeTogetherPreference> TimeTogetherPreference { get; set; } = [];
    public HashSet<OppositeSexFriendships> OppositeSexFriendships { get; set; } = [];

    #endregion RELATIONSHIP

    #region GOALS

    public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];
    public Relocation? Relocation { get; set; }
    public HashSet<WantChildren> WantChildren { get; set; } = [];
    public HashSet<IdealPlaceToLive> IdealPlaceToLive { get; set; } = [];

    #endregion GOALS
}