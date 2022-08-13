using System;
using AbstractResource;
using GTANetworkAPI;
using Logger;
using Logger.EventModels;

namespace AdminPanel
{
    public class AdminPanel : AltAbstractResource
    {
        [RemoteEvent("CEF:SERVER:AdminPanel:randomDamage")]
        private void ReRandomDamage(Player player)
        {
            AltLogger.Instance.LogDevelopment(new AltEvent(this, "RemoteDamage", ""));
            player.Health -= (int) Math.Round(new Random().NextDouble() * 20);
        }
        
        [Command("testbr")]
        public void CMDOnTestBR(Player player)
        {
            CefConnect.TriggerCefRaw(player, "CLIENT:CEF:AdminPanel:onOpenOverlay");
        }
    }
}