using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Subscription.Core
{
    public class PaymentPublicApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Anonymous, null)
    {
        public async Task<bool> StripeValidateSession(string id)
        {
            return await GetAsync<bool>(Endpoint.StripeValidateSession(id));
        }

        private struct Endpoint
        {
            public static string StripeValidateSession(string id) => $"public/stripe/validate-session/{id}";
        }
    }

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