using MM.Shared.Models.Profile;
using MM.WEB.Core.Enum;
using MM.WEB.Core.Models;

namespace MM.WEB.Core
{
    public static class AffinityCore
    {
        public static List<AffinityVM> GetAffinity(ProfileModel? profile, FilterModel? filter, ProfileModel? view)
        {
            if (profile == null) throw new NotificationException("Não foi possível identificar seu perfil");
            if (filter == null) throw new NotificationException("Não foi possível identificar seus filtros");
            if (view == null) throw new NotificationException("Não foi possível identificar o perfil deste usuário");

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
                new(Section.Bio, CompatibilityItem.Height, GetHeight(profile, filter).Select(s => (int)s).IsRangeMatch(((int?)view.Height).ToArray())),
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
                new(Section.Personality, CompatibilityItem.MoneyPersonality, GetMoneyPersonality(profile).IsMatch(view.MoneyPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SharedSpendingStyle, GetSharedSpendingStyle(profile).IsMatch(view.SharedSpendingStyle.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.RelationshipPersonality, GetRelationshipPersonality(profile).IsMatch(view.RelationshipPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, GetMyersBriggsTypeIndicator(profile).IsMatch(view.MBTI.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.LoveLanguage, GetLoveLanguage(profile).IsMatch(view.LoveLanguage.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SexPersonality, GetSexPersonality(profile).IsMatch(view.SexPersonality.ToArray(), true)),

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

        public static HashSet<string> ToArray(this string? item)
        {
            return item.Empty() ? [] : [item];
        }

        public static HashSet<T> ToArray<T>(this T item) where T : struct
        {
            return [item];
        }

        public static HashSet<T> ToArray<T>(this T? item) where T : struct
        {
            if (item.HasValue) return item.Value.ToArray();
            else return [];
        }

        private static bool LocationIsMatch(this (string? loc, int pos) filter, string? view)
        {
            if (filter.pos == -1) return true; //world

            var parts = view?.Split(" - ") ?? [];

            if (filter.pos == 0) //country
            {
                return filter.loc == parts[0];
            }
            else if (filter.pos == 1) //state
            {
                return filter.loc == $"{parts[0]} - {parts[1]}";
            }
            else //city
            {
                return filter.loc == view;
            }
        }

        private static bool IsMatch<T>(this HashSet<T> filters, HashSet<T> view, bool force = false)
        {
            if (force && filters.Count == 0) return false; //if preferences is required
            if (filters.Count == 0) return true; //if preferences are empty then accept all
            if (view.Count == 0) return false; //if the preference is not empty and the view is empty then it does not accept anything

            return filters.Intersect(view).Any();
        }

        private static bool IsRangeMatch(this IEnumerable<int> filters, IEnumerable<int> view)
        {
            if (!filters.Any()) return true; //if preferences are empty then accept all
            if (!view.Any()) return false; //if the preference is not empty and the view is empty then it does not accept anything
            if (filters.Count() != 2) throw new InvalidOperationException("preferences.Count != 2");

            return filters.First() <= view.First() && view.First() <= filters.Last();
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
                _ => (null, -1)
            };
        }

        public static HashSet<Language> GetLanguages(FilterModel? filter, HashSet<Language> languages)
        {
            if (filter != null && filter.Languages.Count != 0)
                return filter.Languages;
            else if (languages.Count != 0)
                return languages;
            else
                return [];
        }

        public static HashSet<MaritalStatus> GetMaritalStatus(FilterModel? filter = null)
        {
            if (filter != null && filter.MaritalStatus.Count != 0)
                return filter.MaritalStatus;
            else
                return [];
        }

        public static HashSet<BiologicalSex> GetBiologicalSex(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.BiologicalSex.Count != 0)
            {
                return filter.BiologicalSex;
            }
            else
            {
                if (profile.GenderIdentities.Contains(GenderIdentity.Cisgender)) //BINARY
                {
                    if (profile.SexualOrientations.Contains(SexualOrientation.Heterosexual))
                    {
                        return profile.BiologicalSex switch
                        {
                            BiologicalSex.Male => BiologicalSex.Female.ToArray(),
                            BiologicalSex.Female => BiologicalSex.Male.ToArray(),
                            _ => []
                        };
                    }
                    else if (profile.SexualOrientations.Contains(SexualOrientation.Homosexual))
                    {
                        return profile.BiologicalSex switch
                        {
                            BiologicalSex.Male => BiologicalSex.Male.ToArray(),
                            BiologicalSex.Female => BiologicalSex.Female.ToArray(),
                            _ => []
                        };
                    }
                    else
                    {
                        return [];
                    }
                }
                else //NON-BINARY
                {
                    return [];
                }
            }
        }

        public static HashSet<GenderIdentity> GetGenderIdentities(FilterModel? filter, HashSet<GenderIdentity> genderIdentities)
        {
            if (filter != null && filter.GenderIdentities.Count != 0)
            {
                return filter.GenderIdentities;
            }
            else
            {
                if (genderIdentities.Contains(GenderIdentity.Cisgender)) //BINARY
                {
                    return GenderIdentity.Cisgender.ToArray();
                }
                else //NON-BINARY
                {
                    return [];
                }
            }
        }

        public static HashSet<SexualOrientation> GetSexualOrientations(FilterModel? filter, HashSet<SexualOrientation> sexualOrientations)
        {
            if (filter != null && filter.SexualOrientations.Count != 0)
            {
                return filter.SexualOrientations;
            }
            else
            {
                if (sexualOrientations.Contains(SexualOrientation.Heterosexual))
                    return [SexualOrientation.Heterosexual];
                else if (sexualOrientations.Contains(SexualOrientation.Homosexual))
                    return [SexualOrientation.Homosexual];
                else
                    return [];
            }
        }

        #endregion BASIC - SEARCH SETTINGS

        #region BIO - SEARCH SETTINGS

        public static HashSet<Ethnicity> GetEthnicity(FilterModel? filter = null)
        {
            if (filter != null && filter.Ethnicity.Count != 0)
                return filter.Ethnicity;
            else
                return [];
        }

        public static HashSet<BodyType> GetBodyType(FilterModel? filter = null)
        {
            if (filter != null && filter.BodyType.Count != 0)
                return filter.BodyType;
            else
                return [];
        }

        public static int[] GetAge(FilterModel? filter, DateTime birthDate, bool force = false)
        {
            int? min;
            int? max;

            if (filter != null && !force)
            {
                min = filter.MinimalAge;
                max = filter.MaxAge;
            }
            else
            {
                var age = birthDate.GetAge();

                min = (int)Math.Round(age * 0.75);
                if (min < 18) min = 18;

                max = (int)Math.Round(age * 1.33);
                if (max > 120) max = 120;
            }

            return [min ?? 18, max ?? 120];
        }

        public static Height[] GetHeight(ProfileModel profile, FilterModel? filter = null, bool force = false)
        {
            Height min;
            Height max;
            var ratio = 1.09;

            if (filter != null && filter.MinimalHeight.HasValue && !force)
            {
                min = filter.MinimalHeight.Value;
            }
            else
            {
                if (profile.Height.HasValue)
                {
                    int minHeight;

                    if (filter != null && filter.BiologicalSex.Count != 0 && filter.BiologicalSex.Count == 1)
                    {
                        //TODO: USE CONTAINS?
                        if (profile.BiologicalSex == BiologicalSex.Male && filter.BiologicalSex.First() == BiologicalSex.Female)
                        {
                            minHeight = (int)Math.Round((int)profile.Height.Value / (ratio + 0.04));
                        }
                        else if (profile.BiologicalSex == BiologicalSex.Female && filter.BiologicalSex.First() == BiologicalSex.Male)
                        {
                            minHeight = (int)Math.Round((int)profile.Height.Value * (ratio - 0.04));
                        }
                        else
                        {
                            minHeight = (int)profile.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        minHeight = (int)profile.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (minHeight < (int)Height._146) minHeight = (int)Height._146;
                    min = (Height)minHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            if (filter != null && filter.MaxHeight.HasValue && !force)
            {
                max = filter.MaxHeight.Value;
            }
            else
            {
                if (profile.Height.HasValue)
                {
                    int maxHeight;

                    if (filter != null && filter.BiologicalSex.Count != 0 && filter.BiologicalSex.Count == 1)
                    {
                        //TODO: USE CONTAINS?
                        if (profile.BiologicalSex == BiologicalSex.Male && filter.BiologicalSex.First() == BiologicalSex.Female)
                        {
                            maxHeight = (int)Math.Round((int)profile.Height.Value / (ratio - 0.04));
                        }
                        else if (profile.BiologicalSex == BiologicalSex.Female && filter.BiologicalSex.First() == BiologicalSex.Male)
                        {
                            maxHeight = (int)Math.Round((int)profile.Height.Value * (ratio + 0.04));
                        }
                        else
                        {
                            maxHeight = (int)profile.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        maxHeight = (int)profile.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (maxHeight > (int)Height._188) maxHeight = (int)Height._188;
                    max = (Height)maxHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            return [min, max];
        }

        public static HashSet<Neurodiversity> GetNeurodiversity(FilterModel? filter = null)
        {
            if (filter != null)
                return filter.Neurodiversities;
            else
                return [];
        }

        public static HashSet<Disability> GetDisability(FilterModel? filter = null)
        {
            if (filter != null)
                return filter.Disabilities;
            else
                return [];
        }

        #endregion BIO - SEARCH SETTINGS

        #region LIFESTYLE - PROFILE COMPATIBILITY OR SEARCH SETTINGS (IF COMPLETED)

        public static HashSet<Drink> GetDrink(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.Drink.Count != 0)
            {
                return filter.Drink;
            }
            else
            {
                return profile.Drink switch
                {
                    Drink.No => [Drink.No, Drink.YesLight],
                    Drink.YesLight => [Drink.No, Drink.YesLight, Drink.YesModerate],
                    Drink.YesModerate => [Drink.YesLight, Drink.YesModerate, Drink.YesHeavy],
                    Drink.YesHeavy => [Drink.YesModerate, Drink.YesHeavy],
                    _ => []
                };
            }
        }

        public static HashSet<Smoke> GetSmoke(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.Smoke.Count != 0)
            {
                return filter.Smoke;
            }
            else
            {
                return profile.Smoke switch
                {
                    Smoke.No => [Smoke.No],
                    Smoke.YesOccasionally => [Smoke.YesOccasionally, Smoke.YesOften],
                    Smoke.YesOften => [Smoke.YesOccasionally, Smoke.YesOften],
                    _ => []
                };
            }
        }

        public static HashSet<Diet> GetDiet(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.Diet.Count != 0)
            {
                return filter.Diet;
            }
            else
            {
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
                    _ => []
                };
            }
        }

        public static HashSet<Religion> GetReligion(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.Religion.Count != 0)
            {
                return filter.Religion;
            }
            else
            {
                return profile.Religion.ToHashSet();
            }
        }

        public static HashSet<FamilyInvolvement> GetFamilyInvolvement(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.FamilyInvolvement.Count != 0)
            {
                return filter.FamilyInvolvement;
            }
            else
            {
                return profile.FamilyInvolvement switch
                {
                    FamilyInvolvement.NotInvolved => [FamilyInvolvement.NotInvolved, FamilyInvolvement.SomeInvolvement],
                    FamilyInvolvement.SomeInvolvement => [FamilyInvolvement.NotInvolved, FamilyInvolvement.SomeInvolvement, FamilyInvolvement.HeavilyInvolved],
                    FamilyInvolvement.HeavilyInvolved => [FamilyInvolvement.SomeInvolvement, FamilyInvolvement.HeavilyInvolved],
                    _ => FamilyInvolvement.NotInvolved.ToArray(),
                };
            }
        }

        public static HashSet<HaveChildren> GetHaveChildren(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.HaveChildren.Count != 0)
            {
                return filter.HaveChildren;
            }
            else
            {
                return profile.HaveChildren switch
                {
                    HaveChildren.No => [HaveChildren.No, HaveChildren.YesNo],
                    HaveChildren.YesNo => [HaveChildren.No, HaveChildren.YesNo],
                    HaveChildren.Yes => [HaveChildren.Yes],
                    _ => []
                };
            }
        }

        public static HashSet<HavePets> GetHavePets(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.HavePets.Count != 0)
            {
                return filter.HavePets;
            }
            else
            {
                return profile.HavePets switch
                {
                    HavePets.IDontHave => EnumHelper.GetArray<HavePets>().ToHashSet(),
                    HavePets.IDontWant => [HavePets.IDontHave, HavePets.IDontWant],
                    HavePets.Dog => [HavePets.Dog, HavePets.DogCat],
                    HavePets.Cat => [HavePets.Cat, HavePets.DogCat],
                    HavePets.DogCat => [HavePets.Dog, HavePets.Cat, HavePets.DogCat],
                    HavePets.SmallPets => [HavePets.SmallPets],
                    HavePets.ExoticPets => [HavePets.ExoticPets],
                    _ => []
                };
            }
        }

        public static HashSet<EducationLevel> GetEducationLevel(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.EducationLevel.Count != 0)
            {
                return filter.EducationLevel;
            }
            else
            {
                return [profile.EducationLevel ?? throw new NotificationException("EducationLevel null")];
            }
        }

        public static HashSet<CareerCluster> GetCareerCluster(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.CareerCluster.Count != 0)
            {
                return filter.CareerCluster;
            }
            else
            {
                var group = profile.CareerCluster?.GetCustomAttribute()?.Group;
                if (group.Empty()) return [CareerCluster.NoCareer];

                return EnumHelper.GetArray<CareerCluster>().Where(w => w.GetCustomAttribute()?.Group == group).ToHashSet();
            }
        }

        public static HashSet<LivingSituation> GetLivingSituation(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.LivingSituation.Count != 0)
            {
                return filter.LivingSituation;
            }
            else
            {
                var groupAll = EnumHelper.GetArray<LivingSituation>().ToHashSet();
                var groupExcExPar = EnumHelper.GetArray<LivingSituation>().Except([LivingSituation.WithExPartner]).ToHashSet();
                var groupExcFam = EnumHelper.GetArray<LivingSituation>().Except([LivingSituation.WithFamily]).ToHashSet();

                return profile.LivingSituation switch
                {
                    LivingSituation.Alone => groupAll,
                    LivingSituation.WithFamily => groupExcExPar,
                    LivingSituation.WithFriends => groupAll,
                    LivingSituation.WithExPartner => groupExcFam,
                    LivingSituation.WithRoommates => groupAll,
                    LivingSituation.Other => groupAll,
                    _ => []
                };
            }
        }

        public static HashSet<TravelFrequency> GetTravelFrequency(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.TravelFrequency.Count != 0)
            {
                return filter.TravelFrequency;
            }
            else
            {
                return profile.TravelFrequency switch
                {
                    TravelFrequency.NeverRarely => [TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently],
                    TravelFrequency.SometimesFrequently => [TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad],
                    TravelFrequency.UsuallyAlwaysNomad => [TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad],
                    _ => []
                };
            }
        }

        public static HashSet<NetWorth> GetNetWorth(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.NetWorth.Count != 0)
            {
                return filter.NetWorth;
            }
            else
            {
                var list = EnumHelper.GetArray<NetWorth>();
                if (!profile.NetWorth.HasValue) return list.ToHashSet();

                var pos = (int)profile.NetWorth - 1;

                var before = pos == 0 ? null : (NetWorth?)list.GetValue(pos - 1);
                var after = pos == list.Length - 1 ? null : (NetWorth?)list.GetValue(pos + 1);

                return profile.NetWorth.ToHashSet().Union(before.ToHashSet()).Union(after.ToHashSet()).ToHashSet();
            }
        }

        public static HashSet<AnnualIncome> GetAnnualIncome(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.AnnualIncome.Count != 0)
            {
                return filter.AnnualIncome;
            }
            else
            {
                var list = EnumHelper.GetArray<AnnualIncome>();
                if (!profile.AnnualIncome.HasValue) return list.ToHashSet();

                var pos = (int)profile.AnnualIncome - 1;

                var before = pos == 0 ? null : (AnnualIncome?)list.GetValue(pos - 1);
                var after = pos == list.Length - 1 ? null : (AnnualIncome?)list.GetValue(pos + 1);

                return profile.AnnualIncome.ToHashSet().Union(before.ToHashSet()).Union(after.ToHashSet()).ToHashSet();
            }
        }

        #endregion LIFESTYLE - PROFILE COMPATIBILITY OR SEARCH SETTINGS (IF COMPLETED)

        #region PERSONALITY - PROFILE COMPATIBILITY

        public static HashSet<MoneyPersonality> GetMoneyPersonality(ProfileModel profile)
        {
            return profile.MoneyPersonality.ToArray();
        }

        public static HashSet<SharedSpendingStyle> GetSharedSpendingStyle(ProfileModel profile)
        {
            //Invented by ChatGPD

            return profile.SharedSpendingStyle switch
            {
                SharedSpendingStyle.Provider => SharedSpendingStyle.Dependent.ToArray(),
                SharedSpendingStyle.Contributor => SharedSpendingStyle.Supporter.ToArray(),
                SharedSpendingStyle.Balanced => SharedSpendingStyle.Balanced.ToArray(),
                SharedSpendingStyle.Supporter => SharedSpendingStyle.Contributor.ToArray(),
                SharedSpendingStyle.Dependent => SharedSpendingStyle.Provider.ToArray(),
                _ => []
            };
        }

        public static HashSet<RelationshipPersonality> GetRelationshipPersonality(ProfileModel profile)
        {
            //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

            return profile.RelationshipPersonality switch
            {
                RelationshipPersonality.Explorers => RelationshipPersonality.Explorers.ToArray(),
                RelationshipPersonality.Directors => RelationshipPersonality.Negotiator.ToArray(),
                RelationshipPersonality.Builders => RelationshipPersonality.Builders.ToArray(),
                RelationshipPersonality.Negotiator => RelationshipPersonality.Directors.ToArray(),
                _ => []
            };
        }

        public static HashSet<MyersBriggsTypeIndicator> GetMyersBriggsTypeIndicator(ProfileModel profile)
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

                MyersBriggsTypeIndicator.INFJ => [MyersBriggsTypeIndicator.ENFP, MyersBriggsTypeIndicator.ENTP, MyersBriggsTypeIndicator.INTJ, MyersBriggsTypeIndicator.INFJ],
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
                _ => []
            };
        }

        public static HashSet<LoveLanguage> GetLoveLanguage(ProfileModel profile)
        {
            return profile.LoveLanguage.ToArray();
        }

        public static HashSet<SexPersonality> GetSexPersonality(ProfileModel profile)
        {
            if (profile.SexPersonalityPreference.Count != 0)
            {
                return profile.SexPersonalityPreference;
            }
            else
            {
                return profile.SexPersonality.ToArray();
            }
        }

        #endregion PERSONALITY - PROFILE COMPATIBILITY

        #region INTEREST - PROFILE COMPATIBILITY (A SINGLE SAME OPTION ALREADY INDICATES COMPATIBILITY)

        public static HashSet<Food> GetFood(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.Food.Count != 0)
                return filter.Food;
            else
                return profile.Food;
        }

        public static HashSet<Vacation> GetVacation(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.Vacation.Count != 0)
                return filter.Vacation;
            else
                return profile.Vacation;
        }

        public static HashSet<Sports> GetSports(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.Sports.Count != 0)
                return filter.Sports;
            else
                return profile.Sports;
        }

        public static HashSet<LeisureActivities> GetLeisureActivities(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.LeisureActivities.Count != 0)
                return filter.LeisureActivities;
            else
                return profile.LeisureActivities;
        }

        public static HashSet<MusicGenre> GetMusicGenre(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.MusicGenre.Count != 0)
                return filter.MusicGenre;
            else
                return profile.MusicGenre;
        }

        public static HashSet<MovieGenre> GetMovieGenre(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.MovieGenre.Count != 0)
                return filter.MovieGenre;
            else
                return profile.MovieGenre;
        }

        public static HashSet<TVGenre> GetTVGenre(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.TVGenre.Count != 0)
                return filter.TVGenre;
            else
                return profile.TVGenre;
        }

        public static HashSet<ReadingGenre> GetReadingGenre(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.ReadingGenre.Count != 0)
                return filter.ReadingGenre;
            else
                return profile.ReadingGenre;
        }

        #endregion INTEREST - PROFILE COMPATIBILITY (A SINGLE SAME OPTION ALREADY INDICATES COMPATIBILITY)

        #region RELATIONSHIP - FIELD SPECIFIC RULES

        public static HashSet<SharedFinances> GetSharedFinances(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.SharedFinances.Count != 0)
                return filter.SharedFinances;
            else
                return profile.SharedFinances switch
                {
                    SharedFinances.JointAccounts => [SharedFinances.JointAccounts, SharedFinances.HybridApproach],
                    SharedFinances.SeparateAccounts => [SharedFinances.SeparateAccounts, SharedFinances.HybridApproach],
                    SharedFinances.HybridApproach => [SharedFinances.JointAccounts, SharedFinances.SeparateAccounts, SharedFinances.HybridApproach],
                    _ => []
                };
        }

        public static HashSet<ConflictResolutionStyle> GetConflictResolutionStyle(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.ConflictResolutionStyle.Count != 0)
                return filter.ConflictResolutionStyle;
            else
                return profile.ConflictResolutionStyle.ToHashSet();
        }

        public static HashSet<HouseholdManagement> GetHouseholdManagement(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.HouseholdManagement.Count != 0)
                return filter.HouseholdManagement;
            else
                return profile.HouseholdManagement.ToHashSet();
        }

        public static HashSet<TimeTogetherPreference> GetTimeTogetherPreference(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.TimeTogetherPreference.Count != 0)
                return filter.TimeTogetherPreference;
            else
                return profile.TimeTogetherPreference switch
                {
                    TimeTogetherPreference.AloneTime => [TimeTogetherPreference.AloneTime, TimeTogetherPreference.BalancedTime],
                    TimeTogetherPreference.BalancedTime => [TimeTogetherPreference.AloneTime, TimeTogetherPreference.BalancedTime, TimeTogetherPreference.QualityTogether],
                    TimeTogetherPreference.QualityTogether => [TimeTogetherPreference.BalancedTime, TimeTogetherPreference.QualityTogether],
                    _ => []
                };
        }

        public static HashSet<OppositeSexFriendships> GetOppositeSexFriendships(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.OppositeSexFriendships.Count != 0)
                return filter.OppositeSexFriendships;
            else
                return profile.OppositeSexFriendships switch
                {
                    OppositeSexFriendships.Comfortable => [OppositeSexFriendships.Comfortable, OppositeSexFriendships.BoundariesNeeded],
                    OppositeSexFriendships.BoundariesNeeded => [OppositeSexFriendships.Comfortable, OppositeSexFriendships.BoundariesNeeded, OppositeSexFriendships.Uncomfortable],
                    OppositeSexFriendships.Uncomfortable => [OppositeSexFriendships.BoundariesNeeded, OppositeSexFriendships.Uncomfortable],
                    _ => []
                };
        }

        #endregion RELATIONSHIP - FIELD SPECIFIC RULES

        #region GOALS - FIELD SPECIFIC RULES

        public static HashSet<RelationshipIntention> GetRelationshipIntentions(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.RelationshipIntentions.Count != 0)
                return filter.RelationshipIntentions;
            else
                return profile.RelationshipIntentions.ToHashSet();
        }

        public static HashSet<Relocation> GetRelocation(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.Relocation.HasValue)
                return filter.Relocation.ToHashSet();
            else
                return profile.Relocation.ToHashSet();
        }

        public static HashSet<WantChildren> GetWantChildren(ProfileModel profile, FilterModel? filter)
        {
            if (filter != null && filter.WantChildren.Count != 0)
            {
                return filter.WantChildren;
            }
            else
            {
                return profile.WantChildren switch
                {
                    WantChildren.No => [WantChildren.No],
                    WantChildren.Maybe => [WantChildren.Maybe, WantChildren.Yes],
                    WantChildren.Yes => [WantChildren.Maybe, WantChildren.Yes],
                    _ => []
                };
            }
        }

        public static HashSet<IdealPlaceToLive> GetIdealPlaceToLive(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.IdealPlaceToLive.Count != 0)
            {
                return filter.IdealPlaceToLive;
            }
            else
            {
                return profile.IdealPlaceToLive switch
                {
                    IdealPlaceToLive.Urban => [IdealPlaceToLive.Urban],
                    IdealPlaceToLive.Suburban => [IdealPlaceToLive.Suburban],
                    IdealPlaceToLive.Rural => [IdealPlaceToLive.Rural],
                    IdealPlaceToLive.Flexible => [IdealPlaceToLive.Urban, IdealPlaceToLive.Suburban, IdealPlaceToLive.Rural, IdealPlaceToLive.Flexible],
                    _ => []
                };
            }
        }

        #endregion GOALS - FIELD SPECIFIC RULES

        public static int GetPercentAffinity(this List<AffinityVM> affinities, Section? category = null)
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

                return (totalBasic * weightBasic +
                    totalBio * weightBio +
                    totalLifestyle * weightLifestyle +
                    totalPersonality * weightPersonality +
                    totalInterest * weightInterest +
                    totalRelationship * weightRelationship +
                    totalGoals + weightGoals) /
                    (weightBasic + weightBio + weightLifestyle + weightPersonality + weightInterest + weightRelationship + weightGoals);
            }
            else
            {
                var totCheck = affinities.Count(w => w.Section == category && w.HaveAffinity);
                var totItens = affinities.Count(w => w.Section == category);

                if (totCheck == 0 || totItens == 0) return 0;

                return Convert.ToInt32(Math.Round((double)totCheck / totItens * 100, 0));
            }
        }
    }
}