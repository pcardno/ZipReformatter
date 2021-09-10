using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class OutputBrand
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("Confidence")]
        public decimal Score { get; set; }

        [JsonProperty("Bounding_box")]
        public BoundingBox BoundingBox { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        public OutputBrand(InputBrand inputFace)
        {
            this.Description = inputFace.Description;
            this.Score = inputFace.Score;
            this.BoundingBox = inputFace.BoundingBox;


        }
    }
}
