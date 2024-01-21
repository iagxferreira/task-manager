using TaskManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Load();
var app = builder.Build();

app.Load();

app.Run();