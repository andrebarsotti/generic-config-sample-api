using Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Repositories.Config;

internal static class ItemListaConfiguration
{
    public static void Configure()
    {
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
    }
}