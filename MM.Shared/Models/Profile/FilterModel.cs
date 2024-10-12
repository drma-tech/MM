namespace MM.Shared.Models.Profile
{
    public class FilterModel
    {
        #region BASIC

        [Custom(Name = "Region", ResourceType = typeof(Resources.FilterModel))]
        public Region Region { get; set; }

        //[Custom(Name = "Change", ResourceType = typeof(Resources.FilterModel))]
        //public Change Change { get; set; }

        [Custom(Name = "Languages", Description = "Languages_Description", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<Language> Languages { get; set; } = [];

        [Custom(Name = "CurrentSituation", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<CurrentSituation> CurrentSituation { get; set; } = [];

        [Custom(Name = "BiologicalSex", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<BiologicalSex> BiologicalSex { get; set; } = [];

        [Custom(Name = "GenderIdentity", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<GenderIdentity> GenderIdentities { get; set; } = [];

        [Custom(Name = "SexualOrientation", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<SexualOrientation> SexualOrientations { get; set; } = [];

        #endregion BASIC

        #region BIO

        [Custom(Name = "RaceCategory", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<RaceCategory> RaceCategory { get; set; } = [];

        [Custom(Name = "BodyMass", ResourceType = typeof(Resources.FilterModel))]
        public HashSet<BodyMass> BodyMass { get; set; } = [];

        [Custom(Name = "MinimalAge", ResourceType = typeof(Resources.FilterModel))]
        public int MinimalAge { get; set; }

        [Custom(Name = "MaxAge", ResourceType = typeof(Resources.FilterModel))]
        public int MaxAge { get; set; }

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

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<HaveChildren> HaveChildren { get; set; } = [];

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<WantChildren> WantChildren { get; set; } = [];

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<EducationLevel> EducationLevel { get; set; } = [];

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<CareerCluster> CareerCluster { get; set; } = [];

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public HashSet<Religion> Religion { get; set; } = [];

        [Custom(Name = "Travel Frequency")]
        public HashSet<TravelFrequency> TravelFrequency { get; set; } = [];

        #endregion LIFESTYLE

        public void UpdateData(FilterModel vm)
        {
            //BASIC
            Region = vm.Region;
            Languages = vm.Languages;
            CurrentSituation = vm.CurrentSituation;
            BiologicalSex = vm.BiologicalSex;
            GenderIdentities = vm.GenderIdentities;
            SexualOrientations = vm.SexualOrientations;
            //BIO
            MinimalAge = vm.MinimalAge;
            MaxAge = vm.MaxAge;
            MinimalHeight = vm.MinimalHeight;
            MaxHeight = vm.MaxHeight;
            RaceCategory = vm.RaceCategory;
            BodyMass = vm.BodyMass;
            Neurodiversities = vm.Neurodiversities;
            Disabilities = vm.Disabilities;
            //LIFESTYLE
            Drink = vm.Drink;
            Smoke = vm.Smoke;
            Diet = vm.Diet;
            HaveChildren = vm.HaveChildren;
            WantChildren = vm.WantChildren;
            EducationLevel = vm.EducationLevel;
            CareerCluster = vm.CareerCluster;
            Religion = vm.Religion;
            TravelFrequency = vm.TravelFrequency;
        }
    }
}