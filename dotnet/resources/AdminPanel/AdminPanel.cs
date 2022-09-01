using AbstractResource;
using GTANetworkAPI;

namespace AdminPanel
{
    public class AdminPanel : AltAbstractResource
    {
        [Command("testbr")]
        public void CMDOnTestBR(Player player)
        {
            CefConnect.Trigger(player, "onOpenOverlay");
        }
    }
}