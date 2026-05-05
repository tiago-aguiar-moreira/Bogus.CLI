---
title: Company Dataset
---

The `company` dataset provides a variety of commands for generating random company-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### bs
Generates a random company BS phrase (buzzword-heavy business speak).

**Usage:**

```bash
bogus dataset company.bs
```

### catchPhrase
Generates a random company catch phrase.

**Usage:**

```bash
bogus dataset company.catchPhrase
```

### companyName
Generates a random company name.

**Usage:**

```bash
bogus dataset company.companyName
```

- **format** (optional): Index of the name format pattern to use. When omitted, a random format is chosen.

```bash
bogus dataset company.companyName(format=0)
```

### companySuffix
Generates a random company suffix (e.g., LLC, Inc., Group).

**Usage:**

```bash
bogus dataset company.companySuffix
```

---

**Previous:** [Commerce Dataset](commerce-dataset.md) | **Next:** [Database Dataset](database-dataset.md)
