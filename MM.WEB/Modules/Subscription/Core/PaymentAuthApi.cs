using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Subscription.Core
{
    public class PaymentAuthApi(IHttpClientFactory factory) : ApiCosmos<AuthSubscription>(factory, ApiType.Authenticated, null)
    {
        public async Task AppleVerify(string receipt)
        {
            await PostAsync(Endpoint.AppleVerify, null, receipt);
        }

        private struct Endpoint
        {
            public const string AppleVerify = "apple/verify";
        }
    }
}