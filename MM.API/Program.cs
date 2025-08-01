using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MM.API.Core.Middleware;

var app = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.UseMiddleware<ExceptionHandlingMiddleware>();
    })
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        if (hostContext.HostingEnvironment.IsDevelopment())
        {
            config.AddJsonFile("local.settings.json");
            config.AddUserSecrets<Program>();
        }

        var cfg = new Configurations();
        config.Build().Bind(cfg);
        ApiStartup.Configurations = cfg;

        ApiStartup.Startup(ApiStartup.Configurations.CosmosDB?.ConnectionString);
    })
    .ConfigureLogging(ConfigureLogging)
    .ConfigureServices(ConfigureServices)
    .Build();

await app.RunAsync();

return;

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddHttpClient("paddle");

    services.AddSingleton<CosmosRepository>();
    services.AddSingleton<CosmosCacheRepository>();
    services.AddSingleton<CosmosProfileOffRepository>();
    services.AddSingleton<CosmosProfileOnRepository>();
    services.AddSingleton<StorageHelper>();
    services.AddApplicationInsightsTelemetryWorkerService();
    services.ConfigureFunctionsApplicationInsights();
    services.AddDistributedMemoryCache();
}

static void ConfigureLogging(ILoggingBuilder builder)
{
    builder.AddProvider(new CosmosLoggerProvider(new CosmosLogRepository()));
}
