namespace MM.Shared.Core.Helper
{
    public static class ProfileHelper
    {
        public static int GetAge(this DateTime date)
        {
            int years = DateTime.UtcNow.Year - date.Year;
            if (date.Month > DateTime.UtcNow.Month || date.Month == DateTime.UtcNow.Month && date.Day > DateTime.UtcNow.Day)
                years--;

            return years;
        }

        public static int GetDaysPassed(this DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.ToLocalTime().Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 24 * HOUR)
                return 0;

            if (delta < 48 * HOUR)
                return 1;

            return ts.Days;
        }

        public enum DistanceType
        {
            Km = 1,
            Mile = 2
        }

        /// <summary>
        /// must be in meters
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDistanceExtension(this double distance, DistanceType type)
        {
            if (distance < 0.5) distance = 0.5;

            return type switch
            {
                DistanceType.Km => $"{distance} km",
                DistanceType.Mile => $"{distance} mile",
                _ => $"null",
            };
        }

        private static double ToRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return angleIn10thofaDegree * Math.PI / 180;
        }

        public static double GetDistance(double lat1, double lat2, double lon1, double lon2, DistanceType type)
        {
            // The math module contains a function named toRadians which converts from degrees to radians.
            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            double RadiusKm = 6371;
            double RadiusMile = 3956;

            return type switch
            {
                DistanceType.Km => c * RadiusKm,
                DistanceType.Mile => c * RadiusMile,
                _ => 0,
            };
        }
    }
}