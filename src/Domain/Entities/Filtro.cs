namespace Domain.Entities;

using Domain.Enums;

public interface IFiltro
{
    Tipo Tipo { get; }
    string Nome { get; }
}

public interface IFiltro<out T> : IFiltro
{
    T Valor { get; }
}

public abstract class FiltroAbstrato<T> : IFiltro<T>
{
    public abstract Tipo Tipo { get; }

    public virtual string Nome { get; set; }

    public virtual T Valor { get; set; } 
}
