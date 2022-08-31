using System;
using System.ComponentModel.DataAnnotations.Schema;
using GTANetworkAPI;

namespace Database.Models
{
    public partial class Character
    {
        #region OnEvents

        public void OnDisconnect(Vector3 position)
        {
            Account.OnDisconnect();
            LastPosition = position;
            UpdateInContext();
        }

        public void OnDeath()
        {
            TimeToReborn += TimeSpan.FromMinutes(5);
            UpdateInContext();
        }

        #endregion

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

        [NotMapped] public bool IsDead => TimeToReborn > TimeSpan.Zero;

        public override string ToString() => $"{Id}: [{FirstName} {LastName}]";
    }
}