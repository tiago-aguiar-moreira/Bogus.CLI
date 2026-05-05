[![NuGet Package: BogusCLI](https://img.shields.io/nuget/vpre/BogusCLI?label=NuGet%3A%20BogusCLI)](https://www.nuget.org/packages/BogusCLI) [![Downloads](https://img.shields.io/nuget/dt/BogusCLI.svg)](https://www.nuget.org/packages/BogusCLI/) [![Coverage Status](https://coveralls.io/repos/github/tiago-aguiar-moreira/Bogus.CLI/badge.svg?branch=main)](https://coveralls.io/github/tiago-aguiar-moreira/Bogus.CLI?branch=main)

# Bogus CLI

Hello, I'm Tiago Aguiar! I am a C#/.NET developer with over 13 years of experience. I am currently working on Bogus.CLI, a command-line tool based on the amazing NuGet package Bogus, created by Brian Chavez. My goal is to bring all the power of Bogus to the command line, making it even easier to generate fake data for various contexts.

Generating data manually can be challenging, especially when trying to make it realistic or avoiding repetitions. Often, manually created data doesn’t make sense in a real-world context, or it becomes time-consuming. When a large volume of data is needed, doing it manually becomes unfeasible. Bogus.CLI solves these issues by automatically generating fake data quickly and realistically, helping developers test their applications efficiently, without wasting time on manual input or relying on external sources.

With Bogus.CLI, you can generate data with ease, flexibility, and efficiency directly from your terminal! If this tool helps you be more productive, please leave a star ⭐ on the repository and share it with your friends. Let's take Bogus.CLI even further together! 🚀

If you'd like to support the project, consider buying me a coffee! ☕ You can contribute via [PIX](https://nubank.com.br/cobrar/1bbq/67b09a37-9e34-45b0-b969-7606b4836375) (for Brazilian supporters), and soon, I will also be adding the option to accept donations in USD. Every contribution helps fund ongoing development, improve documentation, and ensure the tool becomes more and more useful to the community.

## Install

Requires **.NET 8.0** or higher.

```bash
dotnet tool install --global BogusCli
```

## Quick Start

```bash
# Generate 10 full names
bogus dataset name.fullName --count 10

# Generate emails with a custom provider
bogus dataset internet.email(provider=example.com)

# Combine multiple datasets in one command
bogus dataset name.fullName internet.email phone.number --count 5
```

## Available Datasets

| Dataset | Description |
|---|---|
| address | Street addresses, cities, countries, coordinates, and more |
| commerce | Products, prices, categories, and barcodes |
| company | Company names, suffixes, catch phrases, and BS |
| database | Column names, data types, collations, and engines |
| date | Past, future, recent, and between dates and timespans |
| finance | Accounts, amounts, credit cards, IBAN, BTC, and more |
| hacker | Tech jargon, abbreviations, verbs, and phrases |
| images | Image URLs and data URIs from various providers |
| internet | Emails, URLs, IPs, usernames, passwords, and more |
| lorem | Words, sentences, paragraphs, and placeholder text |
| name | First names, last names, full names, and job titles |
| phone | Phone numbers and format patterns |
| random | Primitive values, GUIDs, hashes, and random strings |
| rant | Opinionated product reviews |
| system | File names, paths, MIME types, versions, and device IDs |
| vehicle | VINs, manufacturers, models, types, and fuel types |

## Documentation

Full documentation is available at **[tiago-aguiar-moreira.github.io/Bogus.CLI](https://tiago-aguiar-moreira.github.io/Bogus.CLI/)**.

## Contributors

Created by [Tiago Aguiar](https://github.com/tiago-aguiar-moreira).