using System;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace Database.Models
{
    public partial class Character
    {
        [NotMapped] public string Fullname => $"{FirstName} {LastName}";

        [NotMapped, JsonProperty("age")] public int Age => 
            Birthday.Date > DateTime.Today.AddYears(Birthday.Year - DateTime.Today.Year) ? 
                DateTime.Today.Year - Birthday.Year - 1 : 
                DateTime.Today.Year - Birthday.Year;

        [NotMapped, JsonProperty("inGameTime")]
        public long InGameSeconds => (long)InGameTime.TotalSeconds;

        public void IncreaseInGameTime(TimeSpan time)
        {
            InGameTime += time;
            UpdateInContext();
        }

        #region DeathAndReborn
        
        [NotMapped] public bool IsDead => TimeToReborn > TimeSpan.Zero;

        [NotMapped]
        public int SecondsToReborn => (int)TimeToReborn.TotalSeconds;
        
        public void DecreaseTimeToReborn(TimeSpan time)
        {
            TimeToReborn -= time;
            UpdateInContext();
        }

        public void Resurrect()
        {
            TimeToReborn = TimeSpan.FromSeconds(1);
            UpdateInContext();
        }

        #endregion

        public override string ToString() => $"{Id}_[{Fullname}]";

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