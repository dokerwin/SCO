using Newtonsoft.Json;
using SCO.ConfigurationService.Application;
using SCO.ConfigurationService.Domain.Entities;
using SCO.ConfigurationService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure();
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddLogging();

var app = builder.Build();

app.Run();
 