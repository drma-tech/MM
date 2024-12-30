using AzureStaticWebApps.Blazor.Authentication;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MM.WEB;
using MM.WEB.Api;
using MM.WEB.Modules.Administrator.Core;
using MM.WEB.Modules.Auth.Core;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Modules.Subscription.Core;
using MM.WEB.Modules.Support.Core;
using Polly;
using Polly.Extensions.Http;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

if (builder.RootComponents.Empty())
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

var app = builder.Build();

await ConfigureCulture(app);

await app.RunAsync();

static void ConfigureServices(IServiceCollection collection, string baseAddress)
{
    collection
        .AddBlazorise(options => options.Immediate = true)
        .AddBootstrap5Providers()
        .AddFontAwesomeIcons();

    collection.AddPWAUpdater();
    collection.AddMediaQueryService();

    collection.AddHttpClient("RetryHttpClient", c => { c.BaseAddress = new Uri(baseAddress); })
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddStaticWebAppsAuthentication();
    collection.AddCascadingAuthenticationState();
    collection.AddOptions();
    collection.AddAuthorizationCore();

    collection.AddScoped<AdministratorApi>();
    collection.AddScoped<PrincipalApi>();
    collection.AddScoped<GravatarApi>();
    collection.AddScoped<LoginApi>();
    collection.AddScoped<ProfileApi>();
    collection.AddScoped<FilterApi>();
    collection.AddScoped<SettingApi>();
    collection.AddScoped<TicketApi>();
    collection.AddScoped<UpdateApi>();
    collection.AddScoped<MapApi>();
    collection.AddScoped<StorageApi>();
    collection.AddScoped<MyLikesApi>();
    collection.AddScoped<InviteApi>();

    collection.AddScoped<PaddleConfigurationApi>();
    collection.AddScoped<PaddleSubscriptionApi>();

    collection.AddResizeListener();

    collection.AddLogging(logging =>
    {
        logging.AddProvider(new CosmosLoggerProvider());
    });
}

static async Task ConfigureCulture(WebAssemblyHost? app)
{
    if (app != null)
    {
        var nav = app.Services.GetService<NavigationManager>();
        var language = nav?.QueryString("language");

        if (language.Empty())
        {
            var JsRuntime = app.Services.GetRequiredService<IJSRuntime>();
            language = await JsRuntime.InvokeAsync<string>("GetLocalStorage", "language");
        }

        if (language.NotEmpty())
        {
            CultureInfo cultureInfo;

            try
            {
                cultureInfo = new CultureInfo(language!);
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
        .WaitAndRetryAsync([TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(6)]);
}