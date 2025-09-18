using Microsoft.JSInterop;
using MM.Shared.Models.Auth;
using MM.WEB.Modules.Subscription.Core;
using MudBlazor;
using System.Globalization;
using System.Security.Claims;

namespace MM.WEB.Core;

public static class AppStateStatic
{
    public static bool IsAuthenticated { get; set; }
    public static ClaimsPrincipal? User { get; set; }
    public static string? UserId { get; set; }

    public static Breakpoint Breakpoint { get; set; }
    public static Action<Breakpoint>? BreakpointChanged { get; set; }

    public static string? Version { get; set; }

    #region Platform

    private static Platform? _platform;

    public static async Task<Platform> GetPlatform(IJSRuntime? js = null)
    {
        if (_platform.HasValue)
        {
            return _platform.Value;
        }
        else
        {
            var cache = js != null ? await js.InvokeAsync<string>("GetLocalStorage", "platform") : null;

            if (cache.Empty() && js != null) //shouldn't happen (because it's called in index.html)
            {
                await js.InvokeVoidAsync("SetLocalStorage", "TryDetectPlatform");
                cache = await js.InvokeAsync<string>("GetLocalStorage", "platform");
            }

            if (cache.NotEmpty())
            {
                if (System.Enum.TryParse<Platform>(cache, true, out var platform) && System.Enum.IsDefined(platform))
                    _platform = platform;
                else
                    _platform = null;

                if (_platform == null)
                {
                    _platform = Platform.webapp;
                    if (js != null) await js.InvokeVoidAsync("SetLocalStorage", "platform", _platform.ToString());
                }
            }
            else
            {
                _platform = Platform.webapp;
            }

            return _platform.Value;
        }
    }

    #endregion Platform

    #region AppLanguage

    private static AppLanguage? _appLanguage;

    public static async Task<AppLanguage> GetAppLanguage(IJSRuntime? js = null)
    {
        if (_appLanguage.HasValue)
        {
            return _appLanguage.Value;
        }
        else
        {
            var cache = js != null ? await js.InvokeAsync<string>("GetLocalStorage", "app-language") : null;

            if (cache.NotEmpty())
            {
                _appLanguage = GetAppLanguage(cache);

                if (_appLanguage == null)
                {
                    _appLanguage = AppLanguage.en;
                    if (js != null) await js.InvokeVoidAsync("SetLocalStorage", "app-language", _appLanguage.ToString());
                }
            }
            else
            {
                var culture = CultureInfo.CurrentUICulture ?? CultureInfo.CurrentCulture;
                var code = culture.TwoLetterISOLanguageName?.ToLowerInvariant();

                _appLanguage = GetAppLanguage(code) ?? AppLanguage.en;
                if (js != null) await js.InvokeVoidAsync("SetLocalStorage", "app-language", _appLanguage.ToString());
            }

            return _appLanguage.Value;
        }
    }

    private static AppLanguage? GetAppLanguage(string? code)
    {
        if (System.Enum.TryParse<AppLanguage>(code, true, out var language) && System.Enum.IsDefined(language))
            return language;
        else
            return null;
    }

    #endregion AppLanguage

    #region DarkMode

    public static Action<bool>? DarkModeChanged { get; set; }

    private static bool? _darkMode;

    public static async Task<bool?> GetDarkMode(IJSRuntime? js = null)
    {
        if (_darkMode.HasValue)
        {
            return _darkMode.Value;
        }
        else
        {
            var cache = js != null ? await js.InvokeAsync<string>("GetLocalStorage", "dark-mode") : null;

            if (cache.NotEmpty())
            {
                if (bool.TryParse(cache, out var value))
                    _darkMode = value;

                if (_darkMode == null)
                {
                    _darkMode = false;
                    if (js != null) await js.InvokeVoidAsync("SetLocalStorage", "dark-mode", _darkMode.ToString()?.ToLower());
                }
            }

            return _darkMode;
        }
    }

    public static void ChangeDarkMode(bool darkMode)
    {
        _darkMode = darkMode;
        DarkModeChanged?.Invoke(darkMode);
    }

    #endregion DarkMode

    #region Region Country

    private static string? _country;

    public static async Task<string> GetCountry(IpInfoApi api, IJSRuntime? js = null)
    {
        if (_country.NotEmpty())
        {
            return _country;
        }
        else
        {
            var cache = js != null ? await js.InvokeAsync<string>("GetLocalStorage", "country") : null;

            if (cache.NotEmpty())
            {
                _country = cache.Trim();
            }
            else
            {
                _country = (await api.GetCountry())?.Trim();
                if (js != null) await js.InvokeAsync<string>("SetLocalStorage", "country", _country);
            }

            _country ??= "US";

            return _country;
        }
    }

    #endregion Region

    public static Action<TempAuthPaddle>? RegistrationSuccessful { get; set; }
    public static Action<string>? ShowError { get; set; }
    public static Action? ProcessingStarted { get; set; }
    public static Action? ProcessingFinished { get; set; }
}