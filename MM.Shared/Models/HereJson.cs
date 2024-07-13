namespace MM.Shared.Models
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Accuracy { get; set; }
    }

    /// <summary>
    /// note: language is the same as the searched location
    /// </summary>
    public class HereAddress
    {
        public string? countryCode { get; set; }
        public string? countryName { get; set; }
        public string? state { get; set; }
        public string? county { get; set; }
        public string? city { get; set; }

        public string GetLocation()
        {
            if (countryName.Empty()) throw new NotificationException("country not found");
            if (city.Empty()) throw new NotificationException("city not found");

            return $"{countryName} - {state ?? county ?? countryName} - {city}";
        }
    }

    public class HereRoot
    {
        public HereAddress? address { get; set; }
    }

    public class HereJson
    {
        public List<HereRoot> items { get; set; } = [];
    }
}