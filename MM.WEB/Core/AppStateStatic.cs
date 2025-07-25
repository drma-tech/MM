using System.Globalization;
using MM.Shared.Models.Auth;

namespace MM.WEB.Core;

public static class AppStateStatic
{
    static AppStateStatic()
    {
        //todo: deal with 419
        var languages = EnumHelper.GetList<Language>(false);
        var code = CultureInfo.CurrentCulture.Name.Split('-')[0];
        var language = languages.FirstOrDefault(w => w.Description == code);

        Language = language?.Value ?? Language.English;
    }

    public static List<LogContainer> Logs { get; private set; } = [];

    [Custom(Name = "Language", ResourceType = typeof(GlobalTranslations))]
    public static Language Language { get; private set; } = Language.English;

    [Custom(Name = "Dark Mode")]
    public static bool DarkMode { get; private set; }

    public static Action? RegionChanged { get; set; }
    public static Action? DarkModeChanged { get; set; }
    public static Action<TempClientePaddle>? RegistrationSuccessful { get; set; }
    public static Action<string>? ShowError { get; set; }

    public static string GetLanguageCode()
    {
        return Language switch
        {
            Language.Portuguese => "pt",
            Language.Spanish => "es",
            _ => "en"
        };
    }

    public static void ChangeLanguage(Language value)
    {
        Language = value;
    }

    public static void ChangeDarkMode(bool darkMode)
    {
        DarkMode = darkMode;
        DarkModeChanged?.Invoke();
    }
}