using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stripe;

var app = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.UseMiddleware<ApiMiddleware>();
    })
    .ConfigureLogging((context, logging) =>
    {
        logging.AddSentry(options =>
        {
            options.Dsn = "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712";
            options.DiagnosticLevel = SentryLevel.Warning;
            options.Release = $"mm-api@{DateTime.Now:yyyy.MM.dd}";
            options.Environment = context.HostingEnvironment.EnvironmentName;

            options.TracePropagationTargets = []; //Disable tracing because it breaks communication with external APIs.
        });
    })
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        try
        {
            if (hostContext.HostingEnvironment.IsDevelopment())
            {
                config.AddJsonFile("local.settings.json");
                config.AddUserSecrets<Program>();
            }

            var cfg = new Configurations();
            config.Build().Bind(cfg);
            ApiStartup.Configurations = cfg;

            StripeConfiguration.ApiKey = ApiStartup.Configurations.Stripe?.ApiKey;
            StripeConfiguration.AddBetaVersion("managed_payments_preview", "v1");
        }
        catch (Exception ex)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSentry(options =>
                {
                    options.Dsn = "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712";
                    options.DiagnosticLevel = SentryLevel.Warning;
                });
            });

            var logger = loggerFactory.CreateLogger("StartupConfig");

            logger.LogError(ex, "ConfigureAppConfiguration");

            throw;
        }
    })
    .ConfigureServices(ConfigureServices)
    .Build();

await app.RunAsync();

static void ConfigureServices(IServiceCollection services)
{
    try
    {
        //http clients

        services.AddHttpClient("paddle");
        services.AddHttpClient("apple");
        services.AddHttpClient("auth", client => { client.Timeout = TimeSpan.FromSeconds(60); });
        services.AddHttpClient("ipinfo");

        //repositories

        services.AddSingleton(provider =>
        {
            return new CosmosClient(ApiStartup.Configurations.CosmosDB?.ConnectionString, new CosmosClientOptions
            {
                ConnectionMode = ConnectionMode.Gateway,
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                }
            });
        });

        services.AddSingleton<CosmosRepository>();
        services.AddSingleton<CosmosCacheRepository>();
        services.AddSingleton<CosmosSafetyRepository>();
        services.AddSingleton<CosmosProfileOffRepository>();
        services.AddSingleton<CosmosProfileOnRepository>();
        services.AddSingleton<StorageHelper>();

        //general services

        services.AddDistributedMemoryCache();
    }
    catch (Exception ex)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSentry(options =>
            {
                options.Dsn = "https://ed1ba47e2afd2ee2d3425e67475ac829@o4510938040041472.ingest.us.sentry.io/4510942977523712";
                options.DiagnosticLevel = SentryLevel.Warning;
            });
        });

        var logger = loggerFactory.CreateLogger("StartupConfig");

        logger.LogError(ex, "ConfigureAppConfiguration");

        throw;
    }
}
