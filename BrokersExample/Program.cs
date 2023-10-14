using BrokersExample.ConcreteFactories;
using BrokersExample.ConcreteProducts;
using BrokersExample.FactoryInterface;
using BrokersExample.ProductInterface;
using BrokersExample.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMessageBrokerFactory, MessageBrokerFactory>();

builder.Services.AddScoped<AwsMessageBroker>();
builder.Services.AddScoped<IMessageBroker, AwsMessageBroker>(s => s.GetService<AwsMessageBroker>());

builder.Services.AddScoped<AzureMessageBroker>();
builder.Services.AddScoped<IMessageBroker, AzureMessageBroker>(s => s.GetService<AzureMessageBroker>());

builder.Services.AddScoped<GcpMessageBroker>();
builder.Services.AddScoped<IMessageBroker, GcpMessageBroker>(s => s.GetService<GcpMessageBroker>());






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
