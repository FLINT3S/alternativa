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
            LastPosition = position;
            UpdateInContext();
        }

        #endregion

        [NotMapped] public bool IsAlive => TimeToReborn <= TimeSpan.Zero;
        
        public void IncreaseInGameTime(TimeSpan time)
        {
            InGameTime += time;
            lock (AltContext.Locker)
            {
                UpdateInContext();
            }
        }

        public void DecreaseTimeToReborn(TimeSpan time)
        {
            TimeToReborn -= time;
            lock (AltContext.Locker)
            {
                UpdateInContext();
            }
        }

        public override string ToString() => $"{Id}: [{FirstName} {LastName}]";
    }
}