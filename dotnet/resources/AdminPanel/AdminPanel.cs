using System;
using System.Reflection;
using AbstractResource;
using GTANetworkAPI;

namespace AdminPanel
{
    public class AdminPanel : AltAbstractResource
    {
        [RemoteEvent(AdminPanelEvents.RandomDamageFromCef)]
        private void ReRandomDamage(Player player)
        {
            var es = GetEsFromAttr(MethodBase.GetCurrentMethod());
            
            player.Health -= (int) Math.Round(new Random().NextDouble() * 20);
        }
        
        [Command("testbr")]
        public void CMDOnTestBR(Player player)
        {
            CefConnect.TriggerCefRaw(player, "CLIENT:CEF:AdminPanel:onOpenOverlay");
        }
    }
}