using MM.Shared.Models.Profile;
using MM.WEB.Core.Enum;
using MM.WEB.Core.Models;

namespace MM.WEB.Core;

public static class AffinityCore
{
    public static IReadOnlyCollection<AffinityVM> GetAffinity(ProfileModel? profile, FilterModel? filter, ProfileModel? view)
    {
        if (profile == null) throw new NotificationException("You need to register your profile first");
        if (filter == null) throw new NotificationException("You need to register your filters first");
        if (view == null) throw new NotificationException("Unable to identify this user's profile");

        var obj = new List<AffinityVM>
        {
            //BASIC - SEARCH SETTINGS
            new(Section.Basic, CompatibilityItem.Location, GetLocation(filter, profile.Location).LocationIsMatch(view.Location)),
            new(Section.Basic, CompatibilityItem.Language, GetLanguages(filter, profile.Languages).IsMatch(view.Languages)),
            new(Section.Basic, CompatibilityItem.MaritalStatus, GetMaritalStatus(filter).IsMatch(view.MaritalStatus.ToArray())),
            new(Section.Basic, CompatibilityItem.BiologicalSex, GetBiologicalSex(profile, filter).IsMatch(view.BiologicalSex.ToArray())),
            new(Section.Basic, CompatibilityItem.GenderIdentities, GetGenderIdentities(filter, profile.GenderIdentities).IsMatch(view.GenderIdentities)),
            new(Section.Basic, CompatibilityItem.SexualOrientations, GetSexualOrientations(filter, profile.SexualOrientations).IsMatch(view.SexualOrientations)),

            //BIO - SEARCH SETTINGS
            new(Section.Bio, CompatibilityItem.Ethnicity, GetEthnicity(filter).IsMatch(view.Ethnicity.ToArray())),
            new(Section.Bio, CompatibilityItem.BodyType, GetBodyType(filter).IsMatch(view.BodyType.ToArray())),
            new(Section.Bio, CompatibilityItem.Age, GetAge(filter, profile.BirthDate).IsRangeMatch(view.Age.ToArray())),
            new(Section.Bio, CompatibilityItem.Height, GetHeight(profile, filter).Cast<int>().IsRangeMatch(((int?)view.Height).ToArray())),
            new(Section.Bio, CompatibilityItem.Neurodiversity, GetNeurodiversity(filter).IsMatch(view.Neurodiversity.ToArray())),
            new(Section.Bio, CompatibilityItem.Disabilities, GetDisability(filter).IsMatch(view.Disabilities)),

            //LIFESTYLE - PROFILE COMPATIBILITY OR SEARCH SETTINGS (IF COMPLETED)
            new(Section.Lifestyle, CompatibilityItem.Drink, GetDrink(profile, filter).IsMatch(view.Drink.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.Smoke, GetSmoke(profile, filter).IsMatch(view.Smoke.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.Diet, GetDiet(profile, filter).IsMatch(view.Diet.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.Religion, GetReligion(profile, filter).IsMatch(view.Religion.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.FamilyInvolvement, GetFamilyInvolvement(profile, filter).IsMatch(view.FamilyInvolvement.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.HaveChildren, GetHaveChildren(profile, filter).IsMatch(view.HaveChildren.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.HavePets, GetHavePets(profile, filter).IsMatch(view.HavePets.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.EducationLevel, GetEducationLevel(profile, filter).IsMatch(view.EducationLevel.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.CareerCluster, GetCareerCluster(profile, filter).IsMatch(view.CareerCluster.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.LivingSituation, GetLivingSituation(profile, filter).IsMatch(view.LivingSituation.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.TravelFrequency, GetTravelFrequency(profile, filter).IsMatch(view.TravelFrequency.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.NetWorth, GetNetWorth(profile, filter).IsMatch(view.NetWorth.ToArray())),
            new(Section.Lifestyle, CompatibilityItem.AnnualIncome, GetAnnualIncome(profile, filter).IsMatch(view.AnnualIncome.ToArray())),

            //PERSONALITY - PROFILE COMPATIBILITY
            new(Section.Personality, CompatibilityItem.MoneyPersonality, GetMoneyPersonality(profile).IsMatch(view.MoneyPersonality.ToArray())),
            new(Section.Personality, CompatibilityItem.SharedSpendingStyle, GetSharedSpendingStyle(profile).IsMatch(view.SharedSpendingStyle.ToArray())),
            new(Section.Personality, CompatibilityItem.RelationshipPersonality, GetRelationshipPersonality(profile).IsMatch(view.RelationshipPersonality.ToArray())),
            new(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, GetMyersBriggsTypeIndicator(profile).IsMatch(view.MBTI.ToArray())),
            new(Section.Personality, CompatibilityItem.LoveLanguage, GetLoveLanguage(profile).IsMatch(view.LoveLanguage.ToArray())),
            new(Section.Personality, CompatibilityItem.SexPersonality, GetSexPersonality(profile).IsMatch(view.SexPersonality.ToArray())),

            //INTEREST - PROFILE COMPATIBILITY (A SINGLE SAME OPTION ALREADY INDICATES COMPATIBILITY)
            new(Section.Interest, CompatibilityItem.Food, GetFood(profile, filter).IsMatch(view.Food)),
            new(Section.Interest, CompatibilityItem.Vacation, GetVacation(profile, filter).IsMatch(view.Vacation)),
            new(Section.Interest, CompatibilityItem.Sports, GetSports(profile, filter).IsMatch(view.Sports)),
            new(Section.Interest, CompatibilityItem.LeisureActivities, GetLeisureActivities(profile, filter).IsMatch(view.LeisureActivities)),
            new(Section.Interest, CompatibilityItem.MusicGenre, GetMusicGenre(profile, filter).IsMatch(view.MusicGenre)),
            new(Section.Interest, CompatibilityItem.MovieGenre, GetMovieGenre(profile, filter).IsMatch(view.MovieGenre)),
            new(Section.Interest, CompatibilityItem.TVGenre, GetTVGenre(profile, filter).IsMatch(view.TVGenre)),
            new(Section.Interest, CompatibilityItem.ReadingGenre, GetReadingGenre(profile, filter).IsMatch(view.ReadingGenre)),

            //RELATIONSHIP - FIELD SPECIFIC RULES
            new(Section.Relationship, CompatibilityItem.SharedFinances, GetSharedFinances(profile, filter).IsMatch(view.SharedFinances.ToArray())),
            new(Section.Relationship, CompatibilityItem.ConflictResolutionStyle, GetConflictResolutionStyle(profile, filter).IsMatch(view.ConflictResolutionStyle.ToArray())),
            new(Section.Relationship, CompatibilityItem.HouseholdManagement, GetHouseholdManagement(profile, filter).IsMatch(view.HouseholdManagement.ToArray())),
            new(Section.Relationship, CompatibilityItem.TimeTogetherPreference, GetTimeTogetherPreference(profile, filter).IsMatch(view.TimeTogetherPreference.ToArray())),
            new(Section.Relationship, CompatibilityItem.OppositeSexFriendships, GetOppositeSexFriendships(profile, filter).IsMatch(view.OppositeSexFriendships.ToArray())),

            //GOALS - FIELD SPECIFIC RULES
            new(Section.Goals, CompatibilityItem.RelationshipIntentions, GetRelationshipIntentions(profile, filter).IsMatch(view.RelationshipIntentions)),
            new(Section.Goals, CompatibilityItem.Relocation, GetRelocation(profile, filter).IsMatch(view.Relocation.ToArray())),
            new(Section.Goals, CompatibilityItem.WantChildren, GetWantChildren(profile, filter).IsMatch(view.WantChildren.ToArray())),
            new(Section.Goals, CompatibilityItem.IdealPlaceToLive, GetIdealPlaceToLive(profile, filter).IsMatch(view.IdealPlaceToLive.ToArray())),
        };

        return obj;
    }

    public static IReadOnlyCollection<string> ToArray(this string? item)
    {
        return item.Empty() ? [] : [item];
    }

    public static IReadOnlyCollection<T> ToArray<T>(this T item) where T : struct
    {
        return [item];
    }

    public static IReadOnlyCollection<T> ToArray<T>(this T? item) where T : struct
    {
        if (item.HasValue) return item.Value.ToArray();
        return [];
    }

    private static bool LocationIsMatch(this (string? loc, int pos) filter, string? view)
    {
        if (filter.pos == -1) return true; //world

        var parts = view?.Split(" - ") ?? [];

        if (filter.pos == 0) //country
            return string.Equals(filter.loc, parts[0], StringComparison.OrdinalIgnoreCase);

        if (filter.pos == 1) //state
            return string.Equals(filter.loc, $"{parts[0]} - {parts[1]}", StringComparison.OrdinalIgnoreCase);

        //city
        return string.Equals(filter.loc, view, StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsMatch<T>(this IReadOnlyCollection<T> filters, IReadOnlyCollection<T> view)
    {
        if (filters.Count == 0) return true; //if preferences are empty then accept all
        if (view.Count == 0) return false; //if the preference is not empty and the view is empty then it does not accept anything

        return filters.Intersect(view).Any();
    }

    private static bool IsRangeMatch(this IEnumerable<int> filters, IEnumerable<int> view)
    {
        if (!filters.Any()) return true; //if preferences are empty then accept all
        if (!view.Any()) return false; //if the preference is not empty and the view is empty then it does not accept anything
        if (filters.Take(3).Count() != 2) throw new InvalidOperationException("preferences.Count != 2");

        return filters.First() <= view.First() && view.First() <= filters.Last();
    }

    public static int GetPercentAffinity(this IReadOnlyCollection<AffinityVM> affinities, Section? category = null)
    {
        if (category == null)
        {
            var totalBasic = affinities.GetPercentAffinity(Section.Basic);
            var totalBio = affinities.GetPercentAffinity(Section.Bio);
            var totalLifestyle = affinities.GetPercentAffinity(Section.Lifestyle);
            var totalPersonality = affinities.GetPercentAffinity(Section.Personality);
            var totalInterest = affinities.GetPercentAffinity(Section.Interest);
            var totalRelationship = affinities.GetPercentAffinity(Section.Relationship);
            var totalGoals = affinities.GetPercentAffinity(Section.Goals);

            var weightBasic = 10;
            var weightBio = 5;
            var weightLifestyle = 25;
            var weightPersonality = 25;
            var weightInterest = 5;
            var weightRelationship = 20;
            var weightGoals = 10;

            var calculated = totalBasic * weightBasic +
                             totalBio * weightBio +
                             totalLifestyle * weightLifestyle +
                             totalPersonality * weightPersonality +
                             totalInterest * weightInterest +
                             totalRelationship * weightRelationship +
                             totalGoals * weightGoals;
            var totalWeight = weightBasic + weightBio + weightLifestyle + weightPersonality + weightInterest +
                              weightRelationship + weightGoals;

            return calculated / totalWeight;
        }

        var totCheck = affinities.Count(w => w.Section == category && w.HaveAffinity);
        var totItens = affinities.Count(w => w.Section == category);

        if (totCheck == 0 || totItens == 0) return 0;

        return Convert.ToInt32(Math.Round((double)totCheck / totItens * 100, 0, MidpointRounding.AwayFromZero));
    }

    #region BASIC - SEARCH SETTINGS

    public static Region GetRegion(Relocation? relocation)
    {
        return relocation switch
        {
            Relocation.NoRelocations => Region.City,
            Relocation.OpenMovingCities => Region.Country,
            Relocation.OpenMovingCountries => Region.World,
            _ => Region.City,
        };
    }

    public static (string? loc, int pos) GetLocation(FilterModel? filter, string? location)
    {
        var parts = location?.Split(" - ") ?? [];

        return filter?.Region switch
        {
            Region.City => (location, 2), //level 3
            Region.State => ($"{parts[0]} - {parts[1]}", 1), //level 2
            Region.Country => ($"{parts[0]}", 0), //level 1
            Region.World => (null, -1),
            _ => (null, -1),
        };
    }

    public static IReadOnlyCollection<Language> GetLanguages(FilterModel? filter, IReadOnlyCollection<Language> languages)
    {
        if (filter != null && filter.Languages.Count != 0)
            return filter.Languages;
        if (languages.Count != 0)
            return languages;
        return [];
    }

    public static IReadOnlyCollection<MaritalStatus> GetMaritalStatus(FilterModel? filter = null)
    {
        if (filter != null && filter.MaritalStatus.Count != 0)
            return filter.MaritalStatus;
        return [];
    }

    public static IReadOnlyCollection<BiologicalSex> GetBiologicalSex(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.BiologicalSex.Count != 0) return filter.BiologicalSex;

        if (profile.GenderIdentities.Contains(GenderIdentity.Cisgender)) //BINARY
        {
            if (profile.SexualOrientations.Contains(SexualOrientation.Heterosexual))
                return profile.BiologicalSex switch
                {
                    BiologicalSex.Male => BiologicalSex.Female.ToArray(),
                    BiologicalSex.Female => BiologicalSex.Male.ToArray(),
                    _ => [],
                };

            if (profile.SexualOrientations.Contains(SexualOrientation.Homosexual))
                return profile.BiologicalSex switch
                {
                    BiologicalSex.Male => BiologicalSex.Male.ToArray(),
                    BiologicalSex.Female => BiologicalSex.Female.ToArray(),
                    _ => [],
                };

            return [];
        }

        //NON-BINARY
        return [];
    }

    public static IReadOnlyCollection<GenderIdentity> GetGenderIdentities(FilterModel? filter, IReadOnlyCollection<GenderIdentity> genderIdentities)
    {
        if (filter != null && filter.GenderIdentities.Count != 0) return filter.GenderIdentities;

        if (genderIdentities.Contains(GenderIdentity.Cisgender)) //BINARY
            return GenderIdentity.Cisgender.ToArray();

        //NON-BINARY
        return [];
    }

    public static IReadOnlyCollection<SexualOrientation> GetSexualOrientations(FilterModel? filter, IReadOnlyCollection<SexualOrientation> sexualOrientations)
    {
        if (filter != null && filter.SexualOrientations.Count != 0) return filter.SexualOrientations;

        if (sexualOrientations.Contains(SexualOrientation.Heterosexual))
            return [SexualOrientation.Heterosexual];
        if (sexualOrientations.Contains(SexualOrientation.Homosexual))
            return [SexualOrientation.Homosexual];
        return [];
    }

    #endregion BASIC - SEARCH SETTINGS

    #region BIO - SEARCH SETTINGS

    public static IReadOnlyCollection<Ethnicity> GetEthnicity(FilterModel? filter = null)
    {
        if (filter != null && filter.Ethnicity.Count != 0)
            return filter.Ethnicity;
        return [];
    }

    public static IReadOnlyCollection<BodyType> GetBodyType(FilterModel? filter = null)
    {
        if (filter != null && filter.BodyType.Count != 0)
            return filter.BodyType;
        return [];
    }

    public static int[] GetAge(FilterModel? filter, DateTime? birthDate = null)
    {
        int? min = null;
        int? max = null;

        if (filter != null)
        {
            min = filter.MinimalAge;
            max = filter.MaxAge;
        }
        else
        {
            //var age = birthDate.GetAge();

            //min = (int)Math.Round(age * 0.75);
            //if (min < 18) min = 18;

            //max = (int)Math.Round(age * 1.33);
            //if (max > 120) max = 120;
        }

        return min == null || max == null ? [] : [min.Value, max.Value];
    }

    public static Height[] GetHeight(ProfileModel profile, FilterModel? filter = null)
    {
        Height? min = null;
        Height? max = null;
        //var ratio = 1.09;

        if (profile == null || profile.Height == null) return [];

        if (filter != null && filter.MinimalHeight.HasValue) min = filter.MinimalHeight.Value;
        //else
        //{
        //    int minHeight;

        //    if (filter != null && filter.BiologicalSex.Count != 0 && filter.BiologicalSex.Count == 1)
        //    {
        //        //TODO: USE CONTAINS?
        //        if (profile.BiologicalSex == BiologicalSex.Male && filter.BiologicalSex.First() == BiologicalSex.Female)
        //        {
        //            minHeight = (int)Math.Round((int)profile.Height.Value / (ratio + 0.04));
        //        }
        //        else if (profile.BiologicalSex == BiologicalSex.Female && filter.BiologicalSex.First() == BiologicalSex.Male)
        //        {
        //            minHeight = (int)Math.Round((int)profile.Height.Value * (ratio - 0.04));
        //        }
        //        else
        //        {
        //            minHeight = (int)profile.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
        //        }
        //    }
        //    else
        //    {
        //        minHeight = (int)profile.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
        //    }

        //    if (minHeight < (int)Height._146) minHeight = (int)Height._146;
        //    min = (Height)minHeight;
        //}

        if (filter != null && filter.MaxHeight.HasValue) max = filter.MaxHeight.Value;
        //else
        //{
        //    int maxHeight;

        //    if (filter != null && filter.BiologicalSex.Count != 0 && filter.BiologicalSex.Count == 1)
        //    {
        //        //TODO: USE CONTAINS?
        //        if (profile.BiologicalSex == BiologicalSex.Male && filter.BiologicalSex.First() == BiologicalSex.Female)
        //        {
        //            maxHeight = (int)Math.Round((int)profile.Height.Value / (ratio - 0.04));
        //        }
        //        else if (profile.BiologicalSex == BiologicalSex.Female && filter.BiologicalSex.First() == BiologicalSex.Male)
        //        {
        //            maxHeight = (int)Math.Round((int)profile.Height.Value * (ratio + 0.04));
        //        }
        //        else
        //        {
        //            maxHeight = (int)profile.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
        //        }
        //    }
        //    else
        //    {
        //        maxHeight = (int)profile.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
        //    }

        //    if (maxHeight > (int)Height._188) maxHeight = (int)Height._188;
        //    max = (Height)maxHeight;
        //}

        return min == null || max == null ? [] : [min.Value, max.Value];
    }

    public static IReadOnlyCollection<Neurodiversity> GetNeurodiversity(FilterModel? filter = null)
    {
        if (filter != null)
            return filter.Neurodiversity;
        return [];
    }

    public static IReadOnlyCollection<Disability> GetDisability(FilterModel? filter = null)
    {
        if (filter != null)
            return filter.Disabilities;
        return [];
    }

    #endregion BIO - SEARCH SETTINGS

    #region LIFESTYLE - PROFILE COMPATIBILITY OR SEARCH SETTINGS (IF COMPLETED)

    public static IReadOnlyCollection<Drink> GetDrink(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.Drink.Count != 0) return filter.Drink;

        return profile.Drink switch
        {
            Drink.No => [Drink.No, Drink.YesLight],
            Drink.YesLight => [Drink.No, Drink.YesLight, Drink.YesModerate],
            Drink.YesModerate => [Drink.YesLight, Drink.YesModerate, Drink.YesHeavy],
            Drink.YesHeavy => [Drink.YesModerate, Drink.YesHeavy],
            _ => [],
        };
    }

    public static IReadOnlyCollection<Smoke> GetSmoke(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.Smoke.Count != 0) return filter.Smoke;

        return profile.Smoke switch
        {
            Smoke.No => [Smoke.No],
            Smoke.YesOccasionally => [Smoke.YesOccasionally, Smoke.YesOften],
            Smoke.YesOften => [Smoke.YesOccasionally, Smoke.YesOften],
            _ => [],
        };
    }

    public static IReadOnlyCollection<Diet> GetDiet(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.Diet.Count != 0) return filter.Diet;

        var group01 = new HashSet<Diet>([Diet.Omnivore, Diet.Flexitarian, Diet.GlutenFree]);
        var group02 = new HashSet<Diet>([Diet.Vegetarian, Diet.Vegan]);
        var group03 = new HashSet<Diet>([Diet.RawFood, Diet.OrganicAllnaturalLocal]);

        return profile.Diet switch
        {
            Diet.Omnivore => group01,
            Diet.Flexitarian => group01,
            Diet.Vegetarian => group02,
            Diet.Vegan => group02,
            Diet.RawFood => group03,
            Diet.GlutenFree => group01,
            Diet.OrganicAllnaturalLocal => group03,
            Diet.DetoxWeightLoss => [Diet.DetoxWeightLoss],
            _ => [],
        };
    }

    public static IReadOnlyCollection<Religion> GetReligion(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.Religion.Count != 0) return filter.Religion;

        return profile.Religion.ToCollection();
    }

    public static IReadOnlyCollection<FamilyInvolvement> GetFamilyInvolvement(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.FamilyInvolvement.Count != 0) return filter.FamilyInvolvement;

        return profile.FamilyInvolvement switch
        {
            FamilyInvolvement.NotInvolved => [FamilyInvolvement.NotInvolved, FamilyInvolvement.SomeInvolvement],
            FamilyInvolvement.SomeInvolvement => [FamilyInvolvement.NotInvolved, FamilyInvolvement.SomeInvolvement, FamilyInvolvement.HeavilyInvolved],
            FamilyInvolvement.HeavilyInvolved => [FamilyInvolvement.SomeInvolvement, FamilyInvolvement.HeavilyInvolved],
            _ => [],
        };
    }

    public static IReadOnlyCollection<HaveChildren> GetHaveChildren(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.HaveChildren.Count != 0) return filter.HaveChildren;

        return profile.HaveChildren switch
        {
            HaveChildren.No => [HaveChildren.No, HaveChildren.YesNo],
            HaveChildren.YesNo => [HaveChildren.No, HaveChildren.YesNo],
            HaveChildren.Yes => [HaveChildren.Yes],
            _ => [],
        };
    }

    public static IReadOnlyCollection<HavePets> GetHavePets(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.HavePets.Count != 0) return filter.HavePets;

        return profile.HavePets switch
        {
            HavePets.IDontHave => [.. EnumHelper.GetValues<HavePets>()],
            HavePets.IDontWant => [HavePets.IDontHave, HavePets.IDontWant],
            HavePets.Dog => [HavePets.Dog, HavePets.DogCat],
            HavePets.Cat => [HavePets.Cat, HavePets.DogCat],
            HavePets.DogCat => [HavePets.Dog, HavePets.Cat, HavePets.DogCat],
            HavePets.SmallPets => [HavePets.SmallPets],
            HavePets.ExoticPets => [HavePets.ExoticPets],
            _ => [],
        };
    }

    public static IReadOnlyCollection<EducationLevel> GetEducationLevel(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.EducationLevel.Count != 0) return filter.EducationLevel;

        if (profile != null && profile.EducationLevel.HasValue) return [profile.EducationLevel.Value];

        return [];
    }

    public static IReadOnlyCollection<CareerCluster> GetCareerCluster(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.CareerCluster.Count != 0) return filter.CareerCluster;

        if (!profile.CareerCluster.HasValue) return [];
        var group = profile.CareerCluster?.GetFieldSettings().Group;
        if (group.Empty()) return [CareerCluster.NoCareer];

        return [.. EnumHelper.GetValues<CareerCluster>().Where(w => string.Equals(w.GetFieldSettings().Group, group, StringComparison.OrdinalIgnoreCase))];
    }

    public static IReadOnlyCollection<LivingSituation> GetLivingSituation(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.LivingSituation.Count != 0) return filter.LivingSituation;

        var groupAll = EnumHelper.GetValues<LivingSituation>().ToHashSet();
        var groupExcExPar = EnumHelper.GetValues<LivingSituation>().Except([LivingSituation.WithExPartner]).ToHashSet();
        var groupExcFam = EnumHelper.GetValues<LivingSituation>().Except([LivingSituation.WithFamily]).ToHashSet();

        return profile.LivingSituation switch
        {
            LivingSituation.Alone => groupAll,
            LivingSituation.WithFamily => groupExcExPar,
            LivingSituation.WithFriends => groupAll,
            LivingSituation.WithExPartner => groupExcFam,
            LivingSituation.WithRoommates => groupAll,
            LivingSituation.Other => groupAll,
            _ => [],
        };
    }

    public static IReadOnlyCollection<TravelFrequency> GetTravelFrequency(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.TravelFrequency.Count != 0) return filter.TravelFrequency;

        return profile.TravelFrequency switch
        {
            TravelFrequency.NeverRarely => [TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently],
            TravelFrequency.SometimesFrequently => [TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad],
            TravelFrequency.UsuallyAlwaysNomad => [TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad],
            _ => [],
        };
    }

    public static IReadOnlyCollection<NetWorth> GetNetWorth(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.NetWorth.Count != 0) return filter.NetWorth;

        if (!profile.NetWorth.HasValue) return [];

        var pos = (int)profile.NetWorth - 1;

        var list = EnumHelper.GetValues<NetWorth>();
        var before = pos == 0 ? null : (NetWorth?)list.GetValue(pos - 1);
        var after = pos == list.Length - 1 ? null : (NetWorth?)list.GetValue(pos + 1);

        return [.. profile.NetWorth.ToCollection().Union(before.ToCollection()).Union(after.ToCollection())];
    }

    public static IReadOnlyCollection<AnnualIncome> GetAnnualIncome(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.AnnualIncome.Count != 0) return filter.AnnualIncome;

        if (!profile.AnnualIncome.HasValue) return [];

        var pos = (int)profile.AnnualIncome - 1;

        var list = EnumHelper.GetValues<AnnualIncome>();
        var before = pos == 0 ? null : (AnnualIncome?)list.GetValue(pos - 1);
        var after = pos == list.Length - 1 ? null : (AnnualIncome?)list.GetValue(pos + 1);

        return [.. profile.AnnualIncome.ToCollection().Union(before.ToCollection()).Union(after.ToCollection())];
    }

    #endregion LIFESTYLE - PROFILE COMPATIBILITY OR SEARCH SETTINGS (IF COMPLETED)

    #region PERSONALITY - PROFILE COMPATIBILITY

    public static IReadOnlyCollection<MoneyPersonality> GetMoneyPersonality(ProfileModel profile)
    {
        if (!profile.MoneyPersonality.HasValue) return [];

        return profile.MoneyPersonality.ToArray();
    }

    public static IReadOnlyCollection<SharedSpendingStyle> GetSharedSpendingStyle(ProfileModel profile)
    {
        //Invented by ChatGPD

        return profile.SharedSpendingStyle switch
        {
            SharedSpendingStyle.Provider => SharedSpendingStyle.Dependent.ToArray(),
            SharedSpendingStyle.Contributor => SharedSpendingStyle.Supporter.ToArray(),
            SharedSpendingStyle.Balanced => SharedSpendingStyle.Balanced.ToArray(),
            SharedSpendingStyle.Supporter => SharedSpendingStyle.Contributor.ToArray(),
            SharedSpendingStyle.Dependent => SharedSpendingStyle.Provider.ToArray(),
            _ => [],
        };
    }

    public static IReadOnlyCollection<RelationshipPersonality> GetRelationshipPersonality(ProfileModel profile)
    {
        //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

        return profile.RelationshipPersonality switch
        {
            RelationshipPersonality.Explorers => RelationshipPersonality.Explorers.ToArray(),
            RelationshipPersonality.Directors => RelationshipPersonality.Negotiator.ToArray(),
            RelationshipPersonality.Builders => RelationshipPersonality.Builders.ToArray(),
            RelationshipPersonality.Negotiator => RelationshipPersonality.Directors.ToArray(),
            _ => [],
        };
    }

    public static IReadOnlyCollection<MyersBriggsTypeIndicator> GetMyersBriggsTypeIndicator(ProfileModel profile)
    {
        //http://www.personalityrelationships.net/
        //https://web.archive.org/web/20220322143220/http://www.personalityrelationships.net/
        //https://www.sosyncd.com/the-complete-guide-to-personality-type-compatibility/

        return profile.MBTI switch
        {
            MyersBriggsTypeIndicator.INTJ => [MyersBriggsTypeIndicator.ENTP, MyersBriggsTypeIndicator.ENFP],
            MyersBriggsTypeIndicator.INTP => [MyersBriggsTypeIndicator.ENTJ, MyersBriggsTypeIndicator.ENFJ],
            MyersBriggsTypeIndicator.ENTJ => [MyersBriggsTypeIndicator.INTP, MyersBriggsTypeIndicator.INFP],
            MyersBriggsTypeIndicator.ENTP => [MyersBriggsTypeIndicator.INTJ, MyersBriggsTypeIndicator.INFJ],

            MyersBriggsTypeIndicator.INFJ => [MyersBriggsTypeIndicator.ENFP, MyersBriggsTypeIndicator.ENTP, MyersBriggsTypeIndicator.INTJ, MyersBriggsTypeIndicator.INFJ,],
            MyersBriggsTypeIndicator.INFP => [MyersBriggsTypeIndicator.ENFJ, MyersBriggsTypeIndicator.ENTJ],
            MyersBriggsTypeIndicator.ENFJ => [MyersBriggsTypeIndicator.INFP, MyersBriggsTypeIndicator.INTP],
            MyersBriggsTypeIndicator.ENFP => [MyersBriggsTypeIndicator.INFJ, MyersBriggsTypeIndicator.INTJ],

            MyersBriggsTypeIndicator.ISTJ => [MyersBriggsTypeIndicator.ESTP, MyersBriggsTypeIndicator.ESFP],
            MyersBriggsTypeIndicator.ISFJ => [MyersBriggsTypeIndicator.ESFP, MyersBriggsTypeIndicator.ESTP],
            MyersBriggsTypeIndicator.ESTJ => [MyersBriggsTypeIndicator.ISTP, MyersBriggsTypeIndicator.ISFP],
            MyersBriggsTypeIndicator.ESFJ => [MyersBriggsTypeIndicator.ISFP, MyersBriggsTypeIndicator.ISTP],

            MyersBriggsTypeIndicator.ISTP => [MyersBriggsTypeIndicator.ESFJ, MyersBriggsTypeIndicator.ESTJ],
            MyersBriggsTypeIndicator.ISFP => [MyersBriggsTypeIndicator.ESTJ, MyersBriggsTypeIndicator.ESFJ],
            MyersBriggsTypeIndicator.ESTP => [MyersBriggsTypeIndicator.ISTJ, MyersBriggsTypeIndicator.ISFJ],
            MyersBriggsTypeIndicator.ESFP => [MyersBriggsTypeIndicator.ISTJ, MyersBriggsTypeIndicator.ISFJ],
            _ => [],
        };
    }

    public static IReadOnlyCollection<LoveLanguage> GetLoveLanguage(ProfileModel profile)
    {
        if (!profile.LoveLanguage.HasValue) return [];

        return profile.LoveLanguage.ToArray();
    }

    public static IReadOnlyCollection<SexPersonality> GetSexPersonality(ProfileModel profile)
    {
        if (profile.SexPersonalityPreference.Count != 0) return profile.SexPersonalityPreference;

        if (profile.SexPersonality.HasValue) return profile.SexPersonality.ToArray();

        return [];
    }

    #endregion PERSONALITY - PROFILE COMPATIBILITY

    #region INTEREST - PROFILE COMPATIBILITY (A SINGLE SAME OPTION ALREADY INDICATES COMPATIBILITY)

    public static IReadOnlyCollection<Food> GetFood(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.Food.Count != 0)
            return filter.Food;
        return profile.Food;
    }

    public static IReadOnlyCollection<Vacation> GetVacation(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.Vacation.Count != 0)
            return filter.Vacation;
        return profile.Vacation;
    }

    public static IReadOnlyCollection<Sports> GetSports(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.Sports.Count != 0)
            return filter.Sports;
        return profile.Sports;
    }

    public static IReadOnlyCollection<LeisureActivities> GetLeisureActivities(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.LeisureActivities.Count != 0)
            return filter.LeisureActivities;
        return profile.LeisureActivities;
    }

    public static IReadOnlyCollection<MusicGenre> GetMusicGenre(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.MusicGenre.Count != 0)
            return filter.MusicGenre;
        return profile.MusicGenre;
    }

    public static IReadOnlyCollection<MovieGenre> GetMovieGenre(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.MovieGenre.Count != 0)
            return filter.MovieGenre;
        return profile.MovieGenre;
    }

    public static IReadOnlyCollection<TVGenre> GetTVGenre(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.TVGenre.Count != 0)
            return filter.TVGenre;
        return profile.TVGenre;
    }

    public static IReadOnlyCollection<ReadingGenre> GetReadingGenre(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.ReadingGenre.Count != 0)
            return filter.ReadingGenre;
        return profile.ReadingGenre;
    }

    #endregion INTEREST - PROFILE COMPATIBILITY (A SINGLE SAME OPTION ALREADY INDICATES COMPATIBILITY)

    #region RELATIONSHIP - FIELD SPECIFIC RULES

    public static IReadOnlyCollection<SharedFinances> GetSharedFinances(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.SharedFinances.Count != 0)
            return filter.SharedFinances;
        return profile.SharedFinances switch
        {
            SharedFinances.JointAccounts => [SharedFinances.JointAccounts, SharedFinances.HybridApproach],
            SharedFinances.SeparateAccounts => [SharedFinances.SeparateAccounts, SharedFinances.HybridApproach],
            SharedFinances.HybridApproach => [SharedFinances.JointAccounts, SharedFinances.SeparateAccounts, SharedFinances.HybridApproach],
            _ => [],
        };
    }

    public static IReadOnlyCollection<ConflictResolutionStyle> GetConflictResolutionStyle(ProfileModel profile,
        FilterModel? filter = null)
    {
        if (filter != null && filter.ConflictResolutionStyle.Count != 0)
            return filter.ConflictResolutionStyle;
        return profile.ConflictResolutionStyle.ToCollection();
    }

    public static IReadOnlyCollection<HouseholdManagement> GetHouseholdManagement(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.HouseholdManagement.Count != 0)
            return filter.HouseholdManagement;
        return profile.HouseholdManagement.ToCollection();
    }

    public static IReadOnlyCollection<TimeTogetherPreference> GetTimeTogetherPreference(ProfileModel profile,
        FilterModel? filter = null)
    {
        if (filter != null && filter.TimeTogetherPreference.Count != 0)
            return filter.TimeTogetherPreference;
        return profile.TimeTogetherPreference switch
        {
            TimeTogetherPreference.AloneTime => [TimeTogetherPreference.AloneTime, TimeTogetherPreference.BalancedTime],
            TimeTogetherPreference.BalancedTime => [TimeTogetherPreference.AloneTime, TimeTogetherPreference.BalancedTime, TimeTogetherPreference.QualityTogether],
            TimeTogetherPreference.QualityTogether => [TimeTogetherPreference.BalancedTime, TimeTogetherPreference.QualityTogether],
            _ => [],
        };
    }

    public static IReadOnlyCollection<OppositeSexFriendships> GetOppositeSexFriendships(ProfileModel profile,
        FilterModel? filter = null)
    {
        if (filter != null && filter.OppositeSexFriendships.Count != 0)
            return filter.OppositeSexFriendships;
        return profile.OppositeSexFriendships switch
        {
            OppositeSexFriendships.Comfortable => [OppositeSexFriendships.Comfortable, OppositeSexFriendships.BoundariesNeeded],
            OppositeSexFriendships.BoundariesNeeded => [OppositeSexFriendships.Comfortable, OppositeSexFriendships.BoundariesNeeded, OppositeSexFriendships.Uncomfortable],
            OppositeSexFriendships.Uncomfortable => [OppositeSexFriendships.BoundariesNeeded, OppositeSexFriendships.Uncomfortable],
            _ => [],
        };
    }

    #endregion RELATIONSHIP - FIELD SPECIFIC RULES

    #region GOALS - FIELD SPECIFIC RULES

    public static IReadOnlyCollection<RelationshipIntention> GetRelationshipIntentions(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.RelationshipIntentions.Count != 0)
            return filter.RelationshipIntentions;
        return [.. profile.RelationshipIntentions];
    }

    public static IReadOnlyCollection<Relocation> GetRelocation(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.Relocation.HasValue)
            return filter.Relocation.ToCollection();
        return profile.Relocation.ToCollection();
    }

    public static IReadOnlyCollection<WantChildren> GetWantChildren(ProfileModel profile, FilterModel? filter)
    {
        if (filter != null && filter.WantChildren.Count != 0) return filter.WantChildren;

        return profile.WantChildren switch
        {
            WantChildren.No => [WantChildren.No],
            WantChildren.Maybe => [WantChildren.No, WantChildren.Maybe, WantChildren.Yes],
            WantChildren.Yes => [WantChildren.Maybe, WantChildren.Yes],
            _ => [],
        };
    }

    public static IReadOnlyCollection<IdealPlaceToLive> GetIdealPlaceToLive(ProfileModel profile, FilterModel? filter = null)
    {
        if (filter != null && filter.IdealPlaceToLive.Count != 0) return filter.IdealPlaceToLive;

        return profile.IdealPlaceToLive switch
        {
            IdealPlaceToLive.Urban => [IdealPlaceToLive.Urban],
            IdealPlaceToLive.Suburban => [IdealPlaceToLive.Suburban],
            IdealPlaceToLive.Rural => [IdealPlaceToLive.Rural],
            IdealPlaceToLive.Flexible => [IdealPlaceToLive.Urban, IdealPlaceToLive.Suburban, IdealPlaceToLive.Rural, IdealPlaceToLive.Flexible],
            _ => [],
        };
    }

    #endregion GOALS - FIELD SPECIFIC RULES
}