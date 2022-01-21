using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Exercises.Model
{
    public class ResponseTwo
    {
        [JsonPropertyName("Tamanio del Camión")]
        public int tamanioCamion { get; set; }
        [JsonPropertyName("Paquetes")]
        public List<int> paquetes { get; set; }
        [JsonPropertyName("Resultado")]
        public dynamic resultado { get; set; }
    }
}
