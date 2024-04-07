using Blazorise;
using MM.Shared.Models.Auth;
using System.Globalization;

namespace MM.WEB.Core
{
    public static class AppStateStatic
    {
        public static List<LogContainer> Logs { get; private set; } = [];

        public static Language Language { get; private set; }
        public static Bar? Sidebar { get; set; }

        public static Action<TempClientePaddle>? RegistrationSuccessful { get; set; }
        public static Action<string>? ShowError { get; set; }
        public static Action<bool>? ShowFeedback { get; set; }

        public static bool OnMobile { get; set; }
        public static bool OnTablet { get; set; }
        public static bool OnDesktop { get; set; }
        public static bool OnWidescreen { get; set; }
        public static bool OnFullHD { get; set; }

        static AppStateStatic()
        {
            Enum.TryParse(typeof(Language), CultureInfo.CurrentCulture.Name.Replace("-", ""), out object? language);

            Language = (Language?)language ?? Language.en;
        }

        public static string GetLanguageCode()
        {
            switch (Language)
            {
                case Language.pt: return "pt";
                default: return "en";
            }
        }
    }
}