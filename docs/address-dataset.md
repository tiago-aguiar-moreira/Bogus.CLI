---
title: Address Dataset
---

The `address` dataset provides a variety of commands for generating random address-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### buildingNumber
Generates a random building number.

**Usage:**

```bash
bogus dataset address.buildingNumber
```

### cardinalDirection
Generates a random cardinal direction (e.g., North, South, East, West).

**Usage:**

```bash
bogus dataset address.cardinalDirection
```

- **useAbbreviation** (optional): Returns the abbreviated form (e.g., N, S). Default is `false`.

```bash
bogus dataset address.cardinalDirection(useAbbreviation=true)
```

### city
Generates a random city name.

**Usage:**

```bash
bogus dataset address.city
```

### cityPrefix
Generates a random city prefix (e.g., North, Port).

**Usage:**

```bash
bogus dataset address.cityPrefix
```

### citySuffix
Generates a random city suffix (e.g., ville, town).

**Usage:**

```bash
bogus dataset address.citySuffix
```

### country
Generates a random country name.

**Usage:**

```bash
bogus dataset address.country
```

### countryCode
Generates a random country code.

**Usage:**

```bash
bogus dataset address.countryCode
```

- **format** (optional): Format of the country code. Options: `alpha2` (e.g., US), `alpha3` (e.g., USA). Default is `alpha2`.

```bash
bogus dataset address.countryCode(format=alpha3)
```

### county
Generates a random county name.

**Usage:**

```bash
bogus dataset address.county
```

### direction
Generates a random direction (cardinal or ordinal).

**Usage:**

```bash
bogus dataset address.direction
```

- **useAbbreviation** (optional): Returns the abbreviated form. Default is `false`.

```bash
bogus dataset address.direction(useAbbreviation=true)
```

### fullAddress
Generates a random full address.

**Usage:**

```bash
bogus dataset address.fullAddress
```

### latitude
Generates a random latitude value.

**Usage:**

```bash
bogus dataset address.latitude
```

- **min** (optional): Minimum value. Default is `-90`.
- **max** (optional): Maximum value. Default is `90`.

```bash
bogus dataset address.latitude(min=-23.5,max=-23.0)
```

### longitude
Generates a random longitude value.

**Usage:**

```bash
bogus dataset address.longitude
```

- **min** (optional): Minimum value. Default is `-180`.
- **max** (optional): Maximum value. Default is `180`.

```bash
bogus dataset address.longitude(min=-46.7,max=-46.5)
```

### ordinalDirection
Generates a random ordinal direction (e.g., Northeast, Southwest).

**Usage:**

```bash
bogus dataset address.ordinalDirection
```

- **useAbbreviation** (optional): Returns the abbreviated form (e.g., NE, SW). Default is `false`.

```bash
bogus dataset address.ordinalDirection(useAbbreviation=true)
```

### secondaryAddress
Generates a random secondary address (e.g., Apt. 123, Suite 456).

**Usage:**

```bash
bogus dataset address.secondaryAddress
```

### state
Generates a random state name.

**Usage:**

```bash
bogus dataset address.state
```

### stateAbbr
Generates a random state abbreviation (e.g., CA, NY).

**Usage:**

```bash
bogus dataset address.stateAbbr
```

### streetAddress
Generates a random street address.

**Usage:**

```bash
bogus dataset address.streetAddress
```

- **useFullAddress** (optional): Includes a secondary address. Default is `false`.

```bash
bogus dataset address.streetAddress(useFullAddress=true)
```

### streetName
Generates a random street name.

**Usage:**

```bash
bogus dataset address.streetName
```

### streetSuffix
Generates a random street suffix (e.g., St., Ave., Blvd.).

**Usage:**

```bash
bogus dataset address.streetSuffix
```

### zipCode
Generates a random ZIP code.

**Usage:**

```bash
bogus dataset address.zipCode
```

- **format** (optional): Custom format string using `#` as digit placeholder.

```bash
bogus dataset address.zipCode(format=#####-###)
```

---

**Previous:** [Datasets](datasets.md) | **Next:** [Commerce Dataset](commerce-dataset.md)
