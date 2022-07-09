using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

using Range = Domain.Entities.Range;

namespace Repositories.Config;

internal static class RangeConfiguration
{
    public static void Configure()
    {
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
    }
}