using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Profile;
using MM.Shared.Models.Subscription;
using MM.Shared.Requests;
using System.Text.Json.Serialization;

namespace MM.WEB.Core.Api
{
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(bool?))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(Platform?))]
    [JsonSerializable(typeof(AppLanguage?))]
    [JsonSerializable(typeof(MM.Shared.Enums.Region?))]
    [JsonSerializable(typeof(AuthProvider))]
    [JsonSerializable(typeof(HashSet<DateTime>))]
    internal partial class JavascriptContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(PaymentConfigurations))]
    [JsonSerializable(typeof(AuthPrincipal))]
    [JsonSerializable(typeof(AuthPurchase))]
    [JsonSerializable(typeof(AuthLogin))]
    [JsonSerializable(typeof(ProfileModel))]
    [JsonSerializable(typeof(FilterModel))]
    [JsonSerializable(typeof(FilterModel))]
    [JsonSerializable(typeof(InteractionModel))]
    [JsonSerializable(typeof(HereJson))]
    [JsonSerializable(typeof(SettingModel))]
    [JsonSerializable(typeof(ValidationModel))]
    [JsonSerializable(typeof(MyLikesModel))]
    [JsonSerializable(typeof(MyMatchesModel))]
    [JsonSerializable(typeof(PhotoRequest))]
    [JsonSerializable(typeof(PhotoValidationRequest))]
    [JsonSerializable(typeof(CacheDocument<SumUsers>))]
    [JsonSerializable(typeof(CacheDocument<LastUsers>))]
    internal partial class ApiContext : JsonSerializerContext
    {
    }
}