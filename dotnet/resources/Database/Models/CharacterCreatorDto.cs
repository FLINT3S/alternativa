using System.Collections.Generic;
using Newtonsoft.Json;

namespace Database.Models
{
    public class CharacterCreatorDto
    {
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("surname")]
        public string Surname { get; set; }
        
        [JsonProperty("age")]
        public int Age { get; set; }
        
        [JsonProperty("gender")]
        public int Gender { get; set; }
        
        [JsonProperty("faceFeatures")]
        public List<float> FaceFeatures { get; set; }
        
        [JsonProperty("motherId")]
        public int MotherId { get; set; }
        
        [JsonProperty("fatherId")]
        public int FatherId { get; set; }
        
        [JsonProperty("similarity")]
        public float Similarity { get; set; }
        
        [JsonProperty("skinSimilarity")]
        public float SkinSimilarity { get; set; }
    }
}