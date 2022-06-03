using System.Diagnostics.CodeAnalysis;

using Domain.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

namespace Repositories.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceExtension
{
    public static void AddMongoDBRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetConnectionString("mongodb"));
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton(mongoClient.GetDatabase(configuration["MongoDBDatabbase"]));
        services.AddScoped<RegraRepository, RegraRepositoryMongoDB>();
    }
}