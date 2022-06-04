namespace Domain.Entities;

using Domain.Enums;

public class FiltroValor : FiltroAbstrato<string>
{
    public override Tipo Tipo => Tipo.Valor;
}
