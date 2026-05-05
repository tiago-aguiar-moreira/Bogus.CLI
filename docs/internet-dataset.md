---
title: Internet Dataset
---

The `internet` dataset provides a variety of commands for generating random internet-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### avatar
Generates a random avatar image URL.

**Usage:**

```bash
bogus dataset internet.avatar
```

### color
Generates a random web color.

**Usage:**

```bash
bogus dataset internet.color
```

- **red** (optional): Red channel base value (0–255). Default is `0`.
- **green** (optional): Green channel base value (0–255). Default is `0`.
- **blue** (optional): Blue channel base value (0–255). Default is `0`.
- **grayscale** (optional): Returns a grayscale color. Default is `false`.
- **format** (optional): Output format. Options: `hex`, `rgb`. Default is `hex`.

```bash
bogus dataset internet.color(format=rgb)
bogus dataset internet.color(red=100,green=150,blue=200)
```

### domainName
Generates a random domain name (e.g., `example.com`).

**Usage:**

```bash
bogus dataset internet.domainName
```

### domainSuffix
Generates a random domain suffix (e.g., `.com`, `.net`).

**Usage:**

```bash
bogus dataset internet.domainSuffix
```

### domainWord
Generates a random domain word (e.g., `example`).

**Usage:**

```bash
bogus dataset internet.domainWord
```

### email
Generates a random email address.

**Usage:**

```bash
bogus dataset internet.email
```

- **firstName** (optional): First name to use in the email.
- **lastName** (optional): Last name to use in the email.
- **provider** (optional): Email provider domain (e.g., `gmail.com`).
- **uniqueSuffix** (optional): Suffix appended to make the email unique.

```bash
bogus dataset internet.email(provider=example.com)
bogus dataset internet.email(firstName=John,lastName=Doe)
```

### exampleEmail
Generates a random email address using example domains (e.g., `@example.com`).

**Usage:**

```bash
bogus dataset internet.exampleEmail
```

- **firstName** (optional): First name to use in the email.
- **lastName** (optional): Last name to use in the email.

```bash
bogus dataset internet.exampleEmail(firstName=Jane)
```

### ip
Generates a random IPv4 address string.

**Usage:**

```bash
bogus dataset internet.ip
```

### ipAddress
Generates a random IPv4 address.

**Usage:**

```bash
bogus dataset internet.ipAddress
```

### ipEndPoint
Generates a random IPv4 endpoint (IP + port).

**Usage:**

```bash
bogus dataset internet.ipEndPoint
```

### ipv6
Generates a random IPv6 address string.

**Usage:**

```bash
bogus dataset internet.ipv6
```

### ipv6Address
Generates a random IPv6 address.

**Usage:**

```bash
bogus dataset internet.ipv6Address
```

### ipv6EndPoint
Generates a random IPv6 endpoint (IP + port).

**Usage:**

```bash
bogus dataset internet.ipv6EndPoint
```

### mac
Generates a random MAC address.

**Usage:**

```bash
bogus dataset internet.mac
```

- **separator** (optional): Separator between octets. Default is `:`.

```bash
bogus dataset internet.mac(separator=-)
```

### password
Generates a random password.

**Usage:**

```bash
bogus dataset internet.password
```

- **length** (optional): Password length. Default is `10`.
- **memorable** (optional): Generates a more memorable password. Default is `false`.
- **regex** (optional): Regular expression the password must match.
- **prefix** (optional): Prefix to prepend to the password.

```bash
bogus dataset internet.password(length=16)
bogus dataset internet.password(length=12,memorable=true)
```

### port
Generates a random port number.

**Usage:**

```bash
bogus dataset internet.port
```

### protocol
Generates a random protocol (e.g., `http`, `https`).

**Usage:**

```bash
bogus dataset internet.protocol
```

### url
Generates a random URL.

**Usage:**

```bash
bogus dataset internet.url
```

### urlRootedPath
Generates a random rooted URL path (e.g., `/path/to/resource.html`).

**Usage:**

```bash
bogus dataset internet.urlRootedPath
```

- **fileExt** (optional): File extension for the path (e.g., `html`, `json`).

```bash
bogus dataset internet.urlRootedPath(fileExt=json)
```

### urlWithPath
Generates a random URL with a path.

**Usage:**

```bash
bogus dataset internet.urlWithPath
```

- **protocol** (optional): Protocol to use (e.g., `https`).
- **domain** (optional): Domain to use (e.g., `example.com`).
- **fileExt** (optional): File extension for the path.

```bash
bogus dataset internet.urlWithPath(protocol=https,domain=example.com,fileExt=html)
```

### userAgent
Generates a random browser user agent string.

**Usage:**

```bash
bogus dataset internet.userAgent
```

### userName
Generates a random username.

**Usage:**

```bash
bogus dataset internet.userName
```

- **firstName** (optional): First name to base the username on.
- **lastName** (optional): Last name to base the username on.

```bash
bogus dataset internet.userName(firstName=John,lastName=Doe)
```

### userNameUnicode
Generates a random username that may include unicode characters.

**Usage:**

```bash
bogus dataset internet.userNameUnicode
```

- **firstName** (optional): First name to base the username on.
- **lastName** (optional): Last name to base the username on.

```bash
bogus dataset internet.userNameUnicode(firstName=João)
```

---

**Previous:** [Images Dataset](images-dataset.md) | **Next:** [Phone Dataset](phone-dataset.md)
