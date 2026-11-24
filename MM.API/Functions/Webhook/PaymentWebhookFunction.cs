using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.Common.Core.Types;
using MM.Common.Models.Auth;
using Stripe.Checkout;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Hosting;

namespace MM.API.Functions.Webhook;

public class PaymentWebhookFunction(CosmosMainRepository repo, IHostEnvironment hostEnvironment)
{
    private const string APP_CODE = "mm";
    private const string APP = "app";
    private const string USERID = "userId";

    [Function("PostAppleWebhook")]
    public async Task PostAppleWebhook(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/apple/webhook")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var body = await req.ReadFromJsonAsync<Dictionary<string, string>>(cancellationToken) ?? throw new InvestigationException("body null");

        if (!body.TryGetValue("signedPayload", out var signedPayload)) throw new InvestigationException("signedPayload null");

        var expectedEnvironment = hostEnvironment.IsProduction() ? "Production" : "Sandbox";
        var appleConfig = ApiStartup.Configurations.Apple ?? throw new InvestigationException("Apple configuration missing");
        var notification = AppleJwtDecoder.DecodeServerNotification(signedPayload, appleConfig, expectedEnvironment);

        var info = notification.Data;

        var transaction = AppleJwtDecoder.DecodeTransaction(info.SignedTransactionInfo, info.BundleId, info.Environment);

        var originalTransactionId = transaction.OriginalTransactionId;

        var results = await repo.Query<AuthPrincipal>(MainType.Principal, x => x.AuthPurchases.Any(p => p.PurchaseId == originalTransactionId), transform: null, cancellationToken);

        var client = results.LastOrDefault() ?? throw new InvestigationException($"client null - originalTransactionId:{originalTransactionId}");
        var sub = client.GetPurchase(originalTransactionId, PaymentProvider.Apple);

        //TODO: review this, as we dont deal with subscriptions anymore (sparks need a specific value)
        switch (notification.NotificationType.ToUpperInvariant())
        {
            case "SUBSCRIBED":
            case "DID_RENEW":
            case "DID_RECOVER":
            case "OFFER_REDEEMED":
                sub.Sparks = 10;
                client.Sparks += 10;
                break;

            case "EXPIRED":
            case "GRACE_PERIOD_EXPIRED":
            case "REFUND":
            case "REVOKE":
                sub.Sparks = 0;
                break;
        }

        client.UpdatePurchase(sub);

        var ip = req.GetUserIP(includePort: true);
        client.Events.Add(new EventItem("Apple (Webhooks)", $"SubscriptionId = {originalTransactionId}, Type = {notification.NotificationType}, Subtype = {notification.Subtype}", ip));

        await repo.UpsertItemAsync(client);
        await SyncClerkAccountDeletionAsync(client.UserId ?? throw new InvestigationException("Apple subscription user id is missing"), client.GetActivePurchase() is not null);
    }

    [Function("PostStripeWebhook")]
    public async Task<HttpResponseData> PostStripeWebhook(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/stripe/webhook")] HttpRequestData req, CancellationToken cancellationToken)
    {
        var json = await new StreamReader(req.Body).ReadToEndAsync(cancellationToken);

        req.Headers.TryGetValues("Stripe-Signature", out var Signature);
        if (string.IsNullOrEmpty(Signature?.First())) throw new InvestigationException("Stripe signature missing");
        var stripeEvent = Stripe.EventUtility.ConstructEvent(json, Signature?.First(), ApiStartup.Configurations.Stripe?.SigningSecret ?? throw new InvestigationException("Stripe SigningSecret not configured"), throwOnApiVersionMismatch: false);

        if (stripeEvent.Type.StartsWith("checkout.session", StringComparison.OrdinalIgnoreCase)) //completed, async_payment_succeeded
        {
            (bool success, HttpResponseData? value) = await ProcessCheckoutSession(req, stripeEvent, cancellationToken);

            if (!success)
            {
                return value!;
            }
        }
        else if (string.Equals(stripeEvent.Type, "customer.deleted", StringComparison.OrdinalIgnoreCase))
        {
            (bool success, HttpResponseData? value) = await ProcessCustomerDeleted(req, stripeEvent, cancellationToken);

            if (!success)
            {
                return value!;
            }
        }

        return await req.CreateResponse(HttpStatusCode.OK, "webhook received", cancellationToken);
    }

    private async Task<(bool success, HttpResponseData? value)> ProcessCheckoutSession(HttpRequestData req, Stripe.Event stripeEvent, CancellationToken cancellationToken)
    {
        if (stripeEvent.Data.Object is not Session obj || obj.Id.Empty()) throw new InvestigationException("Stripe session not available");

        if (!obj.Metadata.TryGetValue(APP, out var app) || !string.Equals(app, APP_CODE, StringComparison.OrdinalIgnoreCase))
            return (success: false, value: await req.CreateResponse(HttpStatusCode.OK, $"webhook ignored -> app={app ?? "null"}", cancellationToken));

        if (!obj.Metadata.TryGetValue(USERID, out var userId) || userId.Empty())
            throw new InvestigationException("userId metadata missing in session");

        if (!obj.Metadata.TryGetValue("Quantity", out var qtd) || qtd.Empty())
            throw new InvestigationException("Quantity metadata missing in session");

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken) ?? throw new InvestigationException($"stripe webhook - principal is null - userId:{userId}");

        if (string.Equals(obj.PaymentStatus, "paid", StringComparison.OrdinalIgnoreCase) || string.Equals(stripeEvent.Type, "checkout.session.async_payment_succeeded", StringComparison.OrdinalIgnoreCase))
        {
            var purchase = principal.GetPurchase(obj.Id, PaymentProvider.Stripe);

            if (purchase.Sparks == 0)
            {
                if (!int.TryParse(qtd, CultureInfo.InvariantCulture, out int quantity))
                    throw new InvestigationException("Invalid quantity");

                purchase.Sparks = quantity;
                principal.Sparks += quantity;

                principal.UpdatePurchase(purchase);

                var ip = req.GetUserIP(includePort: true);
                var type = stripeEvent.Type.Split(".")[2];
                principal.Events.Add(new EventItem("Stripe (Webhooks)", string.Create(CultureInfo.InvariantCulture, $"Type = {type}, Status = {obj.PaymentStatus}, Qtd = {quantity} for SessionId = {obj.Id}"), ip));
            }
        }

        await repo.UpsertItemAsync(principal);
        await SyncClerkAccountDeletionAsync(userId, principal.GetActivePurchase() is not null);
        return (success: true, value: null);
    }

    private async Task<(bool success, HttpResponseData? value)> ProcessCustomerDeleted(HttpRequestData req, Stripe.Event stripeEvent, CancellationToken cancellationToken)
    {
        if (stripeEvent.Data.Object is not Stripe.Customer obj || obj.Id.Empty()) throw new InvestigationException("stripe customer not available");

        if (!obj.Metadata.TryGetValue("app", out var app) || !string.Equals(app, APP_CODE, StringComparison.OrdinalIgnoreCase))
            return (success: false, value: await req.CreateResponse(HttpStatusCode.OK, $"webhook ignored -> app={app ?? "null"}", cancellationToken));

        if (!obj.Metadata.TryGetValue(USERID, out var userId) || userId.Empty())
        {
            //if no metadada, try to find the user with the StripeCustomerId
            var list = await repo.Query<AuthPrincipal>(MainType.Principal, p => p.StripeCustomerId == obj.Id, transform: null, cancellationToken);

            if (list.Count > 0)
            {
                var item = list.First();
                item.StripeCustomerId = null;
                await repo.UpsertItemAsync(item);

                return (success: false, value: await req.CreateResponse(HttpStatusCode.OK, "userId metadata missing", cancellationToken));
            }

            throw new InvestigationException("stripe customer id not available");
        }

        var principal = await repo.ReadItemAsync<AuthPrincipal>(new MainIdentity(MainType.Principal, userId), cancellationToken);

        if (principal != null)
        {
            principal.StripeCustomerId = null;
            await repo.UpsertItemAsync(principal);
        }

        return (success: true, value: null);
    }

    private static async Task SyncClerkAccountDeletionAsync(string userId, bool isPremium)
    {
        var secretKey = ApiStartup.Configurations.ClerkAuth?.SecretKey ?? throw new InvalidOperationException("Clerk SecretKey is not configured");

        var clerk = new ClerkBackendApi(bearerAuth: secretKey);

        await clerk.Users.UpdateAsync(
            userId: userId,
            requestBody: new UpdateUserRequestBody
            {
                DeleteSelfEnabled = !isPremium,
            });
    }
}
