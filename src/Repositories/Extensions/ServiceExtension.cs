using System.Diagnostics.CodeAnalysis;

using Domain.Dto;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

using Repositories.Config;

using Range = Domain.Entities.Range;

namespace Repositories.Extensions;

public static class ServiceExtension
{
    [ExcludeFromCodeCoverage]
    public static void AddMongoDBRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        MapDatabaseEntities();
        var mongoClient = new MongoClient(configuration.GetConnectionString("mongodb"));
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton(mongoClient.GetDatabase(configuration["MongoDBDatabbase"]));
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