namespace MM.Shared.Helper
{
    public enum ZodiacType
    {
        [Custom(Name = "Western Zodiac", Description = "")]
        WesternZodiac = 1,

        [Custom(Name = "Chinese Zodiac", Description = "")]
        ChineseZodiac = 2,

        [Custom(Name = "Indian Zodiac", Description = "")]
        IndianZodiac = 3,

        [Custom(Name = "Tropic Zodiac", Description = "")]
        TropicZodiac = 4,

        [Custom(Name = "Sidereal Zodiac", Description = "")]
        SiderealZodiac = 5,

        [Custom(Name = "Celtic Zodiac", Description = "")]
        CelticZodiac = 6,

        [Custom(Name = "Egyptian Zodiac", Description = "")]
        EgyptianZodiac = 7,

        [Custom(Name = "Native American Zodiac", Description = "")]
        NativeAmericanZodiac = 8
    }

    public static class ZodiacHelper
    {
        public static string? GetZodiacName(this DateTime date, ZodiacType type)
        {
            return type switch
            {
                ZodiacType.WesternZodiac => date.GetWesternZodiac().GetName(),
                ZodiacType.ChineseZodiac => date.GetChineseZodiac(),
                ZodiacType.IndianZodiac => date.GetIndianZodiac(),
                ZodiacType.TropicZodiac => "",
                ZodiacType.SiderealZodiac => "",
                ZodiacType.CelticZodiac => "",
                ZodiacType.EgyptianZodiac => "",
                ZodiacType.NativeAmericanZodiac => "",
                _ => throw new NotImplementedException(),
            };
        }

        public static Zodiac GetWesternZodiac(this DateTime date)
        {
            if (date.Month == 12)
            {
                if (date.Day < 22)
                    return Zodiac.Sagittarius;
                else
                    return Zodiac.Capricorn;
            }
            else if (date.Month == 1)
            {
                if (date.Day < 20)
                    return Zodiac.Capricorn;
                else
                    return Zodiac.Aquarius;
            }
            else if (date.Month == 2)
            {
                if (date.Day < 19)
                    return Zodiac.Aquarius;
                else
                    return Zodiac.Pisces;
            }
            else if (date.Month == 3)
            {
                if (date.Day < 21)
                    return Zodiac.Pisces;
                else
                    return Zodiac.Aries;
            }
            else if (date.Month == 4)
            {
                if (date.Day < 20)
                    return Zodiac.Aries;
                else
                    return Zodiac.Taurus;
            }
            else if (date.Month == 5)
            {
                if (date.Day < 21)
                    return Zodiac.Taurus;
                else
                    return Zodiac.Gemini;
            }
            else if (date.Month == 6)
            {
                if (date.Day < 21)
                    return Zodiac.Gemini;
                else
                    return Zodiac.Cancer;
            }
            else if (date.Month == 7)
            {
                if (date.Day < 23)
                    return Zodiac.Cancer;
                else
                    return Zodiac.Leo;
            }
            else if (date.Month == 8)
            {
                if (date.Day < 23)
                    return Zodiac.Leo;
                else
                    return Zodiac.Virgo;
            }
            else if (date.Month == 9)
            {
                if (date.Day < 23)
                    return Zodiac.Virgo;
                else
                    return Zodiac.Libra;
            }
            else if (date.Month == 10)
            {
                if (date.Day < 23)
                    return Zodiac.Libra;
                else
                    return Zodiac.Scorpio;
            }
            else if (date.Month == 11)
            {
                if (date.Day < 22)
                    return Zodiac.Scorpio;
                else
                    return Zodiac.Sagittarius;
            }
            else
            {
                throw new InvalidOperationException("GetZodiac");
            }
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
            if (date.Month == 12)
            {
                if (date.Day <= 14)
                    return Zodiac.Scorpio.GetName() + " (Vrishchika)";
                else
                    return Zodiac.Sagittarius.GetName() + " (Dhanus)";
            }
            else if (date.Month == 1)
            {
                if (date.Day <= 13)
                    return Zodiac.Sagittarius.GetName() + " (Dhanus)";
                else
                    return Zodiac.Capricorn.GetName() + " (Makara)";
            }
            else if (date.Month == 2)
            {
                if (date.Day <= 11)
                    return Zodiac.Capricorn.GetName() + " (Makara)";
                else
                    return Zodiac.Aquarius.GetName() + " (Kumbha)";
            }
            else if (date.Month == 3)
            {
                if (date.Day <= 12)
                    return Zodiac.Aquarius.GetName() + " (Kumbha)";
                else
                    return Zodiac.Pisces.GetName() + " (Meena)";
            }
            else if (date.Month == 4)
            {
                if (date.Day <= 12)
                    return Zodiac.Pisces.GetName() + " (Meena)";
                else
                    return Zodiac.Aries.GetName() + " (Mesha)";
            }
            else if (date.Month == 5)
            {
                if (date.Day <= 14)
                    return Zodiac.Aries.GetName() + " (Mesha)";
                else
                    return Zodiac.Taurus.GetName() + " (Vrishaba)";
            }
            else if (date.Month == 6)
            {
                if (date.Day <= 14)
                    return Zodiac.Taurus.GetName() + " (Vrishaba)";
                else
                    return Zodiac.Gemini.GetName() + " (Mithuna)";
            }
            else if (date.Month == 7)
            {
                if (date.Day <= 14)
                    return Zodiac.Gemini.GetName() + " (Mithuna)";
                else
                    return Zodiac.Cancer.GetName() + " (Karkata)";
            }
            else if (date.Month == 8)
            {
                if (date.Day <= 14)
                    return Zodiac.Cancer.GetName() + " (Karkata)";
                else
                    return Zodiac.Leo.GetName() + " (Simha)";
            }
            else if (date.Month == 9)
            {
                if (date.Day <= 15)
                    return Zodiac.Leo.GetName() + " (Simha)";
                else
                    return Zodiac.Virgo.GetName() + " (Kanya)";
            }
            else if (date.Month == 10)
            {
                if (date.Day <= 15)
                    return Zodiac.Virgo.GetName() + " (Kanya)";
                else
                    return Zodiac.Libra.GetName() + " (Tula)";
            }
            else if (date.Month == 11)
            {
                if (date.Day <= 14)
                    return Zodiac.Libra.GetName() + " (Tula)";
                else
                    return Zodiac.Scorpio.GetName() + " (Vrishchika)";
            }
            else
            {
                throw new InvalidOperationException("GetZodiac");
            }
        }
    }
}