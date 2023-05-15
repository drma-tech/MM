using AzureStaticWebApps.Blazor.Authentication;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MM.WEB;
using MM.WEB.Modules.Auth.Core;
using MM.WEB.Modules.Profile.Core;
using MM.WEB.Modules.Support.Core;
using Polly;
using Polly.Extensions.Http;
using System.Globalization;
using System.Net;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using VerusDate.Web.Api;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

if (!builder.RootComponents.Any())
{
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");
}

var host = builder.Build();

ConfigureCulture(host);

await host.RunAsync();

static void ConfigureServices(IServiceCollection collection, string baseAddress)
{
    collection
        .AddBlazorise(options => options.Immediate = true)
        .AddBootstrapProviders()
        .AddFontAwesomeIcons();

    collection.AddPWAUpdater();
    collection.AddMediaQueryService();
    collection.AddMemoryCache();

    collection.AddHttpClient("RetryHttpClient", c => { c.BaseAddress = new Uri(baseAddress); })
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    collection.AddStaticWebAppsAuthentication();

    collection.AddScoped<PrincipalApi>();
    collection.AddScoped<LoginApi>();
    collection.AddScoped<ProfileApi>();
    collection.AddScoped<TicketApi>();
    collection.AddScoped<TicketVoteApi>();
    collection.AddScoped<AnnouncementApi>();
    collection.AddScoped<InviteApi>();
    collection.AddScoped<MapApi>();

    collection.AddScoped<CacheApi>();

    collection.AddScoped<AppState>();

    collection.AddResizeListener();

    collection.AddLogging(logging =>
    {
        logging.AddProvider(new CosmosLoggerProvider());
    });
}

static void ConfigureCulture(WebAssemblyHost? host)
{
    if (host != null)
    {
        var nav = host.Services.GetService<NavigationManager>();
        var language = nav?.QueryString("language");

        if (!string.IsNullOrEmpty(language))
        {
            CultureInfo cultureInfo;

            try
            {
                cultureInfo = new CultureInfo(language);
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
        .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound) // 404
        .OrResult(msg => msg.StatusCode == HttpStatusCode.Unauthorized) // 401
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))); // Retry 3 times, with wait 1, 2 and 4 seconds.
}