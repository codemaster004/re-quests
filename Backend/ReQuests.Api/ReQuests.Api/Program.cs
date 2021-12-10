global using ReQuests.Api.Exceptions;
global using ReQuests.Api.Services;
using ReQuests.Api;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
Startup.ConfigureServices( builder );

var app = builder.Build();

// Configure the HTTP request pipeline.
Startup.Configure( app );

app.Run();
