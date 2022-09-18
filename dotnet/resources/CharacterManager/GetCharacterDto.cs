using System;
using Database.Models;
using Newtonsoft.Json;

namespace CharacterManager
{
    /// <summary>
    /// DTO для отправки на клиент. В конструкторе принимает обычный Character
    /// </summary>
    public class GetCharacterDto
    {
        public GetCharacterDto(Character character)
        {
            Guid = character.Id.ToString();
            FirstName = character.FirstName;
            LastName = character.LastName;
            var ageSpan = DateTime.Today - character.Birthday;
            Age = (new DateTime(1, 1, 1) + ageSpan).Year - 1;
            StaticId = character.StaticId;
            InGameTime = (long)character.InGameTime.TotalSeconds;
        }

        [JsonProperty("guid")] public string Guid { get; set; }
        [JsonProperty("firstName")] public string FirstName { get; set; }
        [JsonProperty("lastName")] public string LastName { get; set; }
        [JsonProperty("age")] public int Age { get; set; }
        [JsonProperty("staticId")] public long StaticId { get; set; }
        [JsonProperty("inGameTime")] public long InGameTime { get; set; }

        public string GetJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}