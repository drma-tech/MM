using System.Text.Json.Serialization;

namespace MM.WEB.Core.Api
{
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(Platform?))]
    [JsonSerializable(typeof(AppLanguage?))]
    [JsonSerializable(typeof(Region?))]
    [JsonSerializable(typeof(bool?))]
    [JsonSerializable(typeof(string))]
    internal partial class JavascriptContext : JsonSerializerContext
    {
    }
}