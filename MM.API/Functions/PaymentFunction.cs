using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Subscription;
using Stripe.Checkout;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MM.API.Functions;

public class PaymentFunction(CosmosRepository repo, IHttpClientFactory factory)
{
    private const string APP = "mm";

    [Function("PaymentConfigurations")]
    public static PaymentConfigurations PaymentConfigurations(
       [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/payment/configurations")] HttpRequestData req)
    {
        var valid = Enum.TryParse(req.GetQueryParameters()["provider"], out PaymentProvider provider);
        if (!valid) throw new UnhandledException("invalid provider");

        if (provider == PaymentProvider.Apple)
        {
            return new PaymentConfigurations
            {
                PricePhase1 = ApiStartup.Configurations.Apple?.Phase1?.Price,
                PricePhase2 = ApiStartup.Configurations.Apple?.Phase2?.Price,
                PricePhase3 = ApiStartup.Configurations.Apple?.Phase3?.Price,
                PricePhase4 = ApiStartup.Configurations.Apple?.Phase4?.Price,
            };
        }
        else if (provider == PaymentProvider.Stripe)
        {
            return new PaymentConfigurations
            {
                PricePhase1 = ApiStartup.Configurations.Stripe?.Phase1?.Price,
                PricePhase2 = ApiStartup.Configurations.Stripe?.Phase2?.Price,
                PricePhase3 = ApiStartup.Configurations.Stripe?.Phase3?.Price,
                PricePhase4 = ApiStartup.Configurations.Stripe?.Phase4?.Price,
            };
        }
        else
        {
            throw new UnhandledException("provider not implemented");
        }
    }

    [Function("PostAppleVerify")]
    public async Task PostAppleVerify(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "apple/verify")] HttpRequestData req, CancellationToken cancellationToken)
    {
        AuthPrincipal? client = null;
        try
        {
            var userId = await req.GetUserIdAsync(cancellationToken);
            var ip = req.GetUserIP(true);

            client = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("principal null");

            var raw = await req.ReadAsStringAsync();
            var receipt = JsonSerializer.Deserialize<string>(raw ?? throw new UnhandledException("body not present"));

            var bundleId = ApiStartup.Configurations.Apple?.BundleId;

            var result = await VerifyReceipt(ApiStartup.Configurations.Apple?.Endpoint, receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            if (result.status == 21007)
            {
                //when tested with TestFlight
                result = await VerifyReceipt("https://sandbox.itunes.apple.com/", receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            }

            if (result.status != 0) throw new UnhandledException($"invalid status: {result.status}");
            if (result.receipt!.bundle_id != bundleId) throw new UnhandledException("invalid receipt");

            var purchase = result.latest_receipt_info[result.latest_receipt_info.Count - 1];

            var sub = new AuthPurchase
            {
                Provider = PaymentProvider.Apple,
                Product = AccountProduct.Phase1,
                SessionId = receipt, //save receipt before cause it may fail
                PurchaseId = purchase.original_transaction_id,
            };

            client.AddPurchase(sub);

            //https://developer.apple.com/documentation/appstorereceipts/status
            client.Events.Add(new Event("Apple", $"Subscription created with status = {result.status} and id = {purchase.original_transaction_id}", ip));
        }
        finally
        {
            if (client != null) await repo.UpsertItemAsync(client, cancellationToken);
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

    [Function("PostAppleWebhook")]
    public async Task PostAppleWebhook(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/apple/webhook")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var ip = req.GetUserIP(true);

        var body = await req.ReadFromJsonAsync<Dictionary<string, string>>(cancellationToken) ?? throw new UnhandledException("body null");

        if (!body.TryGetValue("signedPayload", out var signedPayload)) throw new UnhandledException("signedPayload null");

        var notification = AppleJwtDecoder.DecodeServerNotification(signedPayload, ApiStartup.Configurations.Apple!);

        var info = notification.Data;

        var transaction = AppleJwtDecoder.DecodeTransaction(info.SignedTransactionInfo);

        var originalTransactionId = transaction.OriginalTransactionId;

        var results = await repo.Query<AuthPrincipal>(x => x.AuthPurchases.Any(p => p.PurchaseId == originalTransactionId), DocumentType.Principal, cancellationToken);

        var client = results.LastOrDefault();

        if (client == null)
        {
            req.LogError(new UnhandledException($"client null - originalTransactionId:{originalTransactionId}"));
            return;
        }

        var sub = client.GetPurchase(originalTransactionId, PaymentProvider.Apple);

        if (notification.NotificationType == "REFUND" || notification.NotificationType == "REVOKE")
        {
            sub.Sparks = 0; //disable immediately
        }
        else
        {
            sub.Sparks = 10;
            //var newExpires = DateTimeOffset.FromUnixTimeMilliseconds(transaction.ExpiresDate);
            //if (sub.ExpiresDate == null || newExpires > sub.ExpiresDate)
            //{
            //    sub.ExpiresDate = newExpires;
            //}
        }

        //var product = transaction.ProductId ?? throw new UnhandledException("product not available");
        //sub.Cycle = product.Contains("yearly") ? AccountCycle.Yearly : AccountCycle.Monthly;

        client.UpdatePurchase(sub);

        client.Events.Add(new Event("Apple (Webhooks)", $"SubscriptionId = {originalTransactionId}, Type = {notification.NotificationType}, Subtype = {notification.Subtype}", ip));

        await repo.UpsertItemAsync(client, cancellationToken);
    }

    [Function("StripeCreateCustomer")]
    public async Task<AuthPrincipal> StripeCreateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "stripe/customer")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken);
        var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("principal null");

        var customer = await new Stripe.CustomerService().CreateAsync(new Stripe.CustomerCreateOptions
        {
            Name = principal.DisplayName,
            Email = principal.Email,
            Metadata = new Dictionary<string, string> {
                { "app", APP },
                { "userId", principal.UserId! },
            },
        }, cancellationToken: cancellationToken);

        principal.StripeCustomerId = customer.Id;

        var ip = req.GetUserIP(true);
        principal.Events.Add(new Event("Stripe", $"User registered with id:{customer.Id}", ip));

        return await repo.UpsertItemAsync(principal, cancellationToken);
    }

    [Function("CreateCheckoutSession")]
    public async Task<string> CreateCheckoutSession(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "stripe/create-checkout-session/{priceId}/{qtd}")] HttpRequestData req, string priceId, int qtd, CancellationToken cancellationToken)
    {
        var userId = await req.GetUserIdAsync(cancellationToken) ?? throw new NotificationException("user not available");
        var ip = req.GetUserIP(true);
        var url = req.GetQueryParameters()["url"];

        var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken) ?? throw new UnhandledException("principal null");

        if (principal.StripeCustomerId.Empty()) throw new NotificationException("Stripe customer not available");

        var options = new SessionCreateOptions
        {
            Customer = principal.StripeCustomerId,
            //CustomerUpdate = new SessionCustomerUpdateOptions
            //{
            //    Name = "never",
            //    Address = "never",
            //    Shipping = "never"
            //},

            LineItems = [new() { Price = priceId, Quantity = qtd, },],
            Mode = "payment",
            SuccessUrl = url + "?stripe_session_id={CHECKOUT_SESSION_ID}",
            Metadata = new Dictionary<string, string> {
                { "app", APP },
                { "userId", principal.UserId! },
                { "Quantity", qtd.ToString() }
            },
            SubscriptionData = new SessionSubscriptionDataOptions
            {
                Metadata = new Dictionary<string, string> {
                    { "app", APP },
                    { "userId", principal.UserId! },
                }
            }
        };

        options.AddExtraParam("managed_payments[enabled]", true);

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

        await repo.UpsertItemAsync(principal, cancellationToken);

        return session.Url;
    }

    [Function("PostStripeWebhook")]
    public async Task<HttpResponseData> PostStripeWebhook(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/stripe/webhook")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var json = await new StreamReader(req.Body).ReadToEndAsync(cancellationToken);

        req.Headers.TryGetValues("Stripe-Signature", out var Signature);
        if (string.IsNullOrEmpty(Signature?.First())) throw new NotificationException("Stripe signature missing");
        var stripeEvent = Stripe.EventUtility.ConstructEvent(json, Signature?.First(), ApiStartup.Configurations.Stripe?.SigningSecret ?? throw new NotificationException("Stripe SigningSecret not configured"), throwOnApiVersionMismatch: false);

        if (stripeEvent.Type.StartsWith("checkout.session")) //completed, async_payment_succeeded
        {
            if (stripeEvent.Data.Object is not Session obj || obj.Id.Empty()) throw new NotificationException("Stripe session not available");

            if (!obj.Metadata.TryGetValue("app", out var app) || app != APP)
                return await req.CreateResponse(HttpStatusCode.OK, $"webhook ignored -> app={app ?? "null"}");

            if (!obj.Metadata.TryGetValue("userId", out var userId) || userId.Empty())
                throw new NotificationException("userId metadata missing in session");

            if (!obj.Metadata.TryGetValue("Quantity", out var qtd) || qtd.Empty())
                throw new NotificationException("Quantity metadata missing in session");

            var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            if (principal == null)
            {
                req.LogError(new NotificationException($"stripe webhook - principal is null - userId:{userId}"));
                return await req.CreateResponse(HttpStatusCode.OK, $"stripe webhook - principal is null - userId:{userId}");
            }

            if (obj.PaymentStatus == "paid" || stripeEvent.Type == "checkout.session.async_payment_succeeded")
            {
                var purchase = principal.GetPurchase(obj.Id, PaymentProvider.Stripe);

                if (purchase.Sparks == 0)
                {
                    if (!int.TryParse(qtd, out int quantity))
                        throw new NotificationException("Invalid quantity");

                    purchase.Sparks = quantity;
                    principal.Sparks += quantity;

                    principal.UpdatePurchase(purchase);

                    var ip = req.GetUserIP(true);
                    var type = stripeEvent.Type.Split(".")[2];
                    principal.Events.Add(new Event("Stripe (Webhooks)", $"Type = {type}, Status = {obj.PaymentStatus}, Qtd = {quantity} for SessionId = {obj.Id}", ip));
                }
            }

            await repo.UpsertItemAsync(principal, cancellationToken);
        }
        else if (stripeEvent.Type == "customer.deleted")
        {
            if (stripeEvent.Data.Object is not Stripe.Customer obj || obj.Id.Empty()) throw new NotificationException("stripe customer not available");

            if (!obj.Metadata.TryGetValue("userId", out var userId) || userId.Empty())
            {
                //if no metadada, try to find the user with the StripeCustomerId
                var list = await repo.Query<AuthPrincipal>(p => p.StripeCustomerId == obj.Id, DocumentType.Principal, cancellationToken);

                if (list.Count > 0)
                {
                    var item = list[0];
                    item.StripeCustomerId = null;
                    await repo.UpsertItemAsync(item, cancellationToken);
                }

                return await req.CreateResponse(HttpStatusCode.OK, "userId metadata missing");
            }

            if (!obj.Metadata.TryGetValue("app", out var app) || app != APP)
                return await req.CreateResponse(HttpStatusCode.OK, $"webhook ignored -> app={app ?? "null"}");

            var principal = await repo.Get<AuthPrincipal>(DocumentType.Principal, userId, cancellationToken);

            if (principal != null)
            {
                principal.StripeCustomerId = null;
                await repo.UpsertItemAsync(principal, cancellationToken);
            }
        }

        return await req.CreateResponse(HttpStatusCode.OK, "webhook received");
    }

    [Function("StripeValidateSession")]
    public async Task<HttpResponseData> StripeValidateSession(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/stripe/validate-session/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(id))
            return await req.CreateResponse(HttpStatusCode.OK, false);

        var service = new SessionService();

        var session = await service.GetAsync(id, cancellationToken: cancellationToken);

        var result = session != null && session.PaymentStatus == "paid" && session.Status == "complete";
        return await req.CreateResponse(HttpStatusCode.OK, result);
    }
}
