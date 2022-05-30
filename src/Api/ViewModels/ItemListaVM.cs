using System.Text.Json.Serialization;

namespace Api.ViewModels;

public class ItemListaVM
{
    [JsonPropertyName("id")]
    public virtual int Id { get; set; }

    [JsonPropertyName("descricao")]
    public virtual string Descricao { get; set; }
}
