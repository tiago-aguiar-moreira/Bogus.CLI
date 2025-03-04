using Bogus.CLI.App.Commands.Dataset;
using Bogus.CLI.App.Commands.DatasetFile;
using Bogus.CLI.App.Commands.ListDataset;
using Bogus.CLI.App.Commands.ListLocale;
using Bogus.CLI.Core;
using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Helpers;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services;
using Bogus.CLI.Core.Services.Interface;
using Bogus.CLI.Infrastructure.Repository;
using Bogus.CLI.Infrastructure.Repository.Interface;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();


// Configure Datasets
builder.Services.AddKeyedScoped<IRepository, SqlServerRepository>(Databases.SQL_SERVER);

// Configure Datasets
builder.Services.AddScoped<IDatasetLoremService, DatasetLoremService>();
builder.Services.AddScoped<IDatasetNameService, DatasetNameService>();
builder.Services.AddScoped<IDatasetPhoneService, DatasetPhoneService>();

// Configure Helpers
builder.Services.AddScoped<IDatasetHelper, DatasetHelper>();

// Configure FakeData Services
builder.Services.AddScoped<IParserDatasetLoremService, ParserDatasetLoremService>();
builder.Services.AddScoped<IParserDatasetNameService, ParserDatasetNameService>();
builder.Services.AddScoped<IParserDatasetPhoneService, ParserDatasetPhoneService>();

// Configure Services
builder.Services.AddScoped<IDatasetService, DatasetService>();
builder.Services.AddScoped<IListDatasetService, ListDatasetService>();
builder.Services.AddScoped<ISeedDatabaseService, SeedDatabaseService>();
builder.Services.AddScoped<IListLocaleService, ListLocaleService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddSingleton<IFakerService, FakerService>();

var app = builder.Build();

app.ConfigureDatasetCommand();
app.ConfigureDatasetFileCommand();
app.ConfigureListDatasetCommand();
app.ConfigureListLocaleCommand();
app.Run();