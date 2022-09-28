using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Api.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceExtension
{
    public static void AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(ObterAssembliesDeProfile());
    }

    private static IEnumerable<Assembly> ObterAssembliesDeProfile()
    {
        yield return typeof(Program).GetTypeInfo().Assembly;
        yield return typeof(Domain.Extensions.ServiceExtension).GetTypeInfo().Assembly;
    }
}