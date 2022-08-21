using System.Threading.Tasks;
using Database.Models;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization
{
    public partial class Authorization
    {
        private static void SuccessLoginActions(Player player, Account account)
        {
            account.UpdateHwid(player.Serial);
            player.TriggerEvent(AuthorizationEvents.LoginSuccessToClient);
            player.SetAccount(account);
        }
    }
}