namespace MM.Shared.Enums
{
    public enum Ethnicity
    {
        [Custom(Name = "White / Caucasian", Description = "People with origins in Europe, the Middle East, or North Africa.")]
        WhiteCaucasian = 1,

        [Custom(Name = "Black / African Descent", Description = "People with origins in Sub-Saharan Africa, including African American, Afro-Caribbean, and other Black identities.")]
        BlackAfricanDescent = 2,

        [Custom(Name = "Indigenous / Native Peoples", Description = "People native to the Americas, Australia, or other regions, such as Native American, First Nations, Aboriginal, or Maori.")]
        IndigenousNativePeoples = 3,

        [Custom(Name = "Asian", Description = "People with origins in East Asia, South Asia, or Southeast Asia, including Chinese, Indian, Filipino, Japanese, and more.")]
        Asian = 4,

        [Custom(Name = "Hispanic / Latino", Description = "People of Latin American or Hispanic descent, including Mexican, Puerto Rican, Cuban, and other Latin American identities.")]
        HispanicLatino = 5,

        [Custom(Name = "Middle Eastern / North African", Description = "People with origins in Middle Eastern or North African countries, such as Arab, Persian, or Berber.")]
        MiddleEasternNorthAfrican = 6,

        [Custom(Name = "Native Hawaiian / Pacific Islander", Description = "People native to the Pacific Islands, including Native Hawaiian, Samoan, and Chamorro.")]
        NativeHawaiianPacificIslander = 7,

        [Custom(Name = "Multiracial / Mixed", Description = "People who identify with more than one racial or ethnic background.")]
        MultiracialMixed = 8,

        [Custom(Name = "Other", Description = "Person with a racial or ethnic background not listed here.")]
        Other = 9,
    }
}