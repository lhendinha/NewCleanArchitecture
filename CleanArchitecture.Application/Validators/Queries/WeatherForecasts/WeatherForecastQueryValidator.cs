using CleanArchitecture.Application.Queries.WeatherForecasts;
using FluentValidation;

namespace CleanArchitecture.Application.Validators.Queries.WeatherForecasts;

public class WeatherForecastQueryValidator : AbstractValidator<WeatherForecastQuery>
{
    public WeatherForecastQueryValidator()
    {
        RuleFor(x => x.MinValue)
            .GreaterThanOrEqualTo(-22)
            .WithMessage("MinValue must be greater than or equal to -22.");

        RuleFor(x => x.MaxValue)
            .GreaterThanOrEqualTo(55)
            .WithMessage("MaxValue must be greater than or equal to 55.");
        
        RuleFor(x => x.MinRange)
            .Must(x => x == 1)
            .WithMessage("MinRange must be equal to 1.");
        
        RuleFor(x => x.MaxRange)
            .Must(x => x == 5)
            .WithMessage("MaxRange must be equal to 5.");
    }
}