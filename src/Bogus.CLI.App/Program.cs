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
builder.Services.AddScoped<ICommerceFakerAdapter, CommerceFakerAdapter>();
builder.Services.AddScoped<IDatabaseFakerAdapter, DatabaseFakerAdapter>();
builder.Services.AddScoped<IDateFakerAdapter, DateFakerAdapter>();
builder.Services.AddScoped<ICompanyFakerAdapter, CompanyFakerAdapter>();
builder.Services.AddScoped<IFinanceFakerAdapter, FinanceFakerAdapter>();
builder.Services.AddScoped<IHackerFakerAdapter, HackerFakerAdapter>();
builder.Services.AddScoped<IImagesFakerAdapter, ImagesFakerAdapter>();
builder.Services.AddScoped<IInternetFakerAdapter, InternetFakerAdapter>();
builder.Services.AddScoped<ILoremFakerAdapter, LoremFakerAdapter>();
builder.Services.AddScoped<INameFakerAdapter, NameFakerAdapter>();
builder.Services.AddScoped<IPhoneFakerAdapter, PhoneFakerAdapter>();
builder.Services.AddScoped<IRantFakerAdapter, RantFakerAdapter>();
builder.Services.AddScoped<IRandomFakerAdapter, RandomFakerAdapter>();
builder.Services.AddScoped<ISystemFakerAdapter, SystemFakerAdapter>();
builder.Services.AddScoped<IVehicleFakerAdapter, VehicleFakerAdapter>();

// Configure Helpers
builder.Services.AddScoped<IDatasetHelper, DatasetHelper>();

// Configure Dataset Services
builder.Services.AddScoped<IAddressDatasetService, AddressDatasetService>();
builder.Services.AddScoped<ICommerceDatasetService, CommerceDatasetService>();
builder.Services.AddScoped<IDatabaseDatasetService, DatabaseDatasetService>();
builder.Services.AddScoped<IDateDatasetService, DateDatasetService>();
builder.Services.AddScoped<ICompanyDatasetService, CompanyDatasetService>();
builder.Services.AddScoped<IFinanceDatasetService, FinanceDatasetService>();
builder.Services.AddScoped<IHackerDatasetService, HackerDatasetService>();
builder.Services.AddScoped<IImagesDatasetService, ImagesDatasetService>();
builder.Services.AddScoped<IInternetDatasetService, InternetDatasetService>();
builder.Services.AddScoped<ILoremDatasetService, LoremDatasetService>();
builder.Services.AddScoped<INameDatasetService, NameDatasetService>();
builder.Services.AddScoped<IPhoneDatasetService, PhoneDatasetService>();
builder.Services.AddScoped<IRantDatasetService, RantDatasetService>();
builder.Services.AddScoped<IRandomDatasetService, RandomDatasetService>();
builder.Services.AddScoped<ISystemDatasetService, SystemDatasetService>();
builder.Services.AddScoped<IVehicleDatasetService, VehicleDatasetService>();

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