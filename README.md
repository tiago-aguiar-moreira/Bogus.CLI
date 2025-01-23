# Bogus CLI

Hello, I'm Tiago Aguiar! **Bogus.CLI** is a tool based on the amazing NuGet package **Bogus**, created by Brian Chavez. My goal is to bring all the power of Bogus to the command line, making it even easier to generate fake data for various contexts. Now you can generate data with ease, flexibility, and efficiency directly from your terminal!

If this tool helps you be more productive, please leave a star ⭐ on the repository and share it with your friends. Let's take Bogus.CLI even further together! 🚀

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

The arguments you pass on the command line are for the invoked command. For example, when you run bogus `dataset name.fullName --count 50`, the argument name.FullName indicates the type of data that will be generated.

## Options

The options you pass on the command line are options for the invoked command. For example, when you run `bogus dataset name.fullName --count 50`, the option `count` indicates the number of records that will be generated.

# Available commands

The following commands are available:

- dataset <NAME>
- list-datasets
- list-locales

# Contributors

Created by Tiago Aguiar.