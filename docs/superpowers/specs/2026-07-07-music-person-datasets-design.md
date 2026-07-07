---
title: Music and Person Datasets Design
---

# Music and Person Datasets

## Context

Bogus.CLI wraps 16 of the 18 dataset categories exposed by the underlying `Bogus` .NET library (v35.6.1). The two missing ones are `music` and `person`. This adds both, following the existing per-dataset pattern exactly.

## Scope

### `music` dataset

Single property, mirrors the size of `rant`/`database`:

| Property | Bogus call | Notes |
|---|---|---|
| `genre` | `Faker.Music.Genre()` | |

### `person` dataset

Exposes the scalar fields of `Bogus.Person`. `Person.Address` (`CardAddress`) and `Person.Company` (`CardCompany`) are complex nested objects already covered by the existing `address` and `company` datasets, so they are excluded to avoid duplicating scope. `Person.Ssn()` is a US-locale-specific extension method (`Bogus.Extensions.UnitedStates`), not a core `Person` field, and is excluded to keep the dataset locale-agnostic.

| Property | Bogus call | Notes |
|---|---|---|
| `firstname` | `Faker.Person.FirstName` | |
| `lastname` | `Faker.Person.LastName` | |
| `fullname` | `Faker.Person.FullName` | |
| `gender` | `Faker.Person.Gender` | enum, converted via `.ToString()` |
| `username` | `Faker.Person.UserName` | |
| `avatar` | `Faker.Person.Avatar` | |
| `email` | `Faker.Person.Email` | |
| `phone` | `Faker.Person.Phone` | |
| `website` | `Faker.Person.Website` | |
| `dateofbirth` | `Faker.Person.DateOfBirth` | formatted `yyyy-MM-dd`, consistent with `DateFakerAdapter`'s date formatting convention |

## Implementation pattern

Each dataset gets the same 8 artifacts as every existing dataset (using `vehicle` as the reference implementation):

1. `src/Bogus.CLI.Core/Constants/Properties/{Music,Person}Property.cs` — lowercase, no-separator property name constants (e.g. `dateofbirth`, matching `NameProperty`'s `firstname`/`lastname` convention)
2. `src/Bogus.CLI.Core/Services/Interface/I{Music,Person}FakerAdapter.cs`
3. `src/Bogus.CLI.Core/Services/Adapters/{Music,Person}FakerAdapter.cs` — `[ExcludeFromCodeCoverage]`, wraps `IFakerService.GetFaker().{Music,Person}`
4. `src/Bogus.CLI.Core/Services/Interface/I{Music,Person}DatasetService.cs`
5. `src/Bogus.CLI.Core/Services/Datasets/{Music,Person}DatasetService.cs` — `Generate(property, parameters)` switch, same shape as `VehicleDatasetService`
6. `tests/Bogus.CLI.Tests/Services/Datasets/{Music,Person}DatasetServiceTests.cs` — one test per property (mocked adapter) + one "unknown property returns null" test, matching `VehicleDatasetServiceTests`
7. `docs/{music,person}-dataset.md` — same structure as `docs/vehicle-dataset.md`

## Wiring (shared touchpoints)

- `src/Bogus.CLI.Core/Constants/Datasets.cs` — add `MUSIC`/`PERSON` constants
- `src/Bogus.CLI.Core/Helpers/DatasetHelper.cs` — add dictionary entries listing each dataset's properties
- `src/Bogus.CLI.Core/Services/Datasets/DatasetService.cs` — add constructor params + dispatch switch cases
- `src/Bogus.CLI.App/Program.cs` — register `I{Music,Person}FakerAdapter` and `I{Music,Person}DatasetService` in DI
- `tests/Bogus.CLI.Tests/Services/Datasets/DatasetServiceTests.cs` — add mocks, constructor wiring, and `ExecuteCommand_*Dataset_ShouldBeOk` test cases (matching the existing `VehicleDataset` test cases)
- `docs/datasets.md` and `README.md` — add table rows for `music` and `person`
- Doc navigation chain — insert at the end: `name-dataset.md` (Next) → `music-dataset.md` → `person-dataset.md` → `architecture.md` (Previous), updating the `Previous`/`Next` links in `name-dataset.md` and `architecture.md` accordingly

## Testing

Unit tests only (matching existing coverage style): adapter classes are `[ExcludeFromCodeCoverage]` (thin wrappers over the `Bogus` library, consistent with all other adapters), dataset services get full unit coverage via mocked adapters.

## Out of scope

- No new CLI commands or flags — both datasets plug into the existing `bogus dataset` and `bogus list-datasets` commands automatically via the wiring above.
- No locale-specific extensions (e.g. `Ssn()`).
- No nested/complex object properties (`Person.Address`, `Person.Company`).
