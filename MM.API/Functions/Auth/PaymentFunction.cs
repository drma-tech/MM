using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Core.Types;
using MM.Shared.Models.Auth;
using Stripe.Checkout;
using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MM.API.Functions.Auth;

public class PaymentFunction(CosmosMainRepository repo, IHttpClientFactory factory)
{
    private const string APP_CODE = "mm";
    private const string APP = "app";
    private const string USERID = "userId";

    [Function("PostAppleVerify")]
    public async Task PostAppleVerify(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "apple/verify")] HttpRequestData req, CancellationToken cancellationToken)
    {
        AuthPrincipal? client = null;
        try
        {
            var userId = await req.GetUserIdAsync();
            var ip = req.GetUserIP(includePort: true);

            client = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("principal null");

            var raw = await req.ReadAsStringAsync();
            var receipt = JsonSerializer.Deserialize<string>(raw ?? throw new UnhandledException("body not present"));

            var bundleId = ApiStartup.Configurations.Apple?.BundleId;

            var result = await VerifyReceipt(ApiStartup.Configurations.Apple?.Endpoint, receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            if (result.status == 21007)
            {
                //when tested with TestFlight
                result = await VerifyReceipt("https://sandbox.itunes.apple.com/", receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            }

            if (result.status != 0) throw new UnhandledException(string.Create(CultureInfo.InvariantCulture, $"invalid status: {result.status}"));
            if (!string.Equals(result.receipt!.bundle_id, bundleId, StringComparison.OrdinalIgnoreCase)) throw new UnhandledException("invalid receipt");

            var purchase = result.latest_receipt_info[^1];

            var sub = new AuthPurchase
            {
                Provider = PaymentProvider.Apple,
                Product = AccountProduct.Phase1,
                SessionId = receipt, //save receipt before cause it may fail
                PurchaseId = purchase.original_transaction_id,
            };

            client.AddPurchase(sub);

            //https://developer.apple.com/documentation/appstorereceipts/status
            client.Events.Add(new Event("Apple", string.Create(CultureInfo.InvariantCulture, $"Subscription created with status = {result.status} and id = {purchase.original_transaction_id}"), ip));
        }
        finally
        {
            if (client != null) await repo.UpsertItemAsync(client);
        }
    }

    private async Task<AppleResponseReceipt?> VerifyReceipt(string? endpoint, string? receipt, CancellationToken cancellationToken)
    {
        var http = factory.CreateClient("apple");
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{endpoint}verifyReceipt");
        request.Content = new StringContent($$"""{"receipt-data":"{{receipt}}","password":"{{ApiStartup.Configurations.Apple?.SharedSecret}}","exclude-old-transactions":true}""", Encoding.UTF8, "application/json");
        var response = await http.SendAsync(request, cancellationToken);
        return await response.Content.ReadFromJsonAsync<AppleResponseReceipt>(cancellationToken);
    }

    [Function("StripeCreateCustomer")]
    public async Task<AuthPrincipal> StripeCreateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "stripe/customer")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();
        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("principal null");

        var customer = await new Stripe.CustomerService().CreateAsync(new Stripe.CustomerCreateOptions
        {
            Name = principal.DisplayName,
            Email = principal.Email,
            Metadata = new Dictionary<string, string>(StringComparer.Ordinal) {
                { APP, APP_CODE },
                { USERID, principal.UserId! },
            },
        }, cancellationToken: cancellationToken);

        principal.StripeCustomerId = customer.Id;

        var ip = req.GetUserIP(includePort: true);
        principal.Events.Add(new Event("Stripe", $"User registered with id:{customer.Id}", ip));

        return await repo.UpsertItemAsync(principal);
    }

    [Function("CreateCheckoutSession")]
    public async Task<string> CreateCheckoutSession(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "stripe/create-checkout-session/{priceId}/{qtd}")] HttpRequestData req, string priceId, int qtd, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync();
        var ip = req.GetUserIP(includePort: true);
        var url = req.GetQueryParameters()["url"];

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new UnhandledException("principal null");

        if (principal.StripeCustomerId.Empty()) throw new UnhandledException("Stripe customer not available");

        var options = new SessionCreateOptions
        {
            Customer = principal.StripeCustomerId,

            LineItems = [new() { Price = priceId, Quantity = qtd, },],
            Mode = "payment",
            SuccessUrl = url + "?stripe_session_id={CHECKOUT_SESSION_ID}",
            Metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                { APP, APP_CODE },
                { USERID, principal.UserId! },
                { "Quantity", qtd.ToString(CultureInfo.InvariantCulture) },
            },
            SubscriptionData = new SessionSubscriptionDataOptions
            {
                Metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                    { APP, APP_CODE },
                    { USERID, principal.UserId! },
                },
            },
        };

        options.AddExtraParam("managed_payments[enabled]", value: true);

        var service = new SessionService();
        Session session = await service.CreateAsync(options, cancellationToken: cancellationToken);

        var purchase = new AuthPurchase()
        {
            PurchaseId = session.Id,
            Provider = PaymentProvider.Stripe,
            Product = AccountProduct.Phase1,
            SessionId = session.Id,
        };

        principal.AddPurchase(purchase);

        principal.Events.Add(new Event("Stripe", $"Session created with SessionId = {session.Id}", ip));

        await repo.UpsertItemAsync(principal);

        return session.Url;
    }
}
