using GTANetworkAPI;

namespace testResource
{
    public class Main
    {
        [Command("testres")]
        public static void CmdTestRes(Player player)
        {
            NAPI.Chat.SendChatMessageToPlayer(player, "Test resource is working");
        }
    }
}