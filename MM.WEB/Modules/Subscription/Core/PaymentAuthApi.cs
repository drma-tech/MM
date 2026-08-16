using MM.Shared.Models.Auth;

namespace MM.WEB.Modules.Subscription.Core
{
    public class PaymentPublicApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Anonymous, key: null, [], ApiContext.Default.AuthPurchase)
    {
        public async Task<bool> StripeValidateSession(string id, CancellationToken cancellationToken)
        {
            return await GetBoolAsync(Endpoint.StripeValidateSession(id), cancellationToken);
        }

        private struct Endpoint
        {
            public static string StripeValidateSession(string id) => $"public/stripe/validate-session/{id}";
        }
    }

    public class PaymentAuthApi(IHttpClientFactory factory) : ApiCosmos<AuthPurchase>(factory, ApiType.Authenticated, key: null, [], ApiContext.Default.AuthPurchase)
    {
        public async Task AppleVerify(string receipt, CancellationToken cancellationToken)
        {
            await PostAsync(Endpoint.AppleVerify, receipt, ApiContext.Default.String, state: null, cancellationToken);
        }

        public async Task<AuthPrincipal?> StripeCustomer(CancellationToken cancellationToken)
        {
            return await GetAsync<AuthPrincipal>(Endpoint.StripeCustomer, setNewVersion: true, state: null, cancellationToken);
        }

        private struct Endpoint
        {
            public const string AppleVerify = "apple/verify";
            public const string StripeCustomer = "stripe/customer";
        }
    }
}