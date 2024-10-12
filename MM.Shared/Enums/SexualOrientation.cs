namespace MM.Shared.Enums
{
    /// <summary>
    /// https://www.india.com/lifestyle/there-are-at-least-15-types-of-sexual-orientations-how-many-do-you-know-2205005/
    /// https://www.healthline.com/health/different-types-of-sexuality
    /// </summary>
    public enum SexualOrientation
    {
        [Custom(Name = "Androgynsexual", Description = "Describes people attracted to those who possess both masculine and feminine traits. The attraction is based on the androgynous appearance of the person.")]
        Androgynsexual = 1,

        [Custom(Name = "Androsexual", Description = "Refers to people who are attracted to men, males, or masculinity, including people who identify as men regardless of their biology or sex assigned at birth.")]
        Androsexual = 2,

        [Custom(Name = "Asexual", Description = "A broad spectrum of people who experience little to no sexual attraction to others. Asexual people may still experience romantic attraction and form relationships, and may also identify with other specific terms on the asexual spectrum.")]
        Asexual = 3,

        [Custom(Name = "Autosexual", Description = "Describes a person who is sexually attracted to themselves. This concept is distinct from self-pleasure or masturbation and relates more to self-desire.")]
        Autosexual = 4,

        [Custom(Name = "Bisexual", Description = "Describes people who experience sexual, romantic, or emotional attraction to more than one gender. This term is flexible and can encompass various forms of attraction to different genders.")]
        Bisexual = 5,

        [Custom(Name = "Demisexual", Description = "Falls within the asexual spectrum, describing people who experience sexual attraction only after forming a deep emotional or romantic bond.")]
        Demisexual = 6,

        [Custom(Name = "Gynosexual", Description = "Refers to people who are attracted to women, females, or femininity, including people who identify as women regardless of their biology or sex assigned at birth.")]
        Gynosexual = 7,

        [Custom(Name = "Graysexual", Description = "Describes people who exist in the “gray area” between asexuality and sexuality, experiencing occasional or conditional sexual attraction.")]
        Graysexual = 8,

        [Custom(Name = "Heterosexual", Description = "Describes people who are sexually, romantically, or emotionally attracted to people of a different gender (e.g., men attracted to women and vice versa).")]
        Heterosexual = 9,

        [Custom(Name = "Homosexual", Description = "Describes people who experience sexual, romantic, or emotional attraction to people of the same gender. However, many prefer terms like \"gay\" or \"lesbian\" as \"homosexual\" can sometimes carry clinical or outdated connotations.")]
        Homosexual = 10,

        [Custom(Name = "Pansexual", Description = "Refers to people who can experience attraction to others regardless of their gender, embracing an openness to all genders and identities.")]
        Pansexual = 11,

        [Custom(Name = "Polysexual", Description = "Refers to people who are attracted to multiple genders but not necessarily all genders. It differs from pansexuality in its focus on attraction to specific genders.")]
        Polysexual = 12,

        [Custom(Name = "Pomosexual", Description = "A term used by people who reject sexuality labels or choose not to identify with any established sexual orientation. It is more of a rejection of categorization than a specific identity.")]
        Pomosexual = 13,

        [Custom(Name = "Sapiosexual", Description = "Describes people who are primarily attracted to intelligence or intellectual connection rather than physical or gender-based attraction.")]
        Sapiosexual = 14,

        [Custom(Name = "Skoliosexual", Description = "Describes people who are attracted to individuals with non-cisgender identities, such as nonbinary, genderqueer, or transgender people.")]
        Skoliosexual = 15,

        [Custom(Name = "Other", Description = "This user identifies with a unique sexual orientation that does not conform to common categories.")]
        Other = 99
    }
}