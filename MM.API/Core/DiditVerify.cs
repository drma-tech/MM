using System.Security.Cryptography;

namespace MM.API.Core
{
    public static class DiditVerify
    {
        public static bool VerifySignatureV2(string body, string? signature, string? timestamp, string? secret)
        {
            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp))
                return false;

            // Prevent replay attack (5 min window)
            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (!long.TryParse(timestamp, out var ts))
                return false;

            if (Math.Abs(now - ts) > 300)
                return false;

            // Build signed payload
            var payload = $"{timestamp}.{body}";

            using var hmac = new HMACSHA256(System.Text.Encoding.UTF8.GetBytes(secret));

            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payload));
            var expectedSignature = Convert.ToHexString(hash).ToLowerInvariant();

            // constant-time compare
            return CryptographicOperations.FixedTimeEquals(
                System.Text.Encoding.UTF8.GetBytes(expectedSignature),
                System.Text.Encoding.UTF8.GetBytes(signature)
            );
        }
    }
}