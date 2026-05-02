The `lorem` dataset provides a variety of commands for generating random text data. Below is a detailed explanation of all available properties and their parameters.

## Available Properties

### letter
Generates a random letter.

**Usage:**

```bash
bogus dataset lorem.letter
```

- **num** (optional): Specifies the number of letters to generate. Default is 1.

```bash
bogus dataset lorem.letter(num=10)
```

### lines
Generates random lines of text.

**Usage:**

```bash
bogus dataset lorem.lines
```

- **linecount** (optional): Number of lines to generate. Default is 3.
- **separator** (optional): Separator between lines. Default is a newline (`\n`).

```bash
bogus dataset lorem.lines(linecount=2,separator=|)
```

### paragraph
Generates a random paragraph.

**Usage:**

```bash
bogus dataset lorem.paragraph
```

- **min** (optional): Minimum number of sentences in the paragraph. Default is 3.

```bash
bogus dataset lorem.paragraph(min=2)
```

### paragraphs
Generates multiple paragraphs.

**Usage:**

```bash
bogus dataset lorem.paragraphs
```

- **count** (optional): Number of paragraphs to generate. Default is 3.
- **separator** (optional): Separator between paragraphs. Default is two newlines (`\n\n`).
- **min** (optional): Minimum number of sentences per paragraph.
- **max** (optional): Maximum number of sentences per paragraph.

```bash
bogus dataset lorem.paragraphs(count=2,separator=|)
bogus dataset lorem.paragraphs(min=2,max=4,separator=|)
```

### sentence
Generates a random sentence.

**Usage:**

```bash
bogus dataset lorem.sentence
```

- **wordcount** (optional): Number of words in the sentence.
- **range** (optional): Adds a random number of words within the range to the sentence length.

```bash
bogus dataset lorem.sentence(wordcount=4)
bogus dataset lorem.sentence(range=2)
```

### sentences
Generates multiple sentences.

**Usage:**

```bash
bogus dataset lorem.sentences
```

- **sentencecount** (optional): Number of sentences to generate.
- **separator** (optional): Separator between sentences. Default is a newline (`\n`).

```bash
bogus dataset lorem.sentences(sentencecount=2)
```

### slug
Generates a slug — a URL-friendly string.

**Usage:**

```bash
bogus dataset lorem.slug
```

- **wordcount** (optional): Number of words in the slug. Default is 3.

```bash
bogus dataset lorem.slug(wordcount=8)
```

### text
Generates random text.

**Usage:**

```bash
bogus dataset lorem.text
```

### word
Generates a single random word.

**Usage:**

```bash
bogus dataset lorem.word
```

### words
Generates multiple random words.

**Usage:**

```bash
bogus dataset lorem.words
```

- **num** (optional): Number of words to generate. Default is 3.
- **separator** (optional): Separator between words. Default is a space (` `).

```bash
bogus dataset lorem.words(num=8)
bogus dataset lorem.words(num=8,separator=;)
```

---

**Previous:** [Name Dataset](name-dataset.md) | **Next:** [Architecture](architecture.md)

