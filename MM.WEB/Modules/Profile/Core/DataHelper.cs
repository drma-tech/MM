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
                    profile.Languages = [Language.zh];
                    break;

                case Country.IND:
                    profile.Languages = [Language.HindiUrdu];
                    break;

                case Country.USA:
                    profile.Languages = [Language.en];
                    break;

                case Country.IDN:
                    profile.Languages = [Language.ms]; //Indonesian = It is a standardized variety of Malay
                    break;

                case Country.PAK:
                    profile.Languages = [Language.HindiUrdu];
                    break;

                case Country.NGA:
                    profile.Languages = [Language.en];
                    break;

                case Country.BRA:
                    profile.Languages = [Language.pt];
                    break;

                case Country.BGD:
                    //profile.Languages = new Language[] { Language.Bengali };
                    break;

                case Country.RUS:
                    profile.Languages = [Language.ru];
                    break;

                case Country.MEX:
                    profile.Languages = [Language.es];
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
                    profile.Languages = [Language.ar];
                    break;

                case Country.VNM:
                    //profile.Languages = new Language[] { Language.Vietnamese };
                    break;

                case Country.COD:
                    profile.Languages = [Language.fr];
                    break;

                case Country.IRN:
                    profile.Languages = [Language.fa];
                    break;

                case Country.TUR:
                    profile.Languages = [Language.Turkish];
                    break;

                case Country.DEU:
                    profile.Languages = [Language.de];
                    break;

                case Country.FRA:
                    profile.Languages = [Language.fr];
                    break;

                case Country.GBR:
                    profile.Languages = [Language.en];
                    break;

                case Country.THA:
                    //Thai
                    break;

                case Country.ZAF:
                    //Zulu, Xhosa, Afrikaans, English
                    break;

                case Country.TZA:
                    profile.Languages = [Language.sw, Language.en];
                    break;

                case Country.ITA:
                    profile.Languages = [Language.it];
                    break;

                case Country.MMR:
                    //Burmese
                    break;

                case Country.KOR:
                    profile.Languages = [Language.Korean];
                    break;

                case Country.COL:
                    profile.Languages = [Language.es];
                    break;

                case Country.KEN:
                    profile.Languages = [Language.sw, Language.en];
                    break;

                case Country.ESP:
                    profile.Languages = [Language.es];
                    break;

                case Country.ARG:
                    profile.Languages = [Language.es];
                    break;

                case Country.DZA:
                    profile.Languages = [Language.ar];
                    break;

                case Country.SDN:
                    profile.Languages = [Language.ar];
                    break;

                case Country.UGA:
                    profile.Languages = [Language.en];
                    break;

                case Country.IRQ:
                    profile.Languages = [Language.ar];
                    break;

                case Country.UKR:
                    //Ukrainian
                    break;

                case Country.CAN:
                    profile.Languages = [Language.en];
                    break;

                case Country.POL:
                    //Polish
                    break;

                case Country.MAR:
                    profile.Languages = [Language.ar];
                    break;

                case Country.UZB:
                    //Uzbek
                    break;

                case Country.SAU:
                    profile.Languages = [Language.ar];
                    break;

                case Country.PER:
                    profile.Languages = [Language.es];
                    break;

                case Country.AGO:
                    profile.Languages = [Language.pt];
                    break;

                case Country.AFG:
                    profile.Languages = [Language.fa]; //Dari, which is a variety of and mutually intelligible with Persian
                    //Pashto, Dari
                    break;

                case Country.MYS:
                    profile.Languages = [Language.ms];
                    break;

                case Country.MOZ:
                    profile.Languages = [Language.pt];
                    break;

                case Country.GHA:
                    profile.Languages = [Language.en];
                    break;

                case Country.YEM:
                    profile.Languages = [Language.ar];
                    break;

                case Country.NPL:
                    //Nepali
                    break;

                case Country.VEN:
                    profile.Languages = [Language.es];
                    break;

                case Country.CIV:
                    profile.Languages = [Language.fr];
                    break;

                case Country.MDG:
                    //Malagasy (official, and national language), French (official).
                    break;

                case Country.AUS:
                    profile.Languages = [Language.en];
                    break;

                case Country.PRK:
                    profile.Languages = [Language.Korean];
                    break;

                case Country.CMR:
                    profile.Languages = [Language.fr];
                    break;

                case Country.NER:
                    profile.Languages = [Language.fr];
                    break;

                case Country.TWN:
                    profile.Languages = [Language.zh];
                    break;

                case Country.LKA:
                    //Sinhala
                    break;

                case Country.BFA:
                    profile.Languages = [Language.fr];
                    break;

                case Country.MWI:
                    profile.Languages = [Language.en];
                    break;

                case Country.MLI:
                    profile.Languages = [Language.fr];
                    break;

                case Country.CHL:
                    profile.Languages = [Language.es];
                    break;

                case Country.KAZ:
                    //Kazakh, Russian
                    break;

                case Country.ROU:
                    profile.Languages = [Language.ro];
                    break;

                case Country.ZMB:
                    profile.Languages = [Language.en];
                    break;

                case Country.SYR:
                    profile.Languages = [Language.ar];
                    break;

                case Country.ECU:
                    profile.Languages = [Language.es];
                    break;

                case Country.NLD:
                    profile.Languages = [Language.nl];
                    break;

                case Country.SEN:
                    profile.Languages = [Language.fr];
                    break;

                case Country.GTM:
                    profile.Languages = [Language.es];
                    break;

                case Country.TCD:
                    profile.Languages = [Language.fr, Language.ar];
                    break;

                case Country.SOM:
                    profile.Languages = [Language.Somali];
                    break;

                case Country.ZWE:
                    //Shona, English
                    break;

                case Country.KHM:
                    //Khmer
                    break;

                case Country.SSD:
                    profile.Languages = [Language.en];
                    break;

                case Country.RWA:
                    //Kinyarwanda
                    break;

                case Country.GIN:
                    profile.Languages = [Language.fr];
                    break;

                case Country.BDI:
                    //Kirundi
                    break;

                case Country.BEN:
                    profile.Languages = [Language.fr];
                    break;

                case Country.BOL:
                    profile.Languages = [Language.es];
                    break;

                case Country.TUN:
                    profile.Languages = [Language.ar];
                    break;

                case Country.HTI:
                    profile.Languages = [Language.fr];
                    break;

                case Country.BEL:
                    profile.Languages = [Language.nl];
                    break;

                case Country.JOR:
                    profile.Languages = [Language.ar];
                    break;

                case Country.CUB:
                    profile.Languages = [Language.es];
                    break;

                case Country.GRC:
                    profile.Languages = [Language.Greek];
                    break;

                case Country.DOM:
                    profile.Languages = [Language.es];
                    break;

                case Country.CZE:
                    //Czech
                    break;

                case Country.SWE:
                    profile.Languages = [Language.Swedish];
                    break;

                case Country.PRT:
                    profile.Languages = [Language.pt];
                    break;

                case Country.AZE:
                    //Azerbaijani
                    break;

                case Country.HUN:
                    //Hungarian
                    break;

                case Country.HND:
                    profile.Languages = [Language.es];
                    break;

                case Country.ISR:
                    //Hebrew
                    break;

                case Country.TJK:
                    profile.Languages = [Language.ru];
                    break;

                case Country.BLR:
                    profile.Languages = [Language.ru];
                    break;

                case Country.ARE:
                    profile.Languages = [Language.ar];
                    break;

                case Country.PNG:
                    profile.Languages = [Language.en];
                    break;

                case Country.AUT:
                    profile.Languages = [Language.de];
                    break;

                case Country.CHE:
                    profile.Languages = [Language.de];
                    break;

                case Country.SLE:
                    profile.Languages = [Language.en];
                    break;

                case Country.TGO:
                    profile.Languages = [Language.fr];
                    break;

                case Country.HKG:
                    //Cantonese
                    break;

                case Country.PRY:
                    profile.Languages = [Language.es];
                    break;

                default:
                    break;
            }
        }
    }
}