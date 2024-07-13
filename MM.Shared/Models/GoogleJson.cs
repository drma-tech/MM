namespace MM.Shared.Models
{
    public class AddressComponent
    {
        public string? long_name { get; set; }
        public string? short_name { get; set; }
        public List<string> types { get; set; } = [];
    }

    public class Bounds
    {
        public Northeast? northeast { get; set; }
        public Southwest? southwest { get; set; }
    }

    public class Geometry
    {
        public Location? location { get; set; }
        public string? location_type { get; set; }
        public Viewport? viewport { get; set; }
        public Bounds? bounds { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class PlusCode
    {
        public string? compound_code { get; set; }
        public string? global_code { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; } = [];
        public string? formatted_address { get; set; }
        public Geometry? geometry { get; set; }
        public string? place_id { get; set; }
        public PlusCode? plus_code { get; set; }
        public List<string> types { get; set; } = [];

        public string GetLocation()
        {
            var country = address_components.Find(f => f.types.Contains("country"))?.long_name;
            var area_level_1 = address_components.Find(f => f.types.Contains("administrative_area_level_1"))?.long_name; //state or county
            var area_level_2 = address_components.Find(f => f.types.Contains("administrative_area_level_2"))?.long_name; //city

            if (area_level_2.Empty())
                return $"{country} - {area_level_1}";
            else
                return $"{country} - {area_level_1} - {area_level_2}";
        }
    }

    public class GoogleJson
    {
        public PlusCode? plus_code { get; set; }
        public List<Result> results { get; set; } = [];
        public string? status { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast? northeast { get; set; }
        public Southwest? southwest { get; set; }
    }
}