using System.Text.RegularExpressions;

namespace MM.Shared.Models.Safety
{
    public class SafetyModel : CosmosDocument
    {
        /// <summary>
        /// gallery validation photo
        /// </summary>
        public string? GalleryPhotoId { get; set; }

        /// <summary>
        /// account email
        /// </summary>
        public string? email { get; set; }

        /// <summary>
        /// IP address used during ID verification.
        /// </summary>
        public string? ip_address { get; set; }

        public string? provider { get; set; }
        public string? session_id { get; set; }
        public string? workflow_id { get; set; }

        public string? hash { get; set; }

        /// <summary>
        /// generates a hash based on user information
        /// </summary>
        /// <param name="countryCode">3 digits</param>
        /// <param name="birthDate">year-month-day</param>
        /// <param name="fullName">with spaces</param>
        public void ComposeHash(string? countryCode, string? birthDate, string? fullName)
        {
            ArgumentNullException.ThrowIfNull(countryCode);
            ArgumentNullException.ThrowIfNull(birthDate);
            ArgumentNullException.ThrowIfNull(fullName);

            countryCode = countryCode.Trim().ToUpperInvariant();
            if (countryCode.Length != 3) throw new NotificationException("Invalid country code length");

            var normalizedName = fullName
                .NormalizeToNfc()!
                .RemoveDiacritics()
                .ToLowerInvariant();

            normalizedName = Regex.Replace(normalizedName, @"\s+", " ", RegexOptions.NonBacktracking);

            hash = $"{countryCode}|{birthDate.Trim()}|{normalizedName}".ToHash();
        }
    }
}