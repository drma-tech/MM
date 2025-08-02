namespace MM.Shared.Enums;

public enum EducationLevel
{
    [Custom(Name = "Basic_Name", Description = "Basic_Description", ResourceType = typeof(Resources.EducationLevel))]
    Basic = 1,

    [Custom(Name = "Intermediary_Name", Description = "Intermediary_Description", ResourceType = typeof(Resources.EducationLevel))]
    Intermediary = 2,

    [Custom(Name = "Advanced_Name", Description = "Advanced_Description", ResourceType = typeof(Resources.EducationLevel))]
    Advanced = 3
}