using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class CharacterAppearance
    {
        public CharacterAppearance(int motherId, int fatherId, float similarity, float skinSimilarity,
            List<float> faceFeatures)
        {
            MotherId = motherId;
            FatherId = fatherId;
            Similarity = similarity;
            SkinSimilarity = skinSimilarity;
            FaceFeatures = faceFeatures;
        }

        public CharacterAppearance(CharacterCreatorDto characterCreatorDto)
        {
            MotherId = characterCreatorDto.MotherId;
            FatherId = characterCreatorDto.FatherId;
            Similarity = characterCreatorDto.Similarity;
            SkinSimilarity = characterCreatorDto.SkinSimilarity;
            FaceFeatures = characterCreatorDto.FaceFeatures;
        }

        [JsonIgnore] public Guid Id { get; set; }

        [JsonIgnore] public Character Character { get; set; }

        public Guid CharacterId { get; set; }

        [JsonProperty("motherId")] public int MotherId { get; set; }

        [JsonProperty("fatherId")] public int FatherId { get; set; }

        [JsonProperty("similarity")] public float Similarity { get; set; }

        [JsonProperty("skinSimilarity")] public float SkinSimilarity { get; set; }

        [JsonProperty("faceFeatures")] public List<float> FaceFeatures { get; set; }

        public string ToJsonString() => JsonConvert.SerializeObject(this);
    }
}