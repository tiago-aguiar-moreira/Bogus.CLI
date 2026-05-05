---
title: Date Dataset
---

The `date` dataset provides a variety of commands for generating random date and time data. Below is a detailed explanation of all available properties and their parameters.

Dates are returned in the format `yyyy-MM-dd HH:mm:ss`. Offset variants are returned in the format `yyyy-MM-ddTHH:mm:sszzz`.

## Available Properties

### between
Generates a random date between two given dates.

**Usage:**

```bash
bogus dataset date.between
```

- **start** (optional): Start date in a parseable format. Default is 1 year ago.
- **end** (optional): End date in a parseable format. Default is today.

```bash
bogus dataset date.between(start=2024-01-01,end=2024-12-31)
```

### betweenOffset
Generates a random `DateTimeOffset` between two given dates.

**Usage:**

```bash
bogus dataset date.betweenOffset
```

- **start** (optional): Start date in ISO 8601 format. Default is 1 year ago.
- **end** (optional): End date in ISO 8601 format. Default is today.

```bash
bogus dataset date.betweenOffset(start=2024-01-01T00:00:00+00:00,end=2024-12-31T23:59:59+00:00)
```

### future
Generates a random date in the future.

**Usage:**

```bash
bogus dataset date.future
```

- **years** (optional): Number of years into the future. Default is `1`.

```bash
bogus dataset date.future(years=2)
```

### futureOffset
Generates a random `DateTimeOffset` in the future.

**Usage:**

```bash
bogus dataset date.futureOffset
```

- **years** (optional): Number of years into the future. Default is `1`.

```bash
bogus dataset date.futureOffset(years=2)
```

### month
Generates a random month name.

**Usage:**

```bash
bogus dataset date.month
```

- **abbreviate** (optional): Returns the abbreviated month name (e.g., Jan, Feb). Default is `false`.

```bash
bogus dataset date.month(abbreviate=true)
```

### past
Generates a random date in the past.

**Usage:**

```bash
bogus dataset date.past
```

- **years** (optional): Number of years into the past. Default is `1`.

```bash
bogus dataset date.past(years=5)
```

### pastOffset
Generates a random `DateTimeOffset` in the past.

**Usage:**

```bash
bogus dataset date.pastOffset
```

- **years** (optional): Number of years into the past. Default is `1`.

```bash
bogus dataset date.pastOffset(years=5)
```

### recent
Generates a random date within the recent past.

**Usage:**

```bash
bogus dataset date.recent
```

- **days** (optional): Number of days into the past. Default is `1`.

```bash
bogus dataset date.recent(days=7)
```

### recentOffset
Generates a random `DateTimeOffset` within the recent past.

**Usage:**

```bash
bogus dataset date.recentOffset
```

- **days** (optional): Number of days into the past. Default is `1`.

```bash
bogus dataset date.recentOffset(days=7)
```

### soon
Generates a random date in the near future.

**Usage:**

```bash
bogus dataset date.soon
```

- **days** (optional): Number of days into the future. Default is `1`.

```bash
bogus dataset date.soon(days=7)
```

### soonOffset
Generates a random `DateTimeOffset` in the near future.

**Usage:**

```bash
bogus dataset date.soonOffset
```

- **days** (optional): Number of days into the future. Default is `1`.

```bash
bogus dataset date.soonOffset(days=7)
```

### timespan
Generates a random `TimeSpan`.

**Usage:**

```bash
bogus dataset date.timespan
```

### timezoneString
Generates a random timezone string (e.g., `America/New_York`).

**Usage:**

```bash
bogus dataset date.timezoneString
```

### weekday
Generates a random weekday name.

**Usage:**

```bash
bogus dataset date.weekday
```

- **abbreviate** (optional): Returns the abbreviated weekday name (e.g., Mon, Tue). Default is `false`.

```bash
bogus dataset date.weekday(abbreviate=true)
```

---

**Previous:** [Database Dataset](database-dataset.md) | **Next:** [Finance Dataset](finance-dataset.md)
