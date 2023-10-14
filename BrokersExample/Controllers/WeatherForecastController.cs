using BrokersExample.ConcreteFactories;
using BrokersExample.FactoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace BrokersExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IMessageBrokerFactory messageBrokerFactory;

    public WeatherForecastController(IMessageBrokerFactory messageBrokerFactory)
    {
        this.messageBrokerFactory = messageBrokerFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        messageBrokerFactory.GetMessageBroker(Providers.Brokers.AWS).SendMessage();
        messageBrokerFactory.GetMessageBroker(Providers.Brokers.Azure).SendMessage();
        messageBrokerFactory.GetMessageBroker(Providers.Brokers.Google).SendMessage();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}