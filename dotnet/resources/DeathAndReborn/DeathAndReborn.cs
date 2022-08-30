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

namespace DeathAndReborn
{
    public class Main : AltAbstractResource
    {
        #region Server Events
        
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            NAPI.Server.SetAutoRespawnAfterDeath(false);
            Task.Run(DeathTimeCounter);
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player client, Player killer, uint reason)
        {
            client.GetActiveCharacter()!.OnDeath();
        }

        #endregion
        
        #region Counter
        
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
            {
                deadCharacter.TimeToReborn -= TimeSpan.FromSeconds(1);
                if (!deadCharacter.IsDead)
                    Respawn(deadCharacter);
            }

            lock (AltContext.Locker)
            {
                AltContext.Instance.UpdateRange(deadCharacters);
                AltContext.Instance.SaveChanges();
            }
        }

        #endregion

        private static void Respawn(Character character)
        {
            var account = character.Account;
            var player = NAPI.Pools.GetAllPlayers().First(p => p.SocialClubId == account.SocialClubId);
            NAPI.Player.SpawnPlayer(player, Vector3.RandomXy());
        }
    }
}
