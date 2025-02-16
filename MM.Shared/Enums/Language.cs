namespace MM.Shared.Enums
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/List_of_ISO_639_language_codes
    /// https://en.wikipedia.org/wiki/List_of_official_languages
    /// https://en.wikipedia.org/wiki/List_of_official_languages_by_country_and_territory
    /// </summary>
    ///
    public enum Language
    {
        [Custom(Name = "Abkhazian", Description = "ab", ResourceType = typeof(Resources.Language))]
        Abkhazian = ('a' * 1000) + 'b',

        [Custom(Name = "Afar", Description = "aa", ResourceType = typeof(Resources.Language))]
        Afar = ('a' * 1000) + 'a',

        [Custom(Name = "Afrikaans", Description = "af", ResourceType = typeof(Resources.Language))]
        Afrikaans = ('a' * 1000) + 'f',

        [Custom(Name = "Akan", Description = "ak", ResourceType = typeof(Resources.Language))]
        Akan = ('a' * 1000) + 'k',

        [Custom(Name = "Albanian", Description = "sq", ResourceType = typeof(Resources.Language))]
        Albanian = ('s' * 1000) + 'q',

        [Custom(Name = "Amharic", Description = "am", ResourceType = typeof(Resources.Language))]
        Amharic = ('a' * 1000) + 'm',

        [Custom(Name = "Arabic", Description = "ar", ResourceType = typeof(Resources.Language))]
        Arabic = ('a' * 1000) + 'r',

        [Custom(Name = "Aragonese", Description = "an", ResourceType = typeof(Resources.Language))]
        Aragonese = ('a' * 1000) + 'n',

        [Custom(Name = "Armenian", Description = "hy", ResourceType = typeof(Resources.Language))]
        Armenian = ('h' * 1000) + 'y',

        [Custom(Name = "Assamese", Description = "as", ResourceType = typeof(Resources.Language))]
        Assamese = ('a' * 1000) + 's',

        [Custom(Name = "Avaric", Description = "av", ResourceType = typeof(Resources.Language))]
        Avaric = ('a' * 1000) + 'v',

        [Custom(Name = "Avestan", Description = "ae", ResourceType = typeof(Resources.Language))]
        Avestan = ('a' * 1000) + 'e',

        [Custom(Name = "Aymara", Description = "ay", ResourceType = typeof(Resources.Language))]
        Aymara = ('a' * 1000) + 'y',

        [Custom(Name = "Azerbaijani", Description = "az", ResourceType = typeof(Resources.Language))]
        Azerbaijani = ('a' * 1000) + 'z',

        [Custom(Name = "Bambara", Description = "bm", ResourceType = typeof(Resources.Language))]
        Bambara = ('b' * 1000) + 'm',

        [Custom(Name = "Bashkir", Description = "ba", ResourceType = typeof(Resources.Language))]
        Bashkir = ('b' * 1000) + 'a',

        [Custom(Name = "Basque", Description = "eu", ResourceType = typeof(Resources.Language))]
        Basque = ('e' * 1000) + 'u',

        [Custom(Name = "Belarusian", Description = "be", ResourceType = typeof(Resources.Language))]
        Belarusian = ('b' * 1000) + 'e',

        [Custom(Name = "Bengali", Description = "bn", ResourceType = typeof(Resources.Language))]
        Bengali = ('b' * 1000) + 'n',

        [Custom(Name = "Bislama", Description = "bi", ResourceType = typeof(Resources.Language))]
        Bislama = ('b' * 1000) + 'i',

        [Custom(Name = "Bosnian", Description = "bs", ResourceType = typeof(Resources.Language))]
        Bosnian = ('b' * 1000) + 's',

        [Custom(Name = "Breton", Description = "br", ResourceType = typeof(Resources.Language))]
        Breton = ('b' * 1000) + 'r',

        [Custom(Name = "Bulgarian", Description = "bg", ResourceType = typeof(Resources.Language))]
        Bulgarian = ('b' * 1000) + 'g',

        [Custom(Name = "Burmese", Description = "my", ResourceType = typeof(Resources.Language))]
        Burmese = ('m' * 1000) + 'y',

        [Custom(Name = "Catalan", Description = "ca", ResourceType = typeof(Resources.Language))]
        Catalan = ('c' * 1000) + 'a',

        [Custom(Name = "CentralKhmer", Description = "km", ResourceType = typeof(Resources.Language))]
        CentralKhmer = ('k' * 1000) + 'm',

        [Custom(Name = "Chamorro", Description = "ch", ResourceType = typeof(Resources.Language))]
        Chamorro = ('c' * 1000) + 'h',

        [Custom(Name = "Chechen", Description = "ce", ResourceType = typeof(Resources.Language))]
        Chechen = ('c' * 1000) + 'e',

        [Custom(Name = "Chichewa", Description = "ny", ResourceType = typeof(Resources.Language))]
        Chichewa = ('n' * 1000) + 'y',

        [Custom(Name = "Chinese", Description = "zh", ResourceType = typeof(Resources.Language))]
        Chinese = ('z' * 1000) + 'h',

        [Custom(Name = "ChurchSlavonic", Description = "cu", ResourceType = typeof(Resources.Language))]
        ChurchSlavonic = ('c' * 1000) + 'u',

        [Custom(Name = "Chuvash", Description = "cv", ResourceType = typeof(Resources.Language))]
        Chuvash = ('c' * 1000) + 'v',

        [Custom(Name = "Cornish", Description = "kw", ResourceType = typeof(Resources.Language))]
        Cornish = ('k' * 1000) + 'w',

        [Custom(Name = "Corsican", Description = "co", ResourceType = typeof(Resources.Language))]
        Corsican = ('c' * 1000) + 'o',

        [Custom(Name = "Cree", Description = "cr", ResourceType = typeof(Resources.Language))]
        Cree = ('c' * 1000) + 'r',

        [Custom(Name = "Croatian", Description = "hr", ResourceType = typeof(Resources.Language))]
        Croatian = ('h' * 1000) + 'r',

        [Custom(Name = "Czech", Description = "cs", ResourceType = typeof(Resources.Language))]
        Czech = ('c' * 1000) + 's',

        [Custom(Name = "Danish", Description = "da", ResourceType = typeof(Resources.Language))]
        Danish = ('d' * 1000) + 'a',

        [Custom(Name = "Divehi", Description = "dv", ResourceType = typeof(Resources.Language))]
        Divehi = ('d' * 1000) + 'v',

        [Custom(Name = "Dutch", Description = "nl", ResourceType = typeof(Resources.Language))]
        Dutch = ('n' * 1000) + 'l',

        [Custom(Name = "Dzongkha", Description = "dz", ResourceType = typeof(Resources.Language))]
        Dzongkha = ('d' * 1000) + 'z',

        [Custom(Name = "English", Description = "en", Group = "site", ResourceType = typeof(Resources.Language))]
        English = ('e' * 1000) + 'n',

        [Custom(Name = "Esperanto", Description = "eo", ResourceType = typeof(Resources.Language))]
        Esperanto = ('e' * 1000) + 'o',

        [Custom(Name = "Estonian", Description = "et", ResourceType = typeof(Resources.Language))]
        Estonian = ('e' * 1000) + 't',

        [Custom(Name = "Ewe", Description = "ee", ResourceType = typeof(Resources.Language))]
        Ewe = ('e' * 1000) + 'e',

        [Custom(Name = "Faroese", Description = "fo", ResourceType = typeof(Resources.Language))]
        Faroese = ('f' * 1000) + 'o',

        [Custom(Name = "Fijian", Description = "fj", ResourceType = typeof(Resources.Language))]
        Fijian = ('f' * 1000) + 'j',

        [Custom(Name = "Finnish", Description = "fi", ResourceType = typeof(Resources.Language))]
        Finnish = ('f' * 1000) + 'i',

        [Custom(Name = "French", Description = "fr", ResourceType = typeof(Resources.Language))]
        French = ('f' * 1000) + 'r',

        [Custom(Name = "Fulah", Description = "ff", ResourceType = typeof(Resources.Language))]
        Fulah = ('f' * 1000) + 'f',

        [Custom(Name = "Gaelic", Description = "gd", ResourceType = typeof(Resources.Language))]
        Gaelic = ('g' * 1000) + 'd',

        [Custom(Name = "Galician", Description = "gl", ResourceType = typeof(Resources.Language))]
        Galician = ('g' * 1000) + 'l',

        [Custom(Name = "Ganda", Description = "lg", ResourceType = typeof(Resources.Language))]
        Ganda = ('l' * 1000) + 'g',

        [Custom(Name = "Georgian", Description = "ka", ResourceType = typeof(Resources.Language))]
        Georgian = ('k' * 1000) + 'a',

        [Custom(Name = "German", Description = "de", ResourceType = typeof(Resources.Language))]
        German = ('d' * 1000) + 'e',

        [Custom(Name = "Greek", Description = "el", ResourceType = typeof(Resources.Language))]
        Greek = ('e' * 1000) + 'l',

        [Custom(Name = "Guarani", Description = "gn", ResourceType = typeof(Resources.Language))]
        Guarani = ('g' * 1000) + 'n',

        [Custom(Name = "Gujarati", Description = "gu", ResourceType = typeof(Resources.Language))]
        Gujarati = ('g' * 1000) + 'u',

        [Custom(Name = "Haitian", Description = "ht", ResourceType = typeof(Resources.Language))]
        Haitian = ('h' * 1000) + 't',

        [Custom(Name = "Hausa", Description = "ha", ResourceType = typeof(Resources.Language))]
        Hausa = ('h' * 1000) + 'a',

        [Custom(Name = "Hebrew", Description = "he", ResourceType = typeof(Resources.Language))]
        Hebrew = ('h' * 1000) + 'e',

        [Custom(Name = "Herero", Description = "hz", ResourceType = typeof(Resources.Language))]
        Herero = ('h' * 1000) + 'z',

        [Custom(Name = "Hindi", Description = "hi", ResourceType = typeof(Resources.Language))]
        Hindi = ('h' * 1000) + 'i',

        [Custom(Name = "HiriMotu", Description = "ho", ResourceType = typeof(Resources.Language))]
        HiriMotu = ('h' * 1000) + 'o',

        [Custom(Name = "Hungarian", Description = "hu", ResourceType = typeof(Resources.Language))]
        Hungarian = ('h' * 1000) + 'u',

        [Custom(Name = "Icelandic", Description = "is", ResourceType = typeof(Resources.Language))]
        Icelandic = ('i' * 1000) + 's',

        [Custom(Name = "Ido", Description = "io", ResourceType = typeof(Resources.Language))]
        Ido = ('i' * 1000) + 'o',

        [Custom(Name = "Igbo", Description = "ig", ResourceType = typeof(Resources.Language))]
        Igbo = ('i' * 1000) + 'g',

        [Custom(Name = "Indonesian", Description = "id", ResourceType = typeof(Resources.Language))]
        Indonesian = ('i' * 1000) + 'd',

        [Custom(Name = "Interlingua", Description = "ia", ResourceType = typeof(Resources.Language))]
        Interlingua = ('i' * 1000) + 'a',

        [Custom(Name = "Interlingue", Description = "ie", ResourceType = typeof(Resources.Language))]
        Interlingue = ('i' * 1000) + 'e',

        [Custom(Name = "Inuktitut", Description = "iu", ResourceType = typeof(Resources.Language))]
        Inuktitut = ('i' * 1000) + 'u',

        [Custom(Name = "Inupiaq", Description = "ik", ResourceType = typeof(Resources.Language))]
        Inupiaq = ('i' * 1000) + 'k',

        [Custom(Name = "Irish", Description = "ga", ResourceType = typeof(Resources.Language))]
        Irish = ('g' * 1000) + 'a',

        [Custom(Name = "Italian", Description = "it", ResourceType = typeof(Resources.Language))]
        Italian = ('i' * 1000) + 't',

        [Custom(Name = "Japanese", Description = "ja", ResourceType = typeof(Resources.Language))]
        Japanese = ('j' * 1000) + 'a',

        [Custom(Name = "Javanese", Description = "jv", ResourceType = typeof(Resources.Language))]
        Javanese = ('j' * 1000) + 'v',

        [Custom(Name = "Kalaallisut", Description = "kl", ResourceType = typeof(Resources.Language))]
        Kalaallisut = ('k' * 1000) + 'l',

        [Custom(Name = "Kannada", Description = "kn", ResourceType = typeof(Resources.Language))]
        Kannada = ('k' * 1000) + 'n',

        [Custom(Name = "Kanuri", Description = "kr", ResourceType = typeof(Resources.Language))]
        Kanuri = ('k' * 1000) + 'r',

        [Custom(Name = "Kashmiri", Description = "ks", ResourceType = typeof(Resources.Language))]
        Kashmiri = ('k' * 1000) + 's',

        [Custom(Name = "Kazakh", Description = "kk", ResourceType = typeof(Resources.Language))]
        Kazakh = ('k' * 1000) + 'k',

        [Custom(Name = "Kikuyu", Description = "ki", ResourceType = typeof(Resources.Language))]
        Kikuyu = ('k' * 1000) + 'i',

        [Custom(Name = "Kinyarwanda", Description = "rw", ResourceType = typeof(Resources.Language))]
        Kinyarwanda = ('r' * 1000) + 'w',

        [Custom(Name = "Kirghiz", Description = "ky", ResourceType = typeof(Resources.Language))]
        Kirghiz = ('k' * 1000) + 'y',

        [Custom(Name = "Komi", Description = "kv", ResourceType = typeof(Resources.Language))]
        Komi = ('k' * 1000) + 'v',

        [Custom(Name = "Kongo", Description = "kg", ResourceType = typeof(Resources.Language))]
        Kongo = ('k' * 1000) + 'g',

        [Custom(Name = "Korean", Description = "ko", ResourceType = typeof(Resources.Language))]
        Korean = ('k' * 1000) + 'o',

        [Custom(Name = "Kuanyama", Description = "kj", ResourceType = typeof(Resources.Language))]
        Kuanyama = ('k' * 1000) + 'j',

        [Custom(Name = "Kurdish", Description = "ku", ResourceType = typeof(Resources.Language))]
        Kurdish = ('k' * 1000) + 'u',

        [Custom(Name = "Lao", Description = "lo", ResourceType = typeof(Resources.Language))]
        Lao = ('l' * 1000) + 'o',

        [Custom(Name = "Latin", Description = "la", ResourceType = typeof(Resources.Language))]
        Latin = ('l' * 1000) + 'a',

        [Custom(Name = "Latvian", Description = "lv", ResourceType = typeof(Resources.Language))]
        Latvian = ('l' * 1000) + 'v',

        [Custom(Name = "Limburgan", Description = "li", ResourceType = typeof(Resources.Language))]
        Limburgan = ('l' * 1000) + 'i',

        [Custom(Name = "Lingala", Description = "ln", ResourceType = typeof(Resources.Language))]
        Lingala = ('l' * 1000) + 'n',

        [Custom(Name = "Lithuanian", Description = "lt", ResourceType = typeof(Resources.Language))]
        Lithuanian = ('l' * 1000) + 't',

        [Custom(Name = "LubaKatanga", Description = "lu", ResourceType = typeof(Resources.Language))]
        LubaKatanga = ('l' * 1000) + 'u',

        [Custom(Name = "Luxembourgish", Description = "lb", ResourceType = typeof(Resources.Language))]
        Luxembourgish = ('l' * 1000) + 'b',

        [Custom(Name = "Macedonian", Description = "mk", ResourceType = typeof(Resources.Language))]
        Macedonian = ('m' * 1000) + 'k',

        [Custom(Name = "Malagasy", Description = "mg", ResourceType = typeof(Resources.Language))]
        Malagasy = ('m' * 1000) + 'g',

        [Custom(Name = "Malay", Description = "ms", ResourceType = typeof(Resources.Language))]
        Malay = ('m' * 1000) + 's',

        [Custom(Name = "Malayalam", Description = "ml", ResourceType = typeof(Resources.Language))]
        Malayalam = ('m' * 1000) + 'l',

        [Custom(Name = "Maltese", Description = "mt", ResourceType = typeof(Resources.Language))]
        Maltese = ('m' * 1000) + 't',

        [Custom(Name = "Manx", Description = "gv", ResourceType = typeof(Resources.Language))]
        Manx = ('g' * 1000) + 'v',

        [Custom(Name = "Maori", Description = "mi", ResourceType = typeof(Resources.Language))]
        Maori = ('m' * 1000) + 'i',

        [Custom(Name = "Marathi", Description = "mr", ResourceType = typeof(Resources.Language))]
        Marathi = ('m' * 1000) + 'r',

        [Custom(Name = "Marshallese", Description = "mh", ResourceType = typeof(Resources.Language))]
        Marshallese = ('m' * 1000) + 'h',

        [Custom(Name = "Mongolian", Description = "mn", ResourceType = typeof(Resources.Language))]
        Mongolian = ('m' * 1000) + 'n',

        [Custom(Name = "Nauru", Description = "na", ResourceType = typeof(Resources.Language))]
        Nauru = ('n' * 1000) + 'a',

        [Custom(Name = "Navajo", Description = "nv", ResourceType = typeof(Resources.Language))]
        Navajo = ('n' * 1000) + 'v',

        [Custom(Name = "Ndonga", Description = "ng", ResourceType = typeof(Resources.Language))]
        Ndonga = ('n' * 1000) + 'g',

        [Custom(Name = "Nepali", Description = "ne", ResourceType = typeof(Resources.Language))]
        Nepali = ('n' * 1000) + 'e',

        [Custom(Name = "NorthernSami", Description = "se", ResourceType = typeof(Resources.Language))]
        NorthernSami = ('s' * 1000) + 'e',

        [Custom(Name = "NorthNdebele", Description = "nd", ResourceType = typeof(Resources.Language))]
        NorthNdebele = ('n' * 1000) + 'd',

        [Custom(Name = "Norwegian", Description = "no", ResourceType = typeof(Resources.Language))]
        Norwegian = ('n' * 1000) + 'o',

        [Custom(Name = "NorwegianBokmål", Description = "nb", ResourceType = typeof(Resources.Language))]
        NorwegianBokmål = ('n' * 1000) + 'b',

        [Custom(Name = "NorwegianNynorsk", Description = "nn", ResourceType = typeof(Resources.Language))]
        NorwegianNynorsk = ('n' * 1000) + 'n',

        [Custom(Name = "Occitan", Description = "oc", ResourceType = typeof(Resources.Language))]
        Occitan = ('o' * 1000) + 'c',

        [Custom(Name = "Ojibwa", Description = "oj", ResourceType = typeof(Resources.Language))]
        Ojibwa = ('o' * 1000) + 'j',

        [Custom(Name = "Oriya", Description = "or", ResourceType = typeof(Resources.Language))]
        Oriya = ('o' * 1000) + 'r',

        [Custom(Name = "Oromo", Description = "om", ResourceType = typeof(Resources.Language))]
        Oromo = ('o' * 1000) + 'm',

        [Custom(Name = "Ossetian", Description = "os", ResourceType = typeof(Resources.Language))]
        Ossetian = ('o' * 1000) + 's',

        [Custom(Name = "Pali", Description = "pi", ResourceType = typeof(Resources.Language))]
        Pali = ('p' * 1000) + 'i',

        [Custom(Name = "Pashto", Description = "ps", ResourceType = typeof(Resources.Language))]
        Pashto = ('p' * 1000) + 's',

        [Custom(Name = "Persian", Description = "fa", ResourceType = typeof(Resources.Language))]
        Persian = ('f' * 1000) + 'a',

        [Custom(Name = "Polish", Description = "pl", ResourceType = typeof(Resources.Language))]
        Polish = ('p' * 1000) + 'l',

        [Custom(Name = "Portuguese", Description = "pt", Group = "site", ResourceType = typeof(Resources.Language))]
        Portuguese = ('p' * 1000) + 't',

        [Custom(Name = "Punjabi", Description = "pa", ResourceType = typeof(Resources.Language))]
        Punjabi = ('p' * 1000) + 'a',

        [Custom(Name = "Quechua", Description = "qu", ResourceType = typeof(Resources.Language))]
        Quechua = ('q' * 1000) + 'u',

        [Custom(Name = "Romanian", Description = "ro", ResourceType = typeof(Resources.Language))]
        Romanian = ('r' * 1000) + 'o',

        [Custom(Name = "Romansh", Description = "rm", ResourceType = typeof(Resources.Language))]
        Romansh = ('r' * 1000) + 'm',

        [Custom(Name = "Rundi", Description = "rn", ResourceType = typeof(Resources.Language))]
        Rundi = ('r' * 1000) + 'n',

        [Custom(Name = "Russian", Description = "ru", ResourceType = typeof(Resources.Language))]
        Russian = ('r' * 1000) + 'u',

        [Custom(Name = "Samoan", Description = "sm", ResourceType = typeof(Resources.Language))]
        Samoan = ('s' * 1000) + 'm',

        [Custom(Name = "Sango", Description = "sg", ResourceType = typeof(Resources.Language))]
        Sango = ('s' * 1000) + 'g',

        [Custom(Name = "Sanskrit", Description = "sa", ResourceType = typeof(Resources.Language))]
        Sanskrit = ('s' * 1000) + 'a',

        [Custom(Name = "Sardinian", Description = "sc", ResourceType = typeof(Resources.Language))]
        Sardinian = ('s' * 1000) + 'c',

        [Custom(Name = "Serbian", Description = "sr", ResourceType = typeof(Resources.Language))]
        Serbian = ('s' * 1000) + 'r',

        [Custom(Name = "Shona", Description = "sn", ResourceType = typeof(Resources.Language))]
        Shona = ('s' * 1000) + 'n',

        [Custom(Name = "SichuanYi", Description = "ii", ResourceType = typeof(Resources.Language))]
        SichuanYi = ('i' * 1000) + 'i',

        [Custom(Name = "Sindhi", Description = "sd", ResourceType = typeof(Resources.Language))]
        Sindhi = ('s' * 1000) + 'd',

        [Custom(Name = "Sinhala", Description = "si", ResourceType = typeof(Resources.Language))]
        Sinhala = ('s' * 1000) + 'i',

        [Custom(Name = "Slovak", Description = "sk", ResourceType = typeof(Resources.Language))]
        Slovak = ('s' * 1000) + 'k',

        [Custom(Name = "Slovenian", Description = "sl", ResourceType = typeof(Resources.Language))]
        Slovenian = ('s' * 1000) + 'l',

        [Custom(Name = "Somali", Description = "so", ResourceType = typeof(Resources.Language))]
        Somali = ('s' * 1000) + 'o',

        [Custom(Name = "SouthernSotho", Description = "st", ResourceType = typeof(Resources.Language))]
        SouthernSotho = ('s' * 1000) + 't',

        [Custom(Name = "SouthNdebele", Description = "nr", ResourceType = typeof(Resources.Language))]
        SouthNdebele = ('n' * 1000) + 'r',

        [Custom(Name = "Spanish", Description = "es", Group = "site", ResourceType = typeof(Resources.Language))]
        Spanish = ('e' * 1000) + 's',

        [Custom(Name = "Sundanese", Description = "su", ResourceType = typeof(Resources.Language))]
        Sundanese = ('s' * 1000) + 'u',

        [Custom(Name = "Swahili", Description = "sw", ResourceType = typeof(Resources.Language))]
        Swahili = ('s' * 1000) + 'w',

        [Custom(Name = "Swati", Description = "ss", ResourceType = typeof(Resources.Language))]
        Swati = ('s' * 1000) + 's',

        [Custom(Name = "Swedish", Description = "sv", ResourceType = typeof(Resources.Language))]
        Swedish = ('s' * 1000) + 'v',

        [Custom(Name = "Tagalog", Description = "tl", ResourceType = typeof(Resources.Language))]
        Tagalog = ('t' * 1000) + 'l',

        [Custom(Name = "Tahitian", Description = "ty", ResourceType = typeof(Resources.Language))]
        Tahitian = ('t' * 1000) + 'y',

        [Custom(Name = "Tajik", Description = "tg", ResourceType = typeof(Resources.Language))]
        Tajik = ('t' * 1000) + 'g',

        [Custom(Name = "Tamil", Description = "ta", ResourceType = typeof(Resources.Language))]
        Tamil = ('t' * 1000) + 'a',

        [Custom(Name = "Tatar", Description = "tt", ResourceType = typeof(Resources.Language))]
        Tatar = ('t' * 1000) + 't',

        [Custom(Name = "Telugu", Description = "te", ResourceType = typeof(Resources.Language))]
        Telugu = ('t' * 1000) + 'e',

        [Custom(Name = "Thai", Description = "th", ResourceType = typeof(Resources.Language))]
        Thai = ('t' * 1000) + 'h',

        [Custom(Name = "Tibetan", Description = "bo", ResourceType = typeof(Resources.Language))]
        Tibetan = ('b' * 1000) + 'o',

        [Custom(Name = "Tigrinya", Description = "ti", ResourceType = typeof(Resources.Language))]
        Tigrinya = ('t' * 1000) + 'i',

        [Custom(Name = "Tonga", Description = "to", ResourceType = typeof(Resources.Language))]
        Tonga = ('t' * 1000) + 'o',

        [Custom(Name = "Tsonga", Description = "ts", ResourceType = typeof(Resources.Language))]
        Tsonga = ('t' * 1000) + 's',

        [Custom(Name = "Tswana", Description = "tn", ResourceType = typeof(Resources.Language))]
        Tswana = ('t' * 1000) + 'n',

        [Custom(Name = "Turkish", Description = "tr", ResourceType = typeof(Resources.Language))]
        Turkish = ('t' * 1000) + 'r',

        [Custom(Name = "Turkmen", Description = "tk", ResourceType = typeof(Resources.Language))]
        Turkmen = ('t' * 1000) + 'k',

        [Custom(Name = "Twi", Description = "tw", ResourceType = typeof(Resources.Language))]
        Twi = ('t' * 1000) + 'w',

        [Custom(Name = "Uighur", Description = "ug", ResourceType = typeof(Resources.Language))]
        Uighur = ('u' * 1000) + 'g',

        [Custom(Name = "Ukrainian", Description = "uk", ResourceType = typeof(Resources.Language))]
        Ukrainian = ('u' * 1000) + 'k',

        [Custom(Name = "Urdu", Description = "ur", ResourceType = typeof(Resources.Language))]
        Urdu = ('u' * 1000) + 'r',

        [Custom(Name = "Uzbek", Description = "uz", ResourceType = typeof(Resources.Language))]
        Uzbek = ('u' * 1000) + 'z',

        [Custom(Name = "Venda", Description = "ve", ResourceType = typeof(Resources.Language))]
        Venda = ('v' * 1000) + 'e',

        [Custom(Name = "Vietnamese", Description = "vi", ResourceType = typeof(Resources.Language))]
        Vietnamese = ('v' * 1000) + 'i',

        [Custom(Name = "Volapük", Description = "vo", ResourceType = typeof(Resources.Language))]
        Volapük = ('v' * 1000) + 'o',

        [Custom(Name = "Walloon", Description = "wa", ResourceType = typeof(Resources.Language))]
        Walloon = ('w' * 1000) + 'a',

        [Custom(Name = "Welsh", Description = "cy", ResourceType = typeof(Resources.Language))]
        Welsh = ('c' * 1000) + 'y',

        [Custom(Name = "WesternFrisian", Description = "fy", ResourceType = typeof(Resources.Language))]
        WesternFrisian = ('f' * 1000) + 'y',

        [Custom(Name = "Wolof", Description = "wo", ResourceType = typeof(Resources.Language))]
        Wolof = ('w' * 1000) + 'o',

        [Custom(Name = "Xhosa", Description = "xh", ResourceType = typeof(Resources.Language))]
        Xhosa = ('x' * 1000) + 'h',

        [Custom(Name = "Yiddish", Description = "yi", ResourceType = typeof(Resources.Language))]
        Yiddish = ('y' * 1000) + 'i',

        [Custom(Name = "Yoruba", Description = "yo", ResourceType = typeof(Resources.Language))]
        Yoruba = ('y' * 1000) + 'o',

        [Custom(Name = "Zhuang", Description = "za", ResourceType = typeof(Resources.Language))]
        Zhuang = ('z' * 1000) + 'a',

        [Custom(Name = "Zulu", Description = "zu", ResourceType = typeof(Resources.Language))]
        Zulu = ('z' * 1000) + 'u',
    }
}