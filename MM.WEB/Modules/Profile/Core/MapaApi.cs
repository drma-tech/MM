using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

namespace MM.WEB.Modules.Profile.Core
{
    public class MapApi(IHttpClientFactory http, IMemoryCache memoryCache) : ApiCosmos<HereJson>(http, memoryCache, "HereJson")
    {
        public struct MapEndpoint
        {
            public static string GetLocation(double Latitude, double Longitude) => $"External/GetLocation/{Latitude.ToString(CultureInfo.InvariantCulture)}/{Longitude.ToString(CultureInfo.InvariantCulture)}";
        }

        public async Task<HereJson?> GetLocation(double Latitude, double Longitude)
        {
            return await GetAsync(MapEndpoint.GetLocation(Latitude, Longitude), null);
        }
    }
}