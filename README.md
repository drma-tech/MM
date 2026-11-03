# Modern Matchmaker

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fdrma-tech%2FMM.svg?type=shield&issueType=license)](https://app.fossa.com/projects/git%2Bgithub.com%2Fdrma-tech%2FMM?ref=badge_shield&issueType=license)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fdrma-tech%2FMM.svg?type=shield&issueType=security)](https://app.fossa.com/projects/git%2Bgithub.com%2Fdrma-tech%2FMM?ref=badge_shield&issueType=security)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=drma-tech_SD&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=drma-tech_MM)

**Meaningful connections start with compatibility.**

Modern Matchmaker is a relationship platform designed to help people find partners whose values, personalities, lifestyles, interests, and relationship goals align with their own.

Instead of relying primarily on swipe-based discovery, the platform uses detailed profiles, personal preferences, and a structured compatibility algorithm to generate relevant match suggestions. The goal is to prioritize compatibility and relationship intent over the volume of profiles.

Website: [modern-matchmaker.com](https://modern-matchmaker.com/en)

## Core Features

- **Detailed Profiles:** Build a more complete picture through profile sections covering basic information, biography, lifestyle, personality, interests, relationship preferences, and goals.
- **Compatibility Matching:** Compare profile information and personal preferences to calculate compatibility scores. Compatibility can be different in each direction because each person's preferences are taken into account.
- **Personalized Match Suggestions:** Explore suggested profiles ranked by compatibility.
- **Search and Filters:** Refine potential matches using profile preferences and filtering options.
- **Likes and Matches:** Keep track of profile interactions and mutual interest.
- **Profile Verification and Safety:** Identity and photo verification workflows, reporting tools, and image moderation help support a safer community.
- **Location-Based Discovery:** Explore people by region and location.
- **Date Safety Tools:** Optional tools support sharing date details with trusted friends or family.

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
