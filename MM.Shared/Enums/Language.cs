﻿namespace MM.Shared.Enums;

/// <summary>
///     https://en.wikipedia.org/wiki/List_of_ISO_639_language_codes
///     https://en.wikipedia.org/wiki/List_of_official_languages
///     https://en.wikipedia.org/wiki/List_of_official_languages_by_country_and_territory
/// </summary>
public enum Language
{
    [Custom(Name = "Abkhazian", Description = "ab", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Abkhazian = 'a' * 1000 + 'b',

    [Custom(Name = "Afar", Description = "aa", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Afar = 'a' * 1000 + 'a',

    [Custom(Name = "Afrikaans", Description = "af", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Afrikaans = 'a' * 1000 + 'f',

    [Custom(Name = "Akan", Description = "ak", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Akan = 'a' * 1000 + 'k',

    [Custom(Name = "Albanian", Description = "sq", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Albanian = 's' * 1000 + 'q',

    [Custom(Name = "Amharic", Description = "am", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Amharic = 'a' * 1000 + 'm',

    [Custom(Name = "Arabic", Description = "ar", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Arabic = 'a' * 1000 + 'r',

    [Custom(Name = "Aragonese", Description = "an", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Aragonese = 'a' * 1000 + 'n',

    [Custom(Name = "Armenian", Description = "hy", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Armenian = 'h' * 1000 + 'y',

    [Custom(Name = "Assamese", Description = "as", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Assamese = 'a' * 1000 + 's',

    [Custom(Name = "Avaric", Description = "av", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Avaric = 'a' * 1000 + 'v',

    [Custom(Name = "Avestan", Description = "ae", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Avestan = 'a' * 1000 + 'e',

    [Custom(Name = "Aymara", Description = "ay", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Aymara = 'a' * 1000 + 'y',

    [Custom(Name = "Azerbaijani", Description = "az", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Azerbaijani = 'a' * 1000 + 'z',

    [Custom(Name = "Bambara", Description = "bm", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bambara = 'b' * 1000 + 'm',

    [Custom(Name = "Bashkir", Description = "ba", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bashkir = 'b' * 1000 + 'a',

    [Custom(Name = "Basque", Description = "eu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Basque = 'e' * 1000 + 'u',

    [Custom(Name = "Belarusian", Description = "be", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Belarusian = 'b' * 1000 + 'e',

    [Custom(Name = "Bengali", Description = "bn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bengali = 'b' * 1000 + 'n',

    [Custom(Name = "Bislama", Description = "bi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bislama = 'b' * 1000 + 'i',

    [Custom(Name = "Bosnian", Description = "bs", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bosnian = 'b' * 1000 + 's',

    [Custom(Name = "Breton", Description = "br", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Breton = 'b' * 1000 + 'r',

    [Custom(Name = "Bulgarian", Description = "bg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Bulgarian = 'b' * 1000 + 'g',

    [Custom(Name = "Burmese", Description = "my", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Burmese = 'm' * 1000 + 'y',

    [Custom(Name = "Catalan", Description = "ca", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Catalan = 'c' * 1000 + 'a',

    [Custom(Name = "CentralKhmer", Description = "km", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    CentralKhmer = 'k' * 1000 + 'm',

    [Custom(Name = "Chamorro", Description = "ch", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Chamorro = 'c' * 1000 + 'h',

    [Custom(Name = "Chechen", Description = "ce", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Chechen = 'c' * 1000 + 'e',

    [Custom(Name = "Chichewa", Description = "ny", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Chichewa = 'n' * 1000 + 'y',

    [Custom(Name = "Chinese", Description = "zh", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Chinese = 'z' * 1000 + 'h',

    [Custom(Name = "ChurchSlavonic", Description = "cu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    ChurchSlavonic = 'c' * 1000 + 'u',

    [Custom(Name = "Chuvash", Description = "cv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Chuvash = 'c' * 1000 + 'v',

    [Custom(Name = "Cornish", Description = "kw", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Cornish = 'k' * 1000 + 'w',

    [Custom(Name = "Corsican", Description = "co", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Corsican = 'c' * 1000 + 'o',

    [Custom(Name = "Cree", Description = "cr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Cree = 'c' * 1000 + 'r',

    [Custom(Name = "Croatian", Description = "hr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Croatian = 'h' * 1000 + 'r',

    [Custom(Name = "Czech", Description = "cs", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Czech = 'c' * 1000 + 's',

    [Custom(Name = "Danish", Description = "da", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Danish = 'd' * 1000 + 'a',

    [Custom(Name = "Divehi", Description = "dv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Divehi = 'd' * 1000 + 'v',

    [Custom(Name = "Dutch", Description = "nl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Dutch = 'n' * 1000 + 'l',

    [Custom(Name = "Dzongkha", Description = "dz", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Dzongkha = 'd' * 1000 + 'z',

    [Custom(Name = "English", Description = "en", Group = "site", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    English = 'e' * 1000 + 'n',

    [Custom(Name = "Esperanto", Description = "eo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Esperanto = 'e' * 1000 + 'o',

    [Custom(Name = "Estonian", Description = "et", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Estonian = 'e' * 1000 + 't',

    [Custom(Name = "Ewe", Description = "ee", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ewe = 'e' * 1000 + 'e',

    [Custom(Name = "Faroese", Description = "fo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Faroese = 'f' * 1000 + 'o',

    [Custom(Name = "Fijian", Description = "fj", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Fijian = 'f' * 1000 + 'j',

    [Custom(Name = "Finnish", Description = "fi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Finnish = 'f' * 1000 + 'i',

    [Custom(Name = "French", Description = "fr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    French = 'f' * 1000 + 'r',

    [Custom(Name = "Fulah", Description = "ff", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Fulah = 'f' * 1000 + 'f',

    [Custom(Name = "Gaelic", Description = "gd", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Gaelic = 'g' * 1000 + 'd',

    [Custom(Name = "Galician", Description = "gl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Galician = 'g' * 1000 + 'l',

    [Custom(Name = "Ganda", Description = "lg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ganda = 'l' * 1000 + 'g',

    [Custom(Name = "Georgian", Description = "ka", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Georgian = 'k' * 1000 + 'a',

    [Custom(Name = "German", Description = "de", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    German = 'd' * 1000 + 'e',

    [Custom(Name = "Greek", Description = "el", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Greek = 'e' * 1000 + 'l',

    [Custom(Name = "Guarani", Description = "gn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Guarani = 'g' * 1000 + 'n',

    [Custom(Name = "Gujarati", Description = "gu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Gujarati = 'g' * 1000 + 'u',

    [Custom(Name = "Haitian", Description = "ht", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Haitian = 'h' * 1000 + 't',

    [Custom(Name = "Hausa", Description = "ha", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Hausa = 'h' * 1000 + 'a',

    [Custom(Name = "Hebrew", Description = "he", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Hebrew = 'h' * 1000 + 'e',

    [Custom(Name = "Herero", Description = "hz", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Herero = 'h' * 1000 + 'z',

    [Custom(Name = "Hindi", Description = "hi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Hindi = 'h' * 1000 + 'i',

    [Custom(Name = "HiriMotu", Description = "ho", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    HiriMotu = 'h' * 1000 + 'o',

    [Custom(Name = "Hungarian", Description = "hu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Hungarian = 'h' * 1000 + 'u',

    [Custom(Name = "Icelandic", Description = "is", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Icelandic = 'i' * 1000 + 's',

    [Custom(Name = "Ido", Description = "io", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ido = 'i' * 1000 + 'o',

    [Custom(Name = "Igbo", Description = "ig", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Igbo = 'i' * 1000 + 'g',

    [Custom(Name = "Indonesian", Description = "id", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Indonesian = 'i' * 1000 + 'd',

    [Custom(Name = "Interlingua", Description = "ia", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Interlingua = 'i' * 1000 + 'a',

    [Custom(Name = "Interlingue", Description = "ie", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Interlingue = 'i' * 1000 + 'e',

    [Custom(Name = "Inuktitut", Description = "iu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Inuktitut = 'i' * 1000 + 'u',

    [Custom(Name = "Inupiaq", Description = "ik", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Inupiaq = 'i' * 1000 + 'k',

    [Custom(Name = "Irish", Description = "ga", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Irish = 'g' * 1000 + 'a',

    [Custom(Name = "Italian", Description = "it", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Italian = 'i' * 1000 + 't',

    [Custom(Name = "Japanese", Description = "ja", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Japanese = 'j' * 1000 + 'a',

    [Custom(Name = "Javanese", Description = "jv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Javanese = 'j' * 1000 + 'v',

    [Custom(Name = "Kalaallisut", Description = "kl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kalaallisut = 'k' * 1000 + 'l',

    [Custom(Name = "Kannada", Description = "kn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kannada = 'k' * 1000 + 'n',

    [Custom(Name = "Kanuri", Description = "kr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kanuri = 'k' * 1000 + 'r',

    [Custom(Name = "Kashmiri", Description = "ks", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kashmiri = 'k' * 1000 + 's',

    [Custom(Name = "Kazakh", Description = "kk", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kazakh = 'k' * 1000 + 'k',

    [Custom(Name = "Kikuyu", Description = "ki", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kikuyu = 'k' * 1000 + 'i',

    [Custom(Name = "Kinyarwanda", Description = "rw", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kinyarwanda = 'r' * 1000 + 'w',

    [Custom(Name = "Kirghiz", Description = "ky", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kirghiz = 'k' * 1000 + 'y',

    [Custom(Name = "Komi", Description = "kv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Komi = 'k' * 1000 + 'v',

    [Custom(Name = "Kongo", Description = "kg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kongo = 'k' * 1000 + 'g',

    [Custom(Name = "Korean", Description = "ko", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Korean = 'k' * 1000 + 'o',

    [Custom(Name = "Kuanyama", Description = "kj", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kuanyama = 'k' * 1000 + 'j',

    [Custom(Name = "Kurdish", Description = "ku", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Kurdish = 'k' * 1000 + 'u',

    [Custom(Name = "Lao", Description = "lo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Lao = 'l' * 1000 + 'o',

    [Custom(Name = "Latin", Description = "la", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Latin = 'l' * 1000 + 'a',

    [Custom(Name = "Latvian", Description = "lv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Latvian = 'l' * 1000 + 'v',

    [Custom(Name = "Limburgan", Description = "li", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Limburgan = 'l' * 1000 + 'i',

    [Custom(Name = "Lingala", Description = "ln", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Lingala = 'l' * 1000 + 'n',

    [Custom(Name = "Lithuanian", Description = "lt", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Lithuanian = 'l' * 1000 + 't',

    [Custom(Name = "LubaKatanga", Description = "lu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    LubaKatanga = 'l' * 1000 + 'u',

    [Custom(Name = "Luxembourgish", Description = "lb", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Luxembourgish = 'l' * 1000 + 'b',

    [Custom(Name = "Macedonian", Description = "mk", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Macedonian = 'm' * 1000 + 'k',

    [Custom(Name = "Malagasy", Description = "mg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Malagasy = 'm' * 1000 + 'g',

    [Custom(Name = "Malay", Description = "ms", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Malay = 'm' * 1000 + 's',

    [Custom(Name = "Malayalam", Description = "ml", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Malayalam = 'm' * 1000 + 'l',

    [Custom(Name = "Maltese", Description = "mt", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Maltese = 'm' * 1000 + 't',

    [Custom(Name = "Manx", Description = "gv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Manx = 'g' * 1000 + 'v',

    [Custom(Name = "Maori", Description = "mi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Maori = 'm' * 1000 + 'i',

    [Custom(Name = "Marathi", Description = "mr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Marathi = 'm' * 1000 + 'r',

    [Custom(Name = "Marshallese", Description = "mh", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Marshallese = 'm' * 1000 + 'h',

    [Custom(Name = "Mongolian", Description = "mn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Mongolian = 'm' * 1000 + 'n',

    [Custom(Name = "Nauru", Description = "na", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Nauru = 'n' * 1000 + 'a',

    [Custom(Name = "Navajo", Description = "nv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Navajo = 'n' * 1000 + 'v',

    [Custom(Name = "Ndonga", Description = "ng", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ndonga = 'n' * 1000 + 'g',

    [Custom(Name = "Nepali", Description = "ne", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Nepali = 'n' * 1000 + 'e',

    [Custom(Name = "NorthernSami", Description = "se", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    NorthernSami = 's' * 1000 + 'e',

    [Custom(Name = "NorthNdebele", Description = "nd", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    NorthNdebele = 'n' * 1000 + 'd',

    [Custom(Name = "Norwegian", Description = "no", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Norwegian = 'n' * 1000 + 'o',

    [Custom(Name = "NorwegianBokmål", Description = "nb", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    NorwegianBokmål = 'n' * 1000 + 'b',

    [Custom(Name = "NorwegianNynorsk", Description = "nn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    NorwegianNynorsk = 'n' * 1000 + 'n',

    [Custom(Name = "Occitan", Description = "oc", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Occitan = 'o' * 1000 + 'c',

    [Custom(Name = "Ojibwa", Description = "oj", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ojibwa = 'o' * 1000 + 'j',

    [Custom(Name = "Oriya", Description = "or", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Oriya = 'o' * 1000 + 'r',

    [Custom(Name = "Oromo", Description = "om", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Oromo = 'o' * 1000 + 'm',

    [Custom(Name = "Ossetian", Description = "os", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ossetian = 'o' * 1000 + 's',

    [Custom(Name = "Pali", Description = "pi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Pali = 'p' * 1000 + 'i',

    [Custom(Name = "Pashto", Description = "ps", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Pashto = 'p' * 1000 + 's',

    [Custom(Name = "Persian", Description = "fa", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Persian = 'f' * 1000 + 'a',

    [Custom(Name = "Polish", Description = "pl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Polish = 'p' * 1000 + 'l',

    [Custom(Name = "Portuguese", Description = "pt", Group = "site", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Portuguese = 'p' * 1000 + 't',

    [Custom(Name = "Punjabi", Description = "pa", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Punjabi = 'p' * 1000 + 'a',

    [Custom(Name = "Quechua", Description = "qu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Quechua = 'q' * 1000 + 'u',

    [Custom(Name = "Romanian", Description = "ro", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Romanian = 'r' * 1000 + 'o',

    [Custom(Name = "Romansh", Description = "rm", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Romansh = 'r' * 1000 + 'm',

    [Custom(Name = "Rundi", Description = "rn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Rundi = 'r' * 1000 + 'n',

    [Custom(Name = "Russian", Description = "ru", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Russian = 'r' * 1000 + 'u',

    [Custom(Name = "Samoan", Description = "sm", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Samoan = 's' * 1000 + 'm',

    [Custom(Name = "Sango", Description = "sg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sango = 's' * 1000 + 'g',

    [Custom(Name = "Sanskrit", Description = "sa", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sanskrit = 's' * 1000 + 'a',

    [Custom(Name = "Sardinian", Description = "sc", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sardinian = 's' * 1000 + 'c',

    [Custom(Name = "Serbian", Description = "sr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Serbian = 's' * 1000 + 'r',

    [Custom(Name = "Shona", Description = "sn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Shona = 's' * 1000 + 'n',

    [Custom(Name = "SichuanYi", Description = "ii", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    SichuanYi = 'i' * 1000 + 'i',

    [Custom(Name = "Sindhi", Description = "sd", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sindhi = 's' * 1000 + 'd',

    [Custom(Name = "Sinhala", Description = "si", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sinhala = 's' * 1000 + 'i',

    [Custom(Name = "Slovak", Description = "sk", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Slovak = 's' * 1000 + 'k',

    [Custom(Name = "Slovenian", Description = "sl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Slovenian = 's' * 1000 + 'l',

    [Custom(Name = "Somali", Description = "so", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Somali = 's' * 1000 + 'o',

    [Custom(Name = "SouthernSotho", Description = "st", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    SouthernSotho = 's' * 1000 + 't',

    [Custom(Name = "SouthNdebele", Description = "nr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    SouthNdebele = 'n' * 1000 + 'r',

    [Custom(Name = "Spanish", Description = "es", Group = "site", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Spanish = 'e' * 1000 + 's',

    [Custom(Name = "Sundanese", Description = "su", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Sundanese = 's' * 1000 + 'u',

    [Custom(Name = "Swahili", Description = "sw", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Swahili = 's' * 1000 + 'w',

    [Custom(Name = "Swati", Description = "ss", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Swati = 's' * 1000 + 's',

    [Custom(Name = "Swedish", Description = "sv", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Swedish = 's' * 1000 + 'v',

    [Custom(Name = "Tagalog", Description = "tl", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tagalog = 't' * 1000 + 'l',

    [Custom(Name = "Tahitian", Description = "ty", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tahitian = 't' * 1000 + 'y',

    [Custom(Name = "Tajik", Description = "tg", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tajik = 't' * 1000 + 'g',

    [Custom(Name = "Tamil", Description = "ta", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tamil = 't' * 1000 + 'a',

    [Custom(Name = "Tatar", Description = "tt", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tatar = 't' * 1000 + 't',

    [Custom(Name = "Telugu", Description = "te", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Telugu = 't' * 1000 + 'e',

    [Custom(Name = "Thai", Description = "th", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Thai = 't' * 1000 + 'h',

    [Custom(Name = "Tibetan", Description = "bo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tibetan = 'b' * 1000 + 'o',

    [Custom(Name = "Tigrinya", Description = "ti", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tigrinya = 't' * 1000 + 'i',

    [Custom(Name = "Tonga", Description = "to", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tonga = 't' * 1000 + 'o',

    [Custom(Name = "Tsonga", Description = "ts", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tsonga = 't' * 1000 + 's',

    [Custom(Name = "Tswana", Description = "tn", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Tswana = 't' * 1000 + 'n',

    [Custom(Name = "Turkish", Description = "tr", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Turkish = 't' * 1000 + 'r',

    [Custom(Name = "Turkmen", Description = "tk", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Turkmen = 't' * 1000 + 'k',

    [Custom(Name = "Twi", Description = "tw", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Twi = 't' * 1000 + 'w',

    [Custom(Name = "Uighur", Description = "ug", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Uighur = 'u' * 1000 + 'g',

    [Custom(Name = "Ukrainian", Description = "uk", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Ukrainian = 'u' * 1000 + 'k',

    [Custom(Name = "Urdu", Description = "ur", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Urdu = 'u' * 1000 + 'r',

    [Custom(Name = "Uzbek", Description = "uz", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Uzbek = 'u' * 1000 + 'z',

    [Custom(Name = "Venda", Description = "ve", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Venda = 'v' * 1000 + 'e',

    [Custom(Name = "Vietnamese", Description = "vi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Vietnamese = 'v' * 1000 + 'i',

    [Custom(Name = "Volapük", Description = "vo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Volapük = 'v' * 1000 + 'o',

    [Custom(Name = "Walloon", Description = "wa", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Walloon = 'w' * 1000 + 'a',

    [Custom(Name = "Welsh", Description = "cy", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Welsh = 'c' * 1000 + 'y',

    [Custom(Name = "WesternFrisian", Description = "fy", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    WesternFrisian = 'f' * 1000 + 'y',

    [Custom(Name = "Wolof", Description = "wo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Wolof = 'w' * 1000 + 'o',

    [Custom(Name = "Xhosa", Description = "xh", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Xhosa = 'x' * 1000 + 'h',

    [Custom(Name = "Yiddish", Description = "yi", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Yiddish = 'y' * 1000 + 'i',

    [Custom(Name = "Yoruba", Description = "yo", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Yoruba = 'y' * 1000 + 'o',

    [Custom(Name = "Zhuang", Description = "za", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Zhuang = 'z' * 1000 + 'a',

    [Custom(Name = "Zulu", Description = "zu", ShowDescription = false, ResourceType = typeof(Resources.Language))]
    Zulu = 'z' * 1000 + 'u'
}