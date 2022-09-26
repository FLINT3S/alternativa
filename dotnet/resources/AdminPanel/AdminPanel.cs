using AbstractResource;
using GTANetworkAPI;

namespace AdminPanel
{
    public partial class AdminPanel : AltAbstractResource
    {
        [Command("testbr")]
        public void CMDOnTestBR(Player player) =>
            CefConnect.Trigger(player, "onOpenOverlay");
    }
}