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
        private void Respawn(Character character) => NAPI.Task.Run(() =>
        {
            var player = (Player)character;
            player.Position = HospitalLocationProvider.GetNearest(player.Position);
            NAPI.Player.SpawnPlayer(player, player.Position);
            LogPlayer(player, "Reborn", $"Respawned at {player.Position}");
            ClientConnect.Trigger(player, "Reborn");
        });

        private static TimeSpan GetTimeToReborn(Player player)
        {
            float distance = RestrictDistance(HospitalLocationProvider.GetLeastDistance(player.Position));
            return RoundSeconds(
                TimeSpan.FromMinutes(distance / 500) + TimeSpan.FromMinutes(1 / (player.GetAccessLevels().VipLevel + 1) * 4)
                );
        }

        private static float RestrictDistance(float distance)
        {
            float restrictedDistance = distance;
            if (distance < 500) restrictedDistance = 500;
            if (distance > 2500) restrictedDistance = 2500;
            return restrictedDistance;
        }

        private static TimeSpan RoundSeconds(TimeSpan timeSpan) => TimeSpan.FromSeconds(timeSpan.TotalSeconds);

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
            LogPlayer(victim, "Death", deathReason);
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
            var deadCharacters = NAPI.Pools.GetActiveCharacters().Where(character => character.IsDead).ToList();
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