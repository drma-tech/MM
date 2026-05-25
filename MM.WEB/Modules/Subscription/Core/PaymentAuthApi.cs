using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Subscription.Core
{
    public class PaymentPublicApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Anonymous, null, ApiContext.Default.AuthPurchase)
    {
        public async Task<bool> StripeValidateSession(string id, CancellationToken cancellationToken)
        {
            return await GetAsync<bool>(Endpoint.StripeValidateSession(id), true, cancellationToken);
        }

        private struct Endpoint
        {
            public static string StripeValidateSession(string id) => $"public/stripe/validate-session/{id}";
        }
    }

    public class PaymentAuthApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Authenticated, null, ApiContext.Default.AuthPurchase)
    {
        public async Task AppleVerify(string receipt, CancellationToken cancellationToken)
        {
            await PostAsync(Endpoint.AppleVerify, receipt, ApiContext.Default.String, cancellationToken);
        }

        public async Task<AuthPrincipal?> StripeCustomer(bool isUserAuthenticated, CancellationToken cancellationToken)
        {
            if (!isUserAuthenticated) return null;

            return await GetAsync<AuthPrincipal>(Endpoint.StripeCustomer, true, cancellationToken);
        }

        private struct Endpoint
        {
            public const string AppleVerify = "apple/verify";
            public const string StripeCustomer = "stripe/customer";
        }
    }
}