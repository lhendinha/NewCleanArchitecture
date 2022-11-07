using CleanArchitecture.Application.Interfaces.WeatherForecasts;
using MediatR;

namespace CleanArchitecture.Application.Queries.WeatherForecasts;

public class WeatherForecastQueryHandler : IRequestHandler<WeatherForecastQuery, QueryResponse>
{
    private readonly IWeatherForecastService _weatherForecastService;
    
    public WeatherForecastQueryHandler(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }
    
    public async Task<QueryResponse> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var weatherForecast = _weatherForecastService.Get(request.MinRange, request.MaxRange, request.MinValue, request.MaxValue);
        
        return new QueryResponse(weatherForecast);
    }
}