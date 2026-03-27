using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Subscription.Core
{
    public class PaymentAuthApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Authenticated, null)
    {
        public async Task AppleVerify(string receipt)
        {
            await PostAsync(Endpoint.AppleVerify, receipt);
        }

        public async Task<AuthPrincipal?> StripeCustomer(bool isUserAuthenticated)
        {
            if (!isUserAuthenticated) return null;

            return await GetAsync<AuthPrincipal>(Endpoint.StripeCustomer);
        }

        private struct Endpoint
        {
            public const string AppleVerify = "apple/verify";
            public const string StripeCustomer = "stripe/customer";
        }
    }
}