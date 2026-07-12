using MM.Shared.Translations.Model;

namespace MM.Shared.Models.Profile;

public class FilterModel : PrivateMainDocument
{
    public FilterModel() : base(DocumentType.Filter)
    {
    }

    #region BASIC

    [FieldSettings("Region", ResourceType = typeof(Translations.Model.FilterModel))]
    public Region Region { get; set; }

    [FieldSettings("Nationality", ResourceType = typeof(Translations.Model.FilterModel))]
    public HashSet<Country> Nationality { get; set; } = [];

    [FieldSettings("Languages_Name", Description = "Languages_Description", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<Language> Languages { get; set; } = [];

    [FieldSettings("MaritalStatus_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<MaritalStatus> MaritalStatus { get; set; } = [];

    [FieldSettings("BiologicalSex_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<BiologicalSex> BiologicalSex { get; set; } = [];

    [FieldSettings("GenderIdentity_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];

    [FieldSettings("SexualOrientation_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    [FieldSettings("Ethnicity_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Ethnicity> Ethnicity { get; set; } = [];

    [FieldSettings("BodyType_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<BodyType> BodyType { get; set; } = [];

    [FieldSettings("MinimalAge", ResourceType = typeof(Translations.Model.FilterModel))]
    public int? MinimalAge { get; set; }

    [FieldSettings("MaxAge", ResourceType = typeof(Translations.Model.FilterModel))]
    public int? MaxAge { get; set; }

    [FieldSettings("MinimalHeight", ResourceType = typeof(Translations.Model.FilterModel))]
    public Height? MinimalHeight { get; set; }

    [FieldSettings("MaxHeight", ResourceType = typeof(Translations.Model.FilterModel))]
    public Height? MaxHeight { get; set; }

    [FieldSettings("Neurodiversity_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Neurodiversity> Neurodiversity { get; set; } = [];

    [FieldSettings("Disabilities_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    [FieldSettings("Drink_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Drink> Drink { get; set; } = [];

    [FieldSettings("Smoke_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Smoke> Smoke { get; set; } = [];

    [FieldSettings("Diet_Name", Description = "Diet_Description", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Diet> Diet { get; set; } = [];

    [FieldSettings("Religion_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Religion> Religion { get; set; } = [];

    [FieldSettings("FamilyInvolvement_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<FamilyInvolvement> FamilyInvolvement { get; set; } = [];

    [FieldSettings("HaveChildren_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<HaveChildren> HaveChildren { get; set; } = [];

    [FieldSettings("HavePets_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<HavePets> HavePets { get; set; } = [];

    [FieldSettings("EducationLevel_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<EducationLevel> EducationLevel { get; set; } = [];

    [FieldSettings("CareerCluster_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<CareerCluster> CareerCluster { get; set; } = [];

    [FieldSettings("LivingSituation_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<LivingSituation> LivingSituation { get; set; } = [];

    [FieldSettings("TravelFrequency_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<TravelFrequency> TravelFrequency { get; set; } = [];

    [FieldSettings("NetWorth", Description = "NetWorth_Description", ResourceType = typeof(Translations.Model.FilterModel))]
    public HashSet<NetWorth> NetWorth { get; set; } = [];

    [FieldSettings("AnnualIncome", Description = "AnnualIncome_Description", ResourceType = typeof(Translations.Model.FilterModel))]
    public HashSet<AnnualIncome> AnnualIncome { get; set; } = [];

    #endregion LIFESTYLE

    #region PERSONALITY

    [FieldSettings("MoneyPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool MoneyPersonality { get; set; }

    [FieldSettings("SharedSpendingStyle_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool SharedSpendingStyle { get; set; }

    [FieldSettings("RelationshipPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool RelationshipPersonality { get; set; }

    [FieldSettings("MBTI_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool MyersBriggsTypeIndicator { get; set; }

    [FieldSettings("LoveLanguage_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool LoveLanguage { get; set; }

    [FieldSettings("SexPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool SexPersonality { get; set; }

    #endregion PERSONALITY

    #region INTEREST

    [FieldSettings("Food", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Food> Food { get; set; } = [];

    [FieldSettings("Vacation", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Vacation> Vacation { get; set; } = [];

    [FieldSettings("Sports", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Sports> Sports { get; set; } = [];

    [FieldSettings("LeisureActivities", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<LeisureActivities> LeisureActivities { get; set; } = [];

    [FieldSettings("MusicGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MusicGenre> MusicGenre { get; set; } = [];

    [FieldSettings("MovieGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MovieGenre> MovieGenre { get; set; } = [];

    [FieldSettings("TVGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<TVGenre> TVGenre { get; set; } = [];

    [FieldSettings("ReadingGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<ReadingGenre> ReadingGenre { get; set; } = [];

    #endregion INTEREST

    #region RELATIONSHIP

    [FieldSettings("SharedFinances", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<SharedFinances> SharedFinances { get; set; } = [];

    [FieldSettings("ConflictResolutionStyle", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<ConflictResolutionStyle> ConflictResolutionStyle { get; set; } = [];

    [FieldSettings("HouseholdManagement", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<HouseholdManagement> HouseholdManagement { get; set; } = [];

    [FieldSettings("TimeTogetherPreference", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<TimeTogetherPreference> TimeTogetherPreference { get; set; } = [];

    [FieldSettings("OppositeSexFriendships", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<OppositeSexFriendships> OppositeSexFriendships { get; set; } = [];

    #endregion RELATIONSHIP

    #region GOALS

    [FieldSettings("RelationshipIntentions", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];

    [FieldSettings("Relocation", ResourceType = typeof(ProfileGoalModel))]
    public Relocation? Relocation { get; set; }

    [FieldSettings("WantChildren", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<WantChildren> WantChildren { get; set; } = [];

    [FieldSettings("IdealPlaceToLive", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<IdealPlaceToLive> IdealPlaceToLive { get; set; } = [];

    #endregion GOALS
}