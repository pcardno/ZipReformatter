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

        //Documents use BoundingBox.Vertices
        //Images use BoundingBox.Vertices
        //Videos use Top, Bottom, Left, Right
        [JsonProperty("boundingPoly")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        //Only used in Video
        public string Segment { get; set; }
    }
}
