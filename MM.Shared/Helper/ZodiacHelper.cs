namespace MM.Shared.Helper
{
    public enum ZodiacType
    {
        [Custom(Name = "Western Zodiac")]
        WesternZodiac = 1,

        [Custom(Name = "Chinese Zodiac")]
        ChineseZodiac = 2,

        [Custom(Name = "Indian Zodiac")]
        IndianZodiac = 3,

        [Custom(Name = "Tropic Zodiac")]
        TropicZodiac = 4,

        [Custom(Name = "Sidereal Zodiac")]
        SiderealZodiac = 5,

        [Custom(Name = "Celtic Zodiac")]
        CelticZodiac = 6,

        [Custom(Name = "Egyptian Zodiac")]
        EgyptianZodiac = 7,

        [Custom(Name = "Native American Zodiac")]
        NativeAmericanZodiac = 8
    }

    public static class ZodiacHelper
    {
        public static string? GetZodiacName(this DateTime date, ZodiacType type)
        {
            return type switch
            {
                ZodiacType.WesternZodiac => date.GetWesternZodiac(),
                ZodiacType.ChineseZodiac => date.GetChineseZodiac(),
                ZodiacType.IndianZodiac => date.GetIndianZodiac(),
                ZodiacType.TropicZodiac => date.GetTropicZodiac(),
                ZodiacType.SiderealZodiac => date.GetSiderealZodiac(),
                ZodiacType.CelticZodiac => date.GetCelticZodiac(),
                ZodiacType.EgyptianZodiac => date.GetEgyptianZodiac(),
                ZodiacType.NativeAmericanZodiac => date.GetNativeAmericanZodiac(),
                _ => throw new NotImplementedException(),
            };
        }

        private enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        private static bool Between(this DateTime date, Month start_month, int start_day, Month end_month, int end_day)
        {
            var year_base = date.Year;
            var start_date = new DateTime(year_base, (int)start_month, start_day);
            var end_date = new DateTime(year_base, (int)end_month, end_day);

            if (start_date > end_date) start_date = new DateTime(year_base - 1, (int)start_month, start_day); //different years

            return start_date <= date && date <= end_date;
        }

        //https://en.wikipedia.org/wiki/Western_astrology
        public static string? GetWesternZodiac(this DateTime date)
        {
            if (date.Between(Month.March, 21, Month.April, 19)) return Zodiac.Aries.GetName();
            else if (date.Between(Month.April, 20, Month.May, 20)) return Zodiac.Taurus.GetName();
            else if (date.Between(Month.May, 21, Month.June, 20)) return Zodiac.Gemini.GetName();
            else if (date.Between(Month.June, 21, Month.July, 22)) return Zodiac.Cancer.GetName();
            else if (date.Between(Month.July, 23, Month.August, 22)) return Zodiac.Leo.GetName();
            else if (date.Between(Month.August, 23, Month.September, 22)) return Zodiac.Virgo.GetName();
            else if (date.Between(Month.September, 23, Month.October, 22)) return Zodiac.Libra.GetName();
            else if (date.Between(Month.October, 23, Month.November, 21)) return Zodiac.Scorpio.GetName();
            else if (date.Between(Month.November, 22, Month.December, 21)) return Zodiac.Sagittarius.GetName();
            else if (date.Between(Month.December, 22, Month.January, 19)) return Zodiac.Capricorn.GetName();
            else if (date.Between(Month.January, 20, Month.February, 18)) return Zodiac.Aquarius.GetName();
            else if (date.Between(Month.February, 19, Month.March, 20)) return Zodiac.Pisces.GetName();
            else throw new InvalidOperationException("GetWesternZodiac");
        }

        public static string? GetChineseZodiac(this DateTime date)
        {
            var cc = new System.Globalization.ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(date);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            //string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
            //int ei = (int)Math.Floor((date.Year - 4.0) % 10 / 2);
            //return $"{years[terrestrialBranch - 1]} ({elements[ei]})";

            return years[terrestrialBranch - 1];
        }

        //https://www.mindbodygreen.com/articles/vedic-astrology-101
        public static string? GetIndianZodiac(this DateTime date)
        {
            if (date.Between(Month.April, 13, Month.May, 14)) return Zodiac.Aries.GetName() + " (Mesha)";
            else if (date.Between(Month.May, 15, Month.June, 14)) return Zodiac.Taurus.GetName() + " (Vrishaba)";
            else if (date.Between(Month.June, 15, Month.July, 14)) return Zodiac.Gemini.GetName() + " (Mithuna)";
            else if (date.Between(Month.July, 15, Month.August, 14)) return Zodiac.Cancer.GetName() + " (Karkata)";
            else if (date.Between(Month.August, 15, Month.September, 15)) return Zodiac.Leo.GetName() + " (Simha)";
            else if (date.Between(Month.September, 16, Month.October, 15)) return Zodiac.Virgo.GetName() + " (Kanya)";
            else if (date.Between(Month.October, 16, Month.November, 14)) return Zodiac.Libra.GetName() + " (Tula)";
            else if (date.Between(Month.November, 15, Month.December, 14)) return Zodiac.Scorpio.GetName() + " (Vrishchika)";
            else if (date.Between(Month.December, 15, Month.January, 13)) return Zodiac.Sagittarius.GetName() + " (Dhanus)";
            else if (date.Between(Month.January, 14, Month.February, 11)) return Zodiac.Capricorn.GetName() + " (Makara)";
            else if (date.Between(Month.February, 12, Month.March, 12)) return Zodiac.Aquarius.GetName() + " (Kumbha)";
            else if (date.Between(Month.March, 13, Month.April, 12)) return Zodiac.Pisces.GetName() + " (Meena)";
            else throw new InvalidOperationException("GetIndianZodiac");
        }

        //https://en.wikipedia.org/wiki/Sidereal_and_tropical_astrology
        public static string? GetTropicZodiac(this DateTime date)
        {
            if (date.Between(Month.March, 22, Month.April, 20)) return Zodiac.Aries.GetName();
            else if (date.Between(Month.April, 21, Month.May, 21)) return Zodiac.Taurus.GetName();
            else if (date.Between(Month.May, 22, Month.June, 21)) return Zodiac.Gemini.GetName();
            else if (date.Between(Month.June, 22, Month.July, 22)) return Zodiac.Cancer.GetName();
            else if (date.Between(Month.July, 23, Month.August, 23)) return Zodiac.Leo.GetName();
            else if (date.Between(Month.August, 24, Month.September, 22)) return Zodiac.Virgo.GetName();
            else if (date.Between(Month.September, 23, Month.October, 23)) return Zodiac.Libra.GetName();
            else if (date.Between(Month.October, 24, Month.November, 22)) return Zodiac.Scorpio.GetName();
            else if (date.Between(Month.November, 23, Month.December, 22)) return Zodiac.Sagittarius.GetName();
            else if (date.Between(Month.December, 23, Month.January, 22)) return Zodiac.Capricorn.GetName();
            else if (date.Between(Month.January, 23, Month.February, 20)) return Zodiac.Aquarius.GetName();
            else if (date.Between(Month.February, 21, Month.March, 21)) return Zodiac.Pisces.GetName();
            else throw new InvalidOperationException("GetTropicZodiac");
        }

        //https://en.wikipedia.org/wiki/Sidereal_and_tropical_astrology
        public static string? GetSiderealZodiac(this DateTime date)
        {
            if (date.Between(Month.April, 14, Month.May, 14)) return Zodiac.Aries.GetName();
            else if (date.Between(Month.May, 15, Month.June, 15)) return Zodiac.Taurus.GetName();
            else if (date.Between(Month.June, 16, Month.July, 16)) return Zodiac.Gemini.GetName();
            else if (date.Between(Month.July, 17, Month.August, 16)) return Zodiac.Cancer.GetName();
            else if (date.Between(Month.August, 17, Month.September, 16)) return Zodiac.Leo.GetName();
            else if (date.Between(Month.September, 17, Month.October, 17)) return Zodiac.Virgo.GetName();
            else if (date.Between(Month.October, 18, Month.November, 16)) return Zodiac.Libra.GetName();
            else if (date.Between(Month.November, 17, Month.December, 15)) return Zodiac.Scorpio.GetName();
            else if (date.Between(Month.December, 16, Month.January, 14)) return Zodiac.Sagittarius.GetName();
            else if (date.Between(Month.January, 15, Month.February, 12)) return Zodiac.Capricorn.GetName();
            else if (date.Between(Month.February, 13, Month.March, 14)) return Zodiac.Aquarius.GetName();
            else if (date.Between(Month.March, 15, Month.April, 13)) return Zodiac.Pisces.GetName();
            else throw new InvalidOperationException("GetSiderealZodiac");
        }

        //https://www.tasteireland.com.au/blogs/news/whats-your-celtic-star-sign
        //https://www.treecouncil.ie/celtic-tree-astrology
        public static string? GetCelticZodiac(this DateTime date)
        {
            if (date.Between(Month.December, 24, Month.January, 20)) return "Birch (The Achiever)";
            else if (date.Between(Month.January, 21, Month.February, 17)) return "Rowan (The Thinker)";
            else if (date.Between(Month.February, 18, Month.March, 17)) return "Ash (The Enchanter)";
            else if (date.Between(Month.March, 18, Month.April, 14)) return "Alder (The Traliblazer)";
            else if (date.Between(Month.April, 15, Month.May, 12)) return "Willow (The Observer)";
            else if (date.Between(Month.May, 13, Month.June, 9)) return "Hawthorn (The Illusionist)";
            else if (date.Between(Month.June, 10, Month.July, 7)) return "Oak (The Stabiliser)";
            else if (date.Between(Month.July, 8, Month.August, 4)) return "Holly (The Ruler)";
            else if (date.Between(Month.August, 5, Month.September, 1)) return "Hazel (The Knower)";
            else if (date.Between(Month.September, 2, Month.September, 29)) return "Vine (The Equaliser)";
            else if (date.Between(Month.September, 30, Month.October, 27)) return "Ivy (The Survivor)";
            else if (date.Between(Month.October, 28, Month.November, 24)) return "Reed (The Leader)";
            else if (date.Between(Month.November, 25, Month.December, 23)) return "Elder (The Scholar)";
            else throw new InvalidOperationException("GetCelticZodiac");
        }

        //https://www.lovetoknow.com/life/astrology/egyptian-astrology
        public static string? GetEgyptianZodiac(this DateTime date)
        {
            if (date.Between(Month.January, 1, Month.January, 7) || 
                date.Between(Month.June, 19, Month.June, 28) || 
                date.Between(Month.September, 1, Month.September, 7) || 
                date.Between(Month.November, 18, Month.November, 26)) 
                return "The Nile";
            else if (date.Between(Month.January, 8, Month.January, 21) ||
                date.Between(Month.February, 1, Month.February, 11)) 
                return "Amon-Ra";
            else if (date.Between(Month.January, 22, Month.January, 31) ||
                date.Between(Month.September, 8, Month.September, 22)) 
                return "Mut";
            else if (date.Between(Month.February, 12, Month.February, 29) ||
                date.Between(Month.August, 20, Month.August, 31)) 
                return "Geb";
            else if (date.Between(Month.March, 1, Month.March, 10) ||
                date.Between(Month.November, 27, Month.December, 18)) 
                return "Osiris";
            else if (date.Between(Month.March, 11, Month.March, 31) ||
                date.Between(Month.October, 18, Month.October, 29) ||
                date.Between(Month.December, 19, Month.December, 31)) 
                return "Isis";
            else if (date.Between(Month.April, 1, Month.April, 19) ||
                date.Between(Month.November, 8, Month.November, 17)) 
                return "Thoth";
            else if (date.Between(Month.April, 20, Month.May, 7) ||
                date.Between(Month.August, 12, Month.August, 19)) 
                return "Horus";
            else if (date.Between(Month.May, 8, Month.May, 27) ||
                date.Between(Month.June, 29, Month.July, 13)) 
                return "Anubis";
            else if (date.Between(Month.May, 28, Month.June, 18) ||
                date.Between(Month.September, 28, Month.October, 2)) 
                return "Seth";
            else if (date.Between(Month.July, 14, Month.July, 28) ||
                date.Between(Month.September, 23, Month.September, 27) ||
                date.Between(Month.October, 3, Month.October, 17)) 
                return "Bastet";
            else if (date.Between(Month.July, 29, Month.August, 11) ||
                date.Between(Month.October, 30, Month.November, 7)) 
                return "Sekhmet";
            else throw new InvalidOperationException("GetCelticZodiac");
        }

        //https://www.elitedaily.com/wellness/native-american-zodiac-sign-can-help-understand-better/1953713
        public static string? GetNativeAmericanZodiac(this DateTime date)
        {
            if (date.Between(Month.January, 20, Month.February, 18)) return "Otter";
            else if (date.Between(Month.February, 19, Month.March, 20)) return "Wolf";
            else if (date.Between(Month.March, 21, Month.April, 19)) return "Falcon";
            else if (date.Between(Month.April, 20, Month.May, 20)) return "Beaver";
            else if (date.Between(Month.May, 21, Month.June, 20)) return "Deer";
            else if (date.Between(Month.June, 21, Month.July, 21)) return "Woodpecker";
            else if (date.Between(Month.July, 22, Month.August, 21)) return "Salmon";
            else if (date.Between(Month.August, 22, Month.September, 21)) return "Bear";
            else if (date.Between(Month.September, 22, Month.October, 22)) return "Raven";
            else if (date.Between(Month.October, 23, Month.November, 22)) return "Snake";
            else if (date.Between(Month.November, 23, Month.December, 21)) return "Owl";
            else if (date.Between(Month.December, 22, Month.January, 19)) return "Goose";
            else throw new InvalidOperationException("GetCelticZodiac");
        }
    }
}