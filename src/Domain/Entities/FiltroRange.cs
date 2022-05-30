namespace Domain.Entities;

using Domain.Enums;

using MongoDB.Bson.Serialization.Attributes;

[Serializable]
[BsonDiscriminator($"{EntitiesConstants.NameSpaceBson}.{nameof(FiltroRange)}")]
public class FiltroRange : FiltroAbstrato<Range>
{
    public override Tipo Tipo => Tipo.Range;
}
