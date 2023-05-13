using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MM.API.Repository.Core;
using Polly;
using Polly.Extensions.Http;
using System.Net;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("appsettings.json", true, true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
    })
    .ConfigureFunctionsWorkerDefaults(app =>
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    })
    .ConfigureServices(ConfigureServices)
    .ConfigureLogging(ConfigureLogging)
    .Build();

host.Run();

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddHttpClient("RetryHttpClient")
        .AddPolicyHandler(request => request.Method == HttpMethod.Get ? GetRetryPolicy() : Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>());

    services.AddSingleton<IRepository>((s) =>
    {
        return new CosmosRepository(context.Configuration);
    });

    services.AddSingleton<CosmosCacheRepository>();
}

static void ConfigureLogging(HostBuilderContext context, ILoggingBuilder builder)
{
    builder.AddProvider(new CosmosLoggerProvider(new CosmosLogRepository(context.Configuration)));
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