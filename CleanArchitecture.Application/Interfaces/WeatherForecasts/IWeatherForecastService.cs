using CleanArchitecture.Domain.Models.WeatherForecasts;

namespace CleanArchitecture.Application.Interfaces.WeatherForecasts;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get(int minRange, int maxRange, int minValue, int maxValue);
}