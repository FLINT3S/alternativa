using System;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace Database.Models.Realty
{
    public class Interior : AbstractModel
    {
        protected Interior()
        {
        }

        public Interior(Guid guid, string iplName, string name, Vector3 entrance, Vector3 exit, bool isWindowed = true)
        {
            Id = guid;
            IplName = iplName;
            Name = name;
            Entrance = entrance;
            Exit = exit;
            IsWindowed = isWindowed;
        }
        
        /*
         * Название модели интерьера
         */
        [JsonProperty("iplName")]
        public string IplName { get; protected set; }
        
        /*
         * Название интерьера. Отображается в интерфейсах
         */
        [JsonProperty("name")]
        public string Name { get; protected set; }
        
        [JsonProperty("entrance")]
        public Vector3 Entrance { get; protected set; }
        
        [JsonIgnore]
        public Vector3 Exit { get; protected set; }
        
        /*
         * Есть ли в интерьере открытые окна. Интерьеры без открытых окон лучше подходят для домов,
         * а с открытыми окнами для квартир
         */
        [JsonProperty("isWindowed")]
        public bool IsWindowed { get; protected set; }
    }
}