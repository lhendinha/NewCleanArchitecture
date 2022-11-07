using CleanArchitecture.Domain.Interfaces.WeatherForecasts;

namespace CleanArchitecture.Infrastructure.Repositories.WeatherForecasts;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    public string[] GetSummaries()
    {
        return new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}