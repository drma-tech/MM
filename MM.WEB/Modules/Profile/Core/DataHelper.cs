using MM.Shared.Models.Profile;

namespace MM.WEB.Modules.Profile.Core
{
    public static class DataHelper
    {
        public static void AddLanguages(this ProfileModel profile, Country country)
        {
            //https://en.wikipedia.org/wiki/List_of_official_languages
            //https://en.wikipedia.org/wiki/List_of_official_languages_by_country_and_territory
            if (profile.Languages.Any()) return;

            switch (country)
            {
                case Country.CHN:
                    profile.Languages = new Language[] { Language.zh };
                    break;

                case Country.IND:
                    profile.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.USA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.IDN:
                    profile.Languages = new Language[] { Language.ms }; //Indonesian = It is a standardized variety of Malay
                    break;

                case Country.PAK:
                    profile.Languages = new Language[] { Language.HindiUrdu };
                    break;

                case Country.NGA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.BRA:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.BGD:
                    //profile.Languages = new Language[] { Language.Bengali };
                    break;

                case Country.RUS:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.MEX:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.JPN:
                    //profile.Languages = new Language[] { Language.Japanese };
                    break;

                case Country.ETH:
                    //Oromo, Amharic
                    break;

                case Country.PHL:
                    //Filipino (Tagalog)
                    break;

                case Country.EGY:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.VNM:
                    //profile.Languages = new Language[] { Language.Vietnamese };
                    break;

                case Country.COD:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.IRN:
                    profile.Languages = new Language[] { Language.fa };
                    break;

                case Country.TUR:
                    profile.Languages = new Language[] { Language.Turkish };
                    break;

                case Country.DEU:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.FRA:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.GBR:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.THA:
                    //Thai
                    break;

                case Country.ZAF:
                    //Zulu, Xhosa, Afrikaans, English
                    break;

                case Country.TZA:
                    profile.Languages = new Language[] { Language.sw, Language.en };
                    break;

                case Country.ITA:
                    profile.Languages = new Language[] { Language.it };
                    break;

                case Country.MMR:
                    //Burmese
                    break;

                case Country.KOR:
                    profile.Languages = new Language[] { Language.Korean };
                    break;

                case Country.COL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.KEN:
                    profile.Languages = new Language[] { Language.sw, Language.en };
                    break;

                case Country.ESP:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.ARG:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.DZA:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.SDN:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UGA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.IRQ:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UKR:
                    //Ukrainian
                    break;

                case Country.CAN:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.POL:
                    //Polish
                    break;

                case Country.MAR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.UZB:
                    //Uzbek
                    break;

                case Country.SAU:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.PER:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.AGO:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.AFG:
                    profile.Languages = new Language[] { Language.fa }; //Dari, which is a variety of and mutually intelligible with Persian
                    //Pashto, Dari
                    break;

                case Country.MYS:
                    profile.Languages = new Language[] { Language.ms };
                    break;

                case Country.MOZ:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.GHA:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.YEM:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.NPL:
                    //Nepali
                    break;

                case Country.VEN:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.CIV:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.MDG:
                    //Malagasy (official, and national language), French (official).
                    break;

                case Country.AUS:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.PRK:
                    profile.Languages = new Language[] { Language.Korean };
                    break;

                case Country.CMR:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.NER:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.TWN:
                    profile.Languages = new Language[] { Language.zh };
                    break;

                case Country.LKA:
                    //Sinhala
                    break;

                case Country.BFA:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.MWI:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.MLI:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.CHL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.KAZ:
                    //Kazakh, Russian
                    break;

                case Country.ROU:
                    profile.Languages = new Language[] { Language.ro };
                    break;

                case Country.ZMB:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.SYR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.ECU:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.NLD:
                    profile.Languages = new Language[] { Language.nl };
                    break;

                case Country.SEN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.GTM:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.TCD:
                    profile.Languages = new Language[] { Language.fr, Language.ar };
                    break;

                case Country.SOM:
                    profile.Languages = new Language[] { Language.Somali };
                    break;

                case Country.ZWE:
                    //Shona, English
                    break;

                case Country.KHM:
                    //Khmer
                    break;

                case Country.SSD:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.RWA:
                    //Kinyarwanda
                    break;

                case Country.GIN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BDI:
                    //Kirundi
                    break;

                case Country.BEN:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BOL:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.TUN:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.HTI:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.BEL:
                    profile.Languages = new Language[] { Language.nl };
                    break;

                case Country.JOR:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.CUB:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.GRC:
                    profile.Languages = new Language[] { Language.Greek };
                    break;

                case Country.DOM:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.CZE:
                    //Czech
                    break;

                case Country.SWE:
                    profile.Languages = new Language[] { Language.Swedish };
                    break;

                case Country.PRT:
                    profile.Languages = new Language[] { Language.pt };
                    break;

                case Country.AZE:
                    //Azerbaijani
                    break;

                case Country.HUN:
                    //Hungarian
                    break;

                case Country.HND:
                    profile.Languages = new Language[] { Language.es };
                    break;

                case Country.ISR:
                    //Hebrew
                    break;

                case Country.TJK:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.BLR:
                    profile.Languages = new Language[] { Language.ru };
                    break;

                case Country.ARE:
                    profile.Languages = new Language[] { Language.ar };
                    break;

                case Country.PNG:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.AUT:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.CHE:
                    profile.Languages = new Language[] { Language.de };
                    break;

                case Country.SLE:
                    profile.Languages = new Language[] { Language.en };
                    break;

                case Country.TGO:
                    profile.Languages = new Language[] { Language.fr };
                    break;

                case Country.HKG:
                    //Cantonese
                    break;

                case Country.PRY:
                    profile.Languages = new Language[] { Language.es };
                    break;

                default:
                    break;
            }
        }
    }
}