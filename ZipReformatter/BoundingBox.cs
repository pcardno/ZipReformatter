using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class BoundingBox
    {
        [JsonProperty("vertices")]
        public List<Vertice> Vertices { get; set; }
        //public Vertice Vertices { get; set; }

        [JsonProperty("top")]
        public string Top { get; set; }
        [JsonProperty("bottom")]
        public string Bottom { get; set; }
        [JsonProperty("left")]
        public string Left { get; set; }
        [JsonProperty("right")]
        public string Right { get; set; }
    }
}
