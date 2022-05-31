namespace Domain.Entities;

using Domain.Enums;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public interface Filtro
{
    Tipo Tipo { get; }
    string Nome { get; }
}

public interface Filtro<T> : Filtro
{
    T Valor { get; }
}

[Serializable]
public abstract class FiltroAbstrato<T> : Filtro<T>
{
    [BsonElement("tipo", Order = 1)]
    [BsonRepresentation(BsonType.String)]
    public abstract Tipo Tipo { get; }

    [BsonElement("nome", Order = 2)]
    [BsonRepresentation(BsonType.String)]
    public virtual string Nome { get; set; }

    [BsonElement("valor", Order = 3)]
    public virtual T Valor { get; set; } 
}
