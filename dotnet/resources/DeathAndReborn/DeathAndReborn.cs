using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
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

        private static TimeSpan GetTimeToReborn(Player player)
        {
            float distance = RestrictDistance(HospitalLocationProvider.GetLeastDistance(player.Position));
            return TimeSpan.FromMinutes(distance / 500) + TimeSpan.FromMinutes(1 / (player.GetAccessLevels().VipLevel + 1) * 4);
        }

        private static float RestrictDistance(float distance)
        {
            float restrictedDistance = distance;
            if (distance < 500) restrictedDistance = 500;
            if (distance > 2500) restrictedDistance = 2500;
            return restrictedDistance;
        }

        #region Server Events

        [ServerEvent(Event.ResourceStart)]
        public void OnTimeCounterStart()
        {
            NAPI.Server.SetAutoRespawnAfterDeath(false);
            Task.Run(DeathTimeCounter);
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player victim, Player? killer, DeathReason reason)
        {
            var victimСharacter = victim.GetCharacter();
            var killerСharacter = killer?.GetCharacter();
            if (victimСharacter.IsDead) return;
            
            var timeToReborn = GetTimeToReborn(victim);
            victimСharacter.OnDeath(timeToReborn);
            
            string deathReason = DeathReasonStringBuilder.GetDeathReason(reason, killerСharacter);
            ClientConnect.Trigger(victim, "Death", victimСharacter.SecondsToReborn, deathReason);
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
