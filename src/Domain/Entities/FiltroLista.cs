namespace Domain.Entities;

using Domain.Enums;

public class FiltroLista : FiltroAbstrato<IEnumerable<ItemLista>>
{
    public override Tipo Tipo => Tipo.Lista;
}
