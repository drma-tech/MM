namespace MM.Shared.Models;

public class Configurations
{
    public CosmosDB? CosmosDB { get; set; }
    public Firebase? Firebase { get; set; }
    public Azure? Azure { get; set; }
    public AWS? AWS { get; set; }
    public Apple? Apple { get; set; }
    public Here? Here { get; set; }
}

public class CosmosDB
{
    public string? DatabaseId { get; set; }
    public string? ConnectionString { get; set; }
}

public class Firebase
{
    public string? ClientId { get; set; }
    public string? PrivateKeyId { get; set; }
    public string? PrivateKey { get; set; }
    public string? ClientEmail { get; set; }
    public string? CertUrl { get; set; }
}

public class Azure
{
    public string? BlobConnectionString { get; set; }
    public string? CognitiveKey { get; set; }
    public string? CognitiveEndpoint { get; set; }
}

public class AWS
{
    public string? Region { get; set; }
    public string? AccessKey { get; set; }
    public string? SecretKey { get; set; }
}

public class Apple
{
    public string? Endpoint { get; set; } = string.Empty;
    public string? SharedSecret { get; set; } = string.Empty; //do not share with users
    public string? BundleId { get; set; }
    public ProductSettings? Standard { get; set; } = new();
    public ProductSettings? Premium { get; set; } = new();
}

public class ProductSettings
{
    public string? PriceMonth { get; set; }
    public string? PriceYear { get; set; }
}

public class Here
{
    public string? ApiKey { get; set; }
}