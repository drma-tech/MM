namespace MM.Shared.Models.Profile
{
    public class FilterModel : PrivateMainDocument
    {
        public FilterModel() : base(DocumentType.Filter)
        {
        }

        #region BASIC

        [Custom(Name = "Region", ResourceType = typeof(Resources.FilterModel))]
        public Region Region { get; set; }

        [Custom(Name = "Nationality")]
        public HashSet<Country> Nationality { get; set; } = [];

        [Custom(Name = "Languages", Description = "Languages_Description", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<Language> Languages { get; set; } = [];

        [Custom(Name = "MaritalStatus", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<MaritalStatus> MaritalStatus { get; set; } = [];

        [Custom(Name = "BiologicalSex", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<BiologicalSex> BiologicalSex { get; set; } = [];

        [Custom(Name = "GenderIdentity", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];

        [Custom(Name = "SexualOrientation", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

        #endregion BASIC

        #region BIO

        [Custom(Name = "Ethnicity", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<Ethnicity> Ethnicity { get; set; } = [];

        [Custom(Name = "BodyType", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<BodyType> BodyType { get; set; } = [];

        [Custom(Name = "MinimalAge", ResourceType = typeof(Resources.FilterModel))]
        public int? MinimalAge { get; set; }

        [Custom(Name = "MaxAge", ResourceType = typeof(Resources.FilterModel))]
        public int? MaxAge { get; set; }

        [Custom(Name = "MinimalHeight", ResourceType = typeof(Resources.FilterModel))]
        public Height? MinimalHeight { get; set; }

        [Custom(Name = "MaxHeight", ResourceType = typeof(Resources.FilterModel))]
        public Height? MaxHeight { get; set; }

        [Custom(Name = "Neurodiversities", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<Neurodiversity> Neurodiversities { get; set; } = [];

        [Custom(Name = "Disabilities", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<Disability> Disabilities { get; set; } = [];

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<Drink> Drink { get; set; } = [];

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<Smoke> Smoke { get; set; } = [];

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<Diet> Diet { get; set; } = [];

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<Religion> Religion { get; set; } = [];

        [Custom(Name = "Family Involvement")]
        public HashSet<FamilyInvolvement> FamilyInvolvement { get; set; } = [];

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<HaveChildren> HaveChildren { get; set; } = [];

        [Custom(Name = "Have Pets")]
        public HashSet<HavePets> HavePets { get; set; } = [];

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<EducationLevel> EducationLevel { get; set; } = [];

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<CareerCluster> CareerCluster { get; set; } = [];

        [Custom(Name = "Living Situation")]
        public HashSet<LivingSituation> LivingSituation { get; set; } = [];

        [Custom(Name = "Travel Frequency")]
        public HashSet<TravelFrequency> TravelFrequency { get; set; } = [];

        [Custom(Name = "Net Worth", Description = "It is necessary to check the field before using it as a filter.")]
        public HashSet<NetWorth> NetWorth { get; set; } = [];

        [Custom(Name = "Annual Income", Description = "It is necessary to check the field before using it as a filter.")]
        public HashSet<AnnualIncome> AnnualIncome { get; set; } = [];

        #endregion LIFESTYLE

        #region PERSONALITY

        [Custom(Name = "Money Personality")]
        public bool MoneyPersonality { get; set; }

        [Custom(Name = "Shared Spending Style")]
        public bool SharedSpendingStyle { get; set; }

        [Custom(Name = "Relationship Personality")]
        public bool RelationshipPersonality { get; set; }

        [Custom(Name = "MBTI Personality")]
        public bool MyersBriggsTypeIndicator { get; set; }

        [Custom(Name = "Love Language")]
        public bool LoveLanguage { get; set; }

        [Custom(Name = "Sex Personality")]
        public bool SexPersonality { get; set; }

        #endregion PERSONALITY

        #region INTEREST

        [Custom(Name = "Food", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<Food> Food { get; set; } = [];

        [Custom(Name = "Vacation", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<Vacation> Vacation { get; set; } = [];

        [Custom(Name = "Sports", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<Sports> Sports { get; set; } = [];

        [Custom(Name = "LeisureActivities", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<LeisureActivities> LeisureActivities { get; set; } = [];

        [Custom(Name = "MusicGenre", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<MusicGenre> MusicGenre { get; set; } = [];

        [Custom(Name = "MovieGenre", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<MovieGenre> MovieGenre { get; set; } = [];

        [Custom(Name = "TVGenre", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<TVGenre> TVGenre { get; set; } = [];

        [Custom(Name = "ReadingGenre", ResourceType = typeof(Resources.ProfileInterestModel))]
        public HashSet<ReadingGenre> ReadingGenre { get; set; } = [];

        #endregion INTEREST

        #region RELATIONSHIP

        [Custom(Name = "Shared Finances")]
        public HashSet<SharedFinances> SharedFinances { get; set; } = [];

        [Custom(Name = "Conflict Resolution Style")]
        public HashSet<ConflictResolutionStyle> ConflictResolutionStyle { get; set; } = [];

        [Custom(Name = "Household Management")]
        public HashSet<HouseholdManagement> HouseholdManagement { get; set; } = [];

        [Custom(Name = "Time Together Preference")]
        public HashSet<TimeTogetherPreference> TimeTogetherPreference { get; set; } = [];

        [Custom(Name = "Opposite-Sex Friendships")]
        public HashSet<OppositeSexFriendships> OppositeSexFriendships { get; set; } = [];

        #endregion RELATIONSHIP

        #region GOALS

        [Custom(Name = "RelationshipIntentions", ResourceType = typeof(Resources.ProfileGoalModel))]
        public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];

        [Custom(Name = "Relocation", ResourceType = typeof(Resources.ProfileGoalModel))]
        public Relocation? Relocation { get; set; }

        [Custom(Name = "WantChildren", ResourceType = typeof(Resources.ProfileGoalModel))]
        public HashSet<WantChildren> WantChildren { get; set; } = [];

        [Custom(Name = "IdealPlaceToLive", ResourceType = typeof(Resources.ProfileGoalModel))]
        public HashSet<IdealPlaceToLive> IdealPlaceToLive { get; set; } = [];

        #endregion GOALS

        public override bool HasValidData()
        {
            throw new NotImplementedException();
        }
    }
}