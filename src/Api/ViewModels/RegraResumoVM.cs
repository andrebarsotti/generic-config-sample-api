using System.Text.Json.Serialization;

namespace Api.ViewModels;

public class RegraResumoVM
{

    [JsonPropertyName("id")]
    public virtual string Id { get; set; }

    [JsonPropertyName("nome")]
    public virtual string Nome { get; set; }

    [JsonPropertyName("dataInlcusao")]
    public virtual DateTime DataInclusao { get; set; }

    public virtual string IncluidoPor { get; set; }
}