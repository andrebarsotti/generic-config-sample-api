using Domain.Entities;
using Domain.Enums;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

using Range = System.Range;

namespace Repositories.Config;

internal static class FiltroRangeConfiguration
{
    public static void Configure()
    {
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

    }
}