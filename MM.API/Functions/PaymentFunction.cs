using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.API.Core.Auth;
using MM.API.Core.Models;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Subscription;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MM.API.Functions;

public class PaymentFunction(CosmosRepository repo, IHttpClientFactory factory)
{
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

            client.Subscription ??= new AuthSubscription();
            client.Subscription.LatestReceipt = receipt; //save receipt before cause it may fail

            var result = await VerifyReceipt(ApiStartup.Configurations.Apple?.Endpoint, receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            if (result.status == 21007)
            {
                //when tested with TestFlight
                result = await VerifyReceipt("https://sandbox.itunes.apple.com/", receipt, cancellationToken) ?? throw new UnhandledException("AppleResponseReceipt null");
            }

            if (result.status != 0) throw new UnhandledException($"invalid status: {result.status}");
            if (result.receipt!.bundle_id != bundleId) throw new UnhandledException("invalid receipt");

            var purchase = result.latest_receipt_info[result.latest_receipt_info.Count - 1];

            client.Subscription.SubscriptionId = purchase.original_transaction_id;
            client.Subscription.ExpiresDate = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(purchase.expires_date_ms ?? "0", CultureInfo.InvariantCulture));

            client.Subscription.Provider = PaymentProvider.Apple;
            client.Subscription.Product = purchase.product_id!.Contains("premium") ? AccountProduct.Premium : AccountProduct.Standard;
            client.Subscription.Cycle = purchase.product_id!.Contains("yearly") ? AccountCycle.Yearly : AccountCycle.Monthly;

            //https://developer.apple.com/documentation/appstorereceipts/status
            client.Events = client.Events.Union([new Event("Apple", $"New status ({result.status}) for SubscriptionId ({purchase.original_transaction_id})", ip)]).ToArray();
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
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

    [Function("PostAppleSubscription")]
    public async Task PostAppleSubscription(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Post, Route = "public/apple/subscription")] HttpRequestData req, CancellationToken cancellationToken)
    {
        try
        {
            var ip = req.GetUserIP(true);

            var body = await req.ReadFromJsonAsync<Dictionary<string, string>>(cancellationToken) ?? throw new UnhandledException("body null");

            if (!body.TryGetValue("signedPayload", out var signedPayload)) throw new UnhandledException("signedPayload null");

            var notification = AppleJwtDecoder.DecodeServerNotification(signedPayload, ApiStartup.Configurations.Apple!);

            var info = notification.Data;

            var transaction = AppleJwtDecoder.DecodeTransaction(info.SignedTransactionInfo);

            var originalTransactionId = transaction.OriginalTransactionId;

            var results = await repo.Query<AuthPrincipal>(x => x.Subscription != null && x.Subscription.SubscriptionId == originalTransactionId, DocumentType.Principal, cancellationToken);

            var client = results.LastOrDefault();

            if (client == null)
            {
                req.LogError(new UnhandledException($"client null - originalTransactionId:{originalTransactionId}"));
                return;
            }

            if (client.Subscription == null) throw new UnhandledException("client.Subscription null");

            var newExpires = DateTimeOffset.FromUnixTimeMilliseconds(transaction.ExpiresDate);
            if (client.Subscription.ExpiresDate == null || newExpires > client.Subscription.ExpiresDate)
            {
                client.Subscription.ExpiresDate = newExpires;
            }
            client.Subscription.Product = transaction.ProductId!.Contains("premium") ? AccountProduct.Premium : AccountProduct.Standard;
            client.Subscription.Cycle = transaction.ProductId!.Contains("yearly") ? AccountCycle.Yearly : AccountCycle.Monthly;

            client.Events = client.Events.Union([new Event("Apple (Webhooks)", $"SubscriptionId = {originalTransactionId}, Product = {client.Subscription.Product}, Cycle = {client.Subscription.Cycle}, Type = {notification.NotificationType}, Subtype = {notification.Subtype}, expiresDate = {newExpires}", ip)]).ToArray();

            await repo.UpsertItemAsync(client, cancellationToken);
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }

    [Function("PaymentConfigurations")]
    public static PaymentConfigurations PaymentConfigurations(
       [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/payment/configurations")] HttpRequestData req)
    {
        try
        {
            var valid = Enum.TryParse(req.GetQueryParameters()["provider"], out PaymentProvider provider);
            if (!valid) throw new UnhandledException("invalid provider");

            if (provider == PaymentProvider.Generic)
            {
                return new PaymentConfigurations
                {
                    //PriceStandardMonth = ApiStartup.Configurations.Paddle?.Standard?.PriceMonth,
                    //PriceStandardYear = ApiStartup.Configurations.Paddle?.Standard?.PriceYear,
                    //PricePremiumMonth = ApiStartup.Configurations.Paddle?.Premium?.PriceMonth,
                    //PricePremiumYear = ApiStartup.Configurations.Paddle?.Premium?.PriceYear
                };
            }
            else if (provider == PaymentProvider.Apple)
            {
                return new PaymentConfigurations
                {
                    PriceStandardMonth = ApiStartup.Configurations.Apple?.Standard?.PriceMonth,
                    PriceStandardYear = ApiStartup.Configurations.Apple?.Standard?.PriceYear,
                    PricePremiumMonth = ApiStartup.Configurations.Apple?.Premium?.PriceMonth,
                    PricePremiumYear = ApiStartup.Configurations.Apple?.Premium?.PriceYear
                };
            }
            else
            {
                throw new UnhandledException("provider not implemented");
            }
        }
        catch (Exception ex)
        {
            req.LogError(ex);
            throw;
        }
    }
}
