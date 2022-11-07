using MediatR;

namespace CleanArchitecture.Application.Queries.WeatherForecasts;

public class WeatherForecastQuery : IRequest<QueryResponse>
{
    public int MinValue { get; set; } = -20;
    
    public int MaxValue { get; set; } = 55;

    public int MinRange { get; set; } = 1;

    public int MaxRange { get; set; } = 5;
}