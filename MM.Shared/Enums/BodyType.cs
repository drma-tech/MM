namespace MM.Shared.Enums
{
    public enum BodyType
    {
        [Custom(Name = "Thin / Slender")]
        Slim = 1,

        [Custom(Name = "Average / Medium Build")]
        Average = 2,

        [Custom(Name = "Athletic / Fit")]
        Athletic = 3,

        [Custom(Name = "Curvy / Plus Size")]
        Curvy = 4,

        [Custom(Name = "Fuller Figure")]
        Full = 5,
    }
}