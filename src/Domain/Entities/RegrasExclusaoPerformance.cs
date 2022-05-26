namespace Domain.Entities;

public class RegrasExclusaoPerformance
{
    public string Id { get; set; }

    public string Nome { get; set; }

    public DateTime DataInclusao { get; set; }

    public string IncluidoPor { get; set; }

    public IEnumerable<IFiltro> Filtros { get; set; }
}
