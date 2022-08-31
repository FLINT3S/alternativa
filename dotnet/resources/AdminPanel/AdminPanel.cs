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
        [RemoteEvent(AdminPanelEvents.RandomDamageFromCef)]
        private void ReRandomDamage(Player player)
        {
            LogEvent(MethodBase.GetCurrentMethod()!);
            player.Health -= (int)Math.Round(new Random().NextDouble() * 20);
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
            CefConnect.Trigger(player, "onOpenOverlay");
        }
    }
}