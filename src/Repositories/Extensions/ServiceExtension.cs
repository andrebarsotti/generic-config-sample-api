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

using Range = Domain.Entities.Range;

namespace Repositories.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceExtension
{
    public static void AddMongoDBRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        MapDatabaseEntities();
        var mongoClient = new MongoClient(configuration.GetConnectionString("mongodb"));
        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton(mongoClient.GetDatabase(configuration["MongoDBDatabbase"]));
        services.AddScoped<RegraRepository, RegraRepositoryMongoDB>();
    }

    public static void MapDatabaseEntities()
    {
        BsonClassMap.RegisterClassMap<Regra>(cm =>
        {
            cm.MapIdMember(ent => ent.Id)
                .SetSerializer(new StringSerializer(BsonType.ObjectId))
                .SetElementName("_id")
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetOrder(1);
            
            cm.MapMember(ent => ent.Nome)
                .SetElementName("nome")
                .SetOrder(2)
                .SetIsRequired(true);
            
            cm.MapMember(ent => ent.DataInclusao)
                .SetSerializer(new DateTimeSerializer(DateTimeKind.Utc))
                .SetElementName("dataInlcusao")
                .SetOrder(3)
                .SetIsRequired(true);
            
            cm.MapMember(ent => ent.IncluidoPor)
                .SetElementName("incluidoPor")
                .SetOrder(4);
            
            cm.MapMember(ent => ent.Filtros)
                .SetElementName("filtros")
                .SetOrder(5);
        });

        BsonClassMap.RegisterClassMap<FiltroAbstrato<IEnumerable<ItemLista>>>(cm =>
        {
            cm.MapMember(ent => ent.Tipo)
                .SetSerializer(new EnumSerializer<Tipo>(BsonType.String))
                .SetElementName("tipo")
                .SetIsRequired(true)
                .SetOrder(1);
            
            cm.MapMember(ent => ent.Nome)
                .SetIsRequired(true)
                .SetElementName("nome")
                .SetOrder(2);
            
            cm.MapMember(ent => ent.Valor)
                .SetElementName("valor")
                .SetIsRequired(true)
                .SetOrder(3);
        });

        BsonClassMap.RegisterClassMap<FiltroLista>(cm =>
        {
            cm.AutoMap();
            cm.SetDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroLista)}");
        });
        
        BsonClassMap.RegisterClassMap<ItemLista>(cm =>
        {
        
            cm.MapMember(ent => ent.Id)
                .SetIsRequired(true)
                .SetElementName("_id")
                .SetSerializer(new Int32Serializer(BsonType.Int32))
                .SetOrder(1);
            
            cm.MapMember(ent => ent.Descricao)
                .SetElementName("descricao")
                .SetOrder(2);
        });
        
        BsonClassMap.RegisterClassMap<FiltroAbstrato<Range>>(cm =>
        {
            cm.MapMember(ent => ent.Tipo)
                .SetSerializer(new EnumSerializer<Tipo>(BsonType.String))
                .SetElementName("tipo")
                .SetIsRequired(true)
                .SetOrder(1);
            
            cm.MapMember(ent => ent.Nome)
                .SetIsRequired(true)
                .SetElementName("nome")
                .SetOrder(2);
            
            cm.MapMember(ent => ent.Valor)
                .SetElementName("valor")
                .SetIsRequired(true)
                .SetOrder(3);
        });
        
        BsonClassMap.RegisterClassMap<FiltroRange>(cm =>
        {
            cm.AutoMap();
            cm.SetDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroRange)}");
        });
        
        BsonClassMap.RegisterClassMap<Range>(cm =>
        {
            cm.MapMember(ent => ent.De)
                .SetElementName("de")
                .SetIsRequired(true)
                .SetSerializer(new Int32Serializer(BsonType.Int32))
                .SetOrder(1);
        
            cm.MapMember(ent => ent.Ate)
                .SetElementName("ate")
                .SetIsRequired(true)
                .SetSerializer(new Int32Serializer(BsonType.Int32))
                .SetOrder(2);
        });
        
        BsonClassMap.RegisterClassMap<FiltroAbstrato<string>>(cm =>
        {
            cm.MapMember(ent => ent.Tipo)
                .SetSerializer(new EnumSerializer<Tipo>(BsonType.String))
                .SetElementName("tipo")
                .SetIsRequired(true)
                .SetOrder(1);
        
            cm.MapMember(ent => ent.Nome)
                .SetIsRequired(true)
                .SetElementName("nome")
                .SetOrder(2);
            
            cm.MapMember(ent => ent.Valor)
                .SetIsRequired(true)
                .SetElementName("valor")
                .SetOrder(3);
        });
        
        BsonClassMap.RegisterClassMap<FiltroValor>(cm =>
        {
            cm.AutoMap();
            cm.SetDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroValor)}");
        });
        
        BsonClassMap.RegisterClassMap<RegraResumoDto>(cm =>
        {
            cm.MapMember(ent => ent.Id)
                .SetSerializer(new StringSerializer(BsonType.ObjectId))
                .SetElementName("_id")
                .SetOrder(1);
        
            cm.MapMember(ent => ent.Nome)
                .SetElementName("nome")
                .SetOrder(2)
                .SetIsRequired(true);
            
            cm.MapMember(ent => ent.DataInclusao)
                .SetSerializer(new DateTimeSerializer(DateTimeKind.Utc))
                .SetElementName("dataInlcusao")
                .SetOrder(3)
                .SetIsRequired(true);
            
            cm.MapMember(ent => ent.IncluidoPor)
                .SetElementName("incluidoPor")
                .SetOrder(4);
        });
    }
}