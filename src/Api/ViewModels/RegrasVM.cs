using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.ViewModels
{
    public class RegrasVM
    {
        [Required]
        [JsonPropertyName("nome")]
        public virtual string Nome { get; set; }

        [Required]
        [JsonPropertyName("filtros")]
        public virtual ICollection<FiltroVM> Filtros { get; set; }

    }
}