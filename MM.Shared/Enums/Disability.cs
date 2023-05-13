namespace MM.Shared.Enums
{
    /// <summary>
    /// https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
    /// </summary>
    public enum Disability
    {
        [Custom(Name = "Physical_Name", Description = "Physical_Description", ResourceType = typeof(Resources.Disability))]
        Physical = 1,

        [Custom(Name = "Visual_Name", Description = "Visual_Description", ResourceType = typeof(Resources.Disability))]
        Visual = 2,

        [Custom(Name = "Hearing_Name", Description = "Hearing_Description", ResourceType = typeof(Resources.Disability))]
        Hearing = 3,

        [Custom(Name = "MentalHealth_Name", Description = "MentalHealth_Description", ResourceType = typeof(Resources.Disability))]
        MentalHealth = 4,

        [Custom(Name = "Intellectual_Name", Description = "Intellectual_Description", ResourceType = typeof(Resources.Disability))]
        Intellectual = 5,

        [Custom(Name = "Learning_Name", Description = "Learning_Description", ResourceType = typeof(Resources.Disability))]
        Learning = 6,
    }
}