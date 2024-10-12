using MM.Shared.Models.Profile;

namespace MM.WEB.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(ProfileModel? profile, FilterModel? filter)
        {
            if (profile == null) throw new NotificationException("Preenchimento de cadastro do perfil não encontrado");
            filter ??= new FilterModel();

            //BASIC
            filter.Region = Region.City;
            filter.Languages = profile.Languages;
            filter.CurrentSituation = AffinityCore.GetCurrentSituation(profile);
            //looking.Intent = profile.Basic.Intent; //selecionado ao carregar a tela
            filter.BiologicalSex = AffinityCore.GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            filter.SexualOrientations = AffinityCore.GetSexualOrientations(profile);

            //BIO
            var ages = AffinityCore.GetAge(profile, filter, true);
            filter.MinimalAge = ages[0];
            filter.MaxAge = ages[1];
            var heights = AffinityCore.GetHeight(profile, filter, true);
            filter.MinimalHeight = heights[0];
            filter.MaxHeight = heights[1];
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