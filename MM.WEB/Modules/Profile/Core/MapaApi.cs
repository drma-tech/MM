﻿using System.Globalization;

namespace MM.WEB.Modules.Profile.Core
{
    public class MapApi(IHttpClientFactory http) : ApiCosmos<HereJson>(http, null)
    {
        public struct MapEndpoint
        {
            public static string GetLocationHere(double Latitude, double Longitude) => $"location/here/{Latitude.ToString(CultureInfo.InvariantCulture)}/{Longitude.ToString(CultureInfo.InvariantCulture)}";

            public static string GetLocationGoogle(double Latitude, double Longitude) => $"location/google/{Latitude.ToString(CultureInfo.InvariantCulture)}/{Longitude.ToString(CultureInfo.InvariantCulture)}";
        }

        public async Task<HereJson?> GetLocationHere(double Latitude, double Longitude)
        {
            return await GetAsync(MapEndpoint.GetLocationHere(Latitude, Longitude), null);
        }

        public async Task<GoogleJson?> GetLocationGoogle(double Latitude, double Longitude)
        {
            return await GetAsync<GoogleJson>(MapEndpoint.GetLocationGoogle(Latitude, Longitude));
        }
    }
}