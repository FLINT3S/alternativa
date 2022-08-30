using AbstractResource;
using GTANetworkAPI;
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
            // var character = player.GetActiveCharacter();
            // character!.OnDisconnect(player.Position);
            
            // var account = player.GetAccount();
            // account!.OnDisconnect();
            
            // LocalContext.EntityLists.OnlinePlayers.Remove(account);
        }
    }
}
