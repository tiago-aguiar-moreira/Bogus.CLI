---
title: Finance Dataset
---

The `finance` dataset provides a variety of commands for generating random finance-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### account
Generates a random bank account number.

**Usage:**

```bash
bogus dataset finance.account
```

- **length** (optional): Number of digits. Default is `8`.

```bash
bogus dataset finance.account(length=12)
```

### accountName
Generates a random bank account name (e.g., Savings Account, Checking Account).

**Usage:**

```bash
bogus dataset finance.accountName
```

### amount
Generates a random monetary amount.

**Usage:**

```bash
bogus dataset finance.amount
```

- **min** (optional): Minimum amount. Default is `0`.
- **max** (optional): Maximum amount. Default is `1000`.
- **decimals** (optional): Number of decimal places. Default is `2`.

```bash
bogus dataset finance.amount(min=100,max=9999,decimals=2)
```

### bic
Generates a random BIC/SWIFT code.

**Usage:**

```bash
bogus dataset finance.bic
```

### bitcoinAddress
Generates a random Bitcoin address.

**Usage:**

```bash
bogus dataset finance.bitcoinAddress
```

### creditCardCvv
Generates a random credit card CVV.

**Usage:**

```bash
bogus dataset finance.creditCardCvv
```

### creditCardNumber
Generates a random credit card number.

**Usage:**

```bash
bogus dataset finance.creditCardNumber
```

- **cardType** (optional): Card type. Options: `Visa`, `Mastercard`, `AmericanExpress`, `Discover`, `all`. Default is `all`.

```bash
bogus dataset finance.creditCardNumber(cardType=Visa)
```

### currency
Generates a random currency name or code.

**Usage:**

```bash
bogus dataset finance.currency
```

- **returnCode** (optional): Returns the currency code (e.g., USD) instead of the name. Default is `false`.

```bash
bogus dataset finance.currency(returnCode=true)
```

### ethereumAddress
Generates a random Ethereum address.

**Usage:**

```bash
bogus dataset finance.ethereumAddress
```

### iban
Generates a random IBAN.

**Usage:**

```bash
bogus dataset finance.iban
```

- **formatted** (optional): Returns the IBAN with spaces. Default is `false`.
- **countryCode** (optional): Two-letter country code (e.g., `DE`, `GB`). When omitted, a random country is used.

```bash
bogus dataset finance.iban(formatted=true)
bogus dataset finance.iban(formatted=true,countryCode=DE)
```

### routingNumber
Generates a random bank routing number.

**Usage:**

```bash
bogus dataset finance.routingNumber
```

### transactionType
Generates a random transaction type (e.g., payment, invoice, deposit).

**Usage:**

```bash
bogus dataset finance.transactionType
```

---

**Previous:** [Date Dataset](date-dataset.md) | **Next:** [Hacker Dataset](hacker-dataset.md)
