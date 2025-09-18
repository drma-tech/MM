using System.Globalization;
using System.Security.Claims;
using MM.Shared.Models.Auth;
using MudBlazor;
using SD.Shared.Enums;

namespace MM.WEB.Core;

public static class AppStateStatic
{
    public static bool IsAuthenticated { get; set; }
    public static ClaimsPrincipal? User { get; set; }
    public static string? UserId { get; set; }

    public static Breakpoint Breakpoint { get; set; }
    public static Action<Breakpoint>? BreakpointChanged { get; set; }

    public static Platform Platform { get; set; } = Platform.webapp;
    public static string? Version { get; set; }

    #region AppLanguage

    [Custom(Name = "AppLanguage", ResourceType = typeof(GlobalTranslations))]
    public static AppLanguage AppLanguage { get; set; }

    public static AppLanguage GetValidAppLanguage(CultureInfo? culture)
    {
        culture ??= CultureInfo.CurrentUICulture ?? CultureInfo.CurrentCulture;
        var code = culture.TwoLetterISOLanguageName?.ToLowerInvariant();

        if (System.Enum.TryParse<AppLanguage>(code, true, out var language) && System.Enum.IsDefined(language))
        {
            return language;
        }
        else
        {
            return AppLanguage.en;
        }
    }

    #endregion AppLanguage

    #region DarkMode

    [Custom(Name = "DarkMode", ResourceType = typeof(GlobalTranslations))]
    public static bool DarkMode { get; private set; }

    public static Action<bool>? DarkModeChanged { get; set; }

    public static void ChangeDarkMode(bool darkMode)
    {
        DarkMode = darkMode;
        DarkModeChanged?.Invoke(darkMode);
    }

    #endregion DarkMode

    public static Action<TempAuthPaddle>? RegistrationSuccessful { get; set; }
    public static Action<string>? ShowError { get; set; }
    public static Action? ProcessingStarted { get; set; }
    public static Action? ProcessingFinished { get; set; }
}