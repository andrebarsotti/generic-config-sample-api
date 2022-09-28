using System.Diagnostics.CodeAnalysis;

using Domain.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

using Repositories.Config;

namespace Repositories.Extensions;

public static class ServiceExtension
{
    [ExcludeFromCodeCoverage]
    public static void AddMongoDBRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        MapDatabaseEntities();
        var mongoClient = new MongoClient(configuration.GetConnectionString(DBConstants.ConnectionStringName));
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton(mongoClient.GetDatabase(configuration[DBConstants.DatabaseNameSectionName]));
        services.AddScoped<IRegraRepository, RegraRepositoryMongoDB>();
    }

    public static void MapDatabaseEntities()
    {
        RegraConfiguration.Configure();

        FiltroListaConfiguration.Configure();

        ItemListaConfiguration.Configure();
        
        FiltroRangeConfiguration.Configure();
        
        RangeConfiguration.Configure();

        FiltroValorConfiguration.Configure();
        
        RegraResumoDtoConfiguration.Configure();
    }
}