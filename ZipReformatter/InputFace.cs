using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class InputFace
    {
        [JsonProperty("detectionConfidence")]
        public decimal Confidence { get; set; }


        [JsonProperty("boundingPoly")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("Bounding box")]
        public BoundingBox VideoBoundingBox { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        //Only used in Video
        public string Segment { get; set; }

        [JsonProperty("Attributes")]
        public List<Attribute> Attributes { get; set; }
    }
}
