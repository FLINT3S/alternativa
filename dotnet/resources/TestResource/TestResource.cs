using AbstractResource;
using GTANetworkAPI;
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
        
        [Command("killme")]
        public void CMDOnKillMe(Player player)
        {
            NAPI.Task.Run(() => player.Health = 0);
        }
    }
}
