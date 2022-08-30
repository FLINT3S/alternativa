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
    public class DeathAndReborn : AltAbstractResource
    {
        #region Server Events
        
        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            NAPI.Server.SetAutoRespawnAfterDeath(false);
            Task.Run(DeathTimeCounter);
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player player, Player killer, uint reason)
        {
            if (player.GetActiveCharacter()!.IsDead) return;
            player.GetActiveCharacter()!.OnDeath();
            ClientConnect.Trigger(player, "Death");
        }

        #endregion
        
        #region Counter
        
        private void DeathTimeCounter()
        {
            while (true)
            {
                Task.Run(DecreaseTimeToReborn);
                Thread.Sleep(1_000);
            }
        }

        private void DecreaseTimeToReborn()
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

        private void Respawn(Character character)
        {
            var account = character.Account;
            NAPI.Task.Run(
                () =>
                {
                    var player = NAPI.Pools.GetAllPlayers().First(p => p.SocialClubId == account.SocialClubId);
                    NAPI.Player.SpawnPlayer(player, Vector3.RandomXy());
                    ClientConnect.Trigger(player, "Reborn");
                });
        }
    }
}
