---
title: Datasets
---

Datasets are the core of Bogus.CLI. Each dataset groups a set of properties that generate fake data for a specific domain. You can combine multiple datasets in a single command to generate rich, structured data.

To see all available datasets directly in the terminal:

```bash
bogus list-datasets
```

To list the properties of a specific dataset:

```bash
bogus list-datasets <datasetName>
```

## Available Datasets

| Dataset | Description |
|---|---|
| [address](address-dataset.md) | Street addresses, cities, countries, coordinates, and more |
| [commerce](commerce-dataset.md) | Products, prices, categories, and barcodes |
| [company](company-dataset.md) | Company names, suffixes, catch phrases, and BS |
| [database](database-dataset.md) | Column names, data types, collations, and engines |
| [date](date-dataset.md) | Past, future, recent, and between dates and timespans |
| [finance](finance-dataset.md) | Accounts, amounts, credit cards, IBAN, BTC, and more |
| [hacker](hacker-dataset.md) | Tech jargon, abbreviations, verbs, and phrases |
| [images](images-dataset.md) | Image URLs and data URIs from various providers |
| [internet](internet-dataset.md) | Emails, URLs, IPs, usernames, passwords, and more |
| [lorem](lorem-dataset.md) | Words, sentences, paragraphs, and placeholder text |
| [name](name-dataset.md) | First names, last names, full names, and job titles |
| [phone](phone-dataset.md) | Phone numbers and format patterns |
| [random](random-dataset.md) | Primitive values, GUIDs, hashes, and random strings |
| [rant](rant-dataset.md) | Opinionated product reviews |
| [system](system-dataset.md) | File names, paths, MIME types, versions, and device IDs |
| [vehicle](vehicle-dataset.md) | VINs, manufacturers, models, types, and fuel types |

---

**Previous:** [Commands](commands.md) | **Next:** [Address Dataset](address-dataset.md)
