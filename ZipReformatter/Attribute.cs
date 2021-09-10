using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }
    }
}
