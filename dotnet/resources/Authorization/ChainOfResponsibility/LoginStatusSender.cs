using System.Threading.Tasks;
using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class LoginStatusSender : AbstractHandler
    {
        protected override Task<bool> CanHandle(Player player) => Task.FromResult(true);

        protected override async Task _Handle(Player player)
        {
            var account = await player.GetAccountFromDb();
            player.SetAccount(account!);
            await account!.OnConnect(player.Address, player.Serial);

            player.TriggerEvent(account.IsSameLastHwid(player.Serial) ? 
                    AuthorizationEvents.LoginSuccessToClient : AuthorizationEvents.NeedLoginToClient
                );
        }
    }
}