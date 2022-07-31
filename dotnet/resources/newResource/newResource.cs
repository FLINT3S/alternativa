using GTANetworkAPI;

namespace newResource
{
    public class Main: Script
    {
        [Command("newres")]
        public static void CmdNewRes(Player player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, "New resource is working");
        }
    }
}