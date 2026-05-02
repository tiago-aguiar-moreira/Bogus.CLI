## Getting Started

After installing Bogus.CLI, you can start generating fake data instantly. Let’s walk through some basic commands to get you up and running quickly.

## Basic Usage

To generate simple fake data, use the following pattern:

```bash
bogus <command> [arguments] [options]
```

The main components are:

- **command**: The action you want to perform.
- **arguments**: The type of data you want to generate.
- **options**: Additional settings to customize the output.

## Example: Generating Fake Names

Let’s generate 10 random full names:

```bash
bogus dataset name.fullname --count 10
```

This command uses:

- `dataset`: The main command for generating data.
- `name.fullname`: An argument specifying the type of data (in this case, full names).
- `--count 10`: An option indicating the number of records to generate.

## Combining Multiple Datasets

You can generate multiple types of data at once. For example, generating full names and emails together:

```bash
bogus dataset name.fullname name.firstname --count 5
```

This will output 5 records, each containing both a full name and an email.

## Viewing Available Commands

To see all available commands, run:

```bash
bogus --help
```

Explore more advanced options and customization in the upcoming sections of the documentation!

---

**Previous:** [Installation](Installation.md) | **Next:** [Commands](commands.md)