using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using LocalContext;

namespace TimeCounter
{
    public class TimeCounter : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart() => Task.Run(TimeCountProcess);

        private static void TimeCountProcess()
        {
            while (true)
            {
                IEnumerable<Character> characters = EntityLists.OnlinePlayers.Select(a => a.ActiveCharacter);
                foreach (var character in characters)
                    Task.Run(() => character?.IncreaseInGameTime(TimeSpan.FromMilliseconds(60_000)));
                Thread.Sleep(60_000);
            }
        }
    }
}
