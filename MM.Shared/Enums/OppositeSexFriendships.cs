namespace MM.Shared.Enums
{
    public enum OppositeSexFriendships
    {
        [Custom(Name = "Comfortable", Description = "Open to friendships with the opposite sex without concerns.")]
        Comfortable = 1,

        [Custom(Name = "Boundaries Needed", Description = "Comfortable with friendships, but prefers clear boundaries.")]
        BoundariesNeeded = 2,

        [Custom(Name = "Uncomfortable", Description = "Feels uneasy about close friendships with the opposite sex.")]
        Uncomfortable = 3,
    }
}