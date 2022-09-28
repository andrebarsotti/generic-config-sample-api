using Domain.Dto;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Repositories.Config;

internal static class RegraResumoDtoConfiguration
{
    public static void Configure()
    {
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