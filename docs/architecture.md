## Overview

Bogus.CLI is organized into **3 projects** following a layered architecture with clear separation of responsibilities. Each layer depends only on the layer below it, and all dependencies are injected via interfaces.

```
Bogus.CLI.App  →  Bogus.CLI.Core  →  Bogus.CLI.Infrastructure
```

---

## Layers

### Bogus.CLI.App — Presentation Layer

Entry point of the application. Responsible for receiving CLI commands, parsing arguments/options, and displaying output to the user.

- Registers all services in the DI container (`Program.cs`)
- Uses **Cocona** as the CLI framework
- Contains one class per command: `DatasetCommand`, `ListDatasetCommand`, `ListLocaleCommand`, `SeedDatabaseCommand`
- Has no business logic — delegates everything to `Core` services

### Bogus.CLI.Core — Business Logic Layer

Heart of the application. Contains all logic for generating fake data, parsing dataset specifications, managing locales, and orchestrating database seeding.

Key responsibilities:
- **Services** — orchestrate data generation and database seeding
- **Parser services** — parse dataset strings (e.g. `name.firstName(gender=male)`) and invoke the correct generator
- **Dataset services** — wrap Bogus generators (Name, Lorem, Phone)
- **Helpers** — validate dataset/property names and parse parameters
- **Constants** — define available dataset names and their properties
- **Models** — represent the YAML seed file structure (`SeedFileModel`, `TableModel`, `Field`)

### Bogus.CLI.Infrastructure — Data Access Layer

Responsible for communicating with external databases. Currently supports SQL Server.

- `SqlServerRepository` — builds and executes parameterized `INSERT` statements in batches using transactions
- `IRepository` — interface that abstracts the database, making it straightforward to add support for other engines (PostgreSQL, MySQL, etc.) in the future

---

## Project Dependencies

```
Bogus.CLI.App
├── Bogus.CLI.Core
│   └── Bogus.CLI.Infrastructure
│       └── Microsoft.Data.SqlClient
├── Cocona (CLI framework)
└── Microsoft.Extensions.DependencyInjection

Bogus.CLI.Core
├── Bogus (fake data generation)
└── Microsoft.Extensions.Logging

Bogus.CLI.Infrastructure
└── Microsoft.Data.SqlClient
```

---

## Key Classes

| Class | Project | Role |
|---|---|---|
| `Program.cs` | App | Entry point, DI configuration |
| `DatasetCommand` | App | Handles the `dataset` CLI command |
| `SeedDatabaseCommand` | App | Handles the `seed-database` CLI command |
| `DatasetService` | Core | Orchestrates fake data generation |
| `FakerService` | Core | Singleton wrapper around `Bogus.Faker`, manages locale |
| `DatasetHelper` | Core | Validates dataset names and parses dataset strings |
| `ParserDatasetNameService` | Core | Parses and generates `name.*` data |
| `ParserDatasetLoremService` | Core | Parses and generates `lorem.*` data |
| `ParserDatasetPhoneService` | Core | Parses and generates `phone.*` data |
| `DatasetNameService` | Core | Wraps `Bogus.Name` methods |
| `DatasetLoremService` | Core | Wraps `Bogus.Lorem` methods |
| `DatasetPhoneService` | Core | Wraps `Bogus.Phone` methods |
| `SeedDatabaseService` | Core | Orchestrates batch generation and DB insertion |
| `TemplateService` | Core | Applies output templates with placeholders |
| `SqlServerRepository` | Infrastructure | Executes batch INSERTs into SQL Server |

---

## Design Patterns

- **Dependency Injection** — all dependencies resolved via interfaces through Cocona + Microsoft.Extensions.DI
- **Repository Pattern** — `IRepository` abstracts database access from business logic
- **Adapter Pattern** — `Dataset*Service` classes adapt the Bogus library API to the application's interface
- **Strategy Pattern** — `ParserDataset*Service` classes implement different generation strategies per dataset type
- **Singleton** — `FakerService` is registered as singleton so locale is consistent across all generators

---

**Previous:** [Lorem Dataset](lorem-dataset.md) | **Next:** [Execution Flow](architecture-flow.md)
