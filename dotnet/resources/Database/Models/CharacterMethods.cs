using System;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace Database.Models
{
    public partial class Character
    {
        [NotMapped] public bool IsDead => TimeToReborn > TimeSpan.Zero;

        [NotMapped] public string Fullname => $"{FirstName} {LastName}";

        [NotMapped] [JsonProperty("age")] public int Age
        {
            get 
            { 
                var today = DateTime.Today;
                int age = today.Year - Birthday.Year;
                if (Birthday.Date > today.AddYears(-age)) 
                    age--;
                return age;
            }
        }

        public void IncreaseInGameTime(TimeSpan time)
        {
            InGameTime += time;
            UpdateInContext();
        }

        public void DecreaseTimeToReborn(TimeSpan time)
        {
            TimeToReborn -= time;
            UpdateInContext();
        }

        public override string ToString() => $"{Id}: [{FirstName} {LastName}]";

        #region OnEvents

        public void OnDisconnect(Player player)
        {
            Account.OnDisconnect();
            SpawnData.OnDisconnect(player);
            UpdateInContext();
        }

        public void OnDeath()
        {
            TimeToReborn += TimeSpan.FromMinutes(5);
            UpdateInContext();
        }

        #endregion
    }
}