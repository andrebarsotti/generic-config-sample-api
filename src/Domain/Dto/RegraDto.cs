using Domain.Entities;

namespace Domain.Dto
{
    public class RegraDto
    {
        public virtual string? Nome { get; set; }

        public virtual string? Responsavel { get; set; }

        public virtual ICollection<IFiltro>? Filtros { get; set; }
    }
}
