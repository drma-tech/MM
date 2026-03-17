namespace MM.Shared.Models.Subscription;

public class PaymentConfigurations
{
    public string? CustomerPortalEndpoint { get; set; }
    public string? Token { get; set; }
    public string? PricePhase1 { get; set; }
    public string? PricePhase2 { get; set; }
    public string? PricePhase3 { get; set; }
    public string? PricePhase4 { get; set; }

    public string? GetPriceId(AccountProduct product)
    {
        return (product) switch
        {
            (AccountProduct.Phase1) => PricePhase1,
            (AccountProduct.Phase2) => PricePhase2,
            (AccountProduct.Phase3) => PricePhase3,
            (AccountProduct.Phase4) => PricePhase4,
            _ => null,
        };
    }
}