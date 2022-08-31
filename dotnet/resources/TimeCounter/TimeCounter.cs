using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
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
                character.IncreaseInGameTime(TimeSpan.FromMinutes(1));
        }

        #endregion
    }
}
