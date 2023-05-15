using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GUSRekrutacja
{
    public class ThematicAreas
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("nazwa")]
        public string Name { get; set; }
        [JsonPropertyName("id-nadrzedny-element")]
        public int IDSuperiorelement { get; set; }
        [JsonPropertyName("id-poziom")]
        public int IDLevel { get; set; }
        [JsonPropertyName("nazwa-poziom")]
        public string NameLevel { get; set; }
        [JsonPropertyName("czy-zmienne")]
        public int Variables { get; set; }
    }
}
