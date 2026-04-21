using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using MM.API.Core.Auth;

namespace MM.API.Functions;

public class ExternalFunction(IHttpClientFactory factory, IConfiguration config)
{
    [Function("External")]
    public async Task<HttpResponseData> External(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/external")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var url = req.GetQueryParameters()["url"]?.ConvertFromBase64ToString() ?? throw new UnhandledException("url null");

        var client = factory.CreateClient();

        using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await req.CreateResponse(stream, TtlCache.OneDay, cancellationToken);
    }

    [Function("Country")]
    public async Task<string?> Country([HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/country")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var ip = req.GetUserIP(false);
        if (ip.Empty()) return null;
        if (ip == "127.0.0.1") return null;

        var client = factory.CreateClient("ipinfo");

        return await client.GetStringAsync($"https://ipinfo.io/{ip}/country", cancellationToken);
    }

    public string? HereApiKey { get; set; } = config.GetValue<string>("Here:ApiKey");
    public string? GoogleApiKey { get; set; } = config.GetValue<string>("Google:ApiKey");

    [Function("GetLocationHere")]
    public async Task<HereJson?> GetLocationHere(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "location/here/{latitude}/{longitude}")]
        HttpRequestData req, string latitude, string longitude, CancellationToken cancellationToken)
    {
        using var http = new HttpClient();
        return await http.Get<HereJson>(
            $"https://browse.search.hereapi.com/v1/browse?at={latitude},{longitude}&lang=en-US&limit=1&apiKey={HereApiKey}",
            cancellationToken);
    }

    [Function("GetLocationGoogle")]
    public async Task<GoogleJson?> GetLocationGoogle(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "location/google/{latitude}/{longitude}")]
        HttpRequestData req, string latitude, string longitude, CancellationToken cancellationToken)
    {
        using var http = new HttpClient();
        return await http.Get<GoogleJson>($"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&language=en&key={GoogleApiKey}", cancellationToken);
    }
}