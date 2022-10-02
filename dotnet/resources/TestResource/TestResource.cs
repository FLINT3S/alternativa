using System;
using System.Reflection;
using AbstractResource;
using AbstractResource.Attributes;
using Database;
using GTANetworkAPI;
using Microsoft.Extensions.Configuration;
using NAPIExtensions;

namespace TestResource
{
    public class TestResource : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnInternalResourceStart()
        {
            Console.WriteLine("Applying migrations...");
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            bool needApplyMigration = config.GetValue<bool>("ApplyMigrationWithStartup");
            if (needApplyMigration)
                AltContext.ApplyMigration();
            Console.WriteLine("Migrations applied!");
        }
        
        [Command("spawncar"), NeedAdminRights(2)]
        public void CMDOnSpawnCar(Player player, VehicleHash vehicleId = VehicleHash.Deveste) => 
            CheckPermissionsAndExecute(player, MethodBase.GetCurrentMethod()!, () => 
                    NAPI.Vehicle.CreateVehicle(vehicleId, player.Position, player.Heading, 131, 131));

        [Command("killme"), NeedAdminRights(1)]
        public void CMDOnKillMe(Player player) =>
            CheckPermissionsAndExecute(player, MethodBase.GetCurrentMethod()!, () => 
                NAPI.Task.Run(() => player.Health = 0));
                
        [Command("respawn"), NeedAdminRights(1)]
        public void CMDOnRespawnMe(Player player) => 
            CheckPermissionsAndExecute(player, MethodBase.GetCurrentMethod()!, () =>
            {
                var character = player.GetCharacter()!;
                character.Resurrect();
            });

        [Command("myposition"), NeedAdminRights(1)]
        public void CMDOnMyPosition(Player player) =>
            CheckPermissionsAndExecute(player, MethodBase.GetCurrentMethod()!, () => 
                NAPI.Chat.SendChatMessageToPlayer(player, $"Position: {player.Position}, Rotation: {player.Rotation}"));
        
        [RemoteProc("CEF:SERVER:TestResource:Test")]
        public string RemoteProcTest(Player player, string test)
        {
            player.SendChatMessage("Test: " + test);
            return player.Name;
        }
        
        [RemoteEvent("CLIENT:SERVER:Root:Error")]
        public void RemoteEventError(Player player, string message)
        {
            Console.WriteLine($"Error from {player.Name}: {message}");
        }
        
        [RemoteEvent("CLIENT:SERVER:Root:Warning")]
        public void RemoteEventWarning(Player player, string message)
        {
            Console.WriteLine($"Warning from {player.Name}: {message}");
        }
    }
}
