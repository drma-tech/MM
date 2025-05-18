using MM.Shared.Enums.Resources;

namespace MM.Shared.Enums;

public enum MaritalStatus
{
    [Custom(Name = "Single_Name", Description = "Single_Description", ResourceType = typeof(CurrentSituation))]
    Single = 1,

    [Custom(Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(CurrentSituation))]
    Married = 2,

    [Custom(Name = "CommonLawCohabiting_Name", Description = "CommonLawCohabiting_Description",
        ResourceType = typeof(CurrentSituation))]
    CommonLawCohabiting = 3,

    [Custom(Name = "Separated_Name", Description = "Separated_Description", ResourceType = typeof(CurrentSituation))]
    Separated = 4,

    [Custom(Name = "Divorced_Name", Description = "Divorced_Description", ResourceType = typeof(CurrentSituation))]
    Divorced = 5,

    [Custom(Name = "Annulled_Name", Description = "Annulled_Description", ResourceType = typeof(CurrentSituation))]
    Annulled = 6,

    [Custom(Name = "MarriageConvenience_Name", Description = "MarriageConvenience_Description",
        ResourceType = typeof(CurrentSituation))]
    MarriageConvenience = 7
}