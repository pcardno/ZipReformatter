using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class Landmark
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("score")]
        public decimal Confidence { get; set; }

        public string Segment { get; set; }

        [JsonProperty("boundingPoly")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
