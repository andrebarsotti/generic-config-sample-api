using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

using Domain.Enums;

namespace Api.ViewModels;

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
