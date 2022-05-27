namespace Domain.Entities;

using System.Text.Json.Serialization;

using Domain.Enums;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface IFiltro 
{ 
    Tipo Tipo { get; }
    string Nome { get; }
}

public interface IFiltro<T> : IFiltro
{
    T Valor { get; } 
}

[Serializable]
public abstract class Filtro<T> : IFiltro<T>
{
    [BsonElement("tipo")]
    [JsonPropertyName("tipo")]
    [BsonRepresentation(BsonType.String)]
    public abstract Tipo Tipo { get; }

    [BsonElement("nome")]
    [JsonPropertyName("nome")]
    [BsonRepresentation(BsonType.String)]
    public virtual string Nome { get; set; }

    [BsonElement("valor")]
    [JsonPropertyName("valor")]
    public virtual T Valor { get; set; } 
}

[Serializable]
[BsonDiscriminator("filtroLista")]
public class FiltroLista : Filtro<IEnumerable<ItemLista>>
{
    public override Tipo Tipo => Tipo.Lista;
}

[Serializable]
[BsonDiscriminator("filtroRange")]
public class FiltroRange : Filtro<Range>
{
    public override Tipo Tipo => Tipo.Range;
}

[Serializable]
[BsonDiscriminator("filtroValor")]
public class FiltroValor : Filtro<string>
{
    public override Tipo Tipo => Tipo.Valor;
}

[Serializable]
public class ItemLista
{
    [BsonRequired]
    [BsonElement("id")]
    [JsonPropertyName("id")]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }

    [BsonRequired]
    [BsonElement("descricao")]
    [JsonPropertyName("descricao")]
    [BsonRepresentation(BsonType.String)]
    public string Descricao { get; set; }
}

[Serializable]
public class Range
{
    [BsonRequired]
    [BsonElement("de")]
    [JsonPropertyName("de")]
    [BsonRepresentation(BsonType.Int32)]
    public int De { get; set; }

    [BsonRequired]
    [BsonElement("ate")]
    [JsonPropertyName("ate")]
    [BsonRepresentation(BsonType.Int32)]
    public int Ate { get; set; }
}
