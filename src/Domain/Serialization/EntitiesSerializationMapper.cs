using Domain.Entities;

using MongoDB.Bson.Serialization;

namespace Domain.Serialization;

public static class EntitiesSerializationMapper
{
    public static void MapEntities()
    {
        BsonClassMap.RegisterClassMap<Regra>();
        BsonClassMap.RegisterClassMap<FiltroLista>();
        BsonClassMap.RegisterClassMap<FiltroRange>();
        BsonClassMap.RegisterClassMap<FiltroValor>();
    }
}
