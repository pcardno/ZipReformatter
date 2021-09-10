using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class InputBrand
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("score")]
        public decimal Score { get; set; }

        [JsonProperty("boundingPoly")]
        public BoundingBox BoundingBox { get; set; }

    }
}
