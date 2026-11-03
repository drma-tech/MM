# Configuration Guide

This guide describes the configuration used by the `MM.API` project and the local development setup for Modern Matchmaker.

## Configuration Overview

The backend settings are defined in `MM.API/Core/Configurations.cs` and bound from the root configuration:

```csharp
var cfg = new Configurations();
config.Build().Bind(cfg);
ApiStartup.Configurations = cfg;
```

In the Development environment, `MM.API/Program.cs` adds these configuration providers in order:

1. `MM.API/local.settings.json`
2. .NET User Secrets

User Secrets are added after the JSON file, so matching keys supplied through User Secrets take precedence.

The project uses this User Secrets ID:

```text
34ce4f7a-ae5c-4644-b219-86df6469e377
```

User Secrets are stored outside the repository in the current user's profile. The underlying file is named `secrets.json`; it is managed through the .NET CLI rather than committed to the project.

## Local Development

Run these commands from the repository root:

```bash
dotnet user-secrets list --project MM.API
dotnet user-secrets edit --project MM.API
```

Set an individual value with:

```bash
dotnet user-secrets set "CosmosDB:DatabaseId" "your-database-id" --project MM.API
```

The configuration binder expects the settings at the root level. For example:

```json
{
  "CosmosDB": {
    "DatabaseId": "your-database-id",
    "ConnectionString": "your-cosmos-db-connection-string"
  },
  "Azure": {
    "BlobConnectionString": "your-blob-storage-connection-string"
  },
  "AWS": {
    "Region": "your-aws-region",
    "AccessKey": "your-aws-access-key",
    "SecretKey": "your-aws-secret-key"
  },
  "Apple": {
    "Endpoint": "your-apple-server-api-endpoint",
    "SharedSecret": "your-apple-shared-secret",
    "BundleId": "your-app-bundle-id",
    "Phase1": {
      "Price": "your-product-price-id"
    },
    "Phase2": {
      "Price": "your-product-price-id"
    },
    "Phase3": {
      "Price": "your-product-price-id"
    },
    "Phase4": {
      "Price": "your-product-price-id"
    }
  },
  "Stripe": {
    "ApiKey": "your-stripe-api-key",
    "SigningSecret": "your-stripe-webhook-signing-secret",
    "Phase1": {
      "Price": "your-product-price-id"
    },
    "Phase2": {
      "Price": "your-product-price-id"
    },
    "Phase3": {
      "Price": "your-product-price-id"
    },
    "Phase4": {
      "Price": "your-product-price-id"
    }
  },
  "Here": {
    "ApiKey": "your-here-api-key"
  },
  "Didit": {
    "ApiKey": "your-didit-api-key",
    "WorkflowId": "your-didit-workflow-id",
    "SecretKey": "your-didit-secret-key"
  },
  "ClerkAuth": {
    "SecretKey": "your-clerk-secret-key",
    "SigningSecret": "your-clerk-webhook-signing-secret"
  },
  "UserJot": {
    "ProjectId": "your-userjot-project-id",
    "Secret": "your-userjot-secret"
  },
  "ZeptoMail": {
    "ApiKey": "your-zeptomail-api-key",
    "SecrectWebhook": "your-zeptomail-webhook-secret",
    "JobApiKey": "your-zeptomail-job-api-key"
  },
  "IsMaintenanceMode": false
}
```

Use the exact property names shown above. In particular, the current configuration property is spelled `SecrectWebhook` in the source code.

## Configuration Reference

| Section | Settings |
| --- | --- |
| `CosmosDB` | `DatabaseId`, `ConnectionString` |
| `Azure` | `BlobConnectionString` |
| `AWS` | `Region`, `AccessKey`, `SecretKey` |
| `Apple` | `Endpoint`, `SharedSecret`, `BundleId`, and `Phase1` through `Phase4`, each with `Price` |
| `Stripe` | `ApiKey`, `SigningSecret`, and `Phase1` through `Phase4`, each with `Price` |
| `Here` | `ApiKey` |
| `Didit` | `ApiKey`, `WorkflowId`, `SecretKey` |
| `ClerkAuth` | `SecretKey`, `SigningSecret` |
| `UserJot` | `ProjectId`, `Secret` |
| `ZeptoMail` | `ApiKey`, `SecrectWebhook`, `JobApiKey` |
| Root | `IsMaintenanceMode` |

## Azure Deployment

In deployed environments, provide the settings through the application's configuration providers, such as Azure Function App application settings.

For hierarchical settings supplied as environment variables, use double underscores (`__`) as the section separator:

```text
CosmosDB__DatabaseId
CosmosDB__ConnectionString
Azure__BlobConnectionString
AWS__Region
AWS__AccessKey
AWS__SecretKey
Stripe__ApiKey
Stripe__SigningSecret
ClerkAuth__SecretKey
ClerkAuth__SigningSecret
IsMaintenanceMode
```

Do not commit credentials, API keys, signing secrets, connection strings, or other private values to source control.

## Frontend Development Settings

The Blazor WebAssembly application reads its local API address from:

```text
MM.WEB/wwwroot/appsettings.Development.json
```

The repository currently configures:

```json
{
  "ApiBaseAddress": "http://localhost:7091/api/"
}
```

Update this value if your local Functions API uses a different address. This is a client-side development setting, not a place for secrets.

## Azure Functions Local Settings

The repository includes `MM.API/local.settings.json` with the local Functions host settings, including:

- `AzureWebJobsStorage`
- `FUNCTIONS_WORKER_RUNTIME`
- `Host:CORS`

The file is copied to the build output and excluded from publish output. Keep local credentials out of committed files.