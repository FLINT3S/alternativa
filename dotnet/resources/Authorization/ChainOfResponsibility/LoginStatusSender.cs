using GTANetworkAPI;
using NAPIExtensions;

namespace Authorization.ChainOfResponsibility
{
    public class LoginStatusSender : AbstractHandler
    {
        protected override bool CanHandle(Player player) => true;

        protected override void _Handle(Player player)
        {
            var account = player.GetAccountFromDb()!;
            player.SetAccount(account);
            account.OnConnect(player.Address, player.Serial);

            player.TriggerEvent(
                    !account.IsSameHwid(player.Serial) ? AuthorizationEvents.NeedLoginToClient
                        : AuthorizationEvents.LoginSuccessToClient
                );
        }
    }
}