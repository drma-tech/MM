using System.ComponentModel.DataAnnotations;

namespace MM.Shared.Models.Auth;

public class AuthPrincipal() : PrivateMainDocument(DocumentType.Principal)
{
    public string? UserId { get; set; }
    public string? DisplayName { get; set; }
    [DataType(DataType.EmailAddress)] public string? Email { get; set; }
    public string? StripeCustomerId { get; set; }
    public bool PublicProfile { get; set; } = false;
    public int Sparks { get; set; } = 0;

    public string[] AuthProviders { get; set; } = [];
    public HashSet<AuthPurchase> AuthPurchases { get; set; } = [];
    public List<Event> Events { get; set; } = [];

    public long? _tsCreated { get; set; }

    public override void Initialize(string userId)
    {
        base.Initialize(userId);
        UserId = userId;
    }

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
}

public class AuthPurchase
{
    public string? PurchaseId { get; set; }
    public string? SessionId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public int Sparks { get; set; } = 0;

    public PaymentProvider? Provider { get; set; }
    public AccountProduct? Product { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not AuthPurchase other) return false;

        return string.Equals(PurchaseId, other.PurchaseId, StringComparison.Ordinal) && string.Equals(SessionId, other.SessionId, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PurchaseId, SessionId);
    }
}

public class Event(string? origin, string? description, string? ip)
{
    public string? Origin { get; set; } = origin;
    public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
    public string? Description { get; set; } = description;
    public string? Ip { get; set; } = ip;
}