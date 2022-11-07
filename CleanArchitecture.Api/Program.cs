using System.Reflection;
using CleanArchitecture.Application.Helpers.Services;
using CleanArchitecture.Application.Services.WeatherForecasts;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add MediatR
var assembly = AppDomain.CurrentDomain.Load("CleanArchitecture.Application");

// Validators.
AssemblyScanner
    .FindValidatorsInAssembly(assembly)
    .ForEach(result => builder.Services.AddScoped(result.InterfaceType, result.ValidatorType));

// Behaviors.
var behaviorType = typeof(IPipelineBehavior<,>);
var behaviors = assembly.DefinedTypes.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == behaviorType));
foreach (var type in behaviors)
    builder.Services.Add(new ServiceDescriptor(behaviorType, type, ServiceLifetime.Scoped));

builder.Services.AddMediatR(assembly);
//

// Add repositories
var contracts = AppDomain.CurrentDomain.Load("CleanArchitecture.Domain").DefinedTypes.Where(
    t => t.IsInterface && t.Name.EndsWith("Repository"));

var repoAssembly = AppDomain.CurrentDomain.Load("CleanArchitecture.Infrastructure");

foreach (var contract in contracts)
    builder.Services.AddScoped(contract, repoAssembly.DefinedTypes.Single(t => contract.IsAssignableFrom(t)));
//

// Add Services Scrutor
builder.Services.Scan(i => 
    i.FromAssemblies(assembly)
        .AddClasses(c => c.WithAttribute<TransientAttribute>())
        .AsImplementedInterfaces()
        .WithTransientLifetime()
        
        .AddClasses(c => c.WithAttribute<ScopedAttribute>())
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        
        .AddClasses(c => c.WithAttribute<SingletonAttribute>())
        .AsImplementedInterfaces()
        .WithSingletonLifetime()
);
//

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

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

