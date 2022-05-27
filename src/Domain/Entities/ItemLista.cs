namespace Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[Serializable]
public class ItemLista
{
    [BsonRequired]
    [BsonElement("id", Order = 1)]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    [BsonRequired]
    [BsonElement("descricao", Order = 2)]
    [BsonRepresentation(BsonType.String)]
    public string Descricao { get; set; }
}
