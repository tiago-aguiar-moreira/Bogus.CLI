[![NuGet Package: BogusCLI](https://img.shields.io/nuget/vpre/BogusCLI?label=NuGet%3A%20BogusCLI)](https://www.nuget.org/packages/BogusCLI) [![Downloads](https://img.shields.io/nuget/dt/BogusCLI.svg)](https://www.nuget.org/packages/BogusCLI/) [![Coverage Status](https://coveralls.io/repos/github/tiago-aguiar-moreira/Bogus.CLI/badge.svg)](https://coveralls.io/github/tiago-aguiar-moreira/Bogus.CLI)

# Bogus CLI

Hello, I'm Tiago Aguiar! I am a C#/.NET developer with over 13 years of experience. I am currently working on Bogus.CLI, a command-line tool based on the amazing NuGet package Bogus, created by Brian Chavez. My goal is to bring all the power of Bogus to the command line, making it even easier to generate fake data for various contexts.

Generating data manually can be challenging, especially when trying to make it realistic or avoiding repetitions. Often, manually created data doesn’t make sense in a real-world context, or it becomes time-consuming. When a large volume of data is needed, doing it manually becomes unfeasible. Bogus.CLI solves these issues by automatically generating fake data quickly and realistically, helping developers test their applications efficiently, without wasting time on manual input or relying on external sources.

With Bogus.CLI, you can generate data with ease, flexibility, and efficiency directly from your terminal! If this tool helps you be more productive, please leave a star ⭐ on the repository and share it with your friends. Let's take Bogus.CLI even further together! 🚀

If you'd like to support the project, consider buying me a coffee! ☕ You can contribute via [PIX](https://nubank.com.br/cobrar/1bbq/67b09a37-9e34-45b0-b969-7606b4836375) (for Brazilian supporters), and soon, I will also be adding the option to accept donations in USD. Every contribution helps fund ongoing development, improve documentation, and ensure the tool becomes more and more useful to the community.

# Table of Contents

- [Install](#install)
- [Documentation](#documentation)
  - [Commands](#commands)
  - [Arguments](#arguments)
  - [Options](#options)
  - [Parameters](#parameters)
  - [Available commands](#available-commands)
- [Contributors](#contributors)

# Install
[Dotnet Tool Bogus.CLI](https://www.nuget.org/packages/BogusCLI)

```
dotnet tool install --global BogusCli
```
Minimum requirements: .NET 8.0.

# Documentation

- [Commands](#commands)
- [Arguments](#arguments)
- [Options](#options)
- [Parameters](#parameters)
- [Available commands](#available-commands)

The structure of a CLI command generally follows this pattern:

```
bogus <command> [arguments] [options]
```

The `command` specifies the action to perform, while `arguments` provide the data needed for the action, and `options` allow further customization.

## Commands

A `command` performs a specific action. For example:

```
bogus dataset
```

This command generates a set of fake data.

## Arguments

`Arguments` supply the necessary information to the command. For instance:

```
bogus dataset person.fullname
```

Here, `person.fullname` is an argument that tells the `dataset` command what type of data to generate.

## Options

`Options` modify the behavior of the command. They typically start with `--` and provide additional control. Example:

```
bogus dataset person.fullname --count 50
```

The option `--count 50` specifies that 50 records should be generated.

## Parameters

Some categories support additional `parameters` that allow you to customize how data is generated. These parameters are specified directly within the property call, following this pattern:

```
bogus dataset <category>.<property>(param1=value1, param2=value2)
```

Examples:

- `dataset date.past(years=1)` — Generates a past date within the last year.
- `dataset finance.amount(min=10, max=1000)` — Generates a random financial amount between 10 and 1000.
- `dataset internet.email(domain="example.com")` — Generates an email address with the specified domain.

If a property doesn't support additional parameters, simply omit them:

```
bogus dataset person.fullname
```

You can also combine multiple datasets in a single command, allowing you to generate various types of data at once.

```
bogus dataset person.fullname internet.email
```

This flexibility allows you to fine-tune the data generated without needing to modify the tool's source code.

# Available commands

The following commands are available:

- list-locales
- list-datasets
- dataset

# Contributors

Created by [Tiago Aguiar](https://github.com/tiago-aguiar-moreira).

