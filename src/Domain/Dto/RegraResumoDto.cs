namespace Domain.Dto;

public class RegraResumoDto
{

    public virtual string Id { get; set; }

    public virtual string Nome { get; set; }

    public virtual DateTime DataInclusao { get; set; }

    public virtual string IncluidoPor { get; set; }
}
