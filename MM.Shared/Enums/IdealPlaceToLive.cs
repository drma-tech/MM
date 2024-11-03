namespace MM.Shared.Enums
{
    public enum IdealPlaceToLive
    {
        [Custom(Name = "Urban", Description = "Prefers the excitement and opportunities of a bustling city environment.")]
        Urban = 1,

        [Custom(Name = "Suburban", Description = "Enjoys the charm and community feel of a small town.")]
        Suburban = 2,

        [Custom(Name = "Rural", Description = "Values the tranquility and natural beauty of countryside living.")]
        Rural = 3,

        [Custom(Name = "Flexible", Description = "Open to various living situations, prioritizing other factors over location.")]
        Flexible = 4
    }
}