using System.Collections.Generic;

namespace Database.Models
{
    public class CharacterCreatorDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public int gender { get; set; }
        public List<float> faceFeatures { get; set; }
        public int motherId { get; set; }
        public int fatherId { get; set; }
        public float similarity { get; set; }
        public float skinSimilarity { get; set; }
    }
}