using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core
{
    public static class DataHelper
    {
        public static void AddLanguages(this ProfileModel profile, Country country)
        {
            if (profile.Languages.Any()) return;

            switch (country)
            {
                case Country.Afghanistan:
                    profile.Languages = [Language.Persian, Language.Pashto];
                    break;

                case Country.AlandIslands:
                    break;

                case Country.Albania:
                    profile.Languages = [Language.Albanian, Language.Italian];
                    break;

                case Country.Algeria:
                    profile.Languages = [Language.Arabic, Language.French]; //Berber
                    break;

                case Country.AmericanSamoa:
                    break;

                case Country.Andorra:
                    profile.Languages = [Language.Catalan];
                    break;

                case Country.Angola:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.Anguilla:
                    break;

                case Country.AntiguaAndBarbuda:
                    profile.Languages = [Language.English];
                    break;

                case Country.Argentina:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Armenia:
                    profile.Languages = [Language.Armenian, Language.Russian];
                    break;

                case Country.Aruba:
                    break;

                case Country.Australia:
                    profile.Languages = [Language.English];
                    break;

                case Country.Austria:
                    profile.Languages = [Language.German, Language.English];
                    break;

                case Country.Azerbaijan:
                    profile.Languages = [Language.Azerbaijani, Language.Russian];
                    break;

                case Country.Bahamas:
                    profile.Languages = [Language.English];
                    break;

                case Country.Bahrain:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Bangladesh:
                    profile.Languages = [Language.Bengali];
                    break;

                case Country.Barbados:
                    profile.Languages = [Language.English];
                    break;

                case Country.Belarus:
                    profile.Languages = [Language.Belarusian, Language.Russian];
                    break;

                case Country.Belgium:
                    profile.Languages = [Language.Dutch, Language.French, Language.German, Language.English];
                    break;

                case Country.Belize:
                    profile.Languages = [Language.English, Language.Spanish];
                    break;

                case Country.Benin:
                    profile.Languages = [Language.French];
                    break;

                case Country.Bermuda:
                    break;

                case Country.Bhutan:
                    profile.Languages = [Language.Dzongkha];
                    break;

                case Country.Bolivia:
                    profile.Languages = [Language.Spanish]; //many others
                    break;

                case Country.CaribbeanNetherlands:
                    break;

                case Country.BosniaAndHerzegovina:
                    profile.Languages = [Language.Bosnian, Language.Croatian, Language.Serbian];
                    break;

                case Country.Botswana:
                    profile.Languages = [Language.English];
                    break;

                case Country.BouvetIsland:
                    break;

                case Country.Brazil:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.BritishIndianOceanTerritory:
                    break;

                case Country.BritishVirginIslands:
                    break;

                case Country.Brunei:
                    profile.Languages = [Language.Malay];
                    break;

                case Country.Bulgaria:
                    profile.Languages = [Language.Bulgarian];
                    break;

                case Country.BurkinaFaso:
                    profile.Languages = [Language.French];
                    break;

                case Country.Burundi:
                    profile.Languages = [Language.French, Language.English, Language.Swahili]; //Kirundi
                    break;

                case Country.Cambodia:
                    profile.Languages = [Language.CentralKhmer];
                    break;

                case Country.Cameroon:
                    profile.Languages = [Language.English, Language.French];
                    break;

                case Country.Canada:
                    profile.Languages = [Language.English, Language.French];
                    break;

                case Country.CapeVerde:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.CaymanIslands:
                    break;

                case Country.CentralAfricanRepublic:
                    profile.Languages = [Language.French, Language.Sango];
                    break;

                case Country.Chad:
                    profile.Languages = [Language.Arabic, Language.French];
                    break;

                case Country.Chile:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.China:
                    profile.Languages = [Language.Chinese];
                    break;

                case Country.HongKong:
                    profile.Languages = [Language.Chinese, Language.English];
                    break;

                case Country.Macao:
                    profile.Languages = [Language.Chinese, Language.Portuguese];
                    break;

                case Country.ChristmasIsland:
                    profile.Languages = [Language.English, Language.Chinese, Language.Malay];
                    break;

                case Country.CocosKeelingIslands:
                    profile.Languages = [Language.English, Language.Malay];
                    break;

                case Country.Colombia:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Comoros:
                    profile.Languages = [Language.Arabic, Language.French]; //Comorian
                    break;

                case Country.RepublicOfTheCongo:
                    profile.Languages = [Language.French];
                    break;

                case Country.CookIslands:
                    profile.Languages = [Language.English, Language.Maori];
                    break;

                case Country.CostaRica:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Croatia:
                    profile.Languages = [Language.Croatian, Language.English];
                    break;

                case Country.Cuba:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Curacao:
                    break;

                case Country.Cyprus:
                    profile.Languages = [Language.Greek, Language.Turkish, Language.English];
                    break;

                case Country.Czechia:
                    profile.Languages = [Language.Czech, Language.Slovak];
                    break;

                case Country.DemocraticRepublicOfTheCongo:
                    profile.Languages = [Language.French];
                    break;

                case Country.Denmark:
                    profile.Languages = [Language.Danish];
                    break;

                case Country.Djibouti:
                    profile.Languages = [Language.Arabic, Language.French];
                    break;

                case Country.Dominica:
                    profile.Languages = [Language.English];
                    break;

                case Country.DominicanRepublic:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.EastTimor:
                    profile.Languages = [Language.Portuguese]; //Tetum
                    break;

                case Country.Ecuador:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Egypt:
                    profile.Languages = [Language.Arabic, Language.English];
                    break;

                case Country.ElSalvador:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.EquatorialGuinea:
                    profile.Languages = [Language.French, Language.Portuguese, Language.Spanish];
                    break;

                case Country.Eritrea:
                    profile.Languages = [Language.Tigrinya, Language.Arabic, Language.Italian];
                    break;

                case Country.Estonia:
                    profile.Languages = [Language.Estonian, Language.Russian];
                    break;

                case Country.Eswatini:
                    profile.Languages = [Language.English]; //Swazi
                    break;

                case Country.Ethiopia:
                    profile.Languages = [Language.Afar, Language.Amharic, Language.Oromo, Language.Somali, Language.Tigrinya];
                    break;

                case Country.FalklandIslands:
                    break;

                case Country.FaroeIslands:
                    break;

                case Country.Fiji:
                    profile.Languages = [Language.English, Language.Fijian, Language.Hindi];
                    break;

                case Country.Finland:
                    profile.Languages = [Language.Finnish, Language.Swedish, Language.English];
                    break;

                case Country.France:
                    profile.Languages = [Language.French, Language.Occitan];
                    break;

                case Country.FrenchGuiana:
                    break;

                case Country.FrenchPolynesia:
                    break;

                case Country.FrenchSouthernAndAntarcticLands:
                    break;

                case Country.Gabon:
                    profile.Languages = [Language.French];
                    break;

                case Country.Gambia:
                    profile.Languages = [Language.English];
                    break;

                case Country.Georgia:
                    profile.Languages = [Language.Georgian, Language.Russian];
                    break;

                case Country.Germany:
                    profile.Languages = [Language.German, Language.English];
                    break;

                case Country.Ghana:
                    profile.Languages = [Language.English];
                    break;

                case Country.Gibraltar:
                    break;

                case Country.Greece:
                    profile.Languages = [Language.Greek];
                    break;

                case Country.Greenland:
                    break;

                case Country.Grenada:
                    profile.Languages = [Language.English];
                    break;

                case Country.Guadeloupe:
                    break;

                case Country.Guam:
                    break;

                case Country.Guatemala:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Guernsey:
                    break;

                case Country.Guinea:
                    profile.Languages = [Language.French];
                    break;

                case Country.GuineaBissau:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.Guyana:
                    profile.Languages = [Language.English];
                    break;

                case Country.Haiti:
                    profile.Languages = [Language.French, Language.Haitian];
                    break;

                case Country.HeardIslandAndMcDonaldIslands:
                    break;

                case Country.Honduras:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Hungary:
                    profile.Languages = [Language.Hungarian];
                    break;

                case Country.Iceland:
                    profile.Languages = [Language.Icelandic];
                    break;

                case Country.India:
                    profile.Languages = [Language.Hindi, Language.English];
                    break;

                case Country.Indonesia:
                    profile.Languages = [Language.Indonesian, Language.Malay, Language.Javanese, Language.Sundanese]; //Madurese, Minangkabau
                    break;

                case Country.Iran:
                    profile.Languages = [Language.Persian];
                    break;

                case Country.Iraq:
                    profile.Languages = [Language.Arabic, Language.Kurdish];
                    break;

                case Country.Ireland:
                    profile.Languages = [Language.Irish, Language.English];
                    break;

                case Country.IsleOfMan:
                    break;

                case Country.Israel:
                    profile.Languages = [Language.Hebrew, Language.Russian, Language.English];
                    break;

                case Country.Italy:
                    profile.Languages = [Language.Italian];
                    break;

                case Country.IvoryCoast:
                    profile.Languages = [Language.French];
                    break;

                case Country.Jamaica:
                    profile.Languages = [Language.English];
                    break;

                case Country.Japan:
                    profile.Languages = [Language.Japanese];
                    break;

                case Country.Jersey:
                    break;

                case Country.Jordan:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Kazakhstan:
                    profile.Languages = [Language.Kazakh, Language.Russian];
                    break;

                case Country.Kenya:
                    profile.Languages = [Language.English, Language.Swahili];
                    break;

                case Country.Kiribati:
                    profile.Languages = [Language.English]; //Gilbertese
                    break;

                case Country.Kosovo:
                    profile.Languages = [Language.Albanian, Language.Serbian];
                    break;

                case Country.Kuwait:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Kyrgyzstan:
                    profile.Languages = [Language.Kirghiz, Language.Russian];
                    break;

                case Country.Laos:
                    profile.Languages = [Language.Lao];
                    break;

                case Country.Latvia:
                    profile.Languages = [Language.Latvian, Language.Russian];
                    break;

                case Country.Lebanon:
                    profile.Languages = [Language.Arabic, Language.English, Language.French];
                    break;

                case Country.Lesotho:
                    profile.Languages = [Language.SouthernSotho, Language.English];
                    break;

                case Country.Liberia:
                    profile.Languages = [Language.English];
                    break;

                case Country.Libya:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Liechtenstein:
                    profile.Languages = [Language.German];
                    break;

                case Country.Lithuania:
                    profile.Languages = [Language.Lithuanian, Language.Russian];
                    break;

                case Country.Luxembourg:
                    profile.Languages = [Language.French, Language.German, Language.Luxembourgish, Language.English, Language.Portuguese];
                    break;

                case Country.Madagascar:
                    profile.Languages = [Language.French, Language.Malagasy];
                    break;

                case Country.Malawi:
                    profile.Languages = [Language.English, Language.Chichewa];
                    break;

                case Country.Malaysia:
                    profile.Languages = [Language.Malay, Language.Chinese, Language.Tamil, Language.English]; //Cantonese
                    break;

                case Country.Maldives:
                    profile.Languages = [Language.Divehi, Language.English];
                    break;

                case Country.Mali:
                    profile.Languages = [Language.Bambara, Language.Fulah]; //Bobo, Bozo, Dogon, Hassaniya, Kassonke, Maninke, Minyanka, Senufo, Songhay languages, Soninke, Tamasheq
                    break;

                case Country.Malta:
                    profile.Languages = [Language.Maltese, Language.English];
                    break;

                //Sovereign Military Order of Malta

                case Country.MarshallIslands:
                    profile.Languages = [Language.English, Language.Marshallese];
                    break;

                case Country.Martinique:
                    break;

                case Country.Mauritania:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Mauritius:
                    profile.Languages = [Language.English]; //Mauritian Creole (Also known as 'Morisien')
                    break;

                case Country.Mayotte:
                    break;

                case Country.Mexico:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Moldova:
                    profile.Languages = [Language.Romanian];
                    break;

                case Country.FederatedStatesOfMicronesia:
                    profile.Languages = [Language.English];
                    break;

                case Country.PrincipalityOfMonaco:
                    profile.Languages = [Language.French]; //Monégasque
                    break;

                case Country.Mongolia:
                    profile.Languages = [Language.Mongolian];
                    break;

                case Country.Montenegro:
                    //Montenegrin
                    break;

                case Country.Montserrat:
                    break;

                case Country.Morocco:
                    profile.Languages = [Language.Arabic]; //Berber
                    break;

                case Country.Mozambique:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.Myanmar:
                    profile.Languages = [Language.Burmese, Language.English];
                    break;

                case Country.Namibia:
                    profile.Languages = [Language.English];
                    break;

                case Country.Nauru:
                    profile.Languages = [Language.English, Language.Nauru];
                    break;

                case Country.Nepal:
                    profile.Languages = [Language.Nepali];
                    break;

                case Country.Netherlands:
                    profile.Languages = [Language.Dutch, Language.English];
                    break;

                case Country.NewCaledonia:
                    break;

                case Country.NewZealand:
                    profile.Languages = [Language.English, Language.Maori];
                    break;

                case Country.Nicaragua:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Niger:
                    profile.Languages = [Language.French];
                    break;

                case Country.Nigeria:
                    profile.Languages = [Language.English, Language.Hausa];
                    break;

                case Country.Niue:
                    profile.Languages = [Language.English]; //Niuean
                    break;

                case Country.NorfolkIsland:
                    profile.Languages = [Language.English]; //Norfuk
                    break;

                case Country.NorthKorea:
                    profile.Languages = [Language.Korean];
                    break;

                case Country.NorthMacedonia:
                    profile.Languages = [Language.Albanian]; //Macedonian
                    break;

                //Northern Cyprus

                case Country.NorthernMarianaIslands:
                    break;

                case Country.Norway:
                    profile.Languages = [Language.NorwegianBokmål, Language.NorwegianNynorsk, Language.English];
                    break;

                case Country.Oman:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Pakistan:
                    profile.Languages = [Language.Urdu, Language.English];
                    break;

                case Country.Palau:
                    profile.Languages = [Language.English]; //Palauan
                    break;

                case Country.Palestine:
                    profile.Languages = [Language.Arabic, Language.English, Language.Hebrew];
                    break;

                case Country.Panama:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.PapuaNewGuinea:
                    profile.Languages = [Language.English, Language.HiriMotu]; //Tok Pisin
                    break;

                case Country.Paraguay:
                    profile.Languages = [Language.Spanish, Language.Guarani];
                    break;

                case Country.Peru:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Philippines:
                    profile.Languages = [Language.English]; //Filipino
                    break;

                case Country.PitcairnIslands:
                    break;

                case Country.Poland:
                    profile.Languages = [Language.Polish, Language.English];
                    break;

                case Country.Portugal:
                    profile.Languages = [Language.Portuguese, Language.English];
                    break;

                case Country.PuertoRico:
                    break;

                case Country.Qatar:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.SouthKorea:
                    profile.Languages = [Language.Korean];
                    break;

                case Country.Reunion:
                    break;

                case Country.Romania:
                    profile.Languages = [Language.Romanian];
                    break;

                case Country.Russia:
                    profile.Languages = [Language.Russian];
                    break;

                case Country.Rwanda:
                    profile.Languages = [Language.English, Language.French, Language.Kinyarwanda, Language.Swahili];
                    break;

                //Sahrawi Arab Democratic Republic - Arabic, Spanish

                case Country.SaintBarthelemy:
                    break;

                case Country.SaintHelenaAscensionAndTristanDaCunha:
                    break;

                case Country.SaintKittsAndNevis:
                    profile.Languages = [Language.English];
                    break;

                case Country.SaintLucia:
                    profile.Languages = [Language.English];
                    break;

                case Country.SaintMartin:
                    break;

                case Country.SaintPierreAndMiquelon:
                    break;

                case Country.SaintVincentAndTheGrenadines:
                    profile.Languages = [Language.English];
                    break;

                case Country.Samoa:
                    profile.Languages = [Language.English, Language.Samoan];
                    break;

                case Country.SanMarino:
                    profile.Languages = [Language.Italian];
                    break;

                case Country.SaoTomeAndPrincipe:
                    profile.Languages = [Language.Portuguese];
                    break;

                case Country.Sark:
                    break;

                case Country.SaudiArabia:
                    profile.Languages = [Language.Arabic, Language.Bengali]; //Filipino
                    break;

                case Country.Senegal:
                    profile.Languages = [Language.French];
                    break;

                case Country.Serbia:
                    profile.Languages = [Language.Serbian];
                    break;

                case Country.Seychelles:
                    profile.Languages = [Language.English, Language.French]; //Seychellois Creole
                    break;

                case Country.SierraLeone:
                    profile.Languages = [Language.English];
                    break;

                case Country.Singapore:
                    profile.Languages = [Language.English, Language.Malay, Language.Chinese, Language.Tamil];
                    break;

                case Country.SintMaarten:
                    break;

                case Country.Slovakia:
                    profile.Languages = [Language.Slovak];
                    break;

                case Country.Slovenia:
                    profile.Languages = [Language.Slovenian];
                    break;

                case Country.SolomonIslands:
                    profile.Languages = [Language.English];
                    break;

                case Country.Somalia:
                    profile.Languages = [Language.Somali, Language.Arabic];
                    break;

                //Somaliland

                case Country.SouthAfrica:
                    profile.Languages = [Language.Afrikaans, Language.English]; //many others
                    break;

                case Country.SouthGeorgiaAndSouthSandwichIslands:
                    break;

                //South Ossetia

                case Country.SouthSudan:
                    profile.Languages = [Language.English];
                    break;

                case Country.Spain:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.SriLanka:
                    profile.Languages = [Language.Sinhala, Language.Tamil, Language.English];
                    break;

                case Country.Sudan:
                    profile.Languages = [Language.Arabic, Language.English];
                    break;

                case Country.Suriname:
                    profile.Languages = [Language.Dutch];
                    break;

                case Country.Svalbard:
                    break;

                case Country.Sweden:
                    profile.Languages = [Language.Swedish];
                    break;

                case Country.Switzerland:
                    profile.Languages = [Language.French, Language.German, Language.Italian, Language.Romansh];
                    break;

                case Country.Syria:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Taiwan:
                    profile.Languages = [Language.Chinese];
                    break;

                case Country.Tajikistan:
                    profile.Languages = [Language.Tajik, Language.Russian];
                    break;

                case Country.Thailand:
                    profile.Languages = [Language.Thai, Language.Burmese];
                    break;

                case Country.Togo:
                    profile.Languages = [Language.French];
                    break;

                case Country.Tokelau:
                    profile.Languages = [Language.English]; //Tokelauan
                    break;

                case Country.Tonga:
                    profile.Languages = [Language.English]; //Tongan
                    break;

                //Transnistria

                case Country.TrinidadAndTobago:
                    profile.Languages = [Language.English]; //Trinidadian Creole
                    break;

                case Country.Tunisia:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Turkey:
                    profile.Languages = [Language.Turkish];
                    break;

                case Country.Turkmenistan:
                    profile.Languages = [Language.Turkmen, Language.Russian];
                    break;

                case Country.TurksAndCaicosIslands:
                    break;

                case Country.Tuvalu:
                    profile.Languages = [Language.English]; //Tuvaluan
                    break;

                case Country.Uganda:
                    profile.Languages = [Language.English, Language.Swahili];
                    break;

                case Country.Ukraine:
                    profile.Languages = [Language.Ukrainian];
                    break;

                case Country.UnitedArabEmirates:
                    profile.Languages = [Language.Arabic, Language.English];
                    break;

                case Country.UnitedKingdom:
                    profile.Languages = [Language.English];
                    break;

                case Country.Tanzania:
                    break;

                case Country.UnitedStatesMinorOutlyingIslands:
                    break;

                case Country.UnitedStatesOfAmerica:
                    profile.Languages = [Language.English, Language.Spanish];
                    break;

                case Country.VirginIslands:
                    break;

                case Country.Uruguay:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Uzbekistan:
                    profile.Languages = [Language.Uzbek, Language.Russian];
                    break;

                case Country.Vanuatu:
                    profile.Languages = [Language.English, Language.French, Language.Bislama];
                    break;

                case Country.VaticanCity:
                    profile.Languages = [Language.Italian, Language.Latin]; //Swiss German
                    break;

                case Country.Venezuela:
                    profile.Languages = [Language.Spanish];
                    break;

                case Country.Vietnam:
                    profile.Languages = [Language.Vietnamese];
                    break;

                case Country.WallisAndFutuna:
                    break;

                case Country.WesternSahara:
                    break;

                case Country.Yemen:
                    profile.Languages = [Language.Arabic];
                    break;

                case Country.Zambia:
                    profile.Languages = [Language.English];
                    break;

                case Country.Zimbabwe:
                    profile.Languages = [Language.English, Language.NorthNdebele, Language.Shona, Language.SouthernSotho, Language.Tonga, Language.Tswana, Language.Venda, Language.Xhosa]; //many others
                    break;

                default:
                    break;
            }
        }
    }
}