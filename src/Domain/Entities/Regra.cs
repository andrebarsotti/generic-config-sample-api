namespace Domain.Entities;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


[Serializable]
public class Regra
{
    [BsonId]
    [BsonElement("_id", Order = 1)]
    [BsonRepresentation(BsonType.ObjectId)]
    public virtual string Id { get; set; }

    [BsonRequired]
    [BsonElement("nome", Order = 2)]
    [BsonRepresentation(BsonType.String)]
    public virtual string Nome { get; set; }

    [BsonRequired]
    [BsonElement("dataInlcusao", Order = 3)]
    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public virtual DateTime DataInclusao { get; set; }

    [BsonRequired]
    [BsonElement("incluidoPor", Order = 4)]
    [BsonRepresentation(BsonType.String)]
    public virtual string IncluidoPor { get; set; }

    [BsonRequired]
    [BsonElement("filtros", Order = 5)]
    public virtual ICollection<Filtro> Filtros { get; set; }
}
