using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class OutputFace
    {
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        //Documents use BoundingBox.Vertices
        //Images use BoundingBox.Vertices
        //Videos use Top, Bottom, Left, Right
        [JsonProperty("Bounding_box")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        //Only used in Video
        public string Segment { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        public OutputFace(InputFace inputFace)
        {
            this.Confidence = inputFace.Confidence;
            this.Page = inputFace.Page;
            this.Segment = inputFace.Segment;
            this.BoundingBox = inputFace.BoundingBox;


        }
    }
}
