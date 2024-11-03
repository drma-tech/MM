namespace MM.Shared.Enums
{
    public enum MaritalStatus
    {
        [Custom(Name = "Single_Name", Description = "Single_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Single = 1,

        [Custom(Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Married = 2,

        [Custom(Name = "CommonLawCohabiting_Name", Description = "CommonLawCohabiting_Description", ResourceType = typeof(Resources.CurrentSituation))]
        CommonLawCohabiting = 3,

        [Custom(Name = "Separated_Name", Description = "Separated_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Separated = 4,

        [Custom(Name = "Divorced_Name", Description = "Divorced_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Divorced = 5,

        [Custom(Name = "Annulled_Name", Description = "Annulled_Description", ResourceType = typeof(Resources.CurrentSituation))]
        Annulled = 6,

        [Custom(Name = "MarriageConvenience_Name", Description = "MarriageConvenience_Description", ResourceType = typeof(Resources.CurrentSituation))]
        MarriageConvenience = 7
    }
}