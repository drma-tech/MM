namespace MM.Shared.Enums
{
    public enum EducationLevel
    {
        [Custom(Name = "Basic", ResourceType = typeof(Resources.EducationLevel))]
        Basic = 1,

        [Custom(Name = "Intermediary", ResourceType = typeof(Resources.EducationLevel))]
        Intermediary = 2,

        [Custom(Name = "Advanced", ResourceType = typeof(Resources.EducationLevel))]
        Advanced = 3
    }
}