using System.Diagnostics.CodeAnalysis;

using Domain.Dto;
using Domain.Services;
using Domain.Validators;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceExtension
{
    public static void AddDomainServicesAndValidators(this IServiceCollection services)
    {
        services.AddScoped <IRegrasService, RegrasService>();
        services.AddScoped<IValidator<RegraDto>, RegraDtoValidator>();
    }
}