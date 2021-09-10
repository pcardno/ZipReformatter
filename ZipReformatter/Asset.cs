using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ZipReformatter
{
    class Asset
    {
        [JsonProperty("asset_id")]
        public string AssetID { get; set; }
        public string URL { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("asset_type")]

        public string AssetType { get; set; }
        [JsonProperty("brands_detected")]
        public bool BrandsDetected { get; set; }
        [JsonProperty("brands")]
        public Object Brands { get; set; }

        [JsonProperty("face_detected")]
        public bool FacesDetected { get; set; }


        [JsonProperty("faces")]
        public Object Faces { get; set; }


        [JsonProperty("landmarks_detected")]
        public bool LandmarksDetected { get; set; }
        [JsonProperty("landmarks")]
        public Object Landmarks { get; set; }

        public bool NeedsSomeReview
        {
            get
            {
                return LandmarksDetected || FacesDetected || BrandsDetected || MusicDetected;
            }
        }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        [JsonIgnore]
        public string BrightCoveURL { get; set; }

        public string Business { get; set; }
        public string Division { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Area { get; set; }

        [JsonProperty("music_detected")]
        public bool MusicDetected { get; set; }

        [JsonProperty("music")]
        public List<MusicTimestamp> MusicTimeStamps { get; set; }








    }
}
