using System;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using LocationProvider;
using NAPIExtensions;

namespace Updater
{
    public class Updater : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnUpdaterStart()
        {
            Task.Run(DimensionReleaseProcess);
        }

        private static void CharacterUpdateProcess()
        {
            while (true)
            {
                var characters = NAPI.Pools.GetActiveCharacters();
                foreach (var character in characters)
                    character.UpdateFromContext();
                Thread.Sleep((int)TimeSpan.FromMinutes(1).TotalMilliseconds);
            }
        }

        private static void DimensionReleaseProcess()
        {
            while (true)
            {
                DimensionProvider.ReleaseUnusedDimensions();
                Thread.Sleep(TimeSpan.FromMinutes(1));
            }
        }
    }
}
