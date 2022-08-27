using System;
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

        public void IncreaseInGameTime(TimeSpan time)
        {
            InGameTime += time;
            lock (AltContext.Locker)
            {
                UpdateInContext();
            }
        }

        public override string ToString() => $"{Id}: [{FirstName} {LastName}]";
    }
}