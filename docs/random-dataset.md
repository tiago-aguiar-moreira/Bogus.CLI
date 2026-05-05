---
title: Random Dataset
---

The `random` dataset provides a variety of commands for generating random primitive values, strings, and identifiers. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### alphanumeric
Generates a random alphanumeric string.

**Usage:**

```bash
bogus dataset random.alphanumeric
```

- **length** (optional): Length of the string. Default is `10`.

```bash
bogus dataset random.alphanumeric(length=20)
```

### bool
Generates a random boolean value.

**Usage:**

```bash
bogus dataset random.bool
```

- **weight** (optional): Probability of returning `true` (0.0–1.0). Default is `0.5`.

```bash
bogus dataset random.bool(weight=0.8)
```

### char
Generates a random character.

**Usage:**

```bash
bogus dataset random.char
```

- **min** (optional): Minimum character. Default is the minimum `char` value.
- **max** (optional): Maximum character. Default is the maximum `char` value.

```bash
bogus dataset random.char(min=a,max=z)
```

### decimal
Generates a random decimal number.

**Usage:**

```bash
bogus dataset random.decimal
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.decimal(min=0,max=100)
```

### double
Generates a random double-precision number.

**Usage:**

```bash
bogus dataset random.double
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.double(min=0,max=100)
```

### even
Generates a random even integer.

**Usage:**

```bash
bogus dataset random.even
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.even(min=0,max=100)
```

### float
Generates a random single-precision floating-point number.

**Usage:**

```bash
bogus dataset random.float
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.float(min=0,max=10)
```

### guid
Generates a random GUID.

**Usage:**

```bash
bogus dataset random.guid
```

### hash
Generates a random hash string.

**Usage:**

```bash
bogus dataset random.hash
```

- **length** (optional): Length of the hash. Default is `40`.
- **uppercase** (optional): Returns the hash in uppercase. Default is `false`.

```bash
bogus dataset random.hash(length=64,uppercase=true)
```

### hexadecimal
Generates a random hexadecimal string.

**Usage:**

```bash
bogus dataset random.hexadecimal
```

- **length** (optional): Number of hex digits. Default is `1`.
- **prefix** (optional): Prefix to prepend. Default is `0x`.

```bash
bogus dataset random.hexadecimal(length=6,prefix=#)
```

### int
Generates a random integer.

**Usage:**

```bash
bogus dataset random.int
```

- **min** (optional): Minimum value. Default is `int.MinValue`.
- **max** (optional): Maximum value. Default is `int.MaxValue`.

```bash
bogus dataset random.int(min=1,max=100)
```

### long
Generates a random long integer.

**Usage:**

```bash
bogus dataset random.long
```

- **min** (optional): Minimum value. Default is `long.MinValue`.
- **max** (optional): Maximum value. Default is `long.MaxValue`.

```bash
bogus dataset random.long(min=1,max=1000000000)
```

### number
Generates a random integer in a given range.

**Usage:**

```bash
bogus dataset random.number
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.number(min=1,max=100)
```

### odd
Generates a random odd integer.

**Usage:**

```bash
bogus dataset random.odd
```

- **min** (optional): Minimum value. Default is `0`.
- **max** (optional): Maximum value. Default is `1`.

```bash
bogus dataset random.odd(min=1,max=99)
```

### randomLocale
Generates a random locale code (e.g., `en`, `pt_BR`).

**Usage:**

```bash
bogus dataset random.randomLocale
```

### replace
Generates a string by replacing `?` with random letters and `#` with random digits.

**Usage:**

```bash
bogus dataset random.replace
```

- **format** (optional): Format string. Default is `???`.

```bash
bogus dataset random.replace(format=??-##)
```

### replaceNumbers
Generates a string by replacing a symbol with random digits.

**Usage:**

```bash
bogus dataset random.replaceNumbers
```

- **format** (optional): Format string. Default is `###`.
- **symbol** (optional): Symbol to replace with digits. Default is `#`.

```bash
bogus dataset random.replaceNumbers(format=####-####,symbol=#)
```

### word
Generates a single random word.

**Usage:**

```bash
bogus dataset random.word
```

### words
Generates multiple random words.

**Usage:**

```bash
bogus dataset random.words
```

- **count** (optional): Number of words to generate. Default is `1`.

```bash
bogus dataset random.words(count=5)
```

---

**Previous:** [Phone Dataset](phone-dataset.md) | **Next:** [Rant Dataset](rant-dataset.md)
