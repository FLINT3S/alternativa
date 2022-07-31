using GTANetworkAPI;

namespace testResource
{
    public class Main: Script
    {
        [Command("testres")]
        public static void CmdTestRes(Player player)
        {
            NAPI.Vehicle.CreateVehicle(VehicleHash.Adder, player.Position, player.Rotation, 1, 1, dimension:player.Dimension);
            NAPI.Chat.SendChatMessageToPlayer(player, "Test resource is working");
        }
    }
}