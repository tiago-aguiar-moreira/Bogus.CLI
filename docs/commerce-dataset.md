---
title: Commerce Dataset
---

The `commerce` dataset provides a variety of commands for generating random commerce-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### categories
Generates a list of random product categories joined as a single string.

**Usage:**

```bash
bogus dataset commerce.categories
```

- **num** (optional): Number of categories to generate. Default is `1`.
- **separator** (optional): Separator between categories. Default is `, `.

```bash
bogus dataset commerce.categories(num=3)
bogus dataset commerce.categories(num=3,separator=|)
```

### color
Generates a random color name.

**Usage:**

```bash
bogus dataset commerce.color
```

### department
Generates a random department name.

**Usage:**

```bash
bogus dataset commerce.department
```

- **max** (optional): Maximum number of departments to combine. Default is `1`.
- **returnMax** (optional): Always returns the maximum number of departments. Default is `false`.

```bash
bogus dataset commerce.department(max=3)
bogus dataset commerce.department(max=3,returnMax=true)
```

### ean8
Generates a random EAN-8 barcode number.

**Usage:**

```bash
bogus dataset commerce.ean8
```

### ean13
Generates a random EAN-13 barcode number.

**Usage:**

```bash
bogus dataset commerce.ean13
```

### price
Generates a random price.

**Usage:**

```bash
bogus dataset commerce.price
```

- **min** (optional): Minimum price. Default is `1`.
- **max** (optional): Maximum price. Default is `1000`.
- **decimals** (optional): Number of decimal places. Default is `2`.
- **symbol** (optional): Currency symbol prefix (e.g., `$`). Default is empty.

```bash
bogus dataset commerce.price(min=10,max=500)
bogus dataset commerce.price(min=10,max=500,decimals=2,symbol=$)
```

### product
Generates a random product name.

**Usage:**

```bash
bogus dataset commerce.product
```

### productAdjective
Generates a random product adjective (e.g., Handcrafted, Refined).

**Usage:**

```bash
bogus dataset commerce.productAdjective
```

### productDescription
Generates a random product description.

**Usage:**

```bash
bogus dataset commerce.productDescription
```

### productMaterial
Generates a random product material (e.g., Steel, Cotton).

**Usage:**

```bash
bogus dataset commerce.productMaterial
```

### productName
Generates a random full product name.

**Usage:**

```bash
bogus dataset commerce.productName
```

---

**Previous:** [Address Dataset](address-dataset.md) | **Next:** [Company Dataset](company-dataset.md)
