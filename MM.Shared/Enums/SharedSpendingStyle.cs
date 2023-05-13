namespace MM.Shared.Enums
{
    /// <summary>
    /// invented by LGPD
    /// </summary>
    public enum SharedSpendingStyle
    {
        [Custom(Name = "Recipient_Name", Description = "Recipient_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Recipient = 1,

        [Custom(Name = "Contributor_Name", Description = "Contributor_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Contributor = 2,

        [Custom(Name = "Balanced_Name", Description = "Balanced_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Balanced = 3,

        [Custom(Name = "Provider_Name", Description = "Provider_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Provider = 4,

        [Custom(Name = "Benefactor_Name", Description = "Benefactor_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Benefactor = 5
    }

    /// <summary>
    /// invented by me (dhiogo)
    /// </summary>
    public enum SplitTheBill_OLd
    {
        [Custom(Name = "Dependent_Name", Description = "Dependent_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Dependent = 1,

        [Custom(Name = "GetGifts_Name", Description = "GetGifts_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        GetGifts = 2,

        [Custom(Name = "Balanced_Name", Description = "Balanced_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Balanced = 3,

        [Custom(Name = "SendGifts_Name", Description = "SendGifts_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        SendGifts = 4,

        [Custom(Name = "Provider_Name", Description = "Provider_Description", ResourceType = typeof(Resources.SharedSpendingStyle))]
        Provider = 5
    }
}