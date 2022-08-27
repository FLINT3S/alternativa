using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using LocalContextCls = LocalContext.Main;

namespace TimeCounter
{
    public class Main : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            Task.Run(TimeCountProcess);
        }

        private static void TimeCountProcess()
        {
            while (true)
            {
                LocalContextCls
                    .OnlinePlayers
                    .AsParallel()
                    .Select(a => a.ActiveCharacter)
                    .ForAll(c => c?.IncreaseInGameTime(TimeSpan.FromMinutes(1)));
                Thread.Sleep(60_000);
            }
        }
    }
}
