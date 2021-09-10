using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class Brand
    {
        public string Description { get; set; }
        public decimal Confidence { get; set; }

        public string Start_Time_Offset { get; set; }
        public string End_Time_Offset { get; set; }


        //This is used by video
        //[JsonProperty("Bounding_Boxes")]
        //public List<BoundingBox> BoundingBoxes { get; set; }

        //This is used by images
        [JsonProperty("Bounding_Boxes")]
        //public BoundingBox BoundingBoxes { get; set; }
        public Object BoundingBoxes { get; set; }

        //Not sure if this is used at all..
        //[JsonProperty("Bounding_box")]
        //public BoundingBox BoundingBox { get; set; }

        public List<BoundingBox> NormalisedBoundingBoxes { get; set; }

    }
}
