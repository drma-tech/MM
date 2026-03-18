using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace MM.API.Core
{
    public static class DiditVerify
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = false };

        public static bool VerifySignatureV2(JsonElement requestJson, string? signature, string? timestamp, string? secret)
        {
            if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp)) { return false; }

            // Normalize signature casing
            signature = signature.ToLowerInvariant();

            // Replay protection (5 min)
            if (!long.TryParse(timestamp, out var ts))
                return false;

            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            if (ts > now + 60) return false; // futuro inválido
            if (now - ts > 300) return false; // expirado

            // Convert JSON back to canonical form:
            // sort_keys, no indent, unescaped Unicode
            string canonicalJson = JsonSerializer.Serialize(ShortenFloats(requestJson), JsonSerializerOptions);

            // Compute HMAC‑SHA256 of canonical JSON
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret!));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(canonicalJson));

            var expectedBytes = hash;
            var receivedBytes = Convert.FromHexString(signature);

            return CryptographicOperations.FixedTimeEquals(expectedBytes, receivedBytes);
        }

        // Match shortening behavior from the official Node.js/Python examples
        private static object? ShortenFloats(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    var sorted = new SortedDictionary<string, object?>();
                    foreach (var prop in element.EnumerateObject())
                    {
                        sorted[prop.Name] = ShortenFloats(prop.Value);
                    }
                    return sorted;

                case JsonValueKind.Array:
                    var list = new List<object?>();
                    foreach (var item in element.EnumerateArray())
                        list.Add(ShortenFloats(item));
                    return list;

                case JsonValueKind.Number:
                    // Treat floats that are whole numbers as ints
                    if (element.TryGetInt64(out var intVal))
                        return intVal;
                    return element.GetDouble();

                case JsonValueKind.String:
                    return element.GetString();

                case JsonValueKind.True:
                case JsonValueKind.False:
                    return element.GetBoolean();

                case JsonValueKind.Null:
                    return null;

                default:
                    return null;
            }
        }
    }
}