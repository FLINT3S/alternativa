using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Database.Models
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class CharacterAppearance
    {
        public CharacterAppearance(byte motherId, byte fatherId, float similarity, float skinSimilarity,
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

        [JsonIgnore] public Character Owner { get; set; }

        public Guid OwnerId { get; set; }

        [JsonProperty("motherId")] public byte MotherId { get; set; }

        [JsonProperty("fatherId")] public byte FatherId { get; set; }

        [JsonProperty("similarity")] public float Similarity { get; set; }

        [JsonProperty("skinSimilarity")] public float SkinSimilarity { get; set; }

        [JsonProperty("faceFeatures")] public List<float> FaceFeatures { get; set; }

        public string ToJsonString() => JsonConvert.SerializeObject(this);
    }
}