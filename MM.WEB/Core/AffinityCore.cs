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
                //BASIC - DEFINIÇÕES DE BUSCA
                //new AffinityVM(Section.Basic, CompatibilityItem.Location, GetLocation(user) == view.Location),
                new(Section.Basic, CompatibilityItem.Language, GetLanguages(profile, filter).IsMatch(view.Languages)),
                new(Section.Basic, CompatibilityItem.MaritalStatus, GetMaritalStatus(profile, filter).IsMatch(view.MaritalStatus.ToArray())),
                new(Section.Basic, CompatibilityItem.RelationshipIntentions, GetRelationshipIntentions(profile).IsMatch(view.RelationshipIntentions)),
                new(Section.Basic, CompatibilityItem.BiologicalSex, GetBiologicalSex(profile, filter).IsMatch(view.BiologicalSex.ToArray())),
                new(Section.Basic, CompatibilityItem.GenderIdentities, GetGenderIdentities(profile, filter).IsMatch(view.GenderIdentities)),
                new(Section.Basic, CompatibilityItem.SexualOrientations, GetSexualOrientations(profile, filter).IsMatch(view.SexualOrientations)),

                //BIO - DEFINIÇÕES DE BUSCA
                new(Section.Bio, CompatibilityItem.Ethnicity, GetEthnicity(filter).IsMatch(view.Ethnicity.ToArray())),
                new(Section.Bio, CompatibilityItem.BodyType, GetBodyType(filter).IsMatch(view.BodyType.ToArray())),
                new(Section.Bio, CompatibilityItem.Age, GetAge(profile, filter).IsRangeMatch(view.Age.ToArray())),
                new(Section.Bio, CompatibilityItem.Height, GetHeight(profile, filter).Select(s => (int)s).IsRangeMatch(((int?)view.Height).ToArray())),
                new(Section.Bio, CompatibilityItem.Neurodiversity, GetNeurodiversity(filter).IsMatch(view.Neurodiversity.ToArray())),
                new(Section.Bio, CompatibilityItem.Disabilities, GetDisability(filter).IsMatch(view.Disabilities)),

                //LIFESTYLE - COMPATIBILIDADE DE PERFIL OU DEFINIÇÕES DE BUSCA (SE PREENCHIDO)
                new(Section.Lifestyle, CompatibilityItem.Drink, GetDrink(profile, filter).IsMatch(view.Drink.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Smoke, GetSmoke(profile, filter).IsMatch(view.Smoke.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Diet, GetDiet(profile, filter).IsMatch(view.Diet.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Religion, GetReligion(profile, filter).IsMatch(view.Religion.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.HaveChildren, GetHaveChildren(profile, filter).IsMatch(view.HaveChildren.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.WantChildren, GetWantChildren(profile, filter).IsMatch(view.WantChildren.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.EducationLevel, GetEducationLevel(profile, filter).IsMatch(view.EducationLevel.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.CareerCluster, GetCareerCluster(profile, filter).IsMatch(view.CareerCluster.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.TravelFrequency, GetTravelFrequency(profile, filter).IsMatch(view.TravelFrequency.ToArray())),

                //PERSONALITY - COMPATIBILIDADE DE PERFIL
                new(Section.Personality, CompatibilityItem.MoneyPersonality, GetMoneyPersonality(profile).IsMatch(view.MoneyPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SharedSpendingStyle, GetSharedSpendingStyle(profile).IsMatch(view.SharedSpendingStyle.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.RelationshipPersonality, GetRelationshipPersonality(profile).IsMatch(view.RelationshipPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, GetMyersBriggsTypeIndicator(profile).IsMatch(view.MBTI.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.LoveLanguage, GetLoveLanguage(profile).IsMatch(view.LoveLanguage.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SexPersonality, GetSexPersonality(profile).IsMatch(view.SexPersonality.ToArray(), true)),

                //INTEREST - COMPATIBILIDADE DE PERFIL (UMA OPÇAO IGUAL JÁ INDICA COMPATIBILIDADE)
                new(Section.Interest, CompatibilityItem.Food, GetFood(profile).IsMatch(view.Food)),
                new(Section.Interest, CompatibilityItem.Vacation, GetVacation(profile).IsMatch(view.Vacation)),
                new(Section.Interest, CompatibilityItem.Sports, GetSports(profile).IsMatch(view.Sports)),
                new(Section.Interest, CompatibilityItem.LeisureActivities, GetLeisureActivities(profile).IsMatch(view.LeisureActivities)),
                new(Section.Interest, CompatibilityItem.MusicGenre, GetMusicGenre(profile).IsMatch(view.MusicGenre)),
                new(Section.Interest, CompatibilityItem.MovieGenre, GetMovieGenre(profile).IsMatch(view.MovieGenre)),
                new(Section.Interest, CompatibilityItem.TVGenre, GetTVGenre(profile).IsMatch(view.TVGenre)),
                new(Section.Interest, CompatibilityItem.ReadingGenre, GetReadingGenre(profile).IsMatch(view.ReadingGenre)),
            };

            return obj;
        }

        public static HashSet<string> ToArray(this string item)
        {
            return [item];
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

        #region BASIC

        public static Region GetRegion(ProfileModel profile)
        {
            return profile?.Relocation switch
            {
                Relocation.NoRelocations => Region.City,
                Relocation.OpenMovingCities => Region.Country,
                Relocation.OpenMovingCountries => Region.World,
                _ => throw new NotImplementedException(),
            };
        }

        public static string GetLocation(ProfileModel profile, FilterModel? filter)
        {
            var parts = profile.Location?.Split(" - ") ?? [];

            return filter?.Region switch
            {
                Region.City => profile.Location, //level 3
                Region.State => $"{parts[0]} - {parts[1]}", //level 2
                Region.Country => $"{parts[0]}", //level 1
                Region.World => "",
                _ => "",
            } ?? "";
        }

        public static HashSet<Language> GetLanguages(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.Languages.Count != 0) return filter.Languages;
            else if (profile.Languages.Count != 0) return profile.Languages;
            else return [];
        }

        public static HashSet<MaritalStatus> GetMaritalStatus(ProfileModel profile, FilterModel? filter = null)
        {
            HashSet<MaritalStatus> selected;
            if (filter != null && filter.MaritalStatus.Count != 0) selected = filter.MaritalStatus;
            else selected = [];

            return selected;
        }

        public static HashSet<RelationshipIntention> GetRelationshipIntentions(ProfileModel profile)
        {
            return profile.RelationshipIntentions;
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

        public static HashSet<GenderIdentity> GetGenderIdentities(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.GenderIdentities.Count != 0)
            {
                return filter.GenderIdentities;
            }
            else
            {
                if (profile.GenderIdentities.Contains(GenderIdentity.Cisgender)) //BINARY
                {
                    return GenderIdentity.Cisgender.ToArray();
                }
                else //NON-BINARY
                {
                    return [];
                }
            }
        }

        public static HashSet<SexualOrientation> GetSexualOrientations(ProfileModel profile, FilterModel? filter = null)
        {
            if (filter != null && filter.SexualOrientations.Count != 0)
            {
                return filter.SexualOrientations;
            }
            else
            {
                if (profile.SexualOrientations.Contains(SexualOrientation.Heterosexual)) return [SexualOrientation.Heterosexual];
                else if (profile.SexualOrientations.Contains(SexualOrientation.Homosexual)) return [SexualOrientation.Homosexual];
                else return [];
            }
        }

        #endregion BASIC

        #region BIO

        public static HashSet<Ethnicity> GetEthnicity(FilterModel? filter = null)
        {
            if (filter != null && filter.Ethnicity.Count != 0) return filter.Ethnicity;
            else return [];
        }

        public static HashSet<BodyType> GetBodyType(FilterModel? filter = null)
        {
            if (filter != null && filter.BodyType.Count != 0) return filter.BodyType;
            else return [];
        }

        public static int[] GetAge(ProfileModel profile, FilterModel? filter = null, bool force = false)
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
                var age = profile.BirthDate.GetAge();

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

        #endregion BIO

        #region LIFESTYLE

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
                return [profile.Religion ?? throw new NotificationException("Religion null")];
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

        public static HashSet<WantChildren> GetWantChildren(ProfileModel profile, FilterModel? filter = null)
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
                return [profile.CareerCluster ?? throw new NotificationException("CareerCluster null")];
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

        #endregion LIFESTYLE

        #region PERSONALITY

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

        #endregion PERSONALITY

        #region INTEREST

        public static HashSet<Food> GetFood(ProfileModel profile)
        {
            return profile.Food;
        }

        public static HashSet<Vacation> GetVacation(ProfileModel profile)
        {
            return profile.Vacation;
        }

        public static HashSet<Sports> GetSports(ProfileModel profile)
        {
            return profile.Sports;
        }

        public static HashSet<LeisureActivities> GetLeisureActivities(ProfileModel profile)
        {
            return profile.LeisureActivities;
        }

        public static HashSet<MusicGenre> GetMusicGenre(ProfileModel profile)
        {
            return profile.MusicGenre;
        }

        public static HashSet<MovieGenre> GetMovieGenre(ProfileModel profile)
        {
            return profile.MovieGenre;
        }

        public static HashSet<TVGenre> GetTVGenre(ProfileModel profile)
        {
            return profile.TVGenre;
        }

        public static HashSet<ReadingGenre> GetReadingGenre(ProfileModel profile)
        {
            return profile.ReadingGenre;
        }

        #endregion INTEREST

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