using System.Text.Json.Serialization;

namespace Api.ViewModels
{
    public class RangeVM
    {
        [JsonPropertyName("de")]
        public int De { get; set; }

        [JsonPropertyName("ate")]
        public int Ate { get; set; }
    }
}