---
title: Rant Dataset
---

The `rant` dataset provides commands for generating random user review-style text — opinionated, informal, and realistic. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### review
Generates a single random product review.

**Usage:**

```bash
bogus dataset rant.review
```

- **product** (optional): Product name to mention in the review.

```bash
bogus dataset rant.review(product=laptop)
```

### reviews
Generates multiple random product reviews joined as a single string.

**Usage:**

```bash
bogus dataset rant.reviews
```

- **product** (optional): Product name to mention in the reviews.
- **lines** (optional): Number of reviews to generate. Default is `1`.
- **separator** (optional): Separator between reviews. Default is `, `.

```bash
bogus dataset rant.reviews(product=headphones,lines=3,separator=|)
```

---

**Previous:** [Random Dataset](random-dataset.md) | **Next:** [System Dataset](system-dataset.md)
