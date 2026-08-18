using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Profile;
using MM.WEB.Core.Enum;
using MM.WEB.Core.Models;
using MM.WEB.Modules.Shared.Field;
using MudBlazor;

namespace MM.WEB.Shared.Field.View
{
    public partial class MMCustomChip<TValue, TValueUser>
    {
        [Parameter] public string? Name { get; set; }
        [Parameter] public string? WhyImportant { get; set; }
        [Parameter] public string? Tips { get; set; }

        [Parameter] public TValue? Value { get; set; }
        [Parameter] public IEnumerable<TValue>? Values { get; set; }
        [Parameter] public TValueUser? ValueUser { get; set; }
        [Parameter] public IEnumerable<TValueUser>? ValuesUser { get; set; }
        [Parameter] public string? ClassIcon { get; set; }
        [Parameter] public IReadOnlyCollection<AffinityVM> Affinities { get; set; } = [];

        [Parameter] public CompatibilityType Type { get; set; }
        [Parameter] public CompatibilityItem Item { get; set; }
        [Parameter] public ProfileModel? User { get; set; }
        [Parameter] public FilterModel? Filter { get; set; }

        private const string NotAnswered = "Not Answered";

        private static string GetValue(TValue? value)
        {
            if (value == null) return NotAnswered;
            if (string.Equals(value?.ToString(), "0", StringComparison.Ordinal)) return NotAnswered;

            if (value is string resultS)
            {
                if (string.IsNullOrEmpty(resultS))
                    return NotAnswered;
                return resultS;
            }

            if (value is int resultI)
            {
                if (resultI <= 0)
                    return NotAnswered;
                return resultI.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }

            if (value is Enum resultE)
            {
                var result = resultE.GetFieldSettings().Name;

                if (string.IsNullOrEmpty(result))
                    return NotAnswered;
                return result;
            }

            throw new InvalidOperationException($"invalid type: {value?.GetType()}");
        }

        private Color GetColor(TValue? value)
        {
            if (!Affinities.Any(s => s.Item == Item)) //if the attribute is not mapped to affinity, it remains neutral
            {
                return Color.Secondary;
            }

            if (Affinities.Single(s => s.Item == Item).HaveAffinity) //if it is mapped and has affinity
            {
                if (value == null)
                {
                    return Color.Success;
                }

                if (value is Enum result && Type == CompatibilityType.Enum)
                {
                    if (!GetExpectedValue().Any() || GetExpectedValue().Contains(result.GetFieldSettings().Name, StringComparer.OrdinalIgnoreCase))
                        return Color.Success;
                    return Color.Warning;
                }

                return Color.Success;
            }

            //if mapped but without affinity
            return Color.Error;
        }

        public Task InstantiateModal()
        {
            if (Values == null && Value != null) Values = [Value];
            if (Values == null && Value == null) Values = [];

            var parameters = new DialogParameters<AboutItemModal<TValue>>
            {
                { x => x.PreferenceValues, GetPreferenceValues() },
                { x => x.ExpectedValues, GetExpectedValue() },
                { x => x.ViewValues, Values },
                { x => x.Affinities, Affinities },
                { x => x.Profile, User },
                { x => x.Type, Type },
                { x => x.Item, Item },
                { x => x.WhyImportant, WhyImportant },
                { x => x.Tips, Tips },
            };

            return DialogService.ShowAsync<AboutItemModal<TValue>>(Name, parameters, PopupHelper.Options(MaxWidth.Medium));
        }

        private IEnumerable<string> GetPreferenceValues()
        {
            foreach (var item in ValuesUser ?? [ValueUser!])
            {
                if (item is Enum resultE)
                {
                    yield return resultE.GetFieldSettings().Name;
                }
                else if (item != null)
                {
                    yield return item.ToString()!;
                }
            }
        }

        private IEnumerable<string?> GetExpectedValue()
        {
            if (User == null) return [];

            if (!GetPreferenceValues().Any()) return [];

            return Item switch
            {
                //BASIC
                CompatibilityItem.Location => AffinityCore.GetLocation(Filter, User.Location).loc.ToArray(),
                CompatibilityItem.Language => AffinityCore.GetLanguages(Filter, User.Languages).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.MaritalStatus => AffinityCore.GetMaritalStatus(Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.BiologicalSex => AffinityCore.GetBiologicalSex(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.GenderIdentities => AffinityCore.GetGenderIdentities(Filter, User.GenderIdentities).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.SexualOrientations => AffinityCore.GetSexualOrientations(Filter, User.SexualOrientations).Select(s => s.GetFieldSettings().Name),
                //BIO
                CompatibilityItem.Ethnicity => AffinityCore.GetEthnicity(Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.BodyType => AffinityCore.GetBodyType(Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Age => AffinityCore.GetAge(Filter, User.BirthDate).Select(s => s.ToString(System.Globalization.CultureInfo.InvariantCulture)),
                CompatibilityItem.Height => AffinityCore.GetHeight(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Neurodiversity => AffinityCore.GetNeurodiversity(Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Disabilities => AffinityCore.GetDisability(Filter).Select(s => s.GetFieldSettings().Name),
                //LIFESTYLE
                CompatibilityItem.Drink => AffinityCore.GetDrink(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Smoke => AffinityCore.GetSmoke(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Diet => AffinityCore.GetDiet(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Religion => AffinityCore.GetReligion(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.FamilyInvolvement => AffinityCore.GetFamilyInvolvement(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.HaveChildren => AffinityCore.GetHaveChildren(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.HavePets => AffinityCore.GetHavePets(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.EducationLevel => AffinityCore.GetEducationLevel(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.CareerCluster => AffinityCore.GetCareerCluster(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.LivingSituation => AffinityCore.GetLivingSituation(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.TravelFrequency => AffinityCore.GetTravelFrequency(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.NetWorth => AffinityCore.GetNetWorth(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.AnnualIncome => AffinityCore.GetAnnualIncome(User, Filter).Select(s => s.GetFieldSettings().Name),
                //PERSONALITY
                CompatibilityItem.MoneyPersonality => AffinityCore.GetMoneyPersonality(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.SharedSpendingStyle => AffinityCore.GetSharedSpendingStyle(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.RelationshipPersonality => AffinityCore.GetRelationshipPersonality(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.MyersBriggsTypeIndicator => AffinityCore.GetMyersBriggsTypeIndicator(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.LoveLanguage => AffinityCore.GetLoveLanguage(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.SexPersonality => AffinityCore.GetSexPersonality(User).Select(s => s.GetFieldSettings().Name),
                //INTEREST
                CompatibilityItem.Food => AffinityCore.GetFood(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Vacation => AffinityCore.GetVacation(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Sports => AffinityCore.GetSports(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.LeisureActivities => AffinityCore.GetLeisureActivities(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.MusicGenre => AffinityCore.GetMusicGenre(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.MovieGenre => AffinityCore.GetMovieGenre(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.TVGenre => AffinityCore.GetTVGenre(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.ReadingGenre => AffinityCore.GetReadingGenre(User, Filter).Select(s => s.GetFieldSettings().Name),
                //RELATIONSHIP
                CompatibilityItem.SharedFinances => AffinityCore.GetSharedFinances(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.ConflictResolutionStyle => AffinityCore.GetConflictResolutionStyle(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.HouseholdManagement => AffinityCore.GetHouseholdManagement(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.TimeTogetherPreference => AffinityCore.GetTimeTogetherPreference(User).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.OppositeSexFriendships => AffinityCore.GetOppositeSexFriendships(User).Select(s => s.GetFieldSettings().Name),
                //GOALS
                CompatibilityItem.RelationshipIntentions => AffinityCore.GetRelationshipIntentions(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.Relocation => AffinityCore.GetRelocation(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.WantChildren => AffinityCore.GetWantChildren(User, Filter).Select(s => s.GetFieldSettings().Name),
                CompatibilityItem.IdealPlaceToLive => AffinityCore.GetIdealPlaceToLive(User).Select(s => s.GetFieldSettings().Name),

                _ => throw new InvalidOperationException("invalid CompatibilityItem: " + Item),
            };
        }
    }
}
