namespace Domain.Entities;

using Domain.Enums;

using MongoDB.Bson.Serialization.Attributes;

[Serializable]
[BsonDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroValor)}")]
public class FiltroValor : FiltroAbstrato<string>
{
    public override Tipo Tipo => Tipo.Valor;
}
