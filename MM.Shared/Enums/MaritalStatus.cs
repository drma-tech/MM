using MM.Shared.Translations.Enum;

namespace MM.Shared.Enums;

public enum MaritalStatus
{
    [FieldSettings("Single_Name", Description = "Single_Description", ResourceType = typeof(CurrentSituation))]
    Single = 1,

    [FieldSettings("Married_Name", Description = "Married_Description", ResourceType = typeof(CurrentSituation))]
    Married = 2,

    [FieldSettings("CommonLawCohabiting_Name", Description = "CommonLawCohabiting_Description", ResourceType = typeof(CurrentSituation))]
    CommonLawCohabiting = 3,

    [FieldSettings("Separated_Name", Description = "Separated_Description", ResourceType = typeof(CurrentSituation))]
    Separated = 4,

    [FieldSettings("Divorced_Name", Description = "Divorced_Description", ResourceType = typeof(CurrentSituation))]
    Divorced = 5,

    [FieldSettings("Annulled_Name", Description = "Annulled_Description", ResourceType = typeof(CurrentSituation))]
    Annulled = 6,

    [FieldSettings("MarriageConvenience_Name", Description = "MarriageConvenience_Description", ResourceType = typeof(CurrentSituation))]
    MarriageConvenience = 7
}