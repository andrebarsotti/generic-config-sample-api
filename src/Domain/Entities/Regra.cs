using System.Text.Json.Serialization;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

[Serializable]
public class Regra
{
    [BsonId]
    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public virtual string Id { get; set; }

    [BsonRequired]
    [BsonElement("nome")]
    [JsonPropertyName("nome")]
    [BsonRepresentation(BsonType.String)]
    public virtual string Nome { get; set; }

    [BsonRequired]
    [BsonElement("dataInlcusao")]
    [JsonPropertyName("dataInlcusao")]
    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public virtual DateTime DataInclusao { get; set; }

    [BsonRequired]
    [BsonElement("incluidoPor")]
    [JsonPropertyName("incluidoPor")]
    [BsonRepresentation(BsonType.String)]
    public virtual string IncluidoPor { get; set; }

    [BsonRequired]
    [BsonElement("filtros")]
    [JsonPropertyName("filtros")]
    public virtual ICollection<IFiltro> Filtros { get; set; }
}
