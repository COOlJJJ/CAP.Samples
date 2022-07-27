using API.Shared.Utils.CacheClient.Microsoft.Extensions.DependencyInjection;
using API.Shared.Utils.MsgTracker.Microsoft.Extensions.DependencyInjection;
using CAP.Stocking.API.Events;
using CAP.Stocking.API.Models;
using CAP.Stocking.API.Services;
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
services.Configure<StockDatabaseSettings>(
    Configuration.GetSection(nameof(StockDatabaseSettings)));
services.AddSingleton<IStockDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<StockDatabaseSettings>>().Value);
// Services
services.AddSingleton<IStockService, StockService>();
// Redis
services.AddRedisClient(Configuration);
// MsgTracker
services.AddMsgTracker();
// EventBus
services.AddCap(option =>
{
    option.UseMongoDB(option =>
    {
        option.DatabaseConnection = Configuration["StockDatabaseSettings:ConnectionString"];
        option.DatabaseName = Configuration["StockDatabaseSettings:DatabaseName"];
    });
    option.UseKafka(option =>
    {
        option.Servers = Configuration["KafkaSettings:BootstrapServers"];
    });
});
// Consumers
services.AddTransient<INewOrderSubmittedEventService, NewOrderSubmittedEventService>();


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
