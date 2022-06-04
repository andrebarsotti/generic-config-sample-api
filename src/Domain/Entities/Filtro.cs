namespace Domain.Entities;

using Domain.Enums;

public interface Filtro
{
    Tipo Tipo { get; }
    string Nome { get; }
}

public interface Filtro<T> : Filtro
{
    T Valor { get; }
}

public abstract class FiltroAbstrato<T> : Filtro<T>
{
    public abstract Tipo Tipo { get; }

    public virtual string Nome { get; set; }

    public virtual T Valor { get; set; } 
}
