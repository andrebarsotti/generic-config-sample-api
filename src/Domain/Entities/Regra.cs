namespace Domain.Entities;

public class Regra
{
    public virtual string Id { get; set; }

    public virtual string Nome { get; set; }

    public virtual DateTime DataInclusao { get; set; }

    public virtual string IncluidoPor { get; set; }

    public virtual ICollection<IFiltro> Filtros { get; set; }
}
