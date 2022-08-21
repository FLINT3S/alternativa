using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AbstractResource;
using GTANetworkAPI;
using NAPIExtensions;

namespace AdminPanel
{
    public class AdminPanel : AltAbstractResource
    {
        [RemoteEvent(AdminPanelEvents.RandomDamageFromCef)]
        private void ReRandomDamage(Player player)
        {
            player.Health -= (int)Math.Round(new Random().NextDouble() * 20);
            GetEsFromAttr(MethodBase.GetCurrentMethod());
            Task.Run(() =>
            {
                var acc = player.GetAccount()!;
                acc.UpdateEmail((int.Parse(acc.Email) + 1).ToString());
                Console.WriteLine(acc.Email);
            });
        }

        [Command("testbr")]
        public void CMDOnTestBR(Player player)
        {
            CefConnect.TriggerCefRaw(player, "CLIENT:CEF:AdminPanel:onOpenOverlay");
        }
    }
}