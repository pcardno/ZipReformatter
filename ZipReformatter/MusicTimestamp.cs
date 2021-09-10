using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class MusicTimestamp
    {
        [JsonProperty("start_time")]
        public decimal StartTime { get; set; }

        [JsonProperty("end_time")]
        public decimal EndTime { get; set; }
    }
}
