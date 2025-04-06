using MM.Shared.Models.Auth;
using System.Globalization;

namespace MM.WEB.Core
{
    public static class AppStateStatic
    {
        public static List<LogContainer> Logs { get; private set; } = [];

        [Custom(Name = "Language", ResourceType = typeof(GlobalTranslations))]
        public static Language Language { get; private set; }

        public static Action<TempClientePaddle>? RegistrationSuccessful { get; set; }
        public static Action<string>? ShowError { get; set; }

        static AppStateStatic()
        {
            var languages = EnumHelper.GetObjArray<Language>(false);
            var code = CultureInfo.CurrentCulture.Name.Split('-')[0];
            var language = languages.FirstOrDefault(w => w.Description == code);

            Language = (Language?)language?.Value ?? Language.English;
        }

        public static string GetLanguageCode()
        {
            return Language switch
            {
                Language.Portuguese => "pt",
                _ => "en",
            };
        }

        public static void ChangeLanguage(Language value)
        {
            Language = value;
        }
    }
}
