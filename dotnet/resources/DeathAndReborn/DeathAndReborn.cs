using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace DeathAndReborn
{
    public class DeathAndReborn : AltAbstractResource
    {
        private void Respawn(Character character)
        {
            var account = character.Account;
            NAPI.Task.Run(
                    () =>
                    {
                        var player = NAPI.Pools.GetAllPlayers().First(p => p.SocialClubId == account.SocialClubId);
                        NAPI.Player.SpawnPlayer(player, Vector3.RandomXy());
                        ClientConnect.Trigger(player, "Reborn");
                    }
                );
        }

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
            if (player.GetCharacter()!.IsDead) return;
            player.GetCharacter()!.OnDeath();
            ClientConnect.Trigger(player, "Death");
        }

        #endregion

        #region Counter

        private void DeathTimeCounter()
        {
            while (true)
            {
                Task.Run(DecreaseTimeToReborn);
                Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
            }
        }

        private void DecreaseTimeToReborn()
        {
            List<Character> deadCharacters = NAPI.Pools.GetActiveCharacters().Where(character => character.IsDead).ToList();
            foreach (var deadCharacter in deadCharacters)
            {
                deadCharacter.DecreaseTimeToReborn(TimeSpan.FromSeconds(1));
                if (!deadCharacter.IsDead)
                    Respawn(deadCharacter);
            }
        }

        #endregion
    }
}