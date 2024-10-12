namespace MM.Shared.Enums
{
    public enum CurrentSituation
    {
        [Custom(Name = "Single", Description = "A person who has never been married and is not in a common-law or cohabiting relationship.")]
        Single = 1,

        [Custom(Name = "Married", Description = "A person who is legally married through a civil or religious ceremony.")]
        Married = 2,

        [Custom(Name = "Common-Law / Cohabiting", Description = "A person who is in a long-term relationship and living with a partner, but without a formal marriage. This relationship is legally recognized in some countries.")]
        CommonLawCohabiting = 3,

        [Custom(Name = "Separated", Description = "A person who is still legally married but living apart from their spouse without having finalized a divorce.")]
        Separated = 4,

        [Custom(Name = "Divorced", Description = "A person who was legally married but has had the marriage legally dissolved through a divorce.")]
        Divorced = 5,

        [Custom(Name = "Annulled", Description = "A person whose marriage was legally declared null and void, meaning it was invalid from the start.")]
        Annulled = 6,

        [Custom(Name = "Marriage of Convenience", Description = "A person who is in a marriage formed for practical reasons (such as legal, financial, or social benefits), which may be recognized in some countries.")]
        MarriageConvenience = 7
    }
}