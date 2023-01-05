using FluentValidation;
using FluentValidation.AspNetCore;
using SCO.Identity.Aplications.Validators;
using SCO.Identity.Application;
using SCO.Identity.EntityFramework;
using SCO.Identity.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAplication(builder.Configuration);
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequstValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
