namespace MM.Shared.Models;

public class Configurations
{
    public CosmosDB? CosmosDB { get; set; }
    public Azure? Azure { get; set; }
    public AWS? AWS { get; set; }
    public Paddle? Paddle { get; set; }
    public Sendgrid? Sendgrid { get; set; }
    public Google? Google { get; set; }
    public Settings? Settings { get; set; }
    public Here? Here { get; set; }
}

public class CosmosDB
{
    public string? DatabaseId { get; set; }
    public string? ConnectionString { get; set; }
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

public class Paddle
{
    public string? Endpoint { get; set; } = string.Empty;
    public string? Token { get; set; } = string.Empty;
    public string? Key { get; set; } = string.Empty;
    public string? Signature { get; set; } = string.Empty;
    public PaddleProductSettings? Standard { get; set; } = new();
    public PaddleProductSettings? Premium { get; set; } = new();
}

public class PaddleProductSettings
{
    public string? Product { get; set; }
    public string? PriceMonth { get; set; }
    public string? PriceYear { get; set; }
}

public class Sendgrid
{
    public string? Key { get; set; }
}

public class Google
{
    public string? ApiKey { get; set; }
    public string? Captcha { get; set; }
}

public class Settings
{
    public bool ShowAdSense { get; set; }
}

public class Here
{
    public string? ApiKey { get; set; }
}