using MM.Shared.Models.Profile;

namespace MM.WEB.Core
{
    public static class AffinityCore
    {
        public static List<AffinityVM> GetAffinity(ProfileModel? user, ProfileModel? view)
        {
            if (user == null) throw new NotificationException("Não foi possível identificar seu perfil");
            if (view == null) throw new NotificationException("Não foi possível identificar o perfil deste usuário");
            if (user.Preference == null) throw new NotificationException("Não foi possível identificar suas preferências");

            var obj = new List<AffinityVM>
            {
                //BASIC - DEFINIÇÕES DE BUSCA
                //new AffinityVM(Section.Basic, CompatibilityItem.Location, GetLocation(user) == view.Location),
                new(Section.Basic, CompatibilityItem.Language, GetLanguages(user, user.Preference).IsMatch(view.Languages)),
                new(Section.Basic, CompatibilityItem.CurrentSituation, GetCurrentSituation(user, user.Preference).IsMatch(view.CurrentSituation.ToArray())),
                new(Section.Basic, CompatibilityItem.Intentions, GetIntentions(user).IsMatch(view.Intentions)),
                new(Section.Basic, CompatibilityItem.BiologicalSex, GetBiologicalSex(user, user.Preference).IsMatch(view.BiologicalSex.ToArray())),
                new(Section.Basic, CompatibilityItem.GenderIdentity, GetGenderIdentity(user, user.Preference).IsMatch(view.GenderIdentity.ToArray())),
                new(Section.Basic, CompatibilityItem.SexualOrientation, GetSexualOrientation(user, user.Preference).IsMatch(view.SexualOrientation.ToArray())),

                //BIO - DEFINIÇÕES DE BUSCA
                new(Section.Bio, CompatibilityItem.RaceCategory, GetRaceCategory(user.Preference).IsMatch(view.RaceCategory.ToArray())),
                new(Section.Bio, CompatibilityItem.BodyMass, GetBodyMass(user.Preference).IsMatch(view.BodyMass.ToArray())),
                new(Section.Bio, CompatibilityItem.Age, GetAge(user, user.Preference).IsRangeMatch(view.Age.ToArray())),
                new(Section.Bio, CompatibilityItem.Zodiac, GetZodiac(user).IsMatch(view.Zodiac.ToArray())),
                new(Section.Bio, CompatibilityItem.Height, GetHeight(user, user.Preference).Select(s => (int)s).IsRangeMatch(((int?)view.Height).ToArray())),
                new(Section.Bio, CompatibilityItem.Neurodiversity, GetNeurodiversity(user.Preference).IsMatch(view.Neurodiversity.ToArray())),
                new(Section.Bio, CompatibilityItem.Disabilities, GetDisability(user.Preference).IsMatch(view.Disabilities)),

                //LIFESTYLE - COMPATIBILIDADE DE PERFIL OU DEFINIÇÕES DE BUSCA (SE PREENCHIDO)
                new(Section.Lifestyle, CompatibilityItem.Drink, GetDrink(user, user.Preference).IsMatch(view.Drink.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Smoke, GetSmoke(user, user.Preference).IsMatch(view.Smoke.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Diet, GetDiet(user, user.Preference).IsMatch(view.Diet.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.Religion, GetReligion(user, user.Preference).IsMatch(view.Religion.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.HaveChildren, GetHaveChildren(user, user.Preference).IsMatch(view.HaveChildren.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.WantChildren, GetWantChildren(user, user.Preference).IsMatch(view.WantChildren.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.EducationLevel, GetEducationLevel(user, user.Preference).IsMatch(view.EducationLevel.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.CareerCluster, GetCareerCluster(user, user.Preference).IsMatch(view.CareerCluster.ToArray())),
                new(Section.Lifestyle, CompatibilityItem.TravelFrequency, GetTravelFrequency(user, user.Preference).IsMatch(view.TravelFrequency.ToArray())),

                //PERSONALITY - COMPATIBILIDADE DE PERFIL
                new(Section.Personality, CompatibilityItem.MoneyPersonality, GetMoneyPersonality(user).IsMatch(view.MoneyPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SharedSpendingStyle, GetSharedSpendingStyle(user).IsMatch(view.SharedSpendingStyle.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.RelationshipPersonality, GetRelationshipPersonality(user).IsMatch(view.RelationshipPersonality.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, GetMyersBriggsTypeIndicator(user).IsMatch(view.MBTI.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.LoveLanguage, GetLoveLanguage(user).IsMatch(view.LoveLanguage.ToArray(), true)),
                new(Section.Personality, CompatibilityItem.SexPersonality, GetSexPersonality(user).IsMatch(view.SexPersonality.ToArray(), true)),

                //INTEREST - COMPATIBILIDADE DE PERFIL (UMA OPÇAO IGUAL JÁ INDICA COMPATIBILIDADE)
                new(Section.Interest, CompatibilityItem.Food, GetFood(user).IsMatch(view.Food)),
                new(Section.Interest, CompatibilityItem.Vacation, GetVacation(user).IsMatch(view.Vacation)),
                new(Section.Interest, CompatibilityItem.Sports, GetSports(user).IsMatch(view.Sports)),
                new(Section.Interest, CompatibilityItem.LeisureActivities, GetLeisureActivities(user).IsMatch(view.LeisureActivities)),
                new(Section.Interest, CompatibilityItem.MusicGenre, GetMusicGenre(user).IsMatch(view.MusicGenre)),
                new(Section.Interest, CompatibilityItem.MovieGenre, GetMovieGenre(user).IsMatch(view.MovieGenre)),
                new(Section.Interest, CompatibilityItem.TVGenre, GetTVGenre(user).IsMatch(view.TVGenre)),
                new(Section.Interest, CompatibilityItem.ReadingGenre, GetReadingGenre(user).IsMatch(view.ReadingGenre)),
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

        private static bool IsMatch<T>(this HashSet<T> preferences, HashSet<T> view, bool force = false)
        {
            if (force && preferences.Count == 0) return false; //if preferences is required
            if (preferences.Count == 0) return true; //if preferences are empty then accept all
            if (view.Count == 0) return false; //if the preference is not empty and the view is empty then it does not accept anything

            return preferences.Intersect(view).Any();
        }

        private static bool IsRangeMatch(this IEnumerable<int> preferences, IEnumerable<int> view)
        {
            if (!preferences.Any()) return true; //if preferences are empty then accept all
            if (!view.Any()) return false; //if the preference is not empty and the view is empty then it does not accept anything
            if (preferences.Count() != 2) throw new InvalidOperationException("preferences.Count != 2");

            return preferences.First() <= view.First() && view.First() <= preferences.Last();
        }

        #region BASIC

        public static string GetLocation(ProfileModel user)
        {
            var parts = user.Location?.Split(" - ") ?? [];

            return user.Preference?.Region switch
            {
                Region.City => user.Location, //level 3
                Region.State => $"{parts[0]} - {parts[1]}", //level 2
                Region.Country => $"{parts[0]}", //level 1
                Region.World => "",
                _ => "",
            } ?? "";
        }

        public static HashSet<Language> GetLanguages(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Languages.Count != 0) return pref.Languages;
            else if (user.Languages.Count != 0) return user.Languages;
            else return [];
        }

        public static HashSet<CurrentSituation> GetCurrentSituation(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            HashSet<CurrentSituation> selected;
            if (pref != null && pref.CurrentSituation.Count != 0) selected = pref.CurrentSituation;
            else if (user.CurrentSituation.HasValue) selected = user.CurrentSituation.ToArray();
            else selected = [];

            if (selected.Count == 1 && selected.First() == CurrentSituation.Single)
                return selected;
            else
                return [];
        }

        public static HashSet<Intentions> GetIntentions(ProfileModel user)
        {
            return user.Intentions;
        }

        public static HashSet<BiologicalSex> GetBiologicalSex(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.BiologicalSex.Count != 0)
            {
                return pref.BiologicalSex;
            }
            else
            {
                if (user.GenderIdentity == GenderIdentity.Cisgender) //BINARY
                {
                    if (user.SexualOrientation == SexualOrientation.Heterosexual)
                    {
                        return user.BiologicalSex switch
                        {
                            BiologicalSex.Male => BiologicalSex.Female.ToArray(),
                            BiologicalSex.Female => BiologicalSex.Male.ToArray(),
                            _ => []
                        };
                    }
                    else if (user.SexualOrientation == SexualOrientation.Homosexual)
                    {
                        return user.BiologicalSex switch
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

        public static HashSet<GenderIdentity> GetGenderIdentity(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.GenderIdentity.Count != 0)
            {
                return pref.GenderIdentity;
            }
            else
            {
                if (user.GenderIdentity == GenderIdentity.Cisgender) //BINARY
                {
                    return GenderIdentity.Cisgender.ToArray();
                }
                else //NON-BINARY
                {
                    return [];
                }
            }
        }

        public static HashSet<SexualOrientation> GetSexualOrientation(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.SexualOrientation.Count != 0)
            {
                return pref.SexualOrientation;
            }
            else
            {
                return user.SexualOrientation switch
                {
                    SexualOrientation.Heterosexual => [SexualOrientation.Heterosexual],
                    SexualOrientation.Homosexual => [SexualOrientation.Homosexual],
                    _ => []
                };
            }
        }

        #endregion BASIC

        #region BIO

        public static HashSet<RaceCategory> GetRaceCategory(ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.RaceCategory.Count != 0) return pref.RaceCategory;
            else return [];
        }

        public static HashSet<BodyMass> GetBodyMass(ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.BodyMass.Count != 0) return pref.BodyMass;
            else return [];
        }

        public static int[] GetAge(ProfileModel user, ProfilePreferenceModel? pref = null, bool force = false)
        {
            int min;
            int max;

            if (pref != null && !force)
            {
                min = pref.MinimalAge;
                max = pref.MaxAge;
            }
            else
            {
                var age = user.BirthDate.GetAge();

                min = age / 2 + 9;
                if (min < 18) min = 18;

                max = (age - 9) * 2;
                if (max > 120) max = 120;
            }

            return [min, max];
        }

        public static HashSet<Zodiac> GetZodiac(ProfileModel user)
        {
            return user.Zodiac switch
            {
                Zodiac.Aries => [Zodiac.Leo, Zodiac.Sagittarius],
                Zodiac.Taurus => [Zodiac.Virgo, Zodiac.Capricorn],
                Zodiac.Gemini => [Zodiac.Libra, Zodiac.Aquarius],
                Zodiac.Cancer => [Zodiac.Scorpio, Zodiac.Pisces],
                Zodiac.Leo => [Zodiac.Aries, Zodiac.Sagittarius],
                Zodiac.Virgo => [Zodiac.Taurus, Zodiac.Capricorn],
                Zodiac.Libra => [Zodiac.Gemini, Zodiac.Aquarius],
                Zodiac.Scorpio => [Zodiac.Cancer, Zodiac.Scorpio, Zodiac.Pisces],
                Zodiac.Sagittarius => [Zodiac.Aries, Zodiac.Leo],
                Zodiac.Capricorn => [Zodiac.Taurus, Zodiac.Virgo],
                Zodiac.Aquarius => [Zodiac.Gemini, Zodiac.Libra],
                Zodiac.Pisces => [Zodiac.Cancer, Zodiac.Scorpio],
                _ => []
            };
        }

        public static Height[] GetHeight(ProfileModel user, ProfilePreferenceModel? pref = null, bool force = false)
        {
            Height min;
            Height max;
            var ratio = 1.09;

            if (pref != null && pref.MinimalHeight.HasValue && !force)
            {
                min = pref.MinimalHeight.Value;
            }
            else
            {
                if (user.Height.HasValue)
                {
                    int minHeight;

                    if (pref != null && pref.BiologicalSex.Count != 0 && pref.BiologicalSex.Count == 1)
                    {
                        //TODO: USE CONTAINS?
                        if (user.BiologicalSex == BiologicalSex.Male && pref.BiologicalSex.First() == BiologicalSex.Female)
                        {
                            minHeight = (int)Math.Round((int)user.Height.Value / (ratio + 0.04));
                        }
                        else if (user.BiologicalSex == BiologicalSex.Female && pref.BiologicalSex.First() == BiologicalSex.Male)
                        {
                            minHeight = (int)Math.Round((int)user.Height.Value * (ratio - 0.04));
                        }
                        else
                        {
                            minHeight = (int)user.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        minHeight = (int)user.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (minHeight < (int)Height._140) minHeight = (int)Height._140;
                    min = (Height)minHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            if (pref != null && pref.MaxHeight.HasValue && !force)
            {
                max = pref.MaxHeight.Value;
            }
            else
            {
                if (user.Height.HasValue)
                {
                    int maxHeight;

                    if (pref != null && pref.BiologicalSex.Count != 0 && pref.BiologicalSex.Count == 1)
                    {
                        //TODO: USE CONTAINS?
                        if (user.BiologicalSex == BiologicalSex.Male && pref.BiologicalSex.First() == BiologicalSex.Female)
                        {
                            maxHeight = (int)Math.Round((int)user.Height.Value / (ratio - 0.04));
                        }
                        else if (user.BiologicalSex == BiologicalSex.Female && pref.BiologicalSex.First() == BiologicalSex.Male)
                        {
                            maxHeight = (int)Math.Round((int)user.Height.Value * (ratio + 0.04));
                        }
                        else
                        {
                            maxHeight = (int)user.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        maxHeight = (int)user.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (maxHeight > (int)Height._192) maxHeight = (int)Height._192;
                    max = (Height)maxHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            return [min, max];
        }

        public static HashSet<Neurodiversity> GetNeurodiversity(ProfilePreferenceModel? pref = null)
        {
            if (pref != null)
                return pref.Neurodiversities;
            else
                return [];
        }

        public static HashSet<Disability> GetDisability(ProfilePreferenceModel? pref = null)
        {
            if (pref != null)
                return pref.Disabilities;
            else
                return [];
        }

        #endregion BIO

        #region LIFESTYLE

        public static HashSet<Drink> GetDrink(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Drink.Count != 0)
            {
                return pref.Drink;
            }
            else
            {
                return user.Drink switch
                {
                    Drink.No => [Drink.No, Drink.YesLight],
                    Drink.YesLight => [Drink.No, Drink.YesLight, Drink.YesModerate],
                    Drink.YesModerate => [Drink.YesLight, Drink.YesModerate, Drink.YesHeavy],
                    Drink.YesHeavy => [Drink.YesModerate, Drink.YesHeavy],
                    _ => []
                };
            }
        }

        public static HashSet<Smoke> GetSmoke(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Smoke.Count != 0)
            {
                return pref.Smoke;
            }
            else
            {
                return user.Smoke switch
                {
                    Smoke.No => [Smoke.No],
                    Smoke.YesOccasionally => [Smoke.YesOccasionally, Smoke.YesOften],
                    Smoke.YesOften => [Smoke.YesOccasionally, Smoke.YesOften],
                    _ => []
                };
            }
        }

        public static HashSet<Diet> GetDiet(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Diet.Count != 0)
            {
                return pref.Diet;
            }
            else
            {
                var group01 = new HashSet<Diet>([Diet.Omnivore, Diet.Flexitarian, Diet.GlutenFree]);
                var group02 = new HashSet<Diet>([Diet.Vegetarian, Diet.Vegan]);
                var group03 = new HashSet<Diet>([Diet.RawFood, Diet.OrganicAllnaturalLocal]);

                return user.Diet switch
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

        public static HashSet<Religion> GetReligion(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Religion.Count != 0)
            {
                return pref.Religion;
            }
            else
            {
                return [user.Religion ?? throw new NotificationException("Religion null")];
            }
        }

        public static HashSet<HaveChildren> GetHaveChildren(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.HaveChildren.Count != 0)
            {
                return pref.HaveChildren;
            }
            else
            {
                return user.HaveChildren switch
                {
                    HaveChildren.No => [HaveChildren.No, HaveChildren.YesNo],
                    HaveChildren.YesNo => [HaveChildren.No, HaveChildren.YesNo],
                    HaveChildren.Yes => [HaveChildren.Yes],
                    _ => []
                };
            }
        }

        public static HashSet<WantChildren> GetWantChildren(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.WantChildren.Count != 0)
            {
                return pref.WantChildren;
            }
            else
            {
                return user.WantChildren switch
                {
                    WantChildren.No => [WantChildren.No],
                    WantChildren.Maybe => [WantChildren.Maybe, WantChildren.Yes],
                    WantChildren.Yes => [WantChildren.Maybe, WantChildren.Yes],
                    _ => []
                };
            }
        }

        public static HashSet<EducationLevel> GetEducationLevel(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.EducationLevel.Count != 0)
            {
                return pref.EducationLevel;
            }
            else
            {
                return [user.EducationLevel ?? throw new NotificationException("EducationLevel null")];
            }
        }

        public static HashSet<CareerCluster> GetCareerCluster(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.CareerCluster.Count != 0)
            {
                return pref.CareerCluster;
            }
            else
            {
                return [user.CareerCluster ?? throw new NotificationException("CareerCluster null")];
            }
        }

        public static HashSet<TravelFrequency> GetTravelFrequency(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.TravelFrequency.Count != 0)
            {
                return pref.TravelFrequency;
            }
            else
            {
                return user.TravelFrequency switch
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

        public static HashSet<MoneyPersonality> GetMoneyPersonality(ProfileModel user)
        {
            return user.MoneyPersonality.ToArray();
        }

        public static HashSet<SharedSpendingStyle> GetSharedSpendingStyle(ProfileModel user)
        {
            //invented by me (dhiogo)

            return user.SharedSpendingStyle switch
            {
                SharedSpendingStyle.Recipient => SharedSpendingStyle.Benefactor.ToArray(),
                SharedSpendingStyle.Contributor => SharedSpendingStyle.Provider.ToArray(),
                SharedSpendingStyle.Balanced => SharedSpendingStyle.Balanced.ToArray(),
                SharedSpendingStyle.Provider => SharedSpendingStyle.Contributor.ToArray(),
                SharedSpendingStyle.Benefactor => SharedSpendingStyle.Recipient.ToArray(),
                _ => []
            };
        }

        public static HashSet<RelationshipPersonality> GetRelationshipPersonality(ProfileModel user)
        {
            //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

            return user.RelationshipPersonality switch
            {
                RelationshipPersonality.Explorers => RelationshipPersonality.Explorers.ToArray(),
                RelationshipPersonality.Directors => RelationshipPersonality.Negotiator.ToArray(),
                RelationshipPersonality.Builders => RelationshipPersonality.Builders.ToArray(),
                RelationshipPersonality.Negotiator => RelationshipPersonality.Directors.ToArray(),
                _ => []
            };
        }

        public static HashSet<MyersBriggsTypeIndicator> GetMyersBriggsTypeIndicator(ProfileModel user)
        {
            //http://www.personalityrelationships.net/
            //https://web.archive.org/web/20220322143220/http://www.personalityrelationships.net/
            //https://www.sosyncd.com/the-complete-guide-to-personality-type-compatibility/

            return user.MBTI switch
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

        public static HashSet<LoveLanguage> GetLoveLanguage(ProfileModel user)
        {
            return user.LoveLanguage.ToArray();
        }

        public static HashSet<SexPersonality> GetSexPersonality(ProfileModel user)
        {
            if (user.SexPersonalityPreference.Count != 0)
            {
                return user.SexPersonalityPreference;
            }
            else
            {
                return user.SexPersonality.ToArray();
            }
        }

        #endregion PERSONALITY

        #region INTEREST

        public static HashSet<Food> GetFood(ProfileModel user)
        {
            return user.Food;
        }

        public static HashSet<Vacation> GetVacation(ProfileModel user)
        {
            return user.Vacation;
        }

        public static HashSet<Sports> GetSports(ProfileModel user)
        {
            return user.Sports;
        }

        public static HashSet<LeisureActivities> GetLeisureActivities(ProfileModel user)
        {
            return user.LeisureActivities;
        }

        public static HashSet<MusicGenre> GetMusicGenre(ProfileModel user)
        {
            return user.MusicGenre;
        }

        public static HashSet<MovieGenre> GetMovieGenre(ProfileModel user)
        {
            return user.MovieGenre;
        }

        public static HashSet<TVGenre> GetTVGenre(ProfileModel user)
        {
            return user.TVGenre;
        }

        public static HashSet<ReadingGenre> GetReadingGenre(ProfileModel user)
        {
            return user.ReadingGenre;
        }

        #endregion INTEREST

        public static int GetPercentAffinity(this List<AffinityVM> Affinities, Section? category = null)
        {
            if (category == null)
            {
                var totBasic = Affinities.GetPercentAffinity(Section.Basic);
                var totBio = Affinities.GetPercentAffinity(Section.Bio);
                var totLifestyle = Affinities.GetPercentAffinity(Section.Lifestyle);
                var totPersonality = Affinities.GetPercentAffinity(Section.Personality);
                var totInterest = Affinities.GetPercentAffinity(Section.Interest);

                var pesoBasic = 10;
                var pesoBio = 15;
                var pesoLifestyle = 20;
                var pesoPersonality = 35;
                var pesoInterest = 20;

                return (totBasic * pesoBasic + totBio * pesoBio + totLifestyle * pesoLifestyle + totPersonality * pesoPersonality + totInterest * pesoInterest) /
                    (pesoBasic + pesoBio + pesoLifestyle + pesoPersonality + pesoInterest);
            }
            else
            {
                var totCheck = Affinities.Count(w => w.Section == category && w.HaveAffinity);
                var totItens = Affinities.Count(w => w.Section == category);

                if (totCheck == 0 || totItens == 0) return 0;

                return Convert.ToInt32(Math.Round((double)totCheck / totItens * 100, 0));
            }
        }
    }
}