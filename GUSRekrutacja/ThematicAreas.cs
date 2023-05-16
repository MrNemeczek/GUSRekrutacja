using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GUSRekrutacja
{
    public class ThematicAreas
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("nazwa")]
        public string Name { get; set; }
        [JsonProperty("id-nadrzedny-element")]
        public int IDSuperiorElement { get; set; }
        [JsonProperty("id-poziom")]
        public int IDLevel { get; set; }
        [JsonProperty("nazwa-poziom")]
        public string NameLevel { get; set; }
        [JsonProperty("czy-zmienne")]
        public bool Variables { get; set; }
    }
}
