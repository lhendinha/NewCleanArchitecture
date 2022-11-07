namespace CleanArchitecture.Domain.Interfaces.WeatherForecasts;

public interface IWeatherForecastRepository
{
    string[] GetSummaries();
}