﻿using Bogus.CLI.App.Commands;
using Bogus.CLI.App.Helpers;
using Bogus.CLI.App.Helpers.Interface;
using Bogus.CLI.App.Services;
using Bogus.CLI.App.Services.Interface;
using Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IFakerService, FakerService>();
builder.Services.AddScoped<IFakeDataLoremService, FakeDataLoremService>();
builder.Services.AddScoped<IFakeDataNameService, FakeDataNameService>();
builder.Services.AddScoped<IFakeDataPhoneService, FakeDataPhoneService>();
builder.Services.AddScoped<IDatasetHelper, DatasetHelper>();
builder.Services.AddScoped<IDatasetService, DatasetService>();
builder.Services.AddScoped<IListDatasetService, ListDatasetService>();
builder.Services.AddScoped<IListLocaleService, ListLocaleService>();

var app = builder.Build();

app.ConfigureDatasetCommand();
app.ConfigureListDatasetCommand();
app.ConfigureListLocaleCommand();
app.Run();