using Bogus.CLI.App.Commands;
using Bogus.CLI.Core.Datasets;
using Bogus.CLI.Core.Datasets.Interfaces;
using Bogus.CLI.Core.Helpers;
using Bogus.CLI.Core.Helpers.Interface;
using Bogus.CLI.Core.Services;
using Bogus.CLI.Core.Services.Interface;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IFakerService, FakerService>();

// Configure Datasets
builder.Services.AddScoped<ILoremDataset, LoremDataset>();
builder.Services.AddScoped<INameDataset, NameDataset>();
builder.Services.AddScoped<IPhoneDataset, PhoneDataset>();

// Configure 
builder.Services.AddScoped<IFakeDataLoremService, FakeDataLoremService>();
builder.Services.AddScoped<IFakeDataNameService, FakeDataNameService>();
builder.Services.AddScoped<IFakeDataPhoneService, FakeDataPhoneService>();

builder.Services.AddScoped<IDatasetHelper, DatasetHelper>();
builder.Services.AddScoped<IDatasetService, DatasetService>();

builder.Services.AddScoped<IListDatasetService, ListDatasetService>();
builder.Services.AddScoped<IListLocaleService, ListLocaleService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();

var app = builder.Build();

app.ConfigureDatasetCommand();
app.ConfigureListDatasetCommand();
app.ConfigureListLocaleCommand();
app.Run();