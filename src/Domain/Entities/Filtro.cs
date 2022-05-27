namespace Domain.Entities;
using Domain.Enums;

public interface IFiltro 
{ 
    Tipo Tipo { get; }
    string Nome { get; }
}

public interface IFiltro<T> : IFiltro
{
    T Valor { get; } 
}

public abstract class Filtro<T> : IFiltro<T>
{
    public abstract Tipo Tipo { get; }
    
    public virtual string Nome { get; set; }
    
    public virtual T Valor { get; set; } 
}

public class FiltroLista : Filtro<IEnumerable<ItemLista>>
{
    public override Tipo Tipo => Tipo.Lista;
}

public class FiltroRange : Filtro<Range>
{
    public override Tipo Tipo => Tipo.Range;
}

public class FiltroValor : Filtro<string>
{
    public override Tipo Tipo => Tipo.Valor;
}

public class ItemLista
{
    public int Id { get; set; }
    public string Descricao { get; set; }
}

public class Range
{
    public int De { get; set; }
    public int Ate { get; set; }
}
