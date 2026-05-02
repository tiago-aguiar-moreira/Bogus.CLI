## Overview

This page describes the execution flow for each command, tracing the path from the terminal input down to the final output.

---

## `dataset` command

Generates fake data and prints it to the console.

**Example:**
```bash
bogus dataset name.fullname lorem.word --count 5 --locale pt_BR
```

**Flow:**

```
1. DatasetCommand.GetCommand()          [App]
   - Receives datasets, count, locale, template options
   - Calls IDatasetService.ExecuteCommand()

2. DatasetService.ExecuteCommand()      [Core]
   - Validates each dataset string via DatasetHelper
   - Sets locale on FakerService (singleton)
   - For each record (up to --count):
       For each dataset argument:
         → Parses "name.fullname" → dataset="name", property="fullname"
         → Delegates to the matching parser service:
             "lorem.*" → ParserDatasetLoremService
             "name.*"  → ParserDatasetNameService
             "phone.*" → ParserDatasetPhoneService
   - Invokes onGenerateFakedata callback with generated values

3. ParserDatasetNameService.Generate()  [Core]
   - Extracts parameters (e.g. gender=male)
   - Calls DatasetNameService.FullName(...)

4. DatasetNameService.FullName()        [Core]
   - Gets locale-aware Faker via FakerService.GetFaker()
   - Calls faker.Name.FullName()
   - Returns generated value (e.g. "Maria Silva")

5. Back in DatasetCommand
   - If --template is set: applies it via TemplateService
   - Prints result to console
```

---

## `seed-database` command

Reads a YAML configuration file, generates fake data, and inserts it into a SQL Server database in batches.

**Example:**
```bash
bogus seed-database config.yaml
```

**Example YAML:**
```yaml
locale: pt_BR
database:
  host: localhost
  port: 1433
  user: sa
  password: secret
tables:
  - tableName: Users
    recordsCount: 1000
    batchSize: 100
    fields:
      - fieldName: FirstName
        dataset: name.firstName(gender=male)
      - fieldName: LastName
        dataset: name.lastName
```

**Flow:**

```
1. SeedDatabaseCommand.GetCommand()         [App]
   - Reads and deserializes the YAML file into SeedFileModel
   - Calls ISeedDatabaseService.ExecuteCommand()
   - Renders progress output on each batch via callback

2. SeedDatabaseService.ExecuteCommand()     [Core]
   For each table:
     For each batch (recordsCount / batchSize):
       - Calls DatasetService to generate a batch of records
       - Calls IRepository.InsertBatch() with the generated records
       - Invokes onInsert callback with progress info

3. DatasetService.ExecuteCommand()          [Core]
   - Same generation logic as the dataset command
   - Returns a list of records (each record is a dict of field → value)

4. SqlServerRepository.InsertBatch()        [Infrastructure]
   - Opens a SqlConnection
   - Starts a transaction
   - For each record:
       Builds: INSERT INTO Users (FirstName, LastName) VALUES (@p0, @p1)
       Adds parameterized values
       Executes ExecuteNonQuery()
   - Commits the transaction

5. Back in SeedDatabaseCommand
   - Prints progress to console:
     [2026-05-01 14:30:45] Table: Users | Records: 100/1000 (10%)
     Overall: 100/1000 (10%) | Tables: 1/2 (50%)
```

---

**Previous:** [Architecture](architecture.md)
