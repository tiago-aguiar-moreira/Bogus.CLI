---
title: System Dataset
---

The `system` dataset provides a variety of commands for generating random system and file-related data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### androidId
Generates a random Android device ID.

**Usage:**

```bash
bogus dataset system.androidId
```

### applePushToken
Generates a random Apple Push Notification token.

**Usage:**

```bash
bogus dataset system.applePushToken
```

### blackBerryPin
Generates a random BlackBerry PIN.

**Usage:**

```bash
bogus dataset system.blackBerryPin
```

### commonFileExt
Generates a random common file extension (e.g., `pdf`, `jpg`).

**Usage:**

```bash
bogus dataset system.commonFileExt
```

### commonFileName
Generates a random common file name with a common extension.

**Usage:**

```bash
bogus dataset system.commonFileName
```

- **ext** (optional): Forces a specific file extension.

```bash
bogus dataset system.commonFileName(ext=pdf)
```

### commonFileType
Generates a random common file type (e.g., `image`, `video`).

**Usage:**

```bash
bogus dataset system.commonFileType
```

### directoryPath
Generates a random directory path.

**Usage:**

```bash
bogus dataset system.directoryPath
```

### exception
Generates a random exception message.

**Usage:**

```bash
bogus dataset system.exception
```

### fileExt
Generates a random file extension.

**Usage:**

```bash
bogus dataset system.fileExt
```

- **mimetype** (optional): MIME type to derive the extension from (e.g., `image/png`).

```bash
bogus dataset system.fileExt(mimetype=image/png)
```

### fileName
Generates a random file name with extension.

**Usage:**

```bash
bogus dataset system.fileName
```

- **ext** (optional): Forces a specific file extension.

```bash
bogus dataset system.fileName(ext=csv)
```

### filePath
Generates a random full file path.

**Usage:**

```bash
bogus dataset system.filePath
```

### fileType
Generates a random file type (e.g., `application`, `image`).

**Usage:**

```bash
bogus dataset system.fileType
```

### mimeType
Generates a random MIME type (e.g., `application/json`).

**Usage:**

```bash
bogus dataset system.mimeType
```

### semver
Generates a random semantic version string (e.g., `3.1.4`).

**Usage:**

```bash
bogus dataset system.semver
```

### version
Generates a random version string (e.g., `2.4.1.0`).

**Usage:**

```bash
bogus dataset system.version
```

---

**Previous:** [Rant Dataset](rant-dataset.md) | **Next:** [Vehicle Dataset](vehicle-dataset.md)
