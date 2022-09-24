using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using LocationProvider;
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
                        player.Position = HospitalLocationProvider.GetNearest(player.Position);
                        NAPI.Player.SpawnPlayer(player, player.Position);
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
            // TODO: Вынести константу времени возрождения, либо сделать её динамической.
            // На клиент отправлять время до возрождения и причину
            var character = player.GetCharacter()!;
            if (character.IsDead) return;
            character.OnDeath();
            ClientConnect.Trigger(player, "Death", character.SecondsToReborn, reason);
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
