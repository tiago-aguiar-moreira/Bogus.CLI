---
title: Database Dataset
---

The `database` dataset provides a variety of commands for generating random database-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### collation
Generates a random database collation (e.g., utf8_general_ci).

**Usage:**

```bash
bogus dataset database.collation
```

### column
Generates a random database column name (e.g., `created_at`, `user_id`).

**Usage:**

```bash
bogus dataset database.column
```

### engine
Generates a random database engine name (e.g., InnoDB, MyISAM).

**Usage:**

```bash
bogus dataset database.engine
```

### type
Generates a random database column type (e.g., varchar, int, blob).

**Usage:**

```bash
bogus dataset database.type
```

---

**Previous:** [Company Dataset](company-dataset.md) | **Next:** [Date Dataset](date-dataset.md)
