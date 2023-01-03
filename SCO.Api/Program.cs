using MassTransit;
using MassTransit.Contracts;
using SCO.Contracts.Requests.Order;
using SCO.Contracts.Requests.Product;
using SCO.EntityFramework;
using SCO.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddAplication(builder.Configuration);
    builder.Services.AddEntityFramework(builder.Configuration);
    builder.Services.AddInfrastructure();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //ConfigureServicesMassTransit.ConfigureServices(builder.Services, builder.Configuration,
    //    new MassTransitConfiguration()
    //    {
    //        IsDebug = false, //section.GetValue<bool>("IsDebug"),
    //        ServiceName = "SCO.Gateway",
    //        Configuration = bus =>
    //        {
    //            bus.AddRequestClient<OrderRequet>();
    //            bus.AddRequestClient<GetProductsByNameRequest>();
    //            bus.AddRequestClient<ProductsByCategoryRequest>();
    //        } 
    //    });


    var rabbitSection = builder.Configuration.GetSection("RabitServer");
    var url = rabbitSection.GetValue<string>("Url");
    var host = rabbitSection.GetValue<string>("Host");


    Thread.Sleep(10000);

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

        config.AddRequestClient<OrderRequest>();
        config.AddRequestClient<ProductsRequest>();
        config.AddRequestClient<ProductsByNameRequest>();
        config.AddRequestClient<ProductsByCategoryRequest>();
        config.AddRequestClient<AddItemOrderRequest>();
    });
}


var app = builder.Build();
{

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
}