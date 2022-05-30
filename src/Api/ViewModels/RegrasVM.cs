using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

using Domain.Enums;

namespace Api.ViewModels;

[Serializable]
public class RegrasVM
{
    [Required]
    [JsonPropertyName("nome")]
    public virtual string Nome { get; set; }

    [Required]
    [JsonPropertyName("filtros")]
    public virtual ICollection<FiltroVM> Filtros { get; set; }

}

[Serializable]
public class FiltroVM
{
    [Required]
    [JsonPropertyName("tipo")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public virtual Tipo Tipo { get; set; }

    [Required]
    [JsonPropertyName("nome")]
    public virtual string Nome { get; set; }

    [Required]
    [JsonPropertyName("valor")]
    public virtual JsonElement Valor { get; set; }
}

public class ItemListaVM
{
    [JsonPropertyName("id")]
    public virtual int Id { get; set; }

    [JsonPropertyName("descricao")]
    public virtual string Descricao { get; set; }
}
