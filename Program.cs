using Microsoft.EntityFrameworkCore;
using Phoenix.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PhoenixContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PhoenixContext") ?? throw new InvalidOperationException("Dados de conexão 'PhoenixContext' não encontrada.")));

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/amxsistemas", () =>
{

});

app.Run();
