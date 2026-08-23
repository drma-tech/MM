using System.Globalization;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Module.Cosmos.Authenticated;

public class MapApi(IHttpClientFactory http) : ApiCosmos<HereJson>(http, ApiType.Anonymous, null, [], ApiContext.Default.HereJson)
{
    public async Task<HereJson?> GetLocationHere(double Latitude, double Longitude, CancellationToken cancellationToken)
    {
        return await GetAsync($"location/here?latitude={Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={Longitude.ToString(CultureInfo.InvariantCulture)}", setNewVersion: false, states: [], cancellationToken);
    }

    //public async Task<GoogleJson?> GetLocationGoogle(double Latitude, double Longitude, CancellationToken cancellationToken)
    //{
    //    return await GetAsync<GoogleJson>($"location/google/{Latitude.ToString(CultureInfo.InvariantCulture)}/{Longitude.ToString(CultureInfo.InvariantCulture)}", setNewVersion: false, states: [], cancellationToken);
    //}
}