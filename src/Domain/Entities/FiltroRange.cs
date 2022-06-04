namespace Domain.Entities;

using Domain.Enums;

public class FiltroRange : FiltroAbstrato<Range>
{
    public override Tipo Tipo => Tipo.Range;
}
