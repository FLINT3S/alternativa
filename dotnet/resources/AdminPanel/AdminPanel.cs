using System;
using System.Reflection;
using System.Threading.Tasks;
using AbstractResource;
using Database;
using GTANetworkAPI;
using NAPIExtensions;

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