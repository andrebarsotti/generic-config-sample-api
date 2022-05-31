using System.Text.Json.Serialization;

namespace Api.ViewModels;

public class RegrasVM
{
    [JsonPropertyName("nome")]
    public virtual string? Nome { get; set; }

    [JsonPropertyName("dataInlcusao")]
    public virtual DateTime? DataInclusao { get; set; }

    [JsonPropertyName("incluidoPor")]
    public virtual string? IncluidoPor { get; set; }
    
    [JsonPropertyName("filtros")]
    public virtual ICollection<FiltroVM>? Filtros { get; set; }

}
