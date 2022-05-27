namespace Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[Serializable]
public class Range
{
    [BsonRequired]
    [BsonElement("de", Order = 1)]
    [BsonRepresentation(BsonType.Int32)]
    public int De { get; set; }

    [BsonRequired]
    [BsonElement("ate", Order = 2)]
    [BsonRepresentation(BsonType.Int32)]
    public int Ate { get; set; }
}
