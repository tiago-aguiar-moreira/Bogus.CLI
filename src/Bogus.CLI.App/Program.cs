using Bogus.CLI.App.Commands.Dataset;
using Bogus.CLI.App.Commands.DatasetFile;
using Bogus.CLI.App.Commands.ListDataset;
using Bogus.CLI.App.Commands.ListLocale;
using Bogus.CLI.Core;
using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Helpers;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services.Adapters;
using Bogus.CLI.Core.Services.Datasets;
using Bogus.CLI.Core.Services.Commands;
using Bogus.CLI.Core.Services.Interface;
using Bogus.CLI.Infrastructure.Repository;
using Bogus.CLI.Infrastructure.Repository.Interface;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();


// Configure Datasets
builder.Services.AddKeyedScoped<IRepository, SqlServerRepository>(Databases.SQL_SERVER);

// Configure Faker Adapters
builder.Services.AddScoped<IAddressFakerAdapter, AddressFakerAdapter>();
builder.Services.AddScoped<ILoremFakerAdapter, LoremFakerAdapter>();
builder.Services.AddScoped<INameFakerAdapter, NameFakerAdapter>();
builder.Services.AddScoped<IPhoneFakerAdapter, PhoneFakerAdapter>();

// Configure Helpers
builder.Services.AddScoped<IDatasetHelper, DatasetHelper>();

// Configure Dataset Services
builder.Services.AddScoped<IAddressDatasetService, AddressDatasetService>();
builder.Services.AddScoped<ILoremDatasetService, LoremDatasetService>();
builder.Services.AddScoped<INameDatasetService, NameDatasetService>();
builder.Services.AddScoped<IPhoneDatasetService, PhoneDatasetService>();

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