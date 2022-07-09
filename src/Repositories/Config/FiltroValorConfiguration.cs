using Domain.Entities;
using Domain.Enums;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Repositories.Config;

internal static class FiltroValorConfiguration
{
    public static void Configure()
    {
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
    }
}