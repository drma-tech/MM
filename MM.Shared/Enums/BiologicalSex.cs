namespace MM.Shared.Enums
{
    public enum BiologicalSex
    {
        [Custom(Name = "MaleName", Description = "MaleDescription", ResourceType = typeof(Resources.BiologicalSex))]
        Male = 1,

        [Custom(Name = "FemaleName", Description = "FemaleDescription", ResourceType = typeof(Resources.BiologicalSex))]
        Female = 2,

        [Custom(Name = "OtherName", Description = "OtherDescription", ResourceType = typeof(Resources.BiologicalSex))]
        Other = 99
    }
}