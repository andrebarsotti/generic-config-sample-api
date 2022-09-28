using Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Repositories.Config;

internal static class RegraConfiguration
{
    public static void Configure()
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
    }
}