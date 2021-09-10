using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZipReformatter
{
    class InputZipFile
    {
        [JsonProperty("asset_id")]
        public string AssetID { get; set; }

        [JsonProperty("asset_url")]
        public string AssetURL { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("file_type")]
        public string FileType { get; set; }

        [JsonProperty("file_name")]
        public string Filename { get; set; }

        [JsonProperty("gcp_url")]
        public string GCPURL { get; set; }

        [JsonProperty("brands_detected")]
        public bool BrandsDetected { get; set; }
        //[JsonProperty("brands")]
        //public List<Brand> Brands { get; set; }

        [JsonProperty("face_detected")]
        public bool FacesDetected { get; set; }


        [JsonProperty("faces")]
        public List<InputFace> Faces { get; set; }

        [JsonProperty("landmarks_detected")]
        public bool LandmarksDetected { get; set; }
        [JsonProperty("landmarks")]
        public List<Landmark> Landmarks { get; set; }

        public bool NeedsSomeReview
        {
            get
            {
                return LandmarksDetected || FacesDetected || BrandsDetected || MusicDetected;
            }
        }

        [JsonProperty("music_detected")]
        public bool MusicDetected { get; set; }

        [JsonProperty("music")]
        public List<MusicTimestamp> MusicTimeStamps { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        public List<Asset> Components { get; set; }
    }
}
