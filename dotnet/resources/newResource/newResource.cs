using GTANetworkAPI;

namespace newResource
{
    public class Main
    {
        [Command("newres")]
        public static void CmdNewRes(Player player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, "New resource is working");
        }
    }
}