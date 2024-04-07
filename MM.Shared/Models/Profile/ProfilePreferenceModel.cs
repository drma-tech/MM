namespace MM.Shared.Models.Profile
{
    public class ProfilePreferenceModel
    {
        #region BASIC

        [Custom(Name = "Region", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public Region Region { get; set; }

        [Custom(Name = "Change", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public Change Change { get; set; }

        [Custom(Name = "Languages", Description = "Languages_Description", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<Language> Languages { get; set; } = [];

        [Custom(Name = "CurrentSituation", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<CurrentSituation> CurrentSituation { get; set; } = [];

        [Custom(Name = "BiologicalSex", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<BiologicalSex> BiologicalSex { get; set; } = [];

        [Custom(Name = "GenderIdentity", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<GenderIdentity> GenderIdentity { get; set; } = [];

        [Custom(Name = "SexualOrientation", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<SexualOrientation> SexualOrientation { get; set; } = [];

        #endregion BASIC

        #region BIO

        [Custom(Name = "RaceCategory", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<RaceCategory> RaceCategory { get; set; } = [];

        [Custom(Name = "BodyMass", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<BodyMass> BodyMass { get; set; } = [];

        [Custom(Name = "MinimalAge", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public int MinimalAge { get; set; }

        [Custom(Name = "MaxAge", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public int MaxAge { get; set; }

        [Custom(Name = "MinimalHeight", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public Height? MinimalHeight { get; set; }

        [Custom(Name = "MaxHeight", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public Height? MaxHeight { get; set; }

        [Custom(Name = "Neurodiversities", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<Neurodiversity> Neurodiversities { get; set; } = [];

        [Custom(Name = "Disabilities", ResourceType = typeof(Resources.ProfilePreferenceModel))]
        public IReadOnlyList<Disability> Disabilities { get; set; } = [];

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<Drink> Drink { get; set; } = [];

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<Smoke> Smoke { get; set; } = [];

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<Diet> Diet { get; set; } = [];

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<HaveChildren> HaveChildren { get; set; } = [];

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<WantChildren> WantChildren { get; set; } = [];

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<EducationLevel> EducationLevel { get; set; } = [];

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<CareerCluster> CareerCluster { get; set; } = [];

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<Religion> Religion { get; set; } = [];

        [Custom(Name = "Travel Frequency")]
        public IReadOnlyList<TravelFrequency> TravelFrequency { get; set; } = [];

        #endregion LIFESTYLE

        #region PERSONALITY

        [Custom(Name = "SexPersonalityPreferences_Name", Description = "SexPersonalityPreferences_Description", ResourceType = typeof(Resources.ProfileLifestyleModel))]
        public IReadOnlyList<SexPersonality> SexPersonality { get; set; } = [];

        #endregion PERSONALITY

        public void UpdateData(ProfilePreferenceModel vm)
        {
            //BASIC
            Region = vm.Region;
            Languages = vm.Languages;
            CurrentSituation = vm.CurrentSituation;
            BiologicalSex = vm.BiologicalSex;
            GenderIdentity = vm.GenderIdentity;
            SexualOrientation = vm.SexualOrientation;
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
            //PERSONALITY
            SexPersonality = vm.SexPersonality;
        }
    }
}