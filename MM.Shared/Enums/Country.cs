namespace MM.Shared.Enums;

/// <summary>
///     https://en.wikipedia.org/wiki/ISO_3166-1
/// </summary>
public enum Country
{
    [Custom(Group = "Asia", Name = "Afghanistan", Tips = "AFG", ResourceType = typeof(Resources.Country))]
    Afghanistan = 4,

    [Custom(Group = "Europe", Name = "AlandIslands", Tips = "ALA", ResourceType = typeof(Resources.Country))]
    AlandIslands = 248,

    [Custom(Group = "Europe", Name = "Albania", Tips = "ALB", ResourceType = typeof(Resources.Country))]
    Albania = 8,

    [Custom(Group = "Africa", Name = "Algeria", Tips = "DZA", ResourceType = typeof(Resources.Country))]
    Algeria = 12,

    [Custom(Group = "Oceania", Name = "AmericanSamoa", Tips = "ASM", ResourceType = typeof(Resources.Country))]
    AmericanSamoa = 16,

    [Custom(Group = "Europe", Name = "Andorra", Tips = "AND", ResourceType = typeof(Resources.Country))]
    Andorra = 20,

    [Custom(Group = "Africa", Name = "Angola", Tips = "AGO", ResourceType = typeof(Resources.Country))]
    Angola = 24,

    [Custom(Group = "Americas", Name = "Anguilla", Tips = "AIA", ResourceType = typeof(Resources.Country))]
    Anguilla = 660,

    [Custom(Group = "Americas", Name = "AntiguaAndBarbuda", Tips = "ATG", ResourceType = typeof(Resources.Country))]
    AntiguaAndBarbuda = 28,

    [Custom(Group = "Americas", Name = "Argentina", Tips = "ARG", ResourceType = typeof(Resources.Country))]
    Argentina = 32,

    [Custom(Group = "Asia", Name = "Armenia", Tips = "ARM", ResourceType = typeof(Resources.Country))]
    Armenia = 51,

    [Custom(Group = "Americas", Name = "Aruba", Tips = "ABW", ResourceType = typeof(Resources.Country))]
    Aruba = 533,

    [Custom(Group = "Oceania", Name = "Australia", Tips = "AUS", ResourceType = typeof(Resources.Country))]
    Australia = 36,

    [Custom(Group = "Europe", Name = "Austria", Tips = "AUT", ResourceType = typeof(Resources.Country))]
    Austria = 40,

    [Custom(Group = "Asia", Name = "Azerbaijan", Tips = "AZE", ResourceType = typeof(Resources.Country))]
    Azerbaijan = 31,

    [Custom(Group = "Americas", Name = "Bahamas", Tips = "BHS", ResourceType = typeof(Resources.Country))]
    Bahamas = 44,

    [Custom(Group = "Asia", Name = "Bahrain", Tips = "BHR", ResourceType = typeof(Resources.Country))]
    Bahrain = 48,

    [Custom(Group = "Asia", Name = "Bangladesh", Tips = "BGD", ResourceType = typeof(Resources.Country))]
    Bangladesh = 50,

    [Custom(Group = "Americas", Name = "Barbados", Tips = "BRB", ResourceType = typeof(Resources.Country))]
    Barbados = 52,

    [Custom(Group = "Europe", Name = "Belarus", Tips = "BLR", ResourceType = typeof(Resources.Country))]
    Belarus = 112,

    [Custom(Group = "Europe", Name = "Belgium", Tips = "BEL", ResourceType = typeof(Resources.Country))]
    Belgium = 56,

    [Custom(Group = "Americas", Name = "Belize", Tips = "BLZ", ResourceType = typeof(Resources.Country))]
    Belize = 84,

    [Custom(Group = "Africa", Name = "Benin", Tips = "BEN", ResourceType = typeof(Resources.Country))]
    Benin = 204,

    [Custom(Group = "Americas", Name = "Bermuda", Tips = "BMU", ResourceType = typeof(Resources.Country))]
    Bermuda = 60,

    [Custom(Group = "Asia", Name = "Bhutan", Tips = "BTN", ResourceType = typeof(Resources.Country))]
    Bhutan = 64,

    [Custom(Group = "Americas", Name = "Bolivia", Tips = "BOL", ResourceType = typeof(Resources.Country))]
    Bolivia = 68,

    [Custom(Group = "Americas", Name = "CaribbeanNetherlands", Tips = "BES", ResourceType = typeof(Resources.Country))]
    CaribbeanNetherlands = 535,

    [Custom(Group = "Europe", Name = "BosniaAndHerzegovina", Tips = "BIH", ResourceType = typeof(Resources.Country))]
    BosniaAndHerzegovina = 70,

    [Custom(Group = "Africa", Name = "Botswana", Tips = "BWA", ResourceType = typeof(Resources.Country))]
    Botswana = 72,

    [Custom(Group = "Americas", Name = "BouvetIsland", Tips = "BVT", ResourceType = typeof(Resources.Country))]
    BouvetIsland = 74,

    [Custom(Group = "Americas", Name = "Brazil", Tips = "BRA", ResourceType = typeof(Resources.Country))]
    Brazil = 76,

    [Custom(Group = "Africa", Name = "BritishIndianOceanTerritory", Tips = "IOT", ResourceType = typeof(Resources.Country))]
    BritishIndianOceanTerritory = 86,

    [Custom(Group = "Americas", Name = "BritishVirginIslands", Tips = "VGB", ResourceType = typeof(Resources.Country))]
    BritishVirginIslands = 92,

    [Custom(Group = "Asia", Name = "Brunei", Tips = "BRN", ResourceType = typeof(Resources.Country))]
    Brunei = 96,

    [Custom(Group = "Europe", Name = "Bulgaria", Tips = "BGR", ResourceType = typeof(Resources.Country))]
    Bulgaria = 100,

    [Custom(Group = "Africa", Name = "BurkinaFaso", Tips = "BFA", ResourceType = typeof(Resources.Country))]
    BurkinaFaso = 854,

    [Custom(Group = "Africa", Name = "Burundi", Tips = "BDI", ResourceType = typeof(Resources.Country))]
    Burundi = 108,

    [Custom(Group = "Asia", Name = "Cambodia", Tips = "KHM", ResourceType = typeof(Resources.Country))]
    Cambodia = 116,

    [Custom(Group = "Africa", Name = "Cameroon", Tips = "CMR", ResourceType = typeof(Resources.Country))]
    Cameroon = 120,

    [Custom(Group = "Americas", Name = "Canada", Tips = "CAN", ResourceType = typeof(Resources.Country))]
    Canada = 124,

    [Custom(Group = "Africa", Name = "CapeVerde", Tips = "CPV", ResourceType = typeof(Resources.Country))]
    CapeVerde = 132,

    [Custom(Group = "Americas", Name = "CaymanIslands", Tips = "CYM", ResourceType = typeof(Resources.Country))]
    CaymanIslands = 136,

    [Custom(Group = "Africa", Name = "CentralAfricanRepublic", Tips = "CAF", ResourceType = typeof(Resources.Country))]
    CentralAfricanRepublic = 140,

    [Custom(Group = "Africa", Name = "Chad", Tips = "TCD", ResourceType = typeof(Resources.Country))]
    Chad = 148,

    [Custom(Group = "Americas", Name = "Chile", Tips = "CHL", ResourceType = typeof(Resources.Country))]
    Chile = 152,

    [Custom(Group = "Asia", Name = "China", Tips = "CHN", ResourceType = typeof(Resources.Country))]
    China = 156,

    [Custom(Group = "Asia", Name = "HongKong", Tips = "HKG", ResourceType = typeof(Resources.Country))]
    HongKong = 344,

    [Custom(Group = "Asia", Name = "Macao", Tips = "MAC", ResourceType = typeof(Resources.Country))]
    Macao = 446,

    [Custom(Group = "Oceania", Name = "ChristmasIsland", Tips = "CXR", ResourceType = typeof(Resources.Country))]
    ChristmasIsland = 162,

    [Custom(Group = "Oceania", Name = "CocosKeelingIslands", Tips = "CCK", ResourceType = typeof(Resources.Country))]
    CocosKeelingIslands = 166,

    [Custom(Group = "Americas", Name = "Colombia", Tips = "COL", ResourceType = typeof(Resources.Country))]
    Colombia = 170,

    [Custom(Group = "Africa", Name = "Comoros", Tips = "COM", ResourceType = typeof(Resources.Country))]
    Comoros = 174,

    [Custom(Group = "Africa", Name = "RepublicOfTheCongo", Tips = "COG", ResourceType = typeof(Resources.Country))]
    RepublicOfTheCongo = 178,

    [Custom(Group = "Oceania", Name = "CookIslands", Tips = "COK", ResourceType = typeof(Resources.Country))]
    CookIslands = 184,

    [Custom(Group = "Americas", Name = "CostaRica", Tips = "CRI", ResourceType = typeof(Resources.Country))]
    CostaRica = 188,

    [Custom(Group = "Africa", Name = "IvoryCoast", Tips = "CIV", ResourceType = typeof(Resources.Country))]
    IvoryCoast = 384,

    [Custom(Group = "Europe", Name = "Croatia", Tips = "HRV", ResourceType = typeof(Resources.Country))]
    Croatia = 191,

    [Custom(Group = "Americas", Name = "Cuba", Tips = "CUB", ResourceType = typeof(Resources.Country))]
    Cuba = 192,

    [Custom(Group = "Americas", Name = "Curacao", Tips = "CUW", ResourceType = typeof(Resources.Country))]
    Curacao = 531,

    [Custom(Group = "Asia", Name = "Cyprus", Tips = "CYP", ResourceType = typeof(Resources.Country))]
    Cyprus = 196,

    [Custom(Group = "Europe", Name = "Czechia", Tips = "CZE", ResourceType = typeof(Resources.Country))]
    Czechia = 203,

    [Custom(Group = "Africa", Name = "DemocraticRepublicOfTheCongo", Tips = "COD", ResourceType = typeof(Resources.Country))]
    DemocraticRepublicOfTheCongo = 180,

    [Custom(Group = "Europe", Name = "Denmark", Tips = "DNK", ResourceType = typeof(Resources.Country))]
    Denmark = 208,

    [Custom(Group = "Africa", Name = "Djibouti", Tips = "DJI", ResourceType = typeof(Resources.Country))]
    Djibouti = 262,

    [Custom(Group = "Americas", Name = "Dominica", Tips = "DMA", ResourceType = typeof(Resources.Country))]
    Dominica = 212,

    [Custom(Group = "Americas", Name = "DominicanRepublic", Tips = "DOM", ResourceType = typeof(Resources.Country))]
    DominicanRepublic = 214,

    [Custom(Group = "Americas", Name = "Ecuador", Tips = "ECU", ResourceType = typeof(Resources.Country))]
    Ecuador = 218,

    [Custom(Group = "Africa", Name = "Egypt", Tips = "EGY", ResourceType = typeof(Resources.Country))]
    Egypt = 818,

    [Custom(Group = "Americas", Name = "ElSalvador", Tips = "SLV", ResourceType = typeof(Resources.Country))]
    ElSalvador = 222,

    [Custom(Group = "Africa", Name = "EquatorialGuinea", Tips = "GNQ", ResourceType = typeof(Resources.Country))]
    EquatorialGuinea = 226,

    [Custom(Group = "Africa", Name = "Eritrea", Tips = "ERI", ResourceType = typeof(Resources.Country))]
    Eritrea = 232,

    [Custom(Group = "Europe", Name = "Estonia", Tips = "EST", ResourceType = typeof(Resources.Country))]
    Estonia = 233,

    [Custom(Group = "Africa", Name = "Eswatini", Tips = "SWZ", ResourceType = typeof(Resources.Country))]
    Eswatini = 748,

    [Custom(Group = "Africa", Name = "Ethiopia", Tips = "ETH", ResourceType = typeof(Resources.Country))]
    Ethiopia = 231,

    [Custom(Group = "Americas", Name = "FalklandIslands", Tips = "FLK", ResourceType = typeof(Resources.Country))]
    FalklandIslands = 238,

    [Custom(Group = "Europe", Name = "FaroeIslands", Tips = "FRO", ResourceType = typeof(Resources.Country))]
    FaroeIslands = 234,

    [Custom(Group = "Oceania", Name = "Fiji", Tips = "FJI", ResourceType = typeof(Resources.Country))]
    Fiji = 242,

    [Custom(Group = "Europe", Name = "Finland", Tips = "FIN", ResourceType = typeof(Resources.Country))]
    Finland = 246,

    [Custom(Group = "Europe", Name = "France", Tips = "FRA", ResourceType = typeof(Resources.Country))]
    France = 250,

    [Custom(Group = "Americas", Name = "FrenchGuiana", Tips = "GUF", ResourceType = typeof(Resources.Country))]
    FrenchGuiana = 254,

    [Custom(Group = "Oceania", Name = "FrenchPolynesia", Tips = "PYF", ResourceType = typeof(Resources.Country))]
    FrenchPolynesia = 258,

    [Custom(Group = "Africa", Name = "FrenchSouthernAndAntarcticLands", Tips = "ATF", ResourceType = typeof(Resources.Country))]
    FrenchSouthernAndAntarcticLands = 260,

    [Custom(Group = "Africa", Name = "Gabon", Tips = "GAB", ResourceType = typeof(Resources.Country))]
    Gabon = 266,

    [Custom(Group = "Africa", Name = "Gambia", Tips = "GMB", ResourceType = typeof(Resources.Country))]
    Gambia = 270,

    [Custom(Group = "Asia", Name = "Georgia", Tips = "GEO", ResourceType = typeof(Resources.Country))]
    Georgia = 268,

    [Custom(Group = "Europe", Name = "Germany", Tips = "DEU", ResourceType = typeof(Resources.Country))]
    Germany = 276,

    [Custom(Group = "Africa", Name = "Ghana", Tips = "GHA", ResourceType = typeof(Resources.Country))]
    Ghana = 288,

    [Custom(Group = "Europe", Name = "Gibraltar", Tips = "GIB", ResourceType = typeof(Resources.Country))]
    Gibraltar = 292,

    [Custom(Group = "Europe", Name = "Greece", Tips = "GRC", ResourceType = typeof(Resources.Country))]
    Greece = 300,

    [Custom(Group = "Americas", Name = "Greenland", Tips = "GRL", ResourceType = typeof(Resources.Country))]
    Greenland = 304,

    [Custom(Group = "Americas", Name = "Grenada", Tips = "GRD", ResourceType = typeof(Resources.Country))]
    Grenada = 308,

    [Custom(Group = "Americas", Name = "Guadeloupe", Tips = "GLP", ResourceType = typeof(Resources.Country))]
    Guadeloupe = 312,

    [Custom(Group = "Oceania", Name = "Guam", Tips = "GUM", ResourceType = typeof(Resources.Country))]
    Guam = 316,

    [Custom(Group = "Americas", Name = "Guatemala", Tips = "GTM", ResourceType = typeof(Resources.Country))]
    Guatemala = 320,

    [Custom(Group = "Europe", Name = "Guernsey", Tips = "GGY", ResourceType = typeof(Resources.Country))]
    Guernsey = 831,

    [Custom(Group = "Africa", Name = "Guinea", Tips = "GIN", ResourceType = typeof(Resources.Country))]
    Guinea = 324,

    [Custom(Group = "Africa", Name = "GuineaBissau", Tips = "GNB", ResourceType = typeof(Resources.Country))]
    GuineaBissau = 624,

    [Custom(Group = "Americas", Name = "Guyana", Tips = "GUY", ResourceType = typeof(Resources.Country))]
    Guyana = 328,

    [Custom(Group = "Americas", Name = "Haiti", Tips = "HTI", ResourceType = typeof(Resources.Country))]
    Haiti = 332,

    [Custom(Group = "Oceania", Name = "HeardIslandAndMcDonaldIslands", Tips = "HMD", ResourceType = typeof(Resources.Country))]
    HeardIslandAndMcDonaldIslands = 334,

    [Custom(Group = "Europe", Name = "VaticanCity", Tips = "VAT", ResourceType = typeof(Resources.Country))]
    VaticanCity = 336,

    [Custom(Group = "Americas", Name = "Honduras", Tips = "HND", ResourceType = typeof(Resources.Country))]
    Honduras = 340,

    [Custom(Group = "Europe", Name = "Hungary", Tips = "HUN", ResourceType = typeof(Resources.Country))]
    Hungary = 348,

    [Custom(Group = "Europe", Name = "Iceland", Tips = "ISL", ResourceType = typeof(Resources.Country))]
    Iceland = 352,

    [Custom(Group = "Asia", Name = "India", Tips = "IND", ResourceType = typeof(Resources.Country))]
    India = 356,

    [Custom(Group = "Asia", Name = "Indonesia", Tips = "IDN", ResourceType = typeof(Resources.Country))]
    Indonesia = 360,

    [Custom(Group = "Asia", Name = "Iran", Tips = "IRN", ResourceType = typeof(Resources.Country))]
    Iran = 364,

    [Custom(Group = "Asia", Name = "Iraq", Tips = "IRQ", ResourceType = typeof(Resources.Country))]
    Iraq = 368,

    [Custom(Group = "Europe", Name = "Ireland", Tips = "IRL", ResourceType = typeof(Resources.Country))]
    Ireland = 372,

    [Custom(Group = "Europe", Name = "IsleOfMan", Tips = "IMN", ResourceType = typeof(Resources.Country))]
    IsleOfMan = 833,

    [Custom(Group = "Asia", Name = "Israel", Tips = "ISR", ResourceType = typeof(Resources.Country))]
    Israel = 376,

    [Custom(Group = "Europe", Name = "Italy", Tips = "ITA", ResourceType = typeof(Resources.Country))]
    Italy = 380,

    [Custom(Group = "Americas", Name = "Jamaica", Tips = "JAM", ResourceType = typeof(Resources.Country))]
    Jamaica = 388,

    [Custom(Group = "Asia", Name = "Japan", Tips = "JPN", ResourceType = typeof(Resources.Country))]
    Japan = 392,

    [Custom(Group = "Europe", Name = "Jersey", Tips = "JEY", ResourceType = typeof(Resources.Country))]
    Jersey = 832,

    [Custom(Group = "Asia", Name = "Jordan", Tips = "JOR", ResourceType = typeof(Resources.Country))]
    Jordan = 400,

    [Custom(Group = "Asia", Name = "Kazakhstan", Tips = "KAZ", ResourceType = typeof(Resources.Country))]
    Kazakhstan = 398,

    [Custom(Group = "Africa", Name = "Kenya", Tips = "KEN", ResourceType = typeof(Resources.Country))]
    Kenya = 404,

    [Custom(Group = "Oceania", Name = "Kiribati", Tips = "KIR", ResourceType = typeof(Resources.Country))]
    Kiribati = 296,

    [Custom(Group = "Europe", Name = "Kosovo", Tips = "XKX", ResourceType = typeof(Resources.Country))]
    Kosovo = 99991,

    [Custom(Group = "Asia", Name = "Kuwait", Tips = "KWT", ResourceType = typeof(Resources.Country))]
    Kuwait = 414,

    [Custom(Group = "Asia", Name = "Kyrgyzstan", Tips = "KGZ", ResourceType = typeof(Resources.Country))]
    Kyrgyzstan = 417,

    [Custom(Group = "Asia", Name = "Laos", Tips = "LAO", ResourceType = typeof(Resources.Country))]
    Laos = 418,

    [Custom(Group = "Europe", Name = "Latvia", Tips = "LVA", ResourceType = typeof(Resources.Country))]
    Latvia = 428,

    [Custom(Group = "Asia", Name = "Lebanon", Tips = "LBN", ResourceType = typeof(Resources.Country))]
    Lebanon = 422,

    [Custom(Group = "Africa", Name = "Lesotho", Tips = "LSO", ResourceType = typeof(Resources.Country))]
    Lesotho = 426,

    [Custom(Group = "Africa", Name = "Liberia", Tips = "LBR", ResourceType = typeof(Resources.Country))]
    Liberia = 430,

    [Custom(Group = "Africa", Name = "Libya", Tips = "LBY", ResourceType = typeof(Resources.Country))]
    Libya = 434,

    [Custom(Group = "Europe", Name = "Liechtenstein", Tips = "LIE", ResourceType = typeof(Resources.Country))]
    Liechtenstein = 438,

    [Custom(Group = "Europe", Name = "Lithuania", Tips = "LTU", ResourceType = typeof(Resources.Country))]
    Lithuania = 440,

    [Custom(Group = "Europe", Name = "Luxembourg", Tips = "LUX", ResourceType = typeof(Resources.Country))]
    Luxembourg = 442,

    [Custom(Group = "Africa", Name = "Madagascar", Tips = "MDG", ResourceType = typeof(Resources.Country))]
    Madagascar = 450,

    [Custom(Group = "Africa", Name = "Malawi", Tips = "MWI", ResourceType = typeof(Resources.Country))]
    Malawi = 454,

    [Custom(Group = "Asia", Name = "Malaysia", Tips = "MYS", ResourceType = typeof(Resources.Country))]
    Malaysia = 458,

    [Custom(Group = "Asia", Name = "Maldives", Tips = "MDV", ResourceType = typeof(Resources.Country))]
    Maldives = 462,

    [Custom(Group = "Africa", Name = "Mali", Tips = "MLI", ResourceType = typeof(Resources.Country))]
    Mali = 466,

    [Custom(Group = "Europe", Name = "Malta", Tips = "MLT", ResourceType = typeof(Resources.Country))]
    Malta = 470,

    [Custom(Group = "Oceania", Name = "MarshallIslands", Tips = "MHL", ResourceType = typeof(Resources.Country))]
    MarshallIslands = 584,

    [Custom(Group = "Americas", Name = "Martinique", Tips = "MTQ", ResourceType = typeof(Resources.Country))]
    Martinique = 474,

    [Custom(Group = "Africa", Name = "Mauritania", Tips = "MRT", ResourceType = typeof(Resources.Country))]
    Mauritania = 478,

    [Custom(Group = "Africa", Name = "Mauritius", Tips = "MUS", ResourceType = typeof(Resources.Country))]
    Mauritius = 480,

    [Custom(Group = "Africa", Name = "Mayotte", Tips = "MYT", ResourceType = typeof(Resources.Country))]
    Mayotte = 175,

    [Custom(Group = "Americas", Name = "Mexico", Tips = "MEX", ResourceType = typeof(Resources.Country))]
    Mexico = 484,

    [Custom(Group = "Oceania", Name = "FederatedStatesOfMicronesia", Tips = "FSM", ResourceType = typeof(Resources.Country))]
    FederatedStatesOfMicronesia = 583,

    [Custom(Group = "Europe", Name = "PrincipalityOfMonaco", Tips = "MCO", ResourceType = typeof(Resources.Country))]
    PrincipalityOfMonaco = 492,

    [Custom(Group = "Asia", Name = "Mongolia", Tips = "MNG", ResourceType = typeof(Resources.Country))]
    Mongolia = 496,

    [Custom(Group = "Europe", Name = "Montenegro", Tips = "MNE", ResourceType = typeof(Resources.Country))]
    Montenegro = 499,

    [Custom(Group = "Americas", Name = "Montserrat", Tips = "MSR", ResourceType = typeof(Resources.Country))]
    Montserrat = 500,

    [Custom(Group = "Africa", Name = "Morocco", Tips = "MAR", ResourceType = typeof(Resources.Country))]
    Morocco = 504,

    [Custom(Group = "Africa", Name = "Mozambique", Tips = "MOZ", ResourceType = typeof(Resources.Country))]
    Mozambique = 508,

    [Custom(Group = "Asia", Name = "Myanmar", Tips = "MMR", ResourceType = typeof(Resources.Country))]
    Myanmar = 104,

    [Custom(Group = "Africa", Name = "Namibia", Tips = "NAM", ResourceType = typeof(Resources.Country))]
    Namibia = 516,

    [Custom(Group = "Oceania", Name = "Nauru", Tips = "NRU", ResourceType = typeof(Resources.Country))]
    Nauru = 520,

    [Custom(Group = "Asia", Name = "Nepal", Tips = "NPL", ResourceType = typeof(Resources.Country))]
    Nepal = 524,

    [Custom(Group = "Europe", Name = "Netherlands", Tips = "NLD", ResourceType = typeof(Resources.Country))]
    Netherlands = 528,

    [Custom(Group = "Oceania", Name = "NewCaledonia", Tips = "NCL", ResourceType = typeof(Resources.Country))]
    NewCaledonia = 540,

    [Custom(Group = "Oceania", Name = "NewZealand", Tips = "NZL", ResourceType = typeof(Resources.Country))]
    NewZealand = 554,

    [Custom(Group = "Americas", Name = "Nicaragua", Tips = "NIC", ResourceType = typeof(Resources.Country))]
    Nicaragua = 558,

    [Custom(Group = "Africa", Name = "Niger", Tips = "NER", ResourceType = typeof(Resources.Country))]
    Niger = 562,

    [Custom(Group = "Africa", Name = "Nigeria", Tips = "NGA", ResourceType = typeof(Resources.Country))]
    Nigeria = 566,

    [Custom(Group = "Oceania", Name = "Niue", Tips = "NIU", ResourceType = typeof(Resources.Country))]
    Niue = 570,

    [Custom(Group = "Oceania", Name = "NorfolkIsland", Tips = "NFK", ResourceType = typeof(Resources.Country))]
    NorfolkIsland = 574,

    [Custom(Group = "Asia", Name = "NorthKorea", Tips = "PRK", ResourceType = typeof(Resources.Country))]
    NorthKorea = 408,

    [Custom(Group = "Europe", Name = "NorthMacedonia", Tips = "MKD", ResourceType = typeof(Resources.Country))]
    NorthMacedonia = 807,

    [Custom(Group = "Oceania", Name = "NorthernMarianaIslands", Tips = "MNP", ResourceType = typeof(Resources.Country))]
    NorthernMarianaIslands = 580,

    [Custom(Group = "Europe", Name = "Norway", Tips = "NOR", ResourceType = typeof(Resources.Country))]
    Norway = 578,

    [Custom(Group = "Asia", Name = "Oman", Tips = "OMN", ResourceType = typeof(Resources.Country))]
    Oman = 512,

    [Custom(Group = "Asia", Name = "Pakistan", Tips = "PAK", ResourceType = typeof(Resources.Country))]
    Pakistan = 586,

    [Custom(Group = "Oceania", Name = "Palau", Tips = "PLW", ResourceType = typeof(Resources.Country))]
    Palau = 585,

    [Custom(Group = "Americas", Name = "Panama", Tips = "PAN", ResourceType = typeof(Resources.Country))]
    Panama = 591,

    [Custom(Group = "Oceania", Name = "PapuaNewGuinea", Tips = "PNG", ResourceType = typeof(Resources.Country))]
    PapuaNewGuinea = 598,

    [Custom(Group = "Americas", Name = "Paraguay", Tips = "PRY", ResourceType = typeof(Resources.Country))]
    Paraguay = 600,

    [Custom(Group = "Americas", Name = "Peru", Tips = "PER", ResourceType = typeof(Resources.Country))]
    Peru = 604,

    [Custom(Group = "Asia", Name = "Philippines", Tips = "PHL", ResourceType = typeof(Resources.Country))]
    Philippines = 608,

    [Custom(Group = "Oceania", Name = "PitcairnIslands", Tips = "PCN", ResourceType = typeof(Resources.Country))]
    PitcairnIslands = 612,

    [Custom(Group = "Europe", Name = "Poland", Tips = "POL", ResourceType = typeof(Resources.Country))]
    Poland = 616,

    [Custom(Group = "Europe", Name = "Portugal", Tips = "PRT", ResourceType = typeof(Resources.Country))]
    Portugal = 620,

    [Custom(Group = "Americas", Name = "PuertoRico", Tips = "PRI", ResourceType = typeof(Resources.Country))]
    PuertoRico = 630,

    [Custom(Group = "Asia", Name = "Qatar", Tips = "QAT", ResourceType = typeof(Resources.Country))]
    Qatar = 634,

    [Custom(Group = "Asia", Name = "SouthKorea", Tips = "KOR", ResourceType = typeof(Resources.Country))]
    SouthKorea = 410,

    [Custom(Group = "Europe", Name = "Moldova", Tips = "MDA", ResourceType = typeof(Resources.Country))]
    Moldova = 498,

    [Custom(Group = "Africa", Name = "Reunion", Tips = "REU", ResourceType = typeof(Resources.Country))]
    Reunion = 638,

    [Custom(Group = "Europe", Name = "Romania", Tips = "ROU", ResourceType = typeof(Resources.Country))]
    Romania = 642,

    [Custom(Group = "Europe", Name = "Russia", Tips = "RUS", ResourceType = typeof(Resources.Country))]
    Russia = 643,

    [Custom(Group = "Africa", Name = "Rwanda", Tips = "RWA", ResourceType = typeof(Resources.Country))]
    Rwanda = 646,

    [Custom(Group = "Americas", Name = "SaintBarthelemy", Tips = "BLM", ResourceType = typeof(Resources.Country))]
    SaintBarthelemy = 652,

    [Custom(Group = "Africa", Name = "SaintHelenaAscensionAndTristanDaCunha", Tips = "SHN", ResourceType = typeof(Resources.Country))]
    SaintHelenaAscensionAndTristanDaCunha = 654,

    [Custom(Group = "Americas", Name = "SaintKittsAndNevis", Tips = "KNA", ResourceType = typeof(Resources.Country))]
    SaintKittsAndNevis = 659,

    [Custom(Group = "Americas", Name = "SaintLucia", Tips = "LCA", ResourceType = typeof(Resources.Country))]
    SaintLucia = 662,

    [Custom(Group = "Americas", Name = "SaintMartin", Tips = "MAF", ResourceType = typeof(Resources.Country))]
    SaintMartin = 663,

    [Custom(Group = "Americas", Name = "SaintPierreAndMiquelon", Tips = "SPM", ResourceType = typeof(Resources.Country))]
    SaintPierreAndMiquelon = 666,

    [Custom(Group = "Americas", Name = "SaintVincentAndTheGrenadines", Tips = "VCT", ResourceType = typeof(Resources.Country))]
    SaintVincentAndTheGrenadines = 670,

    [Custom(Group = "Oceania", Name = "Samoa", Tips = "WSM", ResourceType = typeof(Resources.Country))]
    Samoa = 882,

    [Custom(Group = "Europe", Name = "SanMarino", Tips = "SMR", ResourceType = typeof(Resources.Country))]
    SanMarino = 674,

    [Custom(Group = "Africa", Name = "SaoTomeAndPrincipe", Tips = "STP", ResourceType = typeof(Resources.Country))]
    SaoTomeAndPrincipe = 678,

    [Custom(Group = "Europe", Name = "Sark", Tips = "CRQ", ResourceType = typeof(Resources.Country))]
    Sark = 680,

    [Custom(Group = "Asia", Name = "SaudiArabia", Tips = "SAU", ResourceType = typeof(Resources.Country))]
    SaudiArabia = 682,

    [Custom(Group = "Africa", Name = "Senegal", Tips = "SEN", ResourceType = typeof(Resources.Country))]
    Senegal = 686,

    [Custom(Group = "Europe", Name = "Serbia", Tips = "SRB", ResourceType = typeof(Resources.Country))]
    Serbia = 688,

    [Custom(Group = "Africa", Name = "Seychelles", Tips = "SYC", ResourceType = typeof(Resources.Country))]
    Seychelles = 690,

    [Custom(Group = "Africa", Name = "SierraLeone", Tips = "SLE", ResourceType = typeof(Resources.Country))]
    SierraLeone = 694,

    [Custom(Group = "Asia", Name = "Singapore", Tips = "SGP", ResourceType = typeof(Resources.Country))]
    Singapore = 702,

    [Custom(Group = "Americas", Name = "SintMaarten", Tips = "SXM", ResourceType = typeof(Resources.Country))]
    SintMaarten = 534,

    [Custom(Group = "Europe", Name = "Slovakia", Tips = "SVK", ResourceType = typeof(Resources.Country))]
    Slovakia = 703,

    [Custom(Group = "Europe", Name = "Slovenia", Tips = "SVN", ResourceType = typeof(Resources.Country))]
    Slovenia = 705,

    [Custom(Group = "Oceania", Name = "SolomonIslands", Tips = "SLB", ResourceType = typeof(Resources.Country))]
    SolomonIslands = 90,

    [Custom(Group = "Africa", Name = "Somalia", Tips = "SOM", ResourceType = typeof(Resources.Country))]
    Somalia = 706,

    [Custom(Group = "Africa", Name = "SouthAfrica", Tips = "ZAF", ResourceType = typeof(Resources.Country))]
    SouthAfrica = 710,

    [Custom(Group = "Americas", Name = "SouthGeorgiaAndSouthSandwichIslands", Tips = "SGS", ResourceType = typeof(Resources.Country))]
    SouthGeorgiaAndSouthSandwichIslands = 239,

    [Custom(Group = "Africa", Name = "SouthSudan", Tips = "SSD", ResourceType = typeof(Resources.Country))]
    SouthSudan = 728,

    [Custom(Group = "Europe", Name = "Spain", Tips = "ESP", ResourceType = typeof(Resources.Country))]
    Spain = 724,

    [Custom(Group = "Asia", Name = "SriLanka", Tips = "LKA", ResourceType = typeof(Resources.Country))]
    SriLanka = 144,

    [Custom(Group = "Asia", Name = "Palestine", Tips = "PSE", ResourceType = typeof(Resources.Country))]
    Palestine = 275,

    [Custom(Group = "Africa", Name = "Sudan", Tips = "SDN", ResourceType = typeof(Resources.Country))]
    Sudan = 729,

    [Custom(Group = "Americas", Name = "Suriname", Tips = "SUR", ResourceType = typeof(Resources.Country))]
    Suriname = 740,

    [Custom(Group = "Europe", Name = "Svalbard", Tips = "SJM", ResourceType = typeof(Resources.Country))]
    Svalbard = 744,

    [Custom(Group = "Europe", Name = "Sweden", Tips = "SWE", ResourceType = typeof(Resources.Country))]
    Sweden = 752,

    [Custom(Group = "Europe", Name = "Switzerland", Tips = "CHE", ResourceType = typeof(Resources.Country))]
    Switzerland = 756,

    [Custom(Group = "Asia", Name = "Syria", Tips = "SYR", ResourceType = typeof(Resources.Country))]
    Syria = 760,

    [Custom(Group = "Asia", Name = "Taiwan", Tips = "TWN", ResourceType = typeof(Resources.Country))]
    Taiwan = 99992,

    [Custom(Group = "Asia", Name = "Tajikistan", Tips = "TJK", ResourceType = typeof(Resources.Country))]
    Tajikistan = 762,

    [Custom(Group = "Asia", Name = "Thailand", Tips = "THA", ResourceType = typeof(Resources.Country))]
    Thailand = 764,

    [Custom(Group = "Asia", Name = "EastTimor", Tips = "TLS", ResourceType = typeof(Resources.Country))]
    EastTimor = 626,

    [Custom(Group = "Africa", Name = "Togo", Tips = "TGO", ResourceType = typeof(Resources.Country))]
    Togo = 768,

    [Custom(Group = "Oceania", Name = "Tokelau", Tips = "TKL", ResourceType = typeof(Resources.Country))]
    Tokelau = 772,

    [Custom(Group = "Oceania", Name = "Tonga", Tips = "TON", ResourceType = typeof(Resources.Country))]
    Tonga = 776,

    [Custom(Group = "Americas", Name = "TrinidadAndTobago", Tips = "TTO", ResourceType = typeof(Resources.Country))]
    TrinidadAndTobago = 780,

    [Custom(Group = "Africa", Name = "Tunisia", Tips = "TUN", ResourceType = typeof(Resources.Country))]
    Tunisia = 788,

    [Custom(Group = "Asia", Name = "Turkey", Tips = "TUR", ResourceType = typeof(Resources.Country))]
    Turkey = 792,

    [Custom(Group = "Asia", Name = "Turkmenistan", Tips = "TKM", ResourceType = typeof(Resources.Country))]
    Turkmenistan = 795,

    [Custom(Group = "Americas", Name = "TurksAndCaicosIslands", Tips = "TCA", ResourceType = typeof(Resources.Country))]
    TurksAndCaicosIslands = 796,

    [Custom(Group = "Oceania", Name = "Tuvalu", Tips = "TUV", ResourceType = typeof(Resources.Country))]
    Tuvalu = 798,

    [Custom(Group = "Africa", Name = "Uganda", Tips = "UGA", ResourceType = typeof(Resources.Country))]
    Uganda = 800,

    [Custom(Group = "Europe", Name = "Ukraine", Tips = "UKR", ResourceType = typeof(Resources.Country))]
    Ukraine = 804,

    [Custom(Group = "Asia", Name = "UnitedArabEmirates", Tips = "ARE", ResourceType = typeof(Resources.Country))]
    UnitedArabEmirates = 784,

    [Custom(Group = "Europe", Name = "UnitedKingdom", Tips = "GBR", ResourceType = typeof(Resources.Country))]
    UnitedKingdom = 826,

    [Custom(Group = "Africa", Name = "Tanzania", Tips = "TZA", ResourceType = typeof(Resources.Country))]
    Tanzania = 834,

    [Custom(Group = "Oceania", Name = "UnitedStatesMinorOutlyingIslands", Tips = "UMI", ResourceType = typeof(Resources.Country))]
    UnitedStatesMinorOutlyingIslands = 581,

    [Custom(Group = "Americas", Name = "UnitedStatesOfAmerica", Tips = "USA", ResourceType = typeof(Resources.Country))]
    UnitedStatesOfAmerica = 840,

    [Custom(Group = "Americas", Name = "VirginIslands", Tips = "VIR", ResourceType = typeof(Resources.Country))]
    VirginIslands = 850,

    [Custom(Group = "Americas", Name = "Uruguay", Tips = "URY", ResourceType = typeof(Resources.Country))]
    Uruguay = 858,

    [Custom(Group = "Asia", Name = "Uzbekistan", Tips = "UZB", ResourceType = typeof(Resources.Country))]
    Uzbekistan = 860,

    [Custom(Group = "Oceania", Name = "Vanuatu", Tips = "VUT", ResourceType = typeof(Resources.Country))]
    Vanuatu = 548,

    [Custom(Group = "Americas", Name = "Venezuela", Tips = "VEN", ResourceType = typeof(Resources.Country))]
    Venezuela = 862,

    [Custom(Group = "Asia", Name = "Vietnam", Tips = "VNM", ResourceType = typeof(Resources.Country))]
    Vietnam = 704,

    [Custom(Group = "Oceania", Name = "WallisAndFutuna", Tips = "WLF", ResourceType = typeof(Resources.Country))]
    WallisAndFutuna = 876,

    [Custom(Group = "Africa", Name = "WesternSahara", Tips = "ESH", ResourceType = typeof(Resources.Country))]
    WesternSahara = 732,

    [Custom(Group = "Asia", Name = "Yemen", Tips = "YEM", ResourceType = typeof(Resources.Country))]
    Yemen = 887,

    [Custom(Group = "Africa", Name = "Zambia", Tips = "ZMB", ResourceType = typeof(Resources.Country))]
    Zambia = 894,

    [Custom(Group = "Africa", Name = "Zimbabwe", Tips = "ZWE", ResourceType = typeof(Resources.Country))]
    Zimbabwe = 716
}