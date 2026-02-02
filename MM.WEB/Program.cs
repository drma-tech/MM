using KristofferStrube.Blazor.MediaCaptureStreams;
using KristofferStrube.Blazor.WebIDL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MM.WEB;
using MM.WEB.Api;
using MM.WEB.Core.Auth;
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

builder.Services.AddSingleton<ILoggerProvider, CosmosLoggerProvider>();

var app = builder.Build();

await app.Services.SetupErrorHandlingJSInterop();

var js = app.Services.GetRequiredService<IJSRuntime>();

await ConfigureCulture(app, js);

AppStateStatic.Version = await AppStateStatic.GetAppVersion(js);

await js.Utils().SetStorage("app-version", AppStateStatic.Version);
await AppStateStatic.GetPlatform(js);
await js.Services().InitGoogleAnalytics(AppStateStatic.Version);
await js.Services().InitUserBack(AppStateStatic.Version);

await app.RunAsync();

static void ConfigureServices(IServiceCollection collection, string baseAddress, IConfiguration configuration)
{
    collection.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PreventDuplicates = false;
        config.SnackbarConfiguration.VisibleStateDuration = 10000;
    });

    collection.AddPWAUpdater();
    collection.AddMediaDevicesService();

    collection.AddHttpClient("Local", c => { c.BaseAddress = new Uri(baseAddress); });

    var apiOrigin = configuration["DownstreamApi:BaseUrl"] ??
        (baseAddress.Contains("localhost") || baseAddress.Contains("127.0.0.1") ? throw new UnhandledException($"DownstreamApi:BaseUrl is null.") : $"{baseAddress}api/");

    collection.AddHttpClient("Anonymous", (service, options) => { options.BaseAddress = new Uri(apiOrigin); options.Timeout = TimeSpan.FromSeconds(60); })
       .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddScoped<AuthenticationStateProvider, FirebaseAuthStateProvider>();
    collection.AddScoped<CustomAuthorizationHandler>();
    collection.AddHttpClient("Authenticated", (service, options) => { options.BaseAddress = new Uri(apiOrigin); options.Timeout = TimeSpan.FromSeconds(60); })
        .AddHttpMessageHandler<CustomAuthorizationHandler>()
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddHttpClient("External", (service, options) => { options.Timeout = TimeSpan.FromSeconds(60); })
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddAuthorizationCore();

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

    collection.AddScoped<PaymentConfigurationApi>();
    collection.AddScoped<PaymentAuthApi>();
    collection.AddScoped<IpInfoApi>();
    collection.AddScoped<IpInfoServerApi>();
    collection.AddScoped<LoggerApi>();
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
        .WaitAndRetryAsync([TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(4)]);
}
