namespace Domain.Entities;

using Domain.Enums;

using MongoDB.Bson.Serialization.Attributes;

[Serializable]
[BsonDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroRange)}")]
public class FiltroRange : FiltroAbstraction<Range>
{
    public override Tipo Tipo => Tipo.Range;
}
