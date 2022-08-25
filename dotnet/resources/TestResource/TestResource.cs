﻿using System;
using System.Linq;
using AbstractResource;
using Database;
using Database.Models;
using Database.Models.AccountEvents;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;
using NAPIExtensions;
using Player = GTANetworkAPI.Player;

namespace TestResource
{
    public class TestResource : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTestResourceStart()
        {
            // using var dbContext = new AlternativaContext();
        }

        [Command("spawncar")]
        public void CMDOnSpawnCar(Player player, VehicleHash vehicleId = VehicleHash.Deveste)
        {
            NAPI.Vehicle.CreateVehicle(vehicleId, player.Position, player.Heading, 131, 131);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            var character = player.GetActiveCharacter();
            character!.OnDisconnect(player.Position);
            
            var account = player.GetAccount();
            account!.OnDisconnect();
        }

        [RemoteProc("RPC::CEF:SERVER:AdminPanel:randomDamage")]
        private string RemoteProcRandomDamage(Player player)
        {
            AltLogger.Instance.LogDevelopment(new AltEvent(this, "RemoteProcRandomDamage", ""));
            NAPI.Task.WaitForMainThread(1000);
            player.Health -= (int) Math.Round(new Random().NextDouble() * 20);
            return "Байты получены";
        }
    }
}
