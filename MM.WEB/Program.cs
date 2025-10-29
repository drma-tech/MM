using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Authentication.WebAssembly.Msal.Models;
using Microsoft.JSInterop;
using MM.WEB;
using MM.WEB.Api;
using MM.WEB.Modules.Auth.Core;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Modules.Subscription.Core;
using MudBlazor;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

if (builder.RootComponents.Empty())
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress, builder.Configuration);

var app = builder.Build();

var js = app.Services.GetRequiredService<IJSRuntime>();

await ConfigureCulture(app, js);

var version = MM.WEB.Layout.MainLayout.GetAppVersion();
await js.InvokeVoidAsync("initGoogleAnalytics", "G-P7B5BSBS9S", version);

await app.RunAsync();

static void ConfigureServices(IServiceCollection collection, string baseAddress, IConfiguration configuration)
{
    collection.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
        config.SnackbarConfiguration.PreventDuplicates = false;
    });

    collection.AddPWAUpdater();

    collection.AddHttpClient("Local", c => { c.BaseAddress = new Uri(baseAddress); });

    var apiOrigin = configuration["DownstreamApi:BaseUrl"] ?? $"{baseAddress}api/";

    collection.AddHttpClient("Anonymous", (service, options) => { options.BaseAddress = new Uri(apiOrigin); options.Timeout = TimeSpan.FromSeconds(180); })
       .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddScoped<CachedTokenProvider>();
    collection.AddScoped<CustomAuthorizationHandler>();
    collection.AddHttpClient("Authenticated", (service, options) => { options.BaseAddress = new Uri(apiOrigin); options.Timeout = TimeSpan.FromSeconds(180); })
        .AddHttpMessageHandler<CustomAuthorizationHandler>()
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddHttpClient("External", (service, options) => { options.Timeout = TimeSpan.FromSeconds(180); })
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddCascadingAuthenticationState();
    collection.AddOptions();
    collection.AddAuthorizationCore();

    if (OperatingSystem.IsBrowser())
    {
        collection.AddMsalAuthentication(options =>
        {
            options.ProviderOptions.LoginMode = "redirect";
            configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.Cache = new MsalCacheOptions { CacheLocation = "localStorage" };

            options.ProviderOptions.Authentication.PostLogoutRedirectUri = "/";

            options.ProviderOptions.DefaultAccessTokenScopes.Add("openid"); // Need to provide the scopes that are "by default" should be included with the underlying API call
            options.ProviderOptions.DefaultAccessTokenScopes.Add("email"); //give access to the email scope
            options.ProviderOptions.DefaultAccessTokenScopes.Add(configuration["DownstreamApi:Scopes"] ?? throw new UnhandledException("Scopes null"));
        });

        collection.AddScoped<AccountClaimsPrincipalFactory<RemoteUserAccount>, CustomUserFactory>(); //for some reason roles are not being recognized
    }

    collection.AddScoped<PrincipalApi>();
    collection.AddScoped<LoginApi>();
    collection.AddScoped<ProfileApi>();
    collection.AddScoped<FilterApi>();
    collection.AddScoped<SettingApi>();
    collection.AddScoped<MapApi>();
    collection.AddScoped<StorageApi>();
    collection.AddScoped<MyLikesApi>();
    collection.AddScoped<MyMatchesApi>();
    collection.AddScoped<InviteApi>();
    collection.AddScoped<InteractionApi>();
    collection.AddScoped<DashboardApi>();
    collection.AddScoped<ValidationApi>();

    collection.AddScoped<PaddleConfigurationApi>();
    collection.AddScoped<PaddleSubscriptionApi>();
    collection.AddScoped<IpInfoApi>();
    collection.AddScoped<IpInfoServerApi>();
}

static async Task ConfigureCulture(WebAssemblyHost? app, IJSRuntime js)
{
    if (app != null)
    {
        //app language

        var nav = app.Services.GetService<NavigationManager>();
        var appLanguage = nav?.QueryString("app-language");

        if (appLanguage.Empty())
        {
            appLanguage = (await AppStateStatic.GetAppLanguage(js)).ToString();
        }

        if (appLanguage.NotEmpty())
        {
            CultureInfo cultureInfo;

            try
            {
                cultureInfo = new CultureInfo(appLanguage);
            }
            catch (Exception)
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}

//https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError() // 408,5xx
        .WaitAndRetryAsync([TimeSpan.FromSeconds(1)]);
}
