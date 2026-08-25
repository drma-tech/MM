using Microsoft.AspNetCore.Components;
using MM.Shared.Translations.Model;

namespace MM.WEB.Modules
{
    public partial class TipsDetailsPage
    {
        [Parameter] public string? Category { get; set; }

        public Category CategoryEnum => Category.ParseToEnum<Category>();

        public IList<EnumFieldObject> Fields { get; set; } = [];

        public class EnumFieldObject
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Tips { get; set; }
        }

        protected override async Task LoadStaticDataAsync()
        {
            if (CategoryEnum == MM.Shared.Enums.Category.BASIC)
            {
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.Location_Name, Description = ProfileBasicModel.Location_Why, Tips = ProfileBasicModel.Location_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.Languages_Name, Description = ProfileBasicModel.Languages_Why, Tips = ProfileBasicModel.Languages_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.MaritalStatus_Name, Description = ProfileBasicModel.MaritalStatus_Why, Tips = ProfileBasicModel.MaritalStatus_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.BiologicalSex_Name, Description = ProfileBasicModel.BiologicalSex_Why, Tips = ProfileBasicModel.BiologicalSex_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.GenderIdentity_Name, Description = ProfileBasicModel.GenderIdentities_Why, Tips = ProfileBasicModel.GenderIdentities_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBasicModel.SexualOrientation_Name, Description = ProfileBasicModel.SexualOrientations_Why, Tips = ProfileBasicModel.SexualOrientations_Tips });
            }
            else if (CategoryEnum == MM.Shared.Enums.Category.BIO)
            {
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.Ethnicity_Name, Description = ProfileBioModel.Ethnicity_Why, Tips = ProfileBioModel.Ethnicity_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.BodyType_Name, Description = ProfileBioModel.BodyType_Why, Tips = ProfileBioModel.BodyType_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.Age_Name, Description = ProfileBioModel.Age_Why, Tips = ProfileBioModel.Age_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.Height_Name, Description = ProfileBioModel.Height_Why, Tips = ProfileBioModel.Height_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.Neurodiversity_Name, Description = ProfileBioModel.Neurodiversity_Why, Tips = ProfileBioModel.Neurodiversity_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileBioModel.Disabilities_Name, Description = ProfileBioModel.Disabilities_Why, Tips = ProfileBioModel.Disabilities_Tips });
            }
            else if (CategoryEnum == MM.Shared.Enums.Category.LIFESTYLE)
            {
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.Drink_Name, Description = ProfileLifestyleModel.Drink_Why, Tips = ProfileLifestyleModel.Drink_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.Smoke_Name, Description = ProfileLifestyleModel.Smoke_Why, Tips = ProfileLifestyleModel.Smoke_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.Diet_Name, Description = ProfileLifestyleModel.Diet_Why, Tips = ProfileLifestyleModel.Diet_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.Religion_Name, Description = ProfileLifestyleModel.Religion_Why, Tips = ProfileLifestyleModel.Religion_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.FamilyInvolvement_Name, Description = ProfileLifestyleModel.FamilyInvolvement_Why, Tips = ProfileLifestyleModel.FamilyInvolvement_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.HaveChildren_Name, Description = ProfileLifestyleModel.HaveChildren_Why, Tips = ProfileLifestyleModel.HaveChildren_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.HavePets_Name, Description = ProfileLifestyleModel.HavePets_Why, Tips = ProfileLifestyleModel.HavePets_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.EducationLevel_Name, Description = ProfileLifestyleModel.EducationLevel_Why, Tips = ProfileLifestyleModel.EducationLevel_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.CareerCluster_Name, Description = ProfileLifestyleModel.CareerCluster_Why, Tips = ProfileLifestyleModel.CareerCluster_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.LivingSituation_Name, Description = ProfileLifestyleModel.LivingSituation_Why, Tips = ProfileLifestyleModel.LivingSituation_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.TravelFrequency_Name, Description = ProfileLifestyleModel.TravelFrequency_Why, Tips = ProfileLifestyleModel.TravelFrequency_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.NetWorth_Name, Description = ProfileLifestyleModel.NetWorth_Why, Tips = ProfileLifestyleModel.NetWorth_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileLifestyleModel.AnnualIncome_Name, Description = ProfileLifestyleModel.AnnualIncome_Why, Tips = ProfileLifestyleModel.AnnualIncome_Tips });
            }
            else if (CategoryEnum == MM.Shared.Enums.Category.PERSONALITY)
            {
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.MoneyPersonality_Name, Description = ProfilePersonalityModel.MoneyPersonality_Why, Tips = ProfilePersonalityModel.MoneyPersonality_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.SharedSpendingStyle_Name, Description = ProfilePersonalityModel.SharedSpendingStyle_Why, Tips = ProfilePersonalityModel.SharedSpendingStyle_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.RelationshipPersonality_Name, Description = ProfilePersonalityModel.RelationshipPersonality_Why, Tips = ProfilePersonalityModel.RelationshipPersonality_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.MBTI_Name, Description = ProfilePersonalityModel.MBTI_Why, Tips = ProfilePersonalityModel.MBTI_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.LoveLanguage_Name, Description = ProfilePersonalityModel.LoveLanguage_Why, Tips = ProfilePersonalityModel.LoveLanguage_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfilePersonalityModel.SexPersonality_Name, Description = ProfilePersonalityModel.SexPersonality_Why, Tips = ProfilePersonalityModel.SexPersonality_Tips });
            }
            else if (CategoryEnum == MM.Shared.Enums.Category.RELATIONSHIP)
            {
                Fields.Add(new EnumFieldObject { Name = ProfileRelationshipModel.SharedFinances, Description = ProfileRelationshipModel.SharedFinances_Why, Tips = ProfileRelationshipModel.SharedFinances_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileRelationshipModel.ConflictResolutionStyle, Description = ProfileRelationshipModel.ConflictResolutionStyle_Why, Tips = ProfileRelationshipModel.ConflictResolutionStyle_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileRelationshipModel.HouseholdManagement, Description = ProfileRelationshipModel.HouseholdManagement_Why, Tips = ProfileRelationshipModel.HouseholdManagement_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileRelationshipModel.TimeTogetherPreference, Description = ProfileRelationshipModel.TimeTogetherPreference_Why, Tips = ProfileRelationshipModel.TimeTogetherPreference_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileRelationshipModel.OppositeSexFriendships, Description = ProfileRelationshipModel.OppositeSexFriendships_Why, Tips = ProfileRelationshipModel.OppositeSexFriendships_Tips });
            }
            else if (CategoryEnum == MM.Shared.Enums.Category.GOAL)
            {
                Fields.Add(new EnumFieldObject { Name = ProfileGoalModel.RelationshipIntentions, Description = ProfileGoalModel.RelationshipIntentions_Why, Tips = ProfileGoalModel.RelationshipIntentions_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileGoalModel.Relocation, Description = ProfileGoalModel.Relocation_Why, Tips = ProfileGoalModel.Relocation_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileGoalModel.WantChildren, Description = ProfileGoalModel.WantChildren_Why, Tips = ProfileGoalModel.WantChildren_Tips });
                Fields.Add(new EnumFieldObject { Name = ProfileGoalModel.IdealPlaceToLive, Description = ProfileGoalModel.IdealPlaceToLive_Why, Tips = ProfileGoalModel.IdealPlaceToLive_Tips });
            }
        }

        private static Dictionary<string, string> GetTips(string? tips)
        {
            if (string.IsNullOrEmpty(tips)) return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var values = tips.Split("|");
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < values.Length; i += 2)
            {
                var key = values[i]?.Trim();
                if (string.IsNullOrEmpty(key))
                    continue;

                // If a value is missing (odd number of tokens), indicate it instead of throwing
                var val = (i + 1) < values.Length && !string.IsNullOrEmpty(values[i + 1])
                    ? values[i + 1].Trim()
                    : Translations.Module.Profile.Undefined;

                // Use indexer to avoid exception on duplicate keys
                result[key] = val;
            }

            return result;
        }
    }
}
