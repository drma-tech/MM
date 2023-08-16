using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MM.Shared.Models;

namespace VerusDate.Api.Function
{
    public class ExternalFunction
    {
        public string HereApiKey { get; set; }

        public ExternalFunction(IConfiguration config)
        {
            HereApiKey = config.GetValue<string>("Here_ApiKey");
        }

        [Function("ExternalGetLocation")]
        public async Task<HereJson?> GetLocation(
           [HttpTrigger(AuthorizationLevel.Function, Method.GET, Route = "External/GetLocation/{latitude}/{longitude}")] HttpRequestData req,
           string latitude, string longitude, CancellationToken cancellationToken)
        {
            try
            {
                using var http = new HttpClient();
                return await http.Get<HereJson>($"https://browse.search.hereapi.com/v1/browse?at={latitude},{longitude}&lang=en-US&limit=1&apiKey={HereApiKey}", cancellationToken);
            }
            catch (Exception ex)
            {
                req.ProcessException(ex);
                throw new UnhandledException(ex.BuildException());
            }
        }
    }
}