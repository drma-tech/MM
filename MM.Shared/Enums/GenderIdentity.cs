namespace MM.Shared.Enums
{
    /// <summary>
    /// https://www.masterclass.com/articles/gender-identity-guide
    /// </summary>
    public enum GenderIdentity
    {
        [Custom(Name = "Agender", Description = "A person who does not identify with any gender. Often prefers gender-neutral pronouns, such as 'they'.")]
        Agender = 1,

        [Custom(Name = "Androgyne", Description = "A person whose gender identity or expression incorporates both masculine and feminine elements.")]
        Androgyne = 2,

        [Custom(Name = "Bigender", Description = "A person who identifies with two genders, either simultaneously or switching between them over time.")]
        Bigender = 3,

        [Custom(Name = "Cisgender", Description = "A person whose gender identity aligns with the gender they were assigned at birth.")]
        Cisgender = 4,

        [Custom(Name = "Genderfluid", Description = "A person whose gender identity is flexible and can change over time, expressing different genders at different moments.")]
        Genderfluid = 5,

        [Custom(Name = "Gender-nonconforming", Description = "An umbrella term for people whose gender expression or identity does not align with societal expectations based on their assigned sex at birth.")]
        GenderNonconforming = 6,

        [Custom(Name = "Genderqueer", Description = "A term used by people who reject traditional gender categories. Often overlaps with \"non-binary\" and can refer to anyone who is not cisgender.")]
        Genderqueer = 7,

        [Custom(Name = "Intersex", Description = "A person born with physical sex characteristics (such as chromosomes or genitals) that do not fit typical definitions of male or female bodies. Often assigned a gender at birth through medical intervention.")]
        Intersex = 8,

        [Custom(Name = "Non-binary", Description = "A person who does not identify exclusively as male or female. Non-binary people may feel they embody aspects of both genders or neither.")]
        NonBinary = 9,

        [Custom(Name = "Omnigender / Pangender", Description = "A person who identifies with many or all genders. \"Pangender\" is the more commonly used term today.")]
        Omnigender = 10,

        [Custom(Name = "Questioning", Description = "A person who is exploring or uncertain about their gender identity or expression.")]
        Questioning = 11,

        [Custom(Name = "Transgender (Trans)", Description = "A person whose gender identity differs from the sex they were assigned at birth. Some transgender people transition physically, while others may not. Often referred to as 'trans' (e.g., trans woman, trans man).")]
        Transgender = 12,

        [Custom(Name = "Two-Spirit", Description = "A term used in some Indigenous North American cultures to describe a person who embodies both masculine and feminine qualities, often seen as a distinct spiritual role within their communities.")]
        TwoSpirit = 13,
    }
}