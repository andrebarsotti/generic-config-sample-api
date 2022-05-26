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

public class Filtro<T> : IFiltro<T>
{
    public Tipo Tipo { get; set; }
    public string Nome { get; set; }
    public T Valor { get; set; } 
}

public class FiltroLista : Filtro<IEnumerable<ItemLista>> {}

public class FiltroRange : Filtro<Range> {}

public class FiltroValor : Filtro<string> {}

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
