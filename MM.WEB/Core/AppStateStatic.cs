using Microsoft.JSInterop;
using MM.WEB.Modules.Subscription.Core;
using MudBlazor;
using MudBlazor.Services;
using System.Security.Claims;

namespace MM.WEB.Core;

public static class AppStateStatic
{
    public static string? Token { get; set; }
    public static bool IsAuthenticated { get; set; }
    public static bool IsPremiumUser { get; set; }
    public static ClaimsPrincipal? User { get; set; }
    public static string? UserId { get; set; }

    public static Breakpoint Breakpoint { get; set; } = Breakpoint.Xs;
    public static Action<Breakpoint>? BreakpointChanged { get; set; }
    public static Size Size { get; set; } = Size.Small;

    public static int Spacing => Breakpoint <= Breakpoint.Xs ? 2 : 3;
    public static int SpacingDouble => Breakpoint <= Breakpoint.Xs ? 4 : 6;
    public static int SpacingTriple => Breakpoint <= Breakpoint.Xs ? 6 : 9;

    public static string SpacingClass(string vl) => $"{vl}-{Spacing}";
    public static string SpacingDoubleClass(string vl) => $"{vl}-{SpacingDouble}";
    public static string SpacingTripleClass(string vl) => $"{vl}-{SpacingTriple}";

    public static BrowserWindowSize? BrowserWindowSize { get; set; }
    public static Action<BrowserWindowSize>? BrowserWindowSizeChanged { get; set; }

    public static string? Version { get; set; }

    public static async Task<string> GetAppVersion(IJSRuntime js)
    {
        try
        {
            var vs = await js.Utils().GetAppVersion();

            return vs?.ReplaceLineEndings("").Trim() ?? "version-error";
        }
        catch (Exception)
        {
            return "version-error";
        }
    }

    #region Platform

    private static Platform? _platform;
    private static readonly SemaphoreSlim _platformSemaphore = new(1, 1);

    public static Platform? GetSavedPlatform()
    {
        return _platform;
    }

    public static async Task<Platform> GetPlatform(IJSRuntime js)
    {
        await _platformSemaphore.WaitAsync();
        try
        {
            if (_platform.HasValue)
            {
                return _platform.Value;
            }

            var cache = await js.Utils().GetStorage<Platform?>("platform");

            if (cache.HasValue)
            {
                _platform = cache.Value;
            }
            else
            {
                _platform = Platform.webapp;
                await js.Utils().SetStorage("platform", _platform);
            }

            return _platform.Value;
        }
        finally
        {
            _platformSemaphore.Release();
        }
    }

    #endregion Platform

    #region AppLanguage

    private static AppLanguage? _appLanguage;
    private static readonly SemaphoreSlim _appLanguageSemaphore = new(1, 1);

    public static async Task<AppLanguage> GetAppLanguage(IJSRuntime js)
    {
        await _appLanguageSemaphore.WaitAsync();
        try
        {
            if (_appLanguage.HasValue)
            {
                return _appLanguage.Value;
            }

            var cache = await js.Utils().GetStorage<AppLanguage?>("app-language");

            if (cache.HasValue)
            {
                _appLanguage = cache.Value;
            }
            else
            {
                var code = await js.Window().InvokeAsync<string>("eval", "navigator.language || navigator.userLanguage");
                code = code[..2].ToLowerInvariant();

                _appLanguage = ConvertAppLanguage(code) ?? AppLanguage.en;
                await js.Utils().SetStorage("app-language", _appLanguage);
            }

            return _appLanguage.Value;
        }
        catch
        {
            return AppLanguage.en;
        }
        finally
        {
            _appLanguageSemaphore.Release();
        }
    }

    private static AppLanguage? ConvertAppLanguage(string? code)
    {
        if (code.Empty()) return null;

        if (System.Enum.TryParse<AppLanguage>(code, true, out var language) && System.Enum.IsDefined(language))
            return language;
        else
            return null;
    }

    #endregion AppLanguage

    #region DarkMode

    public static Action<bool>? DarkModeChanged { get; set; }

    private static bool? _darkMode;
    private static readonly SemaphoreSlim _darkModeSemaphore = new(1, 1);

    public static async Task<bool?> GetDarkMode(IJSRuntime js)
    {
        await _darkModeSemaphore.WaitAsync();
        try
        {
            if (_darkMode.HasValue)
            {
                return _darkMode.Value;
            }

            _darkMode = await js.Utils().GetStorage<bool?>("dark-mode");

            return _darkMode;
        }
        catch
        {
            return null;
        }
        finally
        {
            _darkModeSemaphore.Release();
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
    private static readonly SemaphoreSlim _countrySemaphore = new(1, 1);

    public static string? GetSavedCountry()
    {
        return _country;
    }

    public static async Task<string?> GetCountry(IpInfoApi api, IpInfoServerApi serverApi, IJSRuntime js)
    {
        await _countrySemaphore.WaitAsync();
        try
        {
            if (_country.NotEmpty())
            {
                return _country;
            }

            var cache = await js.Utils().GetStorage<string>("country");

            if (cache.NotEmpty())
            {
                _country = cache.Trim();
            }
            else
            {
                _country = (await api.GetCountry())?.Trim();

                if (_country.NotEmpty())
                    await js.Utils().SetStorage("country", _country);
                else
                    _country = await GetCountryFromApiServer(serverApi, js);
            }

            return _country;
        }
        catch
        {
            return await GetCountryFromApiServer(serverApi, js);
        }
        finally
        {
            _countrySemaphore.Release();
        }
    }

    private static async Task<string?> GetCountryFromApiServer(IpInfoServerApi serverApi, IJSRuntime js)
    {
        try
        {
            var country = (await serverApi.GetCountry())?.Trim();
            if (country.NotEmpty()) await js.Utils().SetStorage("country", country);

            return country;
        }
        catch
        {
            return null;
        }
    }

    #endregion Region Country

    public static Action<string?>? AuthChanged { get; set; }
    public static Action<GeoLocation>? LocationChanged { get; set; }
    public static Action<string, string>? NotificationEnabled { get; set; }
    public static Action? UserStateChanged { get; set; }
    public static Action? RegistrationSuccessful { get; set; }
    public static Action<string>? AppleVerify { get; set; }
    public static Action<string>? ShowError { get; set; }
    public static Action? ProcessingStarted { get; set; }
    public static Action? ProcessingFinished { get; set; }
}
