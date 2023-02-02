using MassTransit;
using SCO.ProductService.Application;
using SCO.ProductService.Application.MassTransit;
using SCO.ProductService.EntityFramework;
using SCO.ProductService.EntityFramework.Seed;
using SCO.ProductService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var section = builder.Configuration.GetSection("RebitServer");
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

    config.AddConsumer<ProductsByNameConsumer>();
    config.AddConsumer<ProductsByCategoryConsumer>();
    config.AddConsumer<ProductsConsumer>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseItToSeedSqlServer();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
