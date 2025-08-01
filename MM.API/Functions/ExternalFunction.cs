using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;

namespace MM.API.Functions;

public class ExternalFunction(IConfiguration config)
{
    public string? HereApiKey { get; set; } = config.GetValue<string>("Here:ApiKey");
    public string? GoogleApiKey { get; set; } = config.GetValue<string>("Google:ApiKey");

    [Function("GetLocationHere")]
    public async Task<HereJson?> GetLocationHere(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "location/here/{latitude}/{longitude}")]
        HttpRequestData req,
        string latitude, string longitude, CancellationToken cancellationToken)
    {
        try
        {
            using var http = new HttpClient();
            return await http.Get<HereJson>(
                $"https://browse.search.hereapi.com/v1/browse?at={latitude},{longitude}&lang=en-US&limit=1&apiKey={HereApiKey}",
                cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }

    [Function("GetLocationGoogle")]
    public async Task<GoogleJson?> GetLocationGoogle(
        [HttpTrigger(AuthorizationLevel.Function, Method.Get, Route = "location/google/{latitude}/{longitude}")]
        HttpRequestData req,
        string latitude, string longitude, CancellationToken cancellationToken)
    {
        try
        {
            using var http = new HttpClient();
            return await http.Get<GoogleJson>(
                $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&language=en&key={GoogleApiKey}",
                cancellationToken);
        }
        catch (Exception ex)
        {
            req.ProcessException(ex);
            throw;
        }
    }
}