using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models.Economics.Cash;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace Database.Models
{
    public partial class Character
    {
        [NotMapped] public string Fullname => $"{FirstName} {LastName}";

        [NotMapped]
        [JsonProperty("age")]
        public int Age =>
            Birthday.Date > DateTime.Today.AddYears(Birthday.Year - DateTime.Today.Year) ?
                DateTime.Today.Year - Birthday.Year - 1 :
                DateTime.Today.Year - Birthday.Year;

        public void AddAmountToCash(Character sender, long sum)
        {
            Finances.Cash += sum;
            AltContext.Add(new CashTransaction(sum, sender, this));
            PushInContext();
        }

        public static explicit operator Player (Character character) => character.Account;

        public override string ToString() => $"{Id}_[{Fullname}]";

        #region In Game Time

        [NotMapped]
        [JsonProperty("inGameTime")]
        public long InGameSeconds => (long)InGameTime.TotalSeconds;

        public void IncreaseInGameTime(TimeSpan time)
        {
            InGameTime += time;
            PushInContext();
        }

        #endregion

        #region Death And Reborn

        [NotMapped] public bool IsDead => TimeToReborn > TimeSpan.Zero;

        [NotMapped] public int SecondsToReborn => (int)TimeToReborn.TotalSeconds;

        public void DecreaseTimeToReborn(TimeSpan time)
        {
            PullFromContext();
            TimeToReborn -= time;
            PushInContext();
        }

        public void ResetTimeToReborn()
        {
            PullFromContext();
            TimeToReborn = TimeSpan.FromSeconds(1);
            PushInContext();
        }
        
        #endregion

        #region OnEvents

        public void OnDisconnect(Player player)
        {
            PullFromContext();
            Account.SaveDisconnect();
            SpawnData.Save(player);
            PushInContext();
        }

        public void OnDeath(TimeSpan timeToReborn)
        {
            TimeToReborn += timeToReborn;
            PushInContext();
        }

        #endregion
    }
}