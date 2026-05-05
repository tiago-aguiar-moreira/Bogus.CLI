---
title: Images Dataset
---

The `images` dataset provides a variety of commands for generating random image URLs and data URIs. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### dataUri
Generates a random image as a base64-encoded data URI.

**Usage:**

```bash
bogus dataset images.dataUri
```

- **width** (optional): Image width in pixels. Default is `200`.
- **height** (optional): Image height in pixels. Default is `200`.
- **color** (optional): Background color. Default is `grey`.

```bash
bogus dataset images.dataUri(width=400,height=300,color=blue)
```

### loremFlickrUrl
Generates a random image URL from [LoremFlickr](https://loremflickr.com).

**Usage:**

```bash
bogus dataset images.loremFlickrUrl
```

- **width** (optional): Image width in pixels. Default is `320`.
- **height** (optional): Image height in pixels. Default is `240`.
- **keywords** (optional): Comma-separated keywords to filter images.
- **grayscale** (optional): Returns a grayscale image. Default is `false`.

```bash
bogus dataset images.loremFlickrUrl(width=640,height=480,keywords=nature,grayscale=true)
```

### picsumUrl
Generates a random image URL from [Picsum](https://picsum.photos).

**Usage:**

```bash
bogus dataset images.picsumUrl
```

- **width** (optional): Image width in pixels. Default is `640`.
- **height** (optional): Image height in pixels. Default is `480`.
- **grayscale** (optional): Returns a grayscale image. Default is `false`.
- **blur** (optional): Returns a blurred image. Default is `false`.

```bash
bogus dataset images.picsumUrl(width=800,height=600,grayscale=true)
```

### placeholderUrl
Generates a placeholder image URL from [Placeholder.com](https://placeholder.com).

**Usage:**

```bash
bogus dataset images.placeholderUrl
```

- **width** (optional): Image width in pixels. Default is `200`.
- **height** (optional): Image height in pixels. Default is `200`.
- **text** (optional): Text to display on the image.
- **format** (optional): Image format. Options: `png`, `jpg`, `gif`. Default is `png`.
- **backcolor** (optional): Background color as hex (without `#`). Default is `cccccc`.
- **textcolor** (optional): Text color as hex (without `#`). Default is `9c9c9c`.

```bash
bogus dataset images.placeholderUrl(width=300,height=200,text=Hello,backcolor=000000,textcolor=ffffff)
```

### placeImgUrl
Generates a random image URL from [PlaceImg](https://placeimg.com).

**Usage:**

```bash
bogus dataset images.placeImgUrl
```

- **width** (optional): Image width in pixels. Default is `640`.
- **height** (optional): Image height in pixels. Default is `480`.
- **category** (optional): Image category (e.g., `animals`, `nature`, `tech`). Default is `Any`.

```bash
bogus dataset images.placeImgUrl(width=800,height=600,category=animals)
```

---

**Previous:** [Hacker Dataset](hacker-dataset.md) | **Next:** [Internet Dataset](internet-dataset.md)
