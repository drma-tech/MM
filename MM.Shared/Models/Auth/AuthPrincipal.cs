using MM.Shared.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace MM.Shared.Models.Auth;

public class AuthPrincipal(string? id) : MainDocument(new MainIdentity(MainType.Principal, id))
{
    public string? UserId { get; set; } = id;
    public string? DisplayName { get; set; }
    [DataType(DataType.EmailAddress)] public string? Email { get; set; }
    public string? StripeCustomerId { get; set; }
    public bool PublicProfile { get; set; } = false;
    public int Sparks { get; set; } = 0;

    public string[] AuthProviders { get; set; } = [];
    public HashSet<AuthPurchase> AuthPurchases { get; set; } = [];
    public HashSet<Event> Events { get; set; } = [];

    public AuthPurchase? GetActivePurchase()
    {
        return AuthPurchases.LastOrDefault(p => p.Sparks > 0);
    }

    public AuthPurchase GetPurchase(string? id, PaymentProvider provider)
    {
        var purchase = AuthPurchases.SingleOrDefault(s => s.PurchaseId == id);
        if (purchase != null) return purchase;

        purchase = AuthPurchases.OrderBy(p => p.CreatedAt).LastOrDefault(p => p.Provider == provider) ?? throw new NotificationException($"No purchases found. id={id}");
        purchase.PurchaseId = id;
        return purchase;
    }

    public void AddPurchase(AuthPurchase purchase)
    {
        AuthPurchases.Add(purchase);
    }

    public void UpdatePurchase(AuthPurchase purchase, bool validateId = true)
    {
        if (validateId && purchase.PurchaseId.Empty()) throw new UnhandledException("purchase id is null");

        var sub = AuthPurchases.SingleOrDefault(sub => sub.PurchaseId == purchase.PurchaseId);

        if (sub == null)
        {
            throw new NotificationException("Subscription not found.");
        }
        else
        {
            sub.SessionId = purchase.SessionId;
            sub.Provider = purchase.Provider;
            sub.Product = purchase.Product;
            sub.Sparks = purchase.Sparks;
        }
    }

    public void ConsumesSparks(int qtd)
    {
        if (Sparks < qtd) throw new NotificationException("There are not enough sparks for this operation");
        Sparks -= qtd;
    }

    public bool HasSparks(int qtd)
    {
        return Sparks >= qtd;
    }
}

public class AuthPurchase : EqualityBase<AuthPurchase>
{
    public string? PurchaseId { get; set; }
    public string? SessionId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public int Sparks { get; set; } = 0;

    public PaymentProvider? Provider { get; set; }
    public AccountProduct? Product { get; set; }

    protected override object?[] EqualityValues => [PurchaseId, SessionId];
}

public class Event(string? origin, string? description, string? ip) : EqualityBase<Event>
{
    public string? Origin { get; set; } = origin;
    public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
    public string? Description { get; set; } = description;
    public string? Ip { get; set; } = ip;

    protected override object?[] EqualityValues => [Origin, Date];
}