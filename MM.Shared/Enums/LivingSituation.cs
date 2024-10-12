namespace MM.Shared.Enums
{
    public enum LivingSituation
    {
        [Custom(Name = "Alone", Description = "Lives independently, without other people in the household.")]
        Alone = 1,

        [Custom(Name = "With Family", Description = "Shares a household with family members, such as parents, siblings, or extended relatives.")]
        WithFamily = 2,

        [Custom(Name = "With Friends", Description = "Shares a living space with friends or close acquaintances.")]
        WithFriends = 3,

        [Custom(Name = "With Ex-Partner", Description = "Continues to live with a former romantic partner.")]
        WithExPartner = 4,

        [Custom(Name = "With Roommates", Description = "Shares living arrangements with individuals who are neither family nor close friends.")]
        WithRoommates = 5,

        [Custom(Name = "Other", Description = "Has a different living situation that doesn't fit common categories.")]
        Other = 9
    }
}