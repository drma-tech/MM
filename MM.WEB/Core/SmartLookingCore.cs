using MM.Shared.Models.Profile;

namespace MM.WEB.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(ProfileModel? profile, FilterModel? filter)
        {
            if (profile == null) throw new NotificationException("Profile needs to be filled out first");
            filter ??= new FilterModel();

            //BASIC
            filter.Region = AffinityCore.GetRegion(profile.Relocation);
            filter.Languages = profile.Languages;
            filter.MaritalStatus = AffinityCore.GetMaritalStatus(filter);
            //looking.Intent = profile.Basic.Intent; //selecionado ao carregar a tela
            filter.BiologicalSex = AffinityCore.GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            filter.SexualOrientations = AffinityCore.GetSexualOrientations(filter, profile.SexualOrientations);

            //BIO
            var ages = AffinityCore.GetAge(filter, profile.BirthDate);
            if (ages.Length > 0)
            {
                filter.MinimalAge = ages[0];
                filter.MaxAge = ages[1];
            }

            var heights = AffinityCore.GetHeight(profile, filter);
            if (heights.Length > 0)
            {
                filter.MinimalHeight = heights[0];
                filter.MaxHeight = heights[1];
            }
            //looking.RaceCategory = null;
            //looking.BodyMass = null;

            //LIFESTYLE
            //preference.Drink = GetDrink(profile);
            //preference.Smoke = GetSmoke(profile);
            //preference.Diet = GetDiet(profile);
            //preference.Religion = GetReligion(profile);

            //preference.HaveChildren = GetHaveChildren(profile);
            //preference.WantChildren = GetWantChildren(profile);
            //preference.EducationLevel = GetEducationLevel(profile);
            //preference.CareerCluster = GetCareerCluster(profile);
            //preference.TravelFrequency = AffinityCore.GetTravelFrequency(profile, preference);
        }
    }
}