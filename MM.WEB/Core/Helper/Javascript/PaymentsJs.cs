using Microsoft.JSInterop;

namespace MM.WEB.Core.Helper.Javascript
{
    public class PaymentsJs(IJSRuntime js) : JsModuleBase(js, "./js/payments.js")
    {
        public Task AppleOpenCheckout(string? productId, CancellationToken cancellationToken) => InvokeVoid("apple.openCheckout", cancellationToken, productId);

        public Task GoogleOpenCheckout(string? productId, string type, CancellationToken cancellationToken) => InvokeVoid("google.openCheckout", cancellationToken, productId, type);

        public Task StripeOpenCheckout(string? priceId, int qtd, CancellationToken cancellationToken) => InvokeVoid("stripe.openCheckout", cancellationToken, priceId, qtd);
    }
}