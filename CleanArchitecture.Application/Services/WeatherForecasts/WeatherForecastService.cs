
using CleanArchitecture.Application.Helpers.Services;
using CleanArchitecture.Application.Interfaces.WeatherForecasts;
using CleanArchitecture.Domain.Interfaces.WeatherForecasts;
using CleanArchitecture.Domain.Models.WeatherForecasts;

namespace CleanArchitecture.Application.Services.WeatherForecasts;

[Transient]
public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    
    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public IEnumerable<WeatherForecast> Get(int minRange, int maxRange, int minValue, int maxValue)
    {
        var summaries = _weatherForecastRepository.GetSummaries();
        
        return Enumerable.Range(minRange, maxRange).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(minValue, maxValue),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();
    }
}