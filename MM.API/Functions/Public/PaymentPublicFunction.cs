using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using MM.Shared.Models.Subscription;
using Stripe.Checkout;
using System.Net;

namespace MM.API.Functions.Public;

public class PaymentPublicFunction
{
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

        if (provider == PaymentProvider.Stripe)
        {
            return new PaymentConfigurations
            {
                PricePhase1 = ApiStartup.Configurations.Stripe?.Phase1?.Price,
                PricePhase2 = ApiStartup.Configurations.Stripe?.Phase2?.Price,
                PricePhase3 = ApiStartup.Configurations.Stripe?.Phase3?.Price,
                PricePhase4 = ApiStartup.Configurations.Stripe?.Phase4?.Price,
            };
        }

        throw new UnhandledException("provider not implemented");
    }

    [Function("StripeValidateSession")]
    public static async Task<HttpResponseData> StripeValidateSession(
        [HttpTrigger(AuthorizationLevel.Anonymous, Method.Get, Route = "public/stripe/validate-session/{id}")] HttpRequestData req, string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(id))
            return await req.CreateResponse(HttpStatusCode.OK, value: false, cancellationToken);

        var service = new SessionService();

        var session = await service.GetAsync(id, cancellationToken: cancellationToken);

        var result = session != null && string.Equals(session.PaymentStatus, "paid", StringComparison.OrdinalIgnoreCase) && string.Equals(session.Status, "complete", StringComparison.OrdinalIgnoreCase);

        return await req.CreateResponse(HttpStatusCode.OK, result, cancellationToken);
    }
}
