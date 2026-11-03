# Modern Matchmaker

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fdrma-tech%2FMM.svg?type=shield&issueType=license)](https://app.fossa.com/projects/git%2Bgithub.com%2Fdrma-tech%2FMM?ref=badge_shield&issueType=license)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fdrma-tech%2FMM.svg?type=shield&issueType=security)](https://app.fossa.com/projects/git%2Bgithub.com%2Fdrma-tech%2FMM?ref=badge_shield&issueType=security)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=drma-tech_SD&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=drma-tech_MM)

**Meaningful connections start with compatibility.**

Modern Matchmaker is a relationship platform being developed to help people find partners whose values, personalities, lifestyles, interests, and relationship goals align with their own.

Rather than prioritizing swipe-based discovery, the product is being built around detailed profiles, personal preferences, and structured compatibility-based matchmaking. Its features are being introduced progressively as the community grows.

Website: [modern-matchmaker.com](https://modern-matchmaker.com/en)

## Current Availability

The platform is currently in **Phase 1 (0–10,000 users)**. Account registration is currently the main available product functionality, with the initial focus on building the matchmaking pool.

The compatibility experience and additional matchmaking capabilities are still being developed and will be introduced progressively according to the product roadmap.

## Product Roadmap

The public roadmap is organized into user milestones:

- **Phase 1 (0–10k users):** Build the initial matchmaking pool and introduce the compatibility system.
- **Phase 2 (10k–20k users):** Allow users to apply as matchmaking clients.
- **Phase 3 (20k–30k users):** Introduce Spotlight, allowing users to boost their profiles.
- **Phase 4 (30k–40k users):** Additional features to be announced.

See the [Roadmap](ROADMAP.md) for more details.

## Technology Stack

- **Frontend:** Blazor WebAssembly, C#, MudBlazor
- **Backend:** Azure Functions Isolated Worker, .NET 10
- **Shared Code:** .NET 10 class library
- **Database:** Azure Cosmos DB
- **File Storage:** Azure Blob Storage
- **Authentication:** Clerk
- **Payments:** Stripe and Apple In-App Purchases
- **Identity Verification:** Didit
- **Image Analysis:** AWS Rekognition
- **Location Services:** HERE
- **Monitoring:** Sentry
- **Feedback and Product Communication:** UserJot
- **Email Delivery:** ZeptoMail

## Solution Structure

| Project | Description |
| --- | --- |
| `MM.WEB` | Blazor WebAssembly client application and user interface. |
| `MM.API` | Azure Functions backend, API endpoints, integrations, and data access. |
| `MM.Shared` | Shared models, enums, validation rules, and translations. |

All three projects target **.NET 10**.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Azure Functions Core Tools v4
- An Azure Cosmos DB account or local development configuration
- Required third-party service accounts and credentials for the integrations you intend to run

### Local Development

1. Clone the repository.
2. Configure the backend settings using [.NET User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) for the `MM.API` project.
3. Review `MM.API/local.settings.json` for the Azure Functions local host settings.
4. Check `MM.WEB/wwwroot/appsettings.Development.json` for the local API base address.
5. Start the Azure Functions API and the Blazor WebAssembly application.

See the [Configuration Guide](docs/CONFIGURATION.md) for the required settings and local setup details.

## Documentation

- [Configuration Guide](docs/CONFIGURATION.md)
- [Roadmap](ROADMAP.md)

## License

This project is licensed under the [Mozilla Public License 2.0](LICENSE.md).
