using System.Linq;
using AbstractResource;
using Database;
using Database.Models;
using GTANetworkAPI;
using Player = GTANetworkAPI.Player;

namespace TestResource
{
    public class TestResource : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnTestResourceStart()
        {
            using var dbContext = new AlternativaContext();
            int playerCount = dbContext.Users.Count();
            NAPI.Util.ConsoleOutput("Total players in the database: " + playerCount);
        }

        [Command("spawncar")]
        public void CMDOnSpawnCar(Player player, VehicleHash vehicleId = VehicleHash.Deveste)
        {
            NAPI.Vehicle.CreateVehicle(vehicleId, player.Position, player.Heading, 131, 131);
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            using var dbContext = new AlternativaContext();
            var connectedUser = dbContext.Users.FirstOrDefault(u => u.Name == player.Name);

            var userConnected = new UserEvent
            {
                Type = UserEventType.Connected,
                User = connectedUser
            };

            int connectionsCount = dbContext.UserEvents.Count(ue => ue.User == connectedUser);
            NAPI.Util.ConsoleOutput("Connected: " + connectionsCount);
            dbContext.UserEvents.Add(userConnected);
            dbContext.SaveChanges();
        }
    }
}