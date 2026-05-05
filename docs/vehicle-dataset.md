---
title: Vehicle Dataset
---

The `vehicle` dataset provides a variety of commands for generating random vehicle-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### fuel
Generates a random fuel type (e.g., Gasoline, Diesel, Electric).

**Usage:**

```bash
bogus dataset vehicle.fuel
```

### manufacturer
Generates a random vehicle manufacturer (e.g., Toyota, Ford).

**Usage:**

```bash
bogus dataset vehicle.manufacturer
```

### model
Generates a random vehicle model (e.g., Mustang, Civic).

**Usage:**

```bash
bogus dataset vehicle.model
```

### type
Generates a random vehicle type (e.g., SUV, Sedan, Truck).

**Usage:**

```bash
bogus dataset vehicle.type
```

### vin
Generates a random Vehicle Identification Number (VIN).

**Usage:**

```bash
bogus dataset vehicle.vin
```

- **strict** (optional): Generates a VIN that passes checksum validation. Default is `false`.

```bash
bogus dataset vehicle.vin(strict=true)
```

---

**Previous:** [System Dataset](system-dataset.md) | **Next:** [Lorem Dataset](lorem-dataset.md)
