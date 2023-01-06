using MassTransit;
using MassTransit.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCO.BaskerService.Infrastructure.Persitence;
using SCO.BasketService.Application;
using SCO.BasketService.Application.Common.Interfaces.Persistance;
using SCO.BasketService.Application.MassTransit;
using SCO.BasketService.Domain;
using SCO.BasketService.EntityFramework;
using SCO.BasketService.Infrastructure;
using SCO.BasketService.Infrastructure.Persitence;
using SCO.Contracts.DTOs;
using SCO.Contracts.Requests.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddEntityFramework(builder.Configuration);

builder.Services.AddLogging();

var rabbitSection = builder.Configuration.GetSection("RabitServer");
var url = rabbitSection.GetValue<string>("Url");
var host = rabbitSection.GetValue<string>("Host");

builder.Services.AddMassTransit(config =>
{
    config.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
    {
        c.Host($"rabbitmq://{url}/{host}", configurator =>
        {
            configurator.Username("guest");
            configurator.Password("guest");
        });
        c.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
    }));

    config.AddRequestClient<ProductsRequest>(); 
    config.AddConsumer<OrderConsumer>();
    config.AddConsumer<AddItemToBasketConsumer>();
});




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
