using MM.Common.Models.Auth;
using MM.WEB.Api.Core;

namespace MM.WEB.Api.Modules.Cosmos.Authenticated
{
    public class PaymentAuthApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Authenticated, key: null, [], ApiContext.Default.AuthPurchase)
    {
        public async Task AppleVerify(string receipt, CancellationToken cancellationToken)
        {
            await PostAsync("apple/verify", receipt, ApiContext.Default.String, states: [], cancellationToken);
        }
    }
}