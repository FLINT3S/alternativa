using System;
using Database.Models;
using GTANetworkAPI;

namespace DeathAndReborn
{
    public static class DeathReasonStringBuilder
    {
        public static string GetDeathReason(DeathReason reason, Character? killer) => reason switch
        {
            DeathReason.ElectricFence when killer != null => $"Скончался в результате электротравмы, полученной из-за {killer.Fullname}",
            DeathReason.ElectricFence => "Скончался в результате электротравмы",
            
            DeathReason.HitByWaterCannon when killer != null => throw new NotImplementedException(),
            DeathReason.HitByWaterCannon => throw new NotImplementedException(),
            
            DeathReason.RammedByCar when killer != null => throw new NotImplementedException(),
            DeathReason.RammedByCar => throw new NotImplementedException(),
            
            DeathReason.RunOverByCar when killer != null => throw new NotImplementedException(),
            DeathReason.RunOverByCar => throw new NotImplementedException(),
            
            DeathReason.Fall when killer != null => $"Разбился из-за {killer.Fullname}",
            DeathReason.Fall => "Разбился",
            
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
            
            DeathReason.BarbedWire when killer != null => $"Замотан игроком {killer.Fullname}",
            DeathReason.BarbedWire => "Замотался",
            
            DeathReason.Drowning when killer != null => $"Утоплен игроком {killer.Fullname}",
            DeathReason.Drowning => "Захлебнулся",
            
            DeathReason.DrowningInVehicle when killer != null => $"Утоплен с транспортом игроком {killer.Fullname}",
            DeathReason.DrowningInVehicle => "Захлебнулся в транспорте",
            
            DeathReason.Explosion when killer != null => $"Вас взорвал {killer.Fullname}",
            DeathReason.Explosion => "Взорвался",
            
            DeathReason.Exhaustion when killer != null => throw new NotImplementedException(),
            DeathReason.Exhaustion => throw new NotImplementedException(),
            
            DeathReason.Fire when killer != null => throw new NotImplementedException(),
            DeathReason.Fire => throw new NotImplementedException(),
            
            DeathReason.HeliCrash when killer != null => throw new NotImplementedException(),
            DeathReason.HeliCrash => throw new NotImplementedException(),
            
            DeathReason.VehicleRocket when killer != null => throw new NotImplementedException(),
            DeathReason.VehicleRocket => throw new NotImplementedException(),
            
            _ when killer != null => $"Убит непонятно как игроком {killer.Fullname}",
            _ => "Умер непонятно как"
        };
    }
}