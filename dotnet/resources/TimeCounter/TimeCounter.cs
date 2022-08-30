using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace TimeCounter
{
    public class TimeCounter : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            Task.Run(CommonTimeCounter);
            Task.Run(DeathTimeCounter);
        }

        #region Common Counter
        
        private static void CommonTimeCounter()
        {
            while (true)
            {
                Task.Run(IncreaseGameTime);
                Thread.Sleep(60_000);
            }
        }

        private static void IncreaseGameTime()
        {
            List<Character> onlineCharacters = NAPI.Pools.GetActiveCharacters().ToList();
            foreach (var character in onlineCharacters)
                character.InGameTime += TimeSpan.FromMinutes(1);

            lock (AltContext.Locker)
            {
                AltContext.Instance.UpdateRange(onlineCharacters);
                AltContext.Instance.SaveChanges();
            }
        }

        #endregion

        #region Time to Reborn Counter
        
        private static void DeathTimeCounter()
        {
            while (true)
            {
                Task.Run(DecreaseTimeToReborn);
                Thread.Sleep(1_000);
            }
        }

        private static void DecreaseTimeToReborn()
        {
            List<Character> deadCharacters = NAPI.Pools.GetActiveCharacters().Where(character => character.IsDead).ToList();
            foreach (var deadCharacter in deadCharacters)
                deadCharacter.TimeToReborn -= TimeSpan.FromSeconds(1);

            lock (AltContext.Locker)
            {
                AltContext.Instance.UpdateRange(deadCharacters);
                AltContext.Instance.SaveChanges();
            }
        }

        #endregion
    }
}
