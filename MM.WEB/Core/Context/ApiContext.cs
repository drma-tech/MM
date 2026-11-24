using MM.Common.Models.Auth;
using MM.Common.Models.Dashboard;
using MM.Common.Models.Profile;
using MM.Common.Models.Subscription;
using MM.Common.Requests;
using System.Text.Json.Serialization;

namespace MM.WEB.Core.Context
{
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
    [JsonSerializable(typeof(SumUsersCache))]
    [JsonSerializable(typeof(LastUsersCache))]
    [JsonSerializable(typeof(LastRegionUsersCache))]
    [JsonSerializable(typeof(ProfileManage))]
    internal sealed partial class ApiContext : JsonSerializerContext
    {
    }
}