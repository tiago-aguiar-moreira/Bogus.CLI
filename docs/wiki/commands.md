Here’s a quick overview of the main commands you can use with Bogus.CLI:

## list-locales

Lists all available locales supported by Bogus.

**Usage:**

```bash
bogus list-locales
```

## list-datasets

Lists all available datasets that can be used to generate fake data.

**Usage:**

```bash
bogus list-datasets
```

You can also specify a dataset name to list all properties available within that dataset:

```bash
bogus list-datasets <datasetName>
```

For example, to list all properties of the `person` dataset:

```bash
bogus list-datasets person
```

## dataset

The most powerful and flexible command, allowing you to generate various types of fake data. You can specify datasets and properties, and even customize data generation with parameters.

```bash
bogus dataset <category>.<property>(param1=value1, param2=value2)
```

Examples:

- Generate random names:

```bash
bogus dataset person.fullname
```

- Generate emails with a custom domain:

```bash
bogus dataset internet.email(domain="example.com")
```

- Generate past dates within the last year:

```bash
bogus dataset date.past(years=1)
```

For a detailed explanation of all dataset options and their parameters, visit the [Name Dataset](name-dataset.md) page.

---

Explore each command in depth by clicking the links above, and start generating realistic data quickly and efficiently!

---

**Previous:** [Quick Start](QuickStart.md) | **Next:** [Name Dataset](name-dataset.md)