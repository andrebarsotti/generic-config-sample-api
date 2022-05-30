namespace Domain.Entities;

using Domain.Enums;

using MongoDB.Bson.Serialization.Attributes;

[Serializable]
[BsonDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroLista)}")]
public class FiltroLista : FiltroAbstrato<IEnumerable<ItemLista>>
{
    public override Tipo Tipo => Tipo.Lista;
}
