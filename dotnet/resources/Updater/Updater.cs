using System;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace Updater
{
    public class Updater : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnUpdaterStart() => Task.Run(CharacterUpdateProcess);

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
    }
}
