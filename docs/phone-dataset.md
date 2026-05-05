---
title: Phone Dataset
---

The `phone` dataset provides commands for generating random phone number data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### format
Generates a phone number using a specific format pattern from the locale's list.

**Usage:**

```bash
bogus dataset phone.format
```

- **formatIndex** (optional): Index of the format pattern to use. Default is `0`.

```bash
bogus dataset phone.format(formatIndex=2)
```

> **Tip:** Use the global `--locale` flag to generate phone numbers for a specific region:
> ```bash
> bogus dataset phone.format --locale pt_BR
> ```

### number
Generates a random phone number.

**Usage:**

```bash
bogus dataset phone.number
```

- **format** (optional): Custom format string using `#` as a digit placeholder and `X` for digits 1–9.

```bash
bogus dataset phone.number(format=###-###-####)
```

> **Tip:** Use the global `--locale` flag to generate phone numbers for a specific region:
> ```bash
> bogus dataset phone.number --locale pt_BR
> ```

---

**Previous:** [Internet Dataset](internet-dataset.md) | **Next:** [Random Dataset](random-dataset.md)
