using MM.Shared.Translations.Model;
using Newtonsoft.Json;
using static MM.Shared.Core.Helper.ImageHelper;

namespace MM.Shared.Models.Profile;

public class ProfileModel : CosmosDocument
{
    public enum LocationType
    {
        Full,
        Country,
        State,
        City
    }

    public bool Validated { get; set; }

    public ProfileGalleryModel? Gallery { get; set; }

    public void UpdateData(ProfileModel profile)
    {
        //BASIC
        NickName = profile.NickName;
        Description = profile.Description;
        Country = profile.Country;
        State = profile.State;
        City = profile.City;
        Languages = profile.Languages;
        MaritalStatus = profile.MaritalStatus;
        RelationshipIntentions = profile.RelationshipIntentions;
        BiologicalSex = profile.BiologicalSex;
        GenderIdentities = profile.GenderIdentities;
        SexualOrientations = profile.SexualOrientations;

        //BIO
        BirthDate = profile.BirthDate;
        Height = profile.Height;
        Ethnicity = profile.Ethnicity;
        BodyType = profile.BodyType;

        //LIFESTYLE
        Drink = profile.Drink;
        Smoke = profile.Smoke;
        Diet = profile.Diet;
        HaveChildren = profile.HaveChildren;
        WantChildren = profile.WantChildren;
        EducationLevel = profile.EducationLevel;
        CareerCluster = profile.CareerCluster;
        Religion = profile.Religion;
        TravelFrequency = profile.TravelFrequency;

        //PERSONALITY
        MoneyPersonality = profile.MoneyPersonality;
        SharedSpendingStyle = profile.SharedSpendingStyle;
        RelationshipPersonality = profile.RelationshipPersonality;
        MBTI = profile.MBTI;
        LoveLanguage = profile.LoveLanguage;
        SexPersonality = profile.SexPersonality;

        //INTEREST
        Food = profile.Food;
        Vacation = profile.Vacation;
        Sports = profile.Sports;
        LeisureActivities = profile.LeisureActivities;
        MusicGenre = profile.MusicGenre;
        MovieGenre = profile.MovieGenre;
        TVGenre = profile.TVGenre;
        ReadingGenre = profile.ReadingGenre;

        //OTHERS
        Neurodiversity = profile.Neurodiversity;
        Disabilities = profile.Disabilities;
    }

    public void UpdatePhoto(ProfileGalleryModel obj)
    {
        Gallery = obj;
    }

    public string GetPhoto(PhotoType type, bool fake = false)
    {
        if (Gallery == null) return type == PhotoType.Face ? GetFacePhoto : GetBodyPhoto;
        if (Gallery.Type == GalleryType.BlindDate) return GetBlindDate;

        var id = Gallery.GetPictureId(type);
        if (id == null) return type == PhotoType.Face ? GetFacePhoto : GetBodyPhoto;

        if (fake)
            return id;
        return $"{BlobPath}/{GetPhotoContainer(type)}/{id}";
    }

    public string? GetLocation(LocationType type)
    {
        if (string.IsNullOrEmpty(Location)) return null;

        var parts = Location.Split(" - ");

        switch (type)
        {
            case LocationType.Full:
                return Location;

            case LocationType.Country:
                return parts[0];

            case LocationType.State:
                return parts[1];

            case LocationType.City:
                if (parts.Length == 4)
                    return parts[2] + " - " + parts[3]; //county - city
                return parts[2];

            default:
                return null;
        }
    }

    public void SanitizeOpenTextFields()
    {
        NickName = NickName?.RemoveUnsafeControlChars()?.NormalizeToNfc()?.Trim();
        Description = Description?.RemoveUnsafeControlChars()?.NormalizeToNfc()?.Trim();
    }

    #region BASIC

    public string? NickName { get; set; }
    public string? Description { get; set; }
    public Country? Nationality { get; set; }

    [JsonIgnore]
    public string? Location => Country.NotEmpty() ? $"{Country} - {State} - {City}" : null;

    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }

    public HashSet<Language> Languages { get; set; } = [];
    public MaritalStatus? MaritalStatus { get; set; }
    public BiologicalSex? BiologicalSex { get; set; }
    public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];
    public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

    #endregion BASIC

    #region BIO

    public Ethnicity? Ethnicity { get; set; }
    public BodyType? BodyType { get; set; }
    public DateTime? BirthDate { get; set; }

    [JsonIgnore]
    public int Age { get; set; }

    public Height? Height { get; set; }
    public Neurodiversity? Neurodiversity { get; set; }
    public HashSet<Disability> Disabilities { get; set; } = [];

    #endregion BIO

    #region LIFESTYLE

    public Drink? Drink { get; set; }
    public Smoke? Smoke { get; set; }
    public Diet? Diet { get; set; }
    public Religion? Religion { get; set; }
    public FamilyInvolvement? FamilyInvolvement { get; set; }
    public HaveChildren? HaveChildren { get; set; }
    public HavePets? HavePets { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public CareerCluster? CareerCluster { get; set; }
    public LivingSituation? LivingSituation { get; set; }
    public TravelFrequency? TravelFrequency { get; set; }
    public NetWorth? NetWorth { get; set; }
    public AnnualIncome? AnnualIncome { get; set; }

    #endregion LIFESTYLE

    #region PERSONALITY

    //https://www.pnc.com/insights/personal-finance/spend/money-differences-in-relationships.html
    public MoneyPersonality? MoneyPersonality { get; set; }

    //https://www.wikihow.com/Split-Expenses-As-a-Couple
    public SharedSpendingStyle? SharedSpendingStyle { get; set; }

    //https://www.oprah.com/relationships/finding-your-soul-mate-helen-fishers-formula-for-romance/all
    public RelationshipPersonality? RelationshipPersonality { get; set; }

    //https://www.psychologyjunkie.com/2017/09/05/myers-briggs-type-needs-relationship/
    public MyersBriggsTypeIndicator? MBTI { get; set; }

    //https://thehoneycombers.com/singapore/5-love-languages/
    public LoveLanguage? LoveLanguage { get; set; }

    //https://www.bustle.com/articles/59610-17-sex-tips-for-couples-in-long-term-relationships-because-keeping-it-fresh-takes-more-than-a
    public SexPersonality? SexPersonality { get; set; }

    public HashSet<SexPersonality> SexPersonalityPreference { get; set; } = [];

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

    public SharedFinances? SharedFinances { get; set; }
    public ConflictResolutionStyle? ConflictResolutionStyle { get; set; }
    public HouseholdManagement? HouseholdManagement { get; set; }
    public TimeTogetherPreference? TimeTogetherPreference { get; set; }
    public OppositeSexFriendships? OppositeSexFriendships { get; set; }

    #endregion RELATIONSHIP

    #region GOAL

    public HashSet<RelationshipIntention> RelationshipIntentions { get; set; } = [];
    public WantChildren? WantChildren { get; set; }
    public Relocation? Relocation { get; set; }
    public IdealPlaceToLive? IdealPlaceToLive { get; set; }

    #endregion GOAL
}