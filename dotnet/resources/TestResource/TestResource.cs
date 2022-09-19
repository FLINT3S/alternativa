using System;
using AbstractResource;
using Database;
using GTANetworkAPI;
using Microsoft.Extensions.Configuration;

namespace TestResource
{
    public class TestResource : AltAbstractResource
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnInternalResourceStart()
        {
            Console.WriteLine("TestResource started");
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            bool needApplyMigration = config.GetValue<bool>("ApplyMigrationWithStartup");
            if (needApplyMigration)
                AltContext.ApplyMigration();
        }
        
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
        
        [RemoteProc("CEF:SERVER:TestResource:Test")]
        public string RemoteProcTest(Player player, string test)
        {
            player.SendChatMessage("Test: " + test);
            return player.Name;
        }
    }
}
