using System.Text.Json.Serialization;

namespace MM.WEB.Core.Context
{
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(bool?))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(Platform?))]
    [JsonSerializable(typeof(AppLanguage?))]
    [JsonSerializable(typeof(MM.Shared.Enums.Region?))]
    [JsonSerializable(typeof(AuthProvider))]
    [JsonSerializable(typeof(HashSet<DateTime>))]
    internal sealed partial class JavascriptContext : JsonSerializerContext
    {
    }
}