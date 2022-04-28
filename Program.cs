using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PhoenixContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PhoenixContext") ?? throw new InvalidOperationException("Connection string 'PhoenixContext' not found.")));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/amxsistemas", () =>
{

});

app.Run();
