[![Downloads](https://img.shields.io/nuget/dt/BogusCLI.svg)](https://www.nuget.org/packages/BogusCLI/) [![Coverage Status](https://coveralls.io/repos/github/tiago-aguiar-moreira/Bogus.CLI/badge.svg)](https://coveralls.io/github/tiago-aguiar-moreira/Bogus.CLI)

# Bogus CLI

Hello, I'm Tiago Aguiar!
I am a C#/.NET developer with over 13 years of experience. I am currently working on Bogus.CLI, a command-line tool based on the amazing NuGet package Bogus, created by Brian Chavez. My goal is to bring all the power of Bogus to the command line, making it even easier to generate fake data for various contexts.

Generating data manually can be challenging, especially when trying to make it realistic or avoiding repetitions. Often, manually created data doesn’t make sense in a real-world context, or it becomes time-consuming. When a large volume of data is needed, doing it manually becomes unfeasible. Bogus.CLI solves these issues by automatically generating fake data quickly and realistically, helping developers test their applications efficiently, without wasting time on manual input or relying on external sources.

With Bogus.CLI, you can generate data with ease, flexibility, and efficiency directly from your terminal! If this tool helps you be more productive, please leave a star ⭐ on the repository and share it with your friends. Let's take Bogus.CLI even further together! 🚀

If you'd like to support the project, consider buying me a coffee! ☕ You can contribute via [PIX](https://nubank.com.br/cobrar/1bbq/67b09a37-9e34-45b0-b969-7606b4836375) (for Brazilian supporters), and soon, I will also be adding the option to accept donations in USD. Every contribution helps fund ongoing development, improve documentation, and ensure the tool becomes more and more useful to the community.

# Install
[Dotnet Tool Bogus.CLI](https://www.nuget.org/packages/BogusCLI)

```
dotnet tool install --global BogusCli
```
Minimum requirements: .NET 8.0.

# Documentation

The structure of the CLI command consists of the command and, possibly, the arguments and options of the command. You see this pattern in most CLI operations.

```
bogus dataset name.FullName --count 50
```
## Commands

The command performs an action. For example, `bogus dataset` generates a mass of data.

## Arguments

The arguments you pass on the command line are for the invoked command. For example, when you run bogus `dataset name.fullName --count 50`, the argument `name.FullName` indicates the type of data that will be generated.

## Options

The options you pass on the command line are options for the invoked command. For example, when you run `bogus dataset name.fullName --count 50`, the option `count` indicates the number of records that will be generated.

# Available commands

The following commands are available:

- dataset <NAME>
- list-datasets
- list-locales

# Contributors

Created by Tiago Aguiar.