using MM.Shared.Models.Profile.Resources;

namespace MM.Shared.Models.Profile;

public class FilterModel : PrivateMainDocument
{
    public FilterModel() : base(DocumentType.Filter)
    {
    }

    #region BASIC

    [Custom(Name = "Region", ResourceType = typeof(Resources.FilterModel))]
    public Region Region { get; set; }

    [Custom(Name = "Nationality", ResourceType = typeof(Resources.FilterModel))]
    public HashSet<Country> Nationality { get; set; } = [];

    [Custom(Name = "Languages_Name", Description = "Languages_Description", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<Language> Languages { get; set; } = [];

    [Custom(Name = "MaritalStatus_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<MaritalStatus> MaritalStatus { get; set; } = [];

    [Custom(Name = "BiologicalSex_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<BiologicalSex> BiologicalSex { get; set; } = [];

    [Custom(Name = "GenderIdentity_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];

    [Custom(Name = "SexualOrientation_Name", ResourceType = typeof(ProfileBasicModel))]
    public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    [Custom(Name = "Ethnicity_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Ethnicity> Ethnicity { get; set; } = [];

    [Custom(Name = "BodyType_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<BodyType> BodyType { get; set; } = [];

    [Custom(Name = "MinimalAge", ResourceType = typeof(Resources.FilterModel))]
    public int? MinimalAge { get; set; }

    [Custom(Name = "MaxAge", ResourceType = typeof(Resources.FilterModel))]
    public int? MaxAge { get; set; }

    [Custom(Name = "MinimalHeight", ResourceType = typeof(Resources.FilterModel))]
    public Height? MinimalHeight { get; set; }

    [Custom(Name = "MaxHeight", ResourceType = typeof(Resources.FilterModel))]
    public Height? MaxHeight { get; set; }

    [Custom(Name = "Neurodiversity_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Neurodiversity> Neurodiversities { get; set; } = [];

    [Custom(Name = "Disabilities_Name", ResourceType = typeof(ProfileBioModel))]
    public HashSet<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    [Custom(Name = "Drink_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Drink> Drink { get; set; } = [];

    [Custom(Name = "Smoke_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Smoke> Smoke { get; set; } = [];

    [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Diet> Diet { get; set; } = [];

    [Custom(Name = "Religion_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<Religion> Religion { get; set; } = [];

    [Custom(Name = "FamilyInvolvement_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<FamilyInvolvement> FamilyInvolvement { get; set; } = [];

    [Custom(Name = "HaveChildren_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<HaveChildren> HaveChildren { get; set; } = [];

    [Custom(Name = "HavePets_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<HavePets> HavePets { get; set; } = [];

    [Custom(Name = "EducationLevel_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<EducationLevel> EducationLevel { get; set; } = [];

    [Custom(Name = "CareerCluster_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<CareerCluster> CareerCluster { get; set; } = [];

    [Custom(Name = "LivingSituation_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<LivingSituation> LivingSituation { get; set; } = [];

    [Custom(Name = "TravelFrequency_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public HashSet<TravelFrequency> TravelFrequency { get; set; } = [];

    [Custom(Name = "NetWorth", Description = "NetWorth_Description", ResourceType = typeof(Resources.FilterModel))]
    public HashSet<NetWorth> NetWorth { get; set; } = [];

    [Custom(Name = "AnnualIncome", Description = "AnnualIncome_Description",
        ResourceType = typeof(Resources.FilterModel))]
    public HashSet<AnnualIncome> AnnualIncome { get; set; } = [];

    #endregion LIFESTYLE

    #region PERSONALITY

    [Custom(Name = "MoneyPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool MoneyPersonality { get; set; }

    [Custom(Name = "SharedSpendingStyle_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool SharedSpendingStyle { get; set; }

    [Custom(Name = "RelationshipPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool RelationshipPersonality { get; set; }

    [Custom(Name = "MBTI_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool MyersBriggsTypeIndicator { get; set; }

    [Custom(Name = "LoveLanguage_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool LoveLanguage { get; set; }

    [Custom(Name = "SexPersonality_Name", ResourceType = typeof(ProfileLifestyleModel))]
    public bool SexPersonality { get; set; }

    #endregion PERSONALITY

    #region INTEREST

    [Custom(Name = "Food", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Food> Food { get; set; } = [];

    [Custom(Name = "Vacation", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Vacation> Vacation { get; set; } = [];

    [Custom(Name = "Sports", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<Sports> Sports { get; set; } = [];

    [Custom(Name = "LeisureActivities", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<LeisureActivities> LeisureActivities { get; set; } = [];

    [Custom(Name = "MusicGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MusicGenre> MusicGenre { get; set; } = [];

    [Custom(Name = "MovieGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<MovieGenre> MovieGenre { get; set; } = [];

    [Custom(Name = "TVGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<TVGenre> TVGenre { get; set; } = [];

    [Custom(Name = "ReadingGenre", ResourceType = typeof(ProfileInterestModel))]
    public HashSet<ReadingGenre> ReadingGenre { get; set; } = [];

    #endregion INTEREST

    #region RELATIONSHIP

    [Custom(Name = "SharedFinances", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<SharedFinances> SharedFinances { get; set; } = [];

    [Custom(Name = "ConflictResolutionStyle", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<ConflictResolutionStyle> ConflictResolutionStyle { get; set; } = [];

    [Custom(Name = "HouseholdManagement", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<HouseholdManagement> HouseholdManagement { get; set; } = [];

    [Custom(Name = "TimeTogetherPreference", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<TimeTogetherPreference> TimeTogetherPreference { get; set; } = [];

    [Custom(Name = "OppositeSexFriendships", ResourceType = typeof(ProfileRelationshipModel))]
    public HashSet<OppositeSexFriendships> OppositeSexFriendships { get; set; } = [];

    #endregion RELATIONSHIP

    #region GOALS

    [Custom(Name = "RelationshipIntentions", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];

    [Custom(Name = "Relocation", ResourceType = typeof(ProfileGoalModel))]
    public Relocation? Relocation { get; set; }

    [Custom(Name = "WantChildren", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<WantChildren> WantChildren { get; set; } = [];

    [Custom(Name = "IdealPlaceToLive", ResourceType = typeof(ProfileGoalModel))]
    public HashSet<IdealPlaceToLive> IdealPlaceToLive { get; set; } = [];

    #endregion GOALS
}