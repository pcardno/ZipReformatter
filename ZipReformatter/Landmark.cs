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
        public string Description { get; set; }
        public decimal Confidence { get; set; }
        public string Segment { get; set; }
    }
}
