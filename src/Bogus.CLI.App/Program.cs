using Bogus.CLI.App.Commands;
using Cocona;

var app = CoconaApp.CreateBuilder().Build();

app.AddGenerateCommand();
app.AddListCommand();
app.Run();