using System.Linq;
using Database;
using Database.Models;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace TestResource
    {
    public class TestResource : Script
        {            
            [ServerEvent(Event.ResourceStart)]
            public void OnResourceStart()
            {
                using (var dbContext = new AlternativaContext())
                {
                    var playerCount = dbContext.Users.Count();
                    NAPI.Util.ConsoleOutput("Total players in the database: " + playerCount);
                }
            }

            [Command("spawncar")]
            public void CMDOnSpawnCar(Player player, VehicleHash vehicleId = VehicleHash.Deveste)
            {
                AltPlayerEvent pev = new AltPlayerEvent(player.Name, this, "OnSpawnCar", "Sapawned car 123");
                AltFileLogger altLogger = new AltFileLogger();
                altLogger.Log(LogLevel.Info, pev);
                NAPI.Vehicle.CreateVehicle(vehicleId, player.Position, player.Heading, 131, 131);
            }
            
            [ServerEvent(Event.PlayerConnected)]
            public void OnPlayerConnected(Player player)
            {
                using (var dbContext = new AlternativaContext())
                {
                    var connectedUser = dbContext.Users.Where(u => u.Name == player.Name).FirstOrDefault();
                    
                    var userConnected = new UserEvent
                    {
                        Type = UserEventType.Connected,
                        User = connectedUser
                    };

                    var connectionsCount = dbContext.UserEvents.Where(ue => ue.User == connectedUser).Count();
                    NAPI.Util.ConsoleOutput("Connected: " + connectionsCount);
                    dbContext.UserEvents.Add(userConnected);
                    dbContext.SaveChanges();
                }
            }
        }
    }
    