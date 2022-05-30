using System.Text.Json.Serialization;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Dto
{
    public class RegraResumoDto
    {

        [JsonPropertyName("id")]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }

        [JsonPropertyName("nome")]
        [BsonElement("nome")]
        [BsonRepresentation(BsonType.String)]
        public virtual string Nome { get; set; }

        [BsonElement("dataInlcusao")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public virtual DateTime DataInclusao { get; set; }

        [BsonElement("incluidoPor")]
        [BsonRepresentation(BsonType.String)]
        public virtual string IncluidoPor { get; set; }
    }
}
