using System;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace DeathAndReborn
{
    public static class DeathReasonStringBuilder
    {
        public static string GetDeathReason(DeathReason reason, Player? killer) => 
            ParseDeathReason(reason, killer?.GetCharacter());

        private static string ParseDeathReason(DeathReason reason, Character? killer) => reason switch
        {
            DeathReason.ElectricFence when killer != null => $"Вы скончались в результате электротравмы, полученной из-за {killer.Fullname}",
            DeathReason.ElectricFence => "Вы скончались в результате электротравмы",
            DeathReason.HitByWaterCannon when killer != null => throw new NotImplementedException(),
            DeathReason.HitByWaterCannon => throw new NotImplementedException(),
            DeathReason.RammedByCar when killer != null => throw new NotImplementedException(),
            DeathReason.RammedByCar => throw new NotImplementedException(),
            DeathReason.RunOverByCar when killer != null => throw new NotImplementedException(),
            DeathReason.RunOverByCar => throw new NotImplementedException(),
            DeathReason.Fall when killer != null => throw new NotImplementedException(),
            DeathReason.Fall => throw new NotImplementedException(),
            DeathReason.Animal when killer != null => throw new NotImplementedException(),
            DeathReason.Animal => throw new NotImplementedException(),
            DeathReason.AirstrikeRocket when killer != null => throw new NotImplementedException(),
            DeathReason.AirstrikeRocket => throw new NotImplementedException(),
            DeathReason.Bleeding when killer != null => throw new NotImplementedException(),
            DeathReason.Bleeding => throw new NotImplementedException(),
            DeathReason.Briefcase when killer != null => throw new NotImplementedException(),
            DeathReason.Briefcase => throw new NotImplementedException(),
            DeathReason.Briefcase02 when killer != null => throw new NotImplementedException(),
            DeathReason.Briefcase02 => throw new NotImplementedException(),
            DeathReason.Cougar when killer != null => throw new NotImplementedException(),
            DeathReason.Cougar => throw new NotImplementedException(),
            DeathReason.BarbedWire when killer != null => throw new NotImplementedException(),
            DeathReason.BarbedWire => throw new NotImplementedException(),
            DeathReason.Drowning when killer != null => throw new NotImplementedException(),
            DeathReason.Drowning => throw new NotImplementedException(),
            DeathReason.DrowningInVehicle when killer != null => throw new NotImplementedException(),
            DeathReason.DrowningInVehicle => throw new NotImplementedException(),
            DeathReason.Explosion when killer != null => $"Вас взорвал {killer.Fullname}",
            DeathReason.Explosion => "Вы взорвались",
            DeathReason.Exhaustion when killer != null => throw new NotImplementedException(),
            DeathReason.Exhaustion => throw new NotImplementedException(),
            DeathReason.Fire when killer != null => throw new NotImplementedException(),
            DeathReason.Fire => throw new NotImplementedException(),
            DeathReason.HeliCrash when killer != null => throw new NotImplementedException(),
            DeathReason.HeliCrash => throw new NotImplementedException(),
            DeathReason.VehicleRocket when killer != null => throw new NotImplementedException(),
            DeathReason.VehicleRocket => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(reason), reason, null)
        };
    }
}