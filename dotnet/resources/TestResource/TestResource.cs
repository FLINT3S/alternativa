using System;
using System.Collections.Generic;
using System.Linq;
using AbstractResource;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;
using Player = GTANetworkAPI.Player;

namespace TestResource
{
    public class TestResource : AltAbstractResource
    {
        [Command("spawncar")]
        public void CMDOnSpawnCar(Player player, VehicleHash vehicleId = VehicleHash.Deveste)
        {
            NAPI.Vehicle.CreateVehicle(vehicleId, player.Position, player.Heading, 131, 131);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
        {
            // var character = player.GetActiveCharacter();
            // character!.OnDisconnect(player.Position);
            //
            // var account = player.GetAccount();
            // account!.OnDisconnect();
            throw new NotImplementedException();
            
            List<Account>? onlinePlayers = LocalContext.EntityLists.OnlinePlayers;
            
            if (onlinePlayers.Any(a => a.SocialClubId == player.SocialClubId))
                onlinePlayers.Remove(player.GetAccount()!);
        }
    }
}
