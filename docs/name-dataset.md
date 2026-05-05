---
title: Name Dataset
---

The `name` dataset provides a variety of commands for generating random names, job titles, and related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### findName
Generates a random full name, with options for customization.

**Usage:**

```bash
bogus dataset name.findName
```

- **gender** (optional): Specifies the gender for the name. Options: `male`, `female`.
- **firstName** (optional): Specifies the first name.
- **lastName** (optional): Specifies the last name.
- **withPrefix** (optional): Includes a prefix (e.g., Mr., Ms.). Options: `true`, `false`.
- **withSuffix** (optional): Includes a suffix (e.g., Jr., Sr.). Options: `true`, `false`.

```bash
bogus dataset name.findName(gender=male)
```

```bash
bogus dataset name.findName(firstName=Claudia)
```

```bash
bogus dataset name.findName(withPrefix=false,withSuffix=false)
```

### fullName
Generates a random full name.

**Usage:**

```bash
bogus dataset name.fullName
```

- **gender** (optional): Specifies the gender for the full name. Options: `male`, `female`.

```bash
bogus dataset name.fullName(gender=female)
```

> **Tip:** Use the global `--locale` flag to change the language of generated names:
> ```bash
> bogus dataset name.fullName --locale pt_BR
> ```

### firstName
Generates a random first name.

**Usage:**

```bash
bogus dataset name.firstName
```

- **gender** (optional): Specifies the gender for the first name. Options: `male`, `female`.

```bash
bogus dataset name.firstName(gender=male)
```

### jobArea
Generates a random job area.

**Usage:**

```bash
bogus dataset name.jobArea
```

### jobDescriptor
Generates a random job descriptor.

**Usage:**

```bash
bogus dataset name.jobDescriptor
```

### jobTitle
Generates a random job title.

**Usage:**

```bash
bogus dataset name.jobTitle
```

### jobType
Generates a random job type.

**Usage:**

```bash
bogus dataset name.jobType
```

> **Tip:** Use the global `--locale` flag to change the language:
> ```bash
> bogus dataset name.jobType --locale pt_BR
> ```

### lastName
Generates a random last name.

**Usage:**

```bash
bogus dataset name.lastName
```

- **gender** (optional): Specifies the gender for the last name. Options: `male`, `female`.

```bash
bogus dataset name.lastName(gender=female)
```

### prefix
Generates a random name prefix.

**Usage:**

```bash
bogus dataset name.prefix
```

- **gender** (optional): Specifies the gender for the prefix. Options: `male`, `female`.

```bash
bogus dataset name.prefix(gender=male)
```

### suffix
Generates a random name suffix.

**Usage:**

```bash
bogus dataset name.suffix
```

---

**Previous:** [Lorem Dataset](lorem-dataset.md) | **Next:** [Architecture](architecture.md)