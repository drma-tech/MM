using Microsoft.AspNetCore.Components;
using MM.Shared.Models.Auth;
using MM.Shared.Models.Dashboard;
using MM.Shared.Models.Subscription;

namespace MM.WEB.Modules.Subscription
{
    public partial class SubscriptionPlansComponent
    {
        [Parameter][EditorRequired] public PaymentProvider Provider { get; set; }
        [Parameter][EditorRequired] public AuthPrincipal? Client { get; set; }

        private PaymentConfigurations? Config { get; set; }
        private bool _processing;
        private int _total = 10;

        public SumUsers? SumUsers { get; set; }

        protected override async Task LoadStaticDataAsync()
        {
            var cache = await DashboardApi.GetSumUsers(states: [], Cts.Token);
            SumUsers = cache?.Data;
        }

        protected override IReadOnlyList<string?> GetParameterKey()
        {
            return [Provider.ToString()];
        }

        protected override async Task LoadParameterDataAsync()
        {
            Config = await PaymentPublicApi.GetConfigurations(Provider, Cts.Token);
        }

        public static decimal GetPrice(AccountProduct product)
        {
            return (product) switch
            {
                (AccountProduct.Phase1) => 0.99m,
                (AccountProduct.Phase2) => 1.99m,
                (AccountProduct.Phase3) => 2.99m,
                (AccountProduct.Phase4) => 3.99m,
                _ => 0.00m,
            };
        }

        private double GetPhaseValue(AccountProduct product)
        {
            var totUsers = SumUsers?.TotalUsers ?? 0;

            if (product == AccountProduct.Phase1)
            {
                //do nothing
            }
            else if (product == AccountProduct.Phase2)
            {
                if (totUsers > 10_000) totUsers -= 10_000;
                else return 0;
            }
            else if (product == AccountProduct.Phase3)
            {
                if (totUsers > 20_000) totUsers -= 20_000;
                else return 0;
            }
            else if (product == AccountProduct.Phase4)
            {
                if (totUsers > 30_000) totUsers -= 30_000;
                else return 0;
            }

            if (totUsers < 10_000) return (double)totUsers / 10_000;

            return 1;
        }

        protected async Task OpenCheckout(AccountProduct product, int qtd)
        {
            try
            {
                _processing = true;

                if (AppStateStatic.IsAuthenticated)
                {
                    var priceId = Config?.GetPriceId(product);

                    if (Provider == PaymentProvider.Paddle)
                    {
                        await ShowWarning($"Provider not available: {Provider.GetFieldSettings().Name}");
                        _processing = false; StateHasChanged();
                    }
                    else if (Provider == PaymentProvider.Apple)
                    {
                        await JsRuntime.Payments().AppleOpenCheckout(priceId, Cts.Token);
                    }
                    else if (Provider == PaymentProvider.Google)
                    {
                        await JsRuntime.Payments().GoogleOpenCheckout(priceId, "type", Cts.Token);
                    }
                    else if (Provider == PaymentProvider.Stripe)
                    {
                        if (Client != null && Client.StripeCustomerId.Empty())
                        {
                            Client = await PrincipalApi.StripeCustomer(Cts.Token);
                        }

                        //create session and redirect to checkout
                        await JsRuntime.Payments().StripeOpenCheckout(priceId, qtd, Cts.Token);
                    }
                    else
                    {
                        await ShowWarning($"Provider not implemented: {Provider.GetFieldSettings().Name}");
                        _processing = false; StateHasChanged();
                    }
                }
                else
                {
                    await ShowWarning(Translations.Module.Subscription.YouMustLoggedSubscribe);
                    _processing = false; StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                await ProcessException(ex);
                _processing = false; StateHasChanged();
            }
            finally
            {
                await Task.Delay(5000, Cts.Token);
                _processing = false;
            }
        }
    }
}
