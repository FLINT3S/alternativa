using System;
using System.Linq;
using Database;
using Database.Models;
using GTANetworkAPI;
using GTANetworkMethods;
using Logger;
using Logger.EventModels;
using Player = GTANetworkAPI.Player;

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
                var pev = new AltPlayerEvent(player.Name, this, "OnSpawnCar", "Sapawned car 123");
                var altAbstractLogger = AltLogger.Instance;
                altAbstractLogger.LogInfo(pev);
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
    