using CAP.Ordering.API.Events;
using CAP.Ordering.API.Models;
using CAP.Ordering.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// AutoMapper
services.AddAutoMapper(typeof(MappingProfile));
// Settings
services.Configure<OrderDatabaseSettings>(
    Configuration.GetSection(nameof(OrderDatabaseSettings)));
services.AddSingleton<IOrderDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);
// Repositories
//services.AddSingleton<IOrderRepository, OrderRepository>();
services.AddSingleton<IOrderService, OrderService>();
// EventBus
services.AddCap(option =>
{
    option.UseMongoDB(option =>
    {
        option.DatabaseConnection = Configuration["OrderDatabaseSettings:ConnectionString"];
        option.DatabaseName = Configuration["OrderDatabaseSettings:DatabaseName"];
    });
    option.UseKafka(option =>
    {
        option.Servers = Configuration["KafkaSettings:BootstrapServers"];
    });
});
// Consumer
services.AddTransient<IProductStockDeductedEventService, ProductStockDeductedEventService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
